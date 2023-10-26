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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
      
    //    private readonly HavaDurumu hava = new HavaDurumu();

        private readonly Analog analog = new Analog();
        private bool move = true;
        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);
        string rootFolder = @"C:\Users\" + Environment.UserName + @"\YWidget\";
        private void Form1_Load(object sender, EventArgs e)
        {
         
            Directory.CreateDirectory(rootFolder);

            string[] subDirectories = Directory.GetDirectories(rootFolder);

       
            foreach (string subDirectory in subDirectories)
            {
                if(File.Exists(subDirectory + @"\tur"))
                {
                    string read = File.ReadAllText(subDirectory + @"\tur");
                    if(read == "Saat")
                    {
                       Hour hour = new Hour();
                     string alt = subDirectory + @"\";
                       
                        string bgrenk =   File.ReadAllText(alt + "bgrenk");
                        string arenk = File.ReadAllText(alt + "arenk");
                        string daterenk = File.ReadAllText(alt + "daterenk");
                        string font = File.ReadAllText(alt + "font");
                        string datefont = File.ReadAllText(alt + "datefont");

                        string fontsize = File.ReadAllText(alt + "fontsize");
                        string datefontsize = File.ReadAllText(alt + "datefontsize");
                        string kx = File.ReadAllText(alt + "kx");
                        string ky = File.ReadAllText(alt + "ky");
                        hour.StartPosition = FormStartPosition.Manual;
                        hour.Location = new Point(Convert.ToInt32(kx), Convert.ToInt32(ky) );
                        hour.BackColor = System.Drawing.ColorTranslator.FromHtml(bgrenk);
                        hour.timeLBL.ForeColor = System.Drawing.ColorTranslator.FromHtml(arenk);
                        hour.date.ForeColor = System.Drawing.ColorTranslator.FromHtml(daterenk);
                        hour.timeLBL.Font =  new Font(font,Convert.ToInt32(fontsize));
                        hour.date.Font = new Font(datefont, Convert.ToInt32(datefontsize));
                        if (File.Exists(alt + "saatyazi"))
                        {
                            hour.saat = false;
                            hour.timeLBL.Text = File.ReadAllText(alt + "saatyazi");
                        }
                        if (File.Exists(alt + "dateyazi"))
                        {
                            hour.saat = false;
                            hour.date.Text = File.ReadAllText(alt + "dateyazi");
      
                        }

                        hour.Show();
                       
                    }
                    else if(read == "Analog")
                    {
                        string alt = subDirectory + @"\";
                        string kx = File.ReadAllText(alt + "kx");
                        string ky = File.ReadAllText(alt + "ky");
                   
                        Analog analog = new Analog();
                        analog.StartPosition = FormStartPosition.Manual;
                        analog.Location = new Point(Convert.ToInt32(kx), Convert.ToInt32(ky));
                        try
                        {
                            string color = File.ReadAllText(alt + "color");
                            string font = File.ReadAllText(alt + "font");
                            analog.bg = color;
                            analog.font = font;
                        }
                        catch
                        {

                        }
                        analog.Show();
                    }
                    else if (read == "Resim")
                    {
                        string alt = subDirectory + @"\";
                        string kx = File.ReadAllText(alt + "kx");
                        string ky = File.ReadAllText(alt + "ky");
                        string s1 = File.ReadAllText(alt + "s1");
                        string s2 = File.ReadAllText(alt + "s2");
                        string konum = File.ReadAllText(alt + "konum");
           
                        WidgetTemp analog = new WidgetTemp();
                        analog.StartPosition = FormStartPosition.Manual;
                        analog.Location = new Point(Convert.ToInt32(kx), Convert.ToInt32(ky));
                        analog.Size = new Size(Convert.ToInt32(s1), Convert.ToInt32(s2));
                        analog.pictureBox1.ImageLocation = konum;
                        analog.Show();
               
                    }
                }
            }
       
            Console.ReadLine();
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
         
 
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            YeniWidget yeni = new YeniWidget();
            yeni.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tüm widgetları silmek istediğinize eminmisiniz? (Bu işlem geri alınamaz)", "Tüm Widgetları Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                Directory.Delete(rootFolder,true);
                Application.Restart();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ws ws = new ws();
            ws.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Eğer bu işlemi yaparsanız şuanda kullanmış olduğunuz paket tamamen silinecek. Eminmisiniz?", "Onay İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
              
                 FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    paketbilgisi paket = new paketbilgisi();
                    paket.sww = folderBrowserDialog.SelectedPath;
                    paket.rootFolder = rootFolder;
                    paket.ShowDialog();
            

                }
            }
        }
        static void KlasorKopyala(string kaynak, string hedef)
        {
            if (!Directory.Exists(kaynak))
            {
                Console.WriteLine("Kaynak klasör bulunamadı.");
                return;
            }

            if (!Directory.Exists(hedef))
            {
                Directory.CreateDirectory(hedef);
            }

            string[] dosyalar = Directory.GetFiles(kaynak);

            foreach (string dosya in dosyalar)
            {
                string hedefDosya = Path.Combine(hedef, Path.GetFileName(dosya));
                File.Copy(dosya, hedefDosya, true);
            }

            string[] altKlasorler = Directory.GetDirectories(kaynak);

            foreach (string altKlasor in altKlasorler)
            {
                string yeniHedefKlasor = Path.Combine(hedef, Path.GetFileName(altKlasor));
                KlasorKopyala(altKlasor, yeniHedefKlasor);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            paketbilgisi paket = new paketbilgisi();
            paket.button1.Visible = false;
            if(File.Exists(rootFolder + @"bilgi.txt"))
            {
                paket.label1.Text = File.ReadAllText(rootFolder + @"bilgi.txt");
            }
            paket.pictureBox1.ImageLocation = rootFolder + @"icon.png";
            paket.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            mavikutu mavi = new mavikutu();
            mavi.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Ayarlar ayarlar = new Ayarlar();
            ayarlar.ShowDialog();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\Users\" + Environment.UserName + @"\Başlatıldığında sadece widgetlar açılsın.ayar"))
            {
                this.Hide();
            }
        }
    }
}
