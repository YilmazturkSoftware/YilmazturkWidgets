using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yılmaztürk_Widgets
{
    public partial class WidgetTemp : Form
    {
        public WidgetTemp()
        {
            InitializeComponent();
        }

        private void WidgetTemp_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            if (!File.Exists(@"C:\Users\" + Environment.UserName + @"\Widgetların Arkaplanını Silme.ayar"))
            {
            
                this.TransparencyKey = Color.White;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void widgetıKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ayarlar ayarlar = new Ayarlar();
            ayarlar.ShowDialog();
        }

        private void WidgetTemp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(@"C:\Users\" + Environment.UserName + @"\Widgetlar Alt F4 ile kapansın.ayar"))
            {

            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
