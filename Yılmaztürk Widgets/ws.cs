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
    public partial class ws : Form
    {
        public ws()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\YWidget\bilgi.txt", textBox1.Text);
                if(File.Exists(pictureBox1.ImageLocation))
                {
                    File.Copy(pictureBox1.ImageLocation, @"C:\Users\" + Environment.UserName + @"\YWidget\icon.png");
                }
                KlasorKopyala(@"C:\Users\" + Environment.UserName + @"\YWidget\", folderBrowserDialog.SelectedPath);
                MessageBox.Show("Paketiniz başarıyla dışa aktarıldı. Bu paketi artık paylaşabilirsiniz.");
            }
      
            this.Hide();
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
