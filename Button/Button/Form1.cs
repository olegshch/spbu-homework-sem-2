using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Button
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.MouseEnter += new EventHandler(button1_MouseEnter);
        }
        private void button1_MouseEnter(object sender, EventArgs e)
                {
                    Random rand = new Random();
                    int r = rand.Next(0, 300);
                    this.button1.Location = new Point(r, r);
                }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        
    }
}
