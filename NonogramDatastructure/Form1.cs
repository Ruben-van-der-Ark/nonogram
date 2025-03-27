using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

// TODO: Fix twee verschillende comment talen

namespace NonogramDatastructure
{
    public partial class Form1 : Form
    {
        // Define the necessary variables
        bool[,] solution;
        int cellsize;
        int gridX = 450;
        int gridY = 50;
        int blackchance = 3;
        int cols;
        int rows;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // If there isn't a grid, don't try painting it
            if (solution is null)
            {
                return;
            }

            // Definieer twee kleuren
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush whiteBrush = new SolidBrush(Color.White);

            // Go through every cell in the grid
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Define the place and size of the rectangle
                    RectangleF rect = new RectangleF(i * cellsize + gridX, j * cellsize + gridY, cellsize, cellsize);

                    // Paint the rectangle with the correct color (black for true, white for false)
                    e.Graphics.FillRectangle(solution[i, j] ? blackBrush : whiteBrush, rect);
                }
            }

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
            for (int i = 0; i < cols; i++)
            {
                string values = string.Join(", ", GetRowLabelNumbers(i)).Trim();
                float stringWidth = GetTextWidth(values);
                DrawString(gridX - stringWidth - 10,
                    gridY + i * cellsize,
                    values,
                    drawFormat);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Make a boolean array to store the solution
            // Every boolean defaults to false
            rows = (int)numRows.Value;
            cols = (int)numCols.Value;
            solution = new bool[rows, cols];
            cellsize = 250 / (rows);
            // Instantiate a Random class to generate random numbers
            Random rand = new Random();

            // Go through every cell and pick a random boolean value
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    solution[i, j] = (rand.Next(blackchance) > 0); // 25/75 for true or false
                }
            }
            this.Refresh();
        }

        public int[] GetColLabelNumbers(int row)
        {
            List<int> total = new List<int>(); // Initialize the list

            int idx = 0;
            total.Add(0); // Ensure at least one element exists to modify

            for (int i = 0; i < cols; i += 1)
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
        public float GetTextHeight(string text)
        {
            // If there isn't a cellsize yet, that means we can't calculate the font size.
            if (cellsize == 0)
            {
                MessageBox.Show("Character height calculation error");
                return 0;
            }
            Graphics g = CreateGraphics();
            Font drawFont = new Font("Consolas", 0.66f * cellsize);
            SizeF size = g.MeasureString(text, drawFont);
            float charHeight = size.Height; // Width in pixels
            g.Dispose();
            return charHeight;
        }

    }
}