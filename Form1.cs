using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ZKI
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

        //Aa Bb Cc Dd Ee Ff Gg Hh Ii Jj Kk Ll Mm Nn Oo Pp Qq Rr Ss Tt Uu Vv Ww Xx Yy Zz
        string[,] square =
        {
                {"D", "E", "B", "U", "G", "I"},
                {"N", "A", "C", "F", "H", "J"},
                {"K", "L", "M", "O", "P", "Q"},
                {"R", "S", "T", "V", "W", "X"},
                {"Y", "Z", "0", "1", "2", "3"},
                {"4", "5", "6", "7", "8", "9"}
        };

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < square.GetLength(0); j++)
                {
                    for (int k = 0; k < square.GetLength(1); k++)
                    {
                        if (square[j, k] == input[i].ToString())
                        {
                            richTextBox1.Text += $"{square[j, k]} = {j + 1}{k + 1} \n";
                            output += $"{j + 1}{k + 1}";
                        }
                    }
                }
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(saveFileDialog.FileName, output);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                if (char.IsUpper(e.KeyChar) && char.IsLetter(e.KeyChar) && e.KeyChar >= 'A' && e.KeyChar <= 'Z')
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input = "";
            string output = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    input = File.ReadAllText(openFileDialog.FileName);
                }
            }

            for (int i = 0; i < input.Length; i+=2)
            {
                int row = int.Parse(input[i].ToString()) - 1;
                int col = int.Parse(input[i + 1].ToString()) - 1;

                output += square[row, col];
            }

            textBox2.Text = output;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}