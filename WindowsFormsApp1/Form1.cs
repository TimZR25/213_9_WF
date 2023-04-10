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

        public Form1()
        {
            InitializeComponent();

            textBox1.TextChanged += textBox1_TextChanged;
            chart1.Series[0].Name = "Вероятность СВ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();

            int N = 1000;

            double[] numbers = new double[N];
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                double sum = 0;
                for (int j = 0; j < 20; j++)
                {
                    sum += random.NextDouble();
                }
                numbers[i] = sum/20d;
            }

            for (int i = 0; i < Interval; i++)
            {
                double sum = 0;
                for (int j = 0; j < 1000 / Interval; j++)
                {
                    sum += numbers[i*Interval + j];
                }
                chart1.Series[0].Points.AddXY(0, sum/ (1000 / Interval));
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int buff;
            if (int.TryParse(textBox1.Text, out buff) && buff > 0)
            {
                Interval = buff;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
