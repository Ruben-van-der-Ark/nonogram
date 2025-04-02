using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NonogramDatastructure
{
    public partial class Form1 : Form
    {
        // Define the necessary variables
        bool[,] solution;
        bool[,] guess;
        int cellsize;
        int gridX = 450;
        int gridY = 50;
        int blackchance = 3;
        int rows;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(guess, e);

            // TODO: Modulate this
            // Columns
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            for (int i = 0; i < rows; i++)
            {
                string values = string.Join(Environment.NewLine, GetColLabelNumbers(i));
                DrawString(i * cellsize + gridX,
                    gridY + rows * cellsize,
                    values.Normalize(), drawFormat);
            }
            drawFormat = new StringFormat();
            for (int i = 0; i < rows; i++)
            {
                string values = string.Join(", ", GetRowLabelNumbers(i)).Trim();
                float stringWidth = GetTextWidth(values);
                DrawString(gridX - stringWidth - cellsize/2f,
                    gridY + i * cellsize,
                    values,
                    drawFormat);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateGrid();
            this.Refresh();
        }

        public int[] GetColLabelNumbers(int row)
        {
            List<int> total = new List<int>(); // Initialize the list

            int idx = 0;
            total.Add(0); // Ensure at least one element exists to modify

            for (int i = 0; i < rows; i += 1)
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


        public int[] GetRowLabelNumbers(int col)
        {
            List<int> total = new List<int>(); // Initialize the list

            int idx = 0;
            total.Add(0); // Ensure at least one element exists to modify

            for (int i = 0; i < rows; i += 1)
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

        public void DrawString(float x, float y, string text, StringFormat drawFormat)
        {
            Graphics formGraphics = this.CreateGraphics();
            Font drawFont = new Font("Consolas", 0.66f * cellsize);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            formGraphics.DrawString(text, drawFont, drawBrush, x + cellsize / 2, y, drawFormat);
            drawFont.Dispose();
            drawBrush.Dispose();
            formGraphics.Dispose();
        }

        public float GetTextWidth(string text)
        {
            // If there isn't a cellsize yet, that means we can't calculate the font size.
            if (cellsize == 0)
            {
                MessageBox.Show("Character width calculation error");
                return 0;
            }
            Graphics g = CreateGraphics();
            Font drawFont = new Font("Consolas", 0.66f * cellsize);
            SizeF size = g.MeasureString(text, drawFont);
            float charWidth = size.Width; // Width in pixels
            g.Dispose();
            return charWidth;
        }
        
        private void DrawGrid(bool[,] grid, PaintEventArgs e)
        {
            // Define two colors
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush whiteBrush = new SolidBrush(Color.White);

            // Go through every cell in the grid
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    // Define the place and size of the rectangle
                    RectangleF rect = new RectangleF(i * cellsize + gridX, j * cellsize + gridY, cellsize, cellsize);
                    // Paint the rectangle with the correct color (black for true, white for false)
                    e.Graphics.FillRectangle(grid[i, j] ? blackBrush : whiteBrush, rect);
                }
            }

            // Go through again to draw the lines (these must be drawn last to ensure they're on top of the grid)
            Pen gridLines = new Pen(blackBrush);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    // Draw all vertical lines
                    e.Graphics.DrawLine(gridLines, gridX + j * cellsize, gridY, gridX + j * cellsize, gridY + rows * cellsize);
                }
                // Draw all horizontal lines
                e.Graphics.DrawLine(gridLines, gridX, gridY + i * cellsize, gridX + rows * cellsize, gridY + i * cellsize);
            }

            // Draw the borders
            gridLines = new Pen(blackBrush,2);
            e.Graphics.DrawLine(gridLines, gridX, gridY, gridX + rows * cellsize, gridY);
            e.Graphics.DrawLine(gridLines, gridX, gridY, gridX, gridY + rows * cellsize);
            e.Graphics.DrawLine(gridLines, gridX + rows * cellsize, gridY, gridX + rows * cellsize, gridY + rows * cellsize);
            e.Graphics.DrawLine(gridLines, gridX + rows * cellsize, gridY + rows * cellsize, gridX, gridY + rows * cellsize);
        }

        private void GenerateGrid()
        {
            // Make a boolean array to store the solution
            // Every boolean defaults to false
            rows = (int)numRows.Value;
            solution = new bool[rows, rows];
            guess = new bool[rows, rows];
            cellsize = 250 / (rows);
            // Instantiate a Random class to generate random numbers
            Random rand = new Random();

            // Go through every cell and pick a random boolean value
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    solution[i, j] = (rand.Next(blackchance) > 0); // 25/75 for true or false
                }
            }

        }
    }
}