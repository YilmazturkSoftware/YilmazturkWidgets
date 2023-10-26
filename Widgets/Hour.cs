using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Yılmaztürk_Widgets
{
    public partial class Hour : Form
    {
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
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public bool move = true;
        public Hour()
        {
            InitializeComponent();
            tim.Start();
        }
        private void FormMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && move)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void Tick(object sender, EventArgs e)
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

        private void timeLBL_Click(object sender, EventArgs e)
        {

        }

        private void date_Click(object sender, EventArgs e)
        {

        }

        private void Hour_Load(object sender, EventArgs e)
        {
            this.Location = new Point(1455, 447);
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 30, 30));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.Location.X.ToString() + this.Location.Y);
        }
    }
}