using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yılmaztürk_Widgets
{
    public partial class Same : Form
    {
        public Same()
        {
            InitializeComponent();
        }

        private void Same_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.FromArgb(45, 25, 78);
            this.TopMost = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
        }
    }
}
