using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public int Interval;
        public int Columns = 1;
        public int NumCount = 1000;
        public double[] Numbers;

        public Form1()
        {
            InitializeComponent();

            Numbers = new double[NumCount];

            textBox1.TextChanged += textBox1_TextChanged;
            chart1.Series[0].Name = "Вероятность СВ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();

            if (Numbers.Count() == 0) return;


            for (int i = 0; i < NumCount/Columns; i++)
            {
                double sum = 0;
                for (int j = 0; j < Columns; j++)
                {
                    sum += Numbers[i*Columns+j];
                }
                chart1.Series[0].Points.AddXY(0, sum/Columns);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int buff;
            if (int.TryParse(textBox1.Text, out buff) && buff > 0)
            {
                Interval = buff;
                Columns = (int)(NumCount / Interval);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random random = new Random(); 
            for (int i = 0; i < NumCount; i++) 
            { 
                Numbers[i] = random.NextDouble(); 
            }
        }
    }
}
