using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace NonogramDatastructure
{
    public partial class Form1 : Form
    {
        // Define all variables
        private bool[,] solution; // The correct solution of the puzzle
        private bool?[,] guess; // The players guess of the solution
        private int cellsize; // The size of each grid cell in pixels
        private int gridX = 450; // The x position of the grid
        private int gridY = 50; // The y position of the grid
        private int blackchance = 3; // The chance for any cell to be black in the solution
        private int gridsize; // How many rows and columns there are in the grid
        private bool correct; // Whether the grid is correctly solved
        private bool generated; // Whether the solution has already been generated

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(guess, e);
            DrawColumnLabels(e.Graphics);
            DrawRowLabels(e.Graphics);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateGrid();
            Refresh();
            btnCheck.Visible = true;
            btnClear.Visible = true;
        }

        private int[] GetColLabelNumbers(int row)
        {
            List<int> total = new List<int>(); // Initialize the list

            int idx = 0;
            total.Add(0); // Ensure at least one element exists to modify

            for (int i = 0; i < gridsize; i += 1)
            {
                if (solution[row, i])
                {
                    total[idx] += 1; // If 1, add 1 to the count
                }
                else if (total[idx] > 0)
                {
                    idx++;
                    total.Add(0); // Add a new element to the list when moving to a new index
                }
            }
            if (total.Count > 1 && total[total.Count - 1] == 0) // Check if last element is 0
            {
                total.RemoveAt(total.Count - 1); // Remove last element
            }
            return total.ToArray();
        }


        private int[] GetRowLabelNumbers(int col)
        {
            List<int> total = new List<int>(); // Initialize the list

            int idx = 0;
            total.Add(0); // Ensure at least one element exists to modify

            for (int i = 0; i < gridsize; i += 1)
            {
                if (solution[i, col])
                {
                    total[idx] += 1; // If 1, add 1 to the count
                }
                else if (total[idx] > 0)
                {
                    idx++;
                    total.Add(0); // Add a new element to the list when moving to a new index
                }
            }
            if (total.Count > 1 && total[total.Count - 1] == 0) // Check if last element is 0
            {
                total.RemoveAt(total.Count - 1); // Remove last element
            }
            return total.ToArray();
        }

        private void DrawString(Graphics g, float x, float y, string text, StringFormat drawFormat)
        {
            // Generate all the paramaters
            Graphics formGraphics = CreateGraphics();
            Font drawFont = new Font("Consolas", 0.66f * cellsize);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            // Draw the string
            g.DrawString(text, drawFont, drawBrush, x + cellsize / 2, y, drawFormat);
            // Garbage collect
            drawFont.Dispose();
            drawBrush.Dispose();
            formGraphics.Dispose();
        }

        private float GetTextWidth(string text)
        {
            // If there isn't a cellsize yet, that means we can't calculate the font size.
            if (!generated)
            {
                MessageBox.Show("Character width calculation error");
                return 0;
            }
            Graphics g = CreateGraphics();
            Font drawFont = new Font("Consolas", 0.66f * cellsize);
            SizeF size = g.MeasureString(text, drawFont);
            float charWidth = size.Width; // Width in pixels
            g.Dispose();
            drawFont.Dispose();
            return charWidth;
        }

        private void DrawGrid(bool?[,] grid, PaintEventArgs e)
        {
            // Define two colors
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            SolidBrush grayBrush = new SolidBrush(Color.DimGray);

            // Define a pen for the X symbols in notes
            Pen blackPen = new Pen(blackBrush, 2);

            // Go through every cell in the grid
            for (int i = 0; i < gridsize; i++)
            {
                for (int j = 0; j < gridsize; j++)
                {
                    // Define the place and size of the rectangle
                    RectangleF rect = new RectangleF(i * cellsize + gridX, j * cellsize + gridY, cellsize, cellsize);
                    // Paint the rectangle with the correct color (black for true, white for false)
                    if (grid[i, j] != null)
                    {
                        e.Graphics.FillRectangle((bool)grid[i, j] ? grayBrush : whiteBrush, rect);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(whiteBrush, rect);
                        Point toplt = new Point(i * cellsize + gridX, j * cellsize + gridY);
                        Point btmlt = new Point(i * cellsize + gridX, (j + 1) * cellsize + gridY);
                        Point toprt = new Point((i + 1) * cellsize + gridX, j * cellsize + gridY);
                        Point btmrt = new Point((i + 1) * cellsize + gridX, (j + 1) * cellsize + gridY);
                        e.Graphics.DrawLine(blackPen, toplt, btmrt);
                        e.Graphics.DrawLine(blackPen, btmlt, toprt);
                    }
                }
            }

            // Go through again to draw the lines (these must be drawn last to ensure they're on top of the grid)
            Pen gridLines = new Pen(blackBrush);
            Pen thickGridLines = new Pen(blackBrush, 3);
            for (int i = 0; i < gridsize; i++)
            {
                for (int j = 0; j < gridsize; j++)
                {
                    // Draw all vertical lines
                    if (j%5==0 & j>0)
                    {
                        e.Graphics.DrawLine(thickGridLines, gridX + j * cellsize, gridY, gridX + j * cellsize, gridY + gridsize * cellsize);
                    } else
                    {
                        e.Graphics.DrawLine(gridLines, gridX + j * cellsize, gridY, gridX + j * cellsize, gridY + gridsize * cellsize);
                    }
                }
                if (i % 5 == 0 & i > 0)
                {
                    e.Graphics.DrawLine(thickGridLines, gridX, gridY + i * cellsize, gridX + gridsize * cellsize, gridY + i * cellsize);
                }
                else
                {
                    e.Graphics.DrawLine(gridLines, gridX, gridY + i * cellsize, gridX + gridsize * cellsize, gridY + i * cellsize);
                }
                // Draw all horizontal lines
            }

            // Draw the borders
            gridLines = new Pen(blackBrush, 2);
            e.Graphics.DrawLine(gridLines, gridX, gridY, gridX + gridsize * cellsize, gridY);
            e.Graphics.DrawLine(gridLines, gridX, gridY, gridX, gridY + gridsize * cellsize);
            e.Graphics.DrawLine(gridLines, gridX + gridsize * cellsize, gridY, gridX + gridsize * cellsize, gridY + gridsize * cellsize);
            e.Graphics.DrawLine(gridLines, gridX + gridsize * cellsize, gridY + gridsize * cellsize, gridX, gridY + gridsize * cellsize);

            // Dispose of objects
            blackBrush.Dispose();
            whiteBrush.Dispose();
            blackPen.Dispose();
            gridLines.Dispose();
        }

        public void GenerateGrid()
        {
            generated = true;

            gridsize = (int)numGridSize.Value;
            
            cellsize = 250 / (gridsize);
            
            solution = new bool[gridsize, gridsize]; // Every boolean here defaults to false
            
            ClearGuess(); // Generate an empty bool?[,] for the player's guess and set every value to false

            // Instantiate a Random class to generate random numbers
            Random rand = new Random();

            // Go through every cell and pick a random boolean value
            for (int i = 0; i < gridsize; i++)
            {
                for (int j = 0; j < gridsize; j++)
                {
                    solution[i, j] = (rand.Next(blackchance) > 0); // 25/75 for true or false
                }
            }

        }
        private void DrawColumnLabels(Graphics g)
        {
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            for (int i = 0; i < gridsize; i++)
            {
                string values = string.Join(Environment.NewLine, GetColLabelNumbers(i));
                DrawString(g, i * cellsize + gridX,
                    gridY + gridsize * cellsize,
                    values.Normalize(), drawFormat);
            }
            drawFormat.Dispose();
        }

        private void DrawRowLabels(Graphics g)
        {
            StringFormat drawFormat = new StringFormat();
            for (int i = 0; i < gridsize; i++)
            {
                string values = string.Join(", ", GetRowLabelNumbers(i)).Trim();
                float stringWidth = GetTextWidth(values);
                DrawString(g, gridX - stringWidth - cellsize / 2f,
                    gridY + i * cellsize,
                    values,
                    drawFormat);
            }
            drawFormat.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Hide the check answer button until a grid has been generated
            btnCheck.Visible = false;
            //// Enable DoubleBuffer
            //InitializeComponent();
            DoubleBuffered = true;
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            //UpdateStyles();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // No grid made: don't do anything
            if (!generated) { return; }

            // Translate the mouse position to grid coordinates
            int CellX = e.X;
            int CellY = e.Y;
            CellX -= gridX;
            CellY -= gridY;
            CellX /= cellsize;
            CellY /= cellsize;

            // If it falls within the grid
            if (CellX >= 0 & CellX < gridsize & CellY >= 0 & CellY < gridsize)
            {
                // Set that cell to the appropriate value (left click for black, right for notes and middle click for white)
                // (I chose middle click for white as it's the least important one and not all players will have acces to middle click)
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        guess[CellX, CellY] = true;
                        break;
                    case MouseButtons.Right:
                        guess[CellX, CellY] = null;
                        break;
                    default:
                        guess[CellX, CellY] = false;
                        break;
                }
                // Then refresh the grid
                Refresh();
            }
        }

        private bool? CheckAnswer()
        {
            // Don't check an answer if no grid has been generated yet
            if (!generated) { return false; }

            // Assume everything is correct
            correct = true;

            // Go through every cell
            for (int i = 0; i < gridsize; i++)
            {
                for (int j = 0; j < gridsize; j++)
                {
                    // If the guess is NOT the same as the solution
                    // (and if the cell is null which is used for notes, assume it's white)
                    if ((guess[i, j] ?? false) != solution[i, j])
                    {
                        // The puzzle is incorrectly solved
                        correct = false;
                    }
                }
            }
            return correct;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            // If nothing has been generated, there's no need to check anything
            if (!generated) { return; }
            // Otherwise, we check the answer
            CheckAnswer();
            // And display the appropriate MessageBox
            MessageBox.Show(correct == true ? "Gewonnen!" : "De puzzel is nog niet goed opgelost. Probeer het opnieuw.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearGuess();
            Refresh();
        }

        private void ClearGuess()
        {
            // If there is no grid, stop here
            if (!generated) { return; }

            guess = new bool?[gridsize, gridsize]; // Every boolean? here defaults to null
            // That's why we set them all to false here
            for (int i = 0; i < gridsize; i++)
            {
                for (int j = 0; j < gridsize; j++)
                {
                    guess[i, j] = false;
                }
            }
        }
    }
}
