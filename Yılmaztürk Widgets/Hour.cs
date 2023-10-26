using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yılmaztürk_Widgets
{
    public partial class Hour : Form
    {
        public Hour()
        {
            InitializeComponent();
            tim.Start();
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
           (
              int nLeft,
              int nTop,
              int nRight,
              int nBottom,
              int nWidthEllipse,
              int nHeightEllipse
           );
        public bool saat = true;
        private void Hour_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 30, 30));

        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public bool move = true;
        private void tim_Tick(object sender, EventArgs e)
        {
            if (saat == true)
            {
                int h = DateTime.Now.Hour;
                int m = DateTime.Now.Minute;
                int s = DateTime.Now.Second;
                string time = "";
                if (h < 10) { time += "0" + h; }
                else { time += h; }
                time += ":";
                if (m < 10) { time += "0" + m; }
                else { time += m; }
                time += ":";
                if (s < 10) { time += "0" + s; }
                else { time += s; }
                timeLBL.Text = time;
                date.Text = DateTime.Now.ToString("dd") + " " + DateTime.Now.ToString("MMMM") + " " + DateTime.Now.ToString("yyyy");
            }
        }

        private void Hour_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void Hour_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && move)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
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

        private void Hour_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(File.Exists(@"C:\Users\" + Environment.UserName + @"\Widgetlar Alt F4 ile kapansın.ayar"))
            {

            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
