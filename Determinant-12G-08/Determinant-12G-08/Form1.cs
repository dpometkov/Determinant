using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Determinant_12G_08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                dataGridView1.ColumnCount = 1;
                dataGridView1.RowCount = 1;
            }
            else
            {
                dataGridView1.ColumnCount = Convert.ToInt32(textBox1.Text);
                dataGridView1.RowCount = Convert.ToInt32(textBox1.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var array1 = new double[dataGridView1.RowCount, dataGridView1.ColumnCount];
            for (int x = 0; x < array1.GetLength(0); x++)
                for (int i = 0; i < array1.GetLength(1); i++)
                    array1[x, i] = Convert.ToDouble(dataGridView1.Rows[x].Cells[i].Value);

            
            label3.Text = Convert.ToString(determinant(array1));
        }

        static int SignOfElement(int i, int j)
        {
            if ((i + j) % 2 == 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        static double[,] CreateSmallerMatrix(double[,] input, int i, int j)
        {
            int order = int.Parse(System.Math.Sqrt(input.Length).ToString());
            double[,] output = new double[order - 1, order - 1];
            int x = 0, y = 0;
            for (int m = 0; m < order; m++, x++)
            {
                if (m != i)
                {
                    y = 0;
                    for (int n = 0; n < order; n++)
                    {
                        if (n != j)
                        {
                            output[x, y] = input[m, n];
                            y++;
                        }
                    }
                }
                else
                {
                    x--;
                }
            }
            return output;
        }

        static double determinant(double[,] input)
        {
            int order = int.Parse(System.Math.Sqrt(input.Length).ToString());
            if (order > 2)
            {
                double value = 0;
                for (int j = 0; j < order; j++)
                {
                    double[,] Temp = CreateSmallerMatrix(input, 0, j);
                    value = value + input[0, j] * (SignOfElement(0, j) * determinant(Temp));
                }
                return value;
            }
            else if (order == 2)
            {
                return ((input[0, 0] * input[1, 1]) - (input[1, 0] * input[0, 1]));
            }
            else
            {
                return (input[0, 0]);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            this.dataGridView1.Rows.Clear();
            label3.Text = "";
        }
    }
}
