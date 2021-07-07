using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false; 
        }
        int turn = 0;
        bool flag1 = false;
        bool flag2 = false;
        bool flag3 = false;
        bool flag4 = false;
        bool flag5 = false;
        bool flag6 = false;
        bool flag7 = false;
        bool flag8 = false;
        bool flag9 = false;
        private void check()
        {
            if (button1.Text == button2.Text && button2.Text == button3.Text && button3.Text == "X" && label1.Text == "status:") label1.Text = "X wins";
            if (button4.Text == button5.Text && button5.Text == button6.Text && button6.Text == "X" && label1.Text == "status:") label1.Text = "X wins";
            if (button7.Text == button8.Text && button8.Text == button9.Text && button9.Text == "X" && label1.Text == "status:") label1.Text = "X wins";
            if (button1.Text == button4.Text && button4.Text == button7.Text && button7.Text == "X" && label1.Text == "status:") label1.Text = "X wins";
            if (button2.Text == button5.Text && button5.Text == button8.Text && button8.Text == "X" && label1.Text == "status:") label1.Text = "X wins";
            if (button3.Text == button6.Text && button6.Text == button9.Text && button9.Text == "X" && label1.Text == "status:") label1.Text = "X wins";
            if (button1.Text == button5.Text && button5.Text == button9.Text && button9.Text == "X" && label1.Text == "status:") label1.Text = "X wins";
            if (button3.Text == button5.Text && button5.Text == button7.Text && button7.Text == "X" && label1.Text == "status:") label1.Text = "X wins";
            if (button1.Text == button2.Text && button2.Text == button3.Text && button3.Text == "O" && label1.Text == "status:") label1.Text = "O wins";
            if (button4.Text == button5.Text && button5.Text == button6.Text && button6.Text == "O" && label1.Text == "status:") label1.Text = "O wins";
            if (button7.Text == button8.Text && button8.Text == button9.Text && button9.Text == "O" && label1.Text == "status:") label1.Text = "O wins";
            if (button1.Text == button4.Text && button4.Text == button7.Text && button7.Text == "O" && label1.Text == "status:") label1.Text = "O wins";
            if (button2.Text == button5.Text && button5.Text == button8.Text && button8.Text == "O" && label1.Text == "status:") label1.Text = "O wins";
            if (button3.Text == button6.Text && button6.Text == button9.Text && button9.Text == "O" && label1.Text == "status:") label1.Text = "O wins";
            if (button1.Text == button5.Text && button5.Text == button9.Text && button9.Text == "O" && label1.Text == "status:") label1.Text = "O wins";
            if (button3.Text == button5.Text && button5.Text == button7.Text && button7.Text == "O" && label1.Text == "status:") label1.Text = "O wins";
            if (turn > 8 && label1.Text == "status:") label1.Text = "withdraw";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (turn % 2 == 0 && flag1 == false)
            {
                button1.Text = "O";
                turn++;
                flag1 = true;
                
            }
            if (turn % 2 == 1 && flag1 == false)
            {
                button1.Text = "X";
                turn++;
                flag1 = true;

            }
            check();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (turn % 2 == 0 && flag2 == false)
            {
                button2.Text = "O";
                turn++;
                flag2 = true;
                
            }
            if (turn % 2 == 1 && flag2 == false)
            {
                button2.Text = "X";
                turn++;
                flag2 = true;
            }
            check();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (turn % 2 == 0 && flag3 == false)
            {
                button3.Text = "O";
                turn++;
                flag3 = true;
            }
            if (turn % 2 == 1 && flag3 == false)
            {
                button3.Text = "X";
                turn++;
                flag3 = true;
            }
            check();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (turn % 2 == 0 && flag4 == false)
            {
                button4.Text = "O";
                turn++;
                flag4 = true;
            }
            if (turn % 2 == 1 && flag4 == false)
            {
                button4.Text = "X";
                turn++;
                flag4 = true;
            }
            check();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (turn % 2 == 0 && flag5 == false)
            {
                button5.Text = "O";
                turn++;
                flag5 = true;
            }
            if (turn % 2 == 1 && flag5 == false)
            {
                button5.Text = "X";
                turn++;
                flag5 = true;
            }
            check();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (turn % 2 == 0 && flag6 == false)
            {
                button6.Text = "O";
                turn++;
                flag6 = true;
            }
            if (turn % 2 == 1 && flag6 == false)
            {
                button6.Text = "X";
                turn++;
                flag6 = true;
            }
            check();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (turn % 2 == 0 && flag7 == false)
            {
                button7.Text = "O";
                turn++;
                flag7 = true;
            }
            if (turn % 2 == 1 && flag7 == false)
            {
                button7.Text = "X";
                turn++;
                flag7 = true;
            }
            check();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (turn % 2 == 0 && flag8 == false)
            {
                button8.Text = "O";
                turn++;
                flag8 = true;
            }
            if (turn % 2 == 1 && flag8 == false)
            {
                button8.Text = "X";
                turn++;
                flag8 = true;
            }
            check();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (turn % 2 == 0 && flag9 == false)
            {
                button9.Text = "O";
                turn++;
                flag9 = true;
            }
            if (turn % 2 == 1 && flag9 == false)
            {
                button9.Text = "X";
                turn++;
                flag9 = true;
            }
            check();
        }
       // if(turn>8)
    }
}
