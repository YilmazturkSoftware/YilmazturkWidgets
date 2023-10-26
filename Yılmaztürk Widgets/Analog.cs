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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.IO;

namespace Yılmaztürk_Widgets
{
    public partial class Analog : Form
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
        public bool move = true; Timer t = new Timer();

        int WIDTH = 210, HEIGHT = 210, secHAND = 140, minHAND = 110, hrHAND = 80;

        //center
        int cx, cy;

        Bitmap bmp;
        Graphics g;
        public Analog()
        {
            InitializeComponent();

        }
        public string font = "";
        public string bg = "";
        private void FormMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && move)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.Location.X.ToString() + this.Location.Y);
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
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

        private void Analog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(@"C:\Users\" + Environment.UserName + @"\Widgetlar Alt F4 ile kapansın.ayar"))
            {

            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Tick(object sender, EventArgs e)
        {

          
            g = Graphics.FromImage(bmp);

          
            int ss = DateTime.Now.Second;
            int mm = DateTime.Now.Minute;
            int hh = DateTime.Now.Hour;

            int[] handCoord = new int[2];

      
            g.Clear(System.Drawing.ColorTranslator.FromHtml(bg));

          
            g.DrawEllipse(new Pen(Color.Black, 1f), 0, 0, WIDTH, HEIGHT);

         
            g.DrawString("12", new Font(font, 14,FontStyle.Bold), Brushes.White, new PointF(90, 2));
            g.DrawString("3", new Font(font, 14, FontStyle.Bold), Brushes.White, new PointF(186, 100));
            g.DrawString("6", new Font(font, 14, FontStyle.Bold), Brushes.White, new PointF(102, 182));
            g.DrawString("9", new Font(font, 14, FontStyle.Bold), Brushes.White, new PointF(0, 100));

     
            handCoord = msCoord(ss, secHAND);
            g.DrawLine(new Pen(Color.Red, 1f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

          
            handCoord = msCoord(mm, minHAND);
            g.DrawLine(new Pen(Color.Black, 2f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            handCoord = hrCoord(hh % 12, mm, hrHAND);
            g.DrawLine(new Pen(Color.Gray, 3f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            pictureBox1.Image = bmp;

            this.Text = "Analog Clock -  " + hh + ":" + mm + ":" + ss;

            g.Dispose();
        }

        private void HavaDurumu_Load(object sender, EventArgs e)
        {
            if(font == "")
            {
                font = "Microsoft Tai Le";
            }
            if(bg == "")
            {
                bg = "#141519";
            }
           
            GraphicsPath sekil = new GraphicsPath();
            sekil.AddEllipse(0, 0, this.Width, this.Height);
            Region sekilbolge = new Region(sekil);
            this.Region = sekilbolge;

            bmp = new Bitmap(WIDTH + 1, HEIGHT + 1);

            
            cx = WIDTH / 2;
            cy = HEIGHT / 2;

            this.BackColor = Color.WhiteSmoke;


            t.Interval = 1000;
            t.Tick += new EventHandler(this.Tick);
            t.Start();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private int[] msCoord(int val, int hlen)
        {
            int[] coord = new int[2];
            val *= 6;

            if (val >= 0 && val <= 180)
            {
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coord[0] = cx - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            return coord;
        }


        private int[] hrCoord(int hval, int mval, int hlen)
        {
            int[] coord = new int[2];
      
            int val = (int)((hval * 30) + (mval * 0.5));

            if (val >= 0 && val <= 180)
            {
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coord[0] = cx - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            return coord;
        }

    }
}