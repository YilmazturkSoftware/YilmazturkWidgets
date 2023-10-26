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
using System.Xml.Linq;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Yılmaztürk_Widgets
{
    public partial class HavaDurumu : Form
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
        public HavaDurumu()
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

           
        }

        private void HavaDurumu_Load(object sender, EventArgs e)
        {
            this.Location = new Point(1686, 613);
            this.Region =  Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 30, 30));

            string baglanti = "https://api.openweathermap.org/data/2.5/weather?q=bursa&units=metric&lang=tr&mode=xml&appid=0360ff62c1d41fcaef31a3106e3bfc27";
            XDocument weather = XDocument.Load(baglanti);
            var temp = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var weatherstate = weather.Descendants("weather").ElementAt(0).Attribute("value").Value;
            Console.Write("bursa için sıcaklık: " + temp + " hava durrumu : " + weatherstate);
            label2.Text = temp + "°";
            label3.Text = weatherstate;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.Location.X.ToString() + this.Location.Y);
        }
    }
}