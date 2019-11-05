using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculations;

namespace GUI_calc
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        Calculations.Calculations calc = new Calculations.Calculations();

        //true, если ввод идет сразу после операции
        bool flagOper = false;

        private void button_Click(object sender, EventArgs e)
        {
            if(flagOper == true)
            {
                textBox.Text = "";
                flagOper = false;
            }
            if(textBox.Text != "0")
            {
                textBox.Text += ((Button)sender).Text;
            }
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            if(textBox.Text != "")
            {
                textBox.Text = string.Concat(-1 * double.Parse(textBox.Text));
            }           
        }

        //true, если в числе уже есть точка
        bool flagPoint = false;

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            if (!flagPoint)
            {
                if (textBox.Text != "")
                {
                    textBox.Text += ",";
                    flagPoint = true;
                }
            }
            
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox.Text = "";
            flagPoint = false;
            calc.operSymbol = "";
        }

        private void buttonErase_Click(object sender, EventArgs e)
        {
            if (textBox.Text != "")
            {
                string expression = "";
                if (textBox.Text[textBox.Text.Length - 1] == ',') flagPoint = false;
                for (int i = 0; i < textBox.Text.Length - 1; i++)
                {
                    expression += textBox.Text[i];
                }
                textBox.Text = expression;
            }
        }

        private void buttonOperation_Click(object sender, EventArgs e)
        {
            flagOper = true;
            flagPoint = false;
            if(calc.operSymbol == "")
            {
                calc.operand = double.Parse(textBox.Text);                
            }
            else
            {                                
                textBox.Text = string.Concat(calc.Calculate(double.Parse(textBox.Text))); 
            }
            calc.operSymbol = ((Button)sender).Text;
        }
    }
}
