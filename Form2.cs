using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace ZKI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            char[,] shifr = new char[4, 4];
            int pos = 0;
            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                for (int j = 0; j < shifr.GetLength(1); j++)
                {
                    if (pos < textBox1.TextLength)
                    {
                        shifr[i, j] = textBox1.Text[pos];
                        pos++;
                    }
                    else
                    {
                        shifr[i, j] = '*';
                    }
                }
            }

            pos = 0;

            char[] col1 = new char[4];
            char[] col2 = new char[4];
            char[] col3 = new char[4];
            char[] col4 = new char[4];

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                col1[i] = shifr[i, 0];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                col2[i] = shifr[i, 1];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                col3[i] = shifr[i, 2];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                col4[i] = shifr[i, 3];
            }

            //столбцы 3241
            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                shifr[i, 2] = col1[i];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                shifr[i, 3] = col3[i];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                shifr[i, 0] = col4[i];
            }

            char[] row1 = new char[4];
            char[] row2 = new char[4];
            char[] row3 = new char[4];
            char[] row4 = new char[4];

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                row1[i] = shifr[0, i];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                row2[i] = shifr[1, i];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                row3[i] = shifr[2, i];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                row4[i] = shifr[3, i];
            }

            //строки 2431
            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                shifr[1, i] = row1[i];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                shifr[3, i] = row2[i];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                shifr[0, i] = row4[i];
            }

            char[] output = new char[16];


            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                for (int j = 0; j < shifr.GetLength(1); j++)
                {
                    
                        output[pos] = shifr[i, j];
                        pos++;
                    
                }
            }

            string outputString = new string(output);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, outputString);
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                richTextBox1.Text += '\n';
                for (int j = 0; j < shifr.GetLength(1); j++)
                {
                    richTextBox1.Text += shifr[i, j];
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            string input = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                input = File.ReadAllText(openFileDialog.FileName);
            }

            char[,] shifr = new char[4, 4];
            int pos = 0;
            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                for (int j = 0; j < shifr.GetLength(1); j++)
                {
                    if (input[pos] == '\0')
                    {
                        shifr[i, j] = '*';
                    }
                    else
                    {
                        shifr[i, j] = input[pos];
                        pos++;
                    }
                }
            }

            pos = 0;

            char[] col1 = new char[4];
            char[] col2 = new char[4];
            char[] col3 = new char[4];
            char[] col4 = new char[4];

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                col1[i] = shifr[i, 0];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                col2[i] = shifr[i, 1];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                col3[i] = shifr[i, 2];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                col4[i] = shifr[i, 3];
            }

            //столбцы 3241
            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                shifr[i, 2] = col4[i];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                shifr[i, 3] = col1[i];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                shifr[i, 0] = col3[i];
            }

            char[] row1 = new char[4];
            char[] row2 = new char[4];
            char[] row3 = new char[4];
            char[] row4 = new char[4];

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                row1[i] = shifr[0, i];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                row2[i] = shifr[1, i];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                row3[i] = shifr[2, i];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                row4[i] = shifr[3, i];
            }

            //строки 2431
            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                shifr[1, i] = row4[i];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                shifr[3, i] = row1[i];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                shifr[0, i] = row2[i];
            }

            for (int i = 0; i < shifr.GetLength(0); i++)
            {
                richTextBox1.Text += '\n';
                for (int j = 0; j < shifr.GetLength(1); j++)
                {
                    richTextBox1.Text += shifr[i, j];
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) && char.IsLower(e.KeyChar) && e.KeyChar >= 'а' && e.KeyChar <= 'я'))
            {
                e.Handled = true;
            }
        }
    }
}
