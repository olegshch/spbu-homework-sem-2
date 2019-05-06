﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock2
{
    public partial class Form1 : Form
    {
        Timer time = new Timer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            time.Interval = 1000;
            time.Tick += new EventHandler(this.time_Tick);
            time.Start();
        }
        private void time_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
        }

    }
}
