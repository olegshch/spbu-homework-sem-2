using System;
using System.Windows.Forms;

namespace Clock2
{
    public partial class Clock : Form
    {
        Timer time = new Timer();
        public Clock()
        {
            InitializeComponent();
            time_Tick(null, null);
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
