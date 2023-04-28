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
        public int Interval = 1;
        public int Columns = 1;
        public int NumCount = 1000;
        public double[] UniformNumbers;
        public double[] NormalNumbers;
        public int MinNum = 0;
        public int MaxNum = 1;


        public Form1()
        {
            InitializeComponent();

            UniformNumbers = new double[NumCount];
            NormalNumbers = new double[NumCount/20];

            chart1.Series[0].Name = "Вероятность СВ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Draw_Histogram(UniformNumbers);
            }

            if (comboBox1.SelectedIndex == 1)
            {
                Draw_Histogram(NormalNumbers);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Draw_Histogram(UniformNumbers);
            }

            if (comboBox1.SelectedIndex == 1)
            {
                Draw_Histogram(NormalNumbers);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                Generate_UniformDistribution();

                Generate_NormalDistribution();
        }

        private void Generate_UniformDistribution()
        {
            Random random = new Random();
            for (int i = 0; i < NumCount; i++)
            {
                UniformNumbers[i] = MinNum + random.NextDouble() * (MaxNum - MinNum);
            }
        }

        private void Generate_NormalDistribution()
        {
            for (int i = 0; i < NormalNumbers.Length; i++)
            {
                double sum = 0.0;
                for (int j = 0; j < 20; j++)
                {
                    sum += UniformNumbers[i*20+j];
                }
                NormalNumbers[i] = sum;
            }
        }

        private void Draw_Histogram(double[] numbers)
        {
            chart1.Series[0].Points.Clear();

            if (numbers.Length == 0) return;

            int columns = numbers.Length / Interval;

            for (int i = 0; i < Interval; i++)
            {
                double sum = 0;
                for (int j = 0; j < columns; j++)
                {
                    sum += numbers[i * columns + j];
                }
                chart1.Series[0].Points.AddXY(0, sum / columns);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = NumCount;
            numericUpDown1.Minimum = 1;
            Interval = Convert.ToInt32(numericUpDown1.Value);
        }
    }
}
