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
    public partial class paketbilgisi : Form
    {
        public paketbilgisi()
        {
            InitializeComponent();
        }
        public string rootFolder = "";
        public string sww = "";
        private void paketbilgisi_Load(object sender, EventArgs e)
        {
            try
            {
                string read = File.ReadAllText( sww + @"\bilgi.txt");
                label1.Text = read;
                pictureBox1.ImageLocation =   sww + @"\icon.png";
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Directory.Delete(rootFolder,true);
            KlasorKopyala(sww, rootFolder);
            MessageBox.Show("Paketiniz içe aktarıldı. Uygulama yeniden başlatılacak");
            Application.Restart();
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
    }
}
