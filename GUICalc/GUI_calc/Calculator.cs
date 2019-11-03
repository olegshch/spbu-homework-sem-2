using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_calc
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if(!(textBox.Text == "" && ((Button)sender).Text == "0"))
            {
                textBox.Text += ((Button)sender).Text;
            }
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            textBox.Text = string.Concat(-1 * double.Parse(textBox.Text));
        }

        bool flag = false;
        private void buttonPoint_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                if (textBox.Text != "")
                {
                    textBox.Text += ".";
                    flag = true;
                }
            }
            
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox.Text = "";
            flag = false;
        }

        private void buttonErase_Click(object sender, EventArgs e)
        {
            string expression = "";
            if (textBox.Text[textBox.Text.Length - 1] == '.') flag = false;
            for(int i = 0; i < textBox.Text.Length - 1; i++)
            {
                expression += textBox.Text[i];
            }
            textBox.Text = expression;
        }
    }
}
