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
    public partial class KonumBelirle : Form
    {
        public KonumBelirle()
        {
            InitializeComponent();
        }

        private void KonumBelirle_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.White;
        }
        bool durum = false;
        Point İlkkonum = new Point();
        public YeniWidget yeniWidget;
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            durum = false;
            this.Cursor = Cursors.Default;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

            if (durum)
            {
                panel1.Top = e.Y + panel1.Top - (İlkkonum.Y);
                panel1.Left = e.X + panel1.Left - (İlkkonum.X);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            durum = true;
            this.Cursor = Cursors.SizeAll;
            İlkkonum = e.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            yeniWidget.sonuc = panel1.Location;
          
        }
    }
}
