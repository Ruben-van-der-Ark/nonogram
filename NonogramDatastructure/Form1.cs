using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;


namespace NonogramDatastructure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Instantieer een Random class om een willekeurig patroon te kunnen 
            Random rand = new Random();

            // Maak een 2D bool array om het antwoord in op te slaan
            // Alles staat standaard op false
            bool[,] answer = new bool[5,5]; 

            // Ga langs elke waarde en geef elke coordinaat een willekeurige waarde
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    answer[i,j] = rand.Next(2)==1; // 50/50 voor true of false
                }
            }

            // Haal alle text van het Label weg zodat we er iets nieuws in kunnen zetten
            Label.Text = "";

            // Ga langs elke waarde en zet ze in het label
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Label.Text += answer[i, j] ? 1 : 0; // 1 voor true, 0 voor false
                }
                Label.Text += '\n'; // Line break na elke rij
            }
        }
    }
}
