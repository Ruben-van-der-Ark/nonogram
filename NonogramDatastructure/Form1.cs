using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

// TODO: Fix twee verschillende comment talen

namespace NonogramDatastructure
{
    public partial class Form1 : Form
    {
        // Definieer nodige waardes zodat ze in de goede scope staan
        bool[,] answer;
        int cellsize;
        int gridX = 400;
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
            // Als er nog geen grid is gegenereerd, probeer het dan ook niet te painten
            if (answer is null)
            {
                return;
            }

            // Definieer twee kleuren
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            
            // Ga langs elke cel in het grid
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Definieer de positie en grootte van de rectangle
                    RectangleF rect = new RectangleF(i * cellsize + gridX, j * cellsize + gridY, cellsize, cellsize);

                    // Paint de rectangle met de goede kleur (black voor true, white voor false)
                    e.Graphics.FillRectangle(answer[i, j] ? blackBrush : whiteBrush, rect);
                }
            }

            for (int i = 0; i < rows; i++)
            {
                string values = string.Join(Environment.NewLine, GetColLabelNumbers(i));
                DrawString(i*cellsize +  gridX, rows + cellsize * (rows)+5, values);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Maak een 2D bool array om het antwoord in op te slaan
            // Alles staat standaard op false
            answer = new bool[(int) numRows.Value, (int) numCols.Value];
            cellsize = 250/((int) numRows.Value);
            rows = (int) numRows.Value;
            cols = (int) numCols.Value;
            // Instantieer een Random class om een willekeurig patroon te kunnen 
            Random rand = new Random();

            // Ga langs elke waarde en geef elke coordinaat een willekeurige waarde
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    answer[i, j] = (rand.Next(blackchance) > 0); // 25/75 voor true of false
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
                if (answer[row, i])
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
                if (answer[i, col])
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

        public void DrawString(float x, float y, string text)
        {
            Graphics formGraphics = this.CreateGraphics();
            Font drawFont = new Font("Arial", 200/cellsize);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            formGraphics.DrawString(text, drawFont, drawBrush, x+cellsize/2, y, drawFormat);
            drawFont.Dispose();
            drawBrush.Dispose();
            formGraphics.Dispose();
        }
    }
}