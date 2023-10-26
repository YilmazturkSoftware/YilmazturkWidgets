using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yılmaztürk_Widgets
{
    public partial class mavikutu : Form
    {
        public mavikutu()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if(color.ShowDialog() == DialogResult.OK)
            {

                try
                {

                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Colors", true);
                    RegistryKey key2 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Colors", true);
                    if (key != null)
                    {

                        key.SetValue("Hilight", color.Color.R + " " + color.Color.G + " " + color.Color.B); 

                        key.Close();

                        key2.SetValue("HotTrackingColor", color.Color.R + " " + color.Color.G + " " + color.Color.B);

                        key2.Close();
                        DialogResult result = MessageBox.Show("Renk ayarlandı, bilgisayarın yeniden başlatılması gerek. Başlatılsınmı?", "Başarılı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                        if (result == DialogResult.Yes)
                        {
                            Process.Start("shutdown", "/r /t 0");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Anahtar bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Colors", true);
                RegistryKey key2 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Colors", true);
                if (key != null)
                {

                    key.SetValue("Hilight", "0 120 215");

                    key.Close();

                    key2.SetValue("HotTrackingColor", "0 120 215");

                    key2.Close();
                    DialogResult result = MessageBox.Show("Renk sıfırlandı, bilgisayarın yeniden başlatılması gerek. Başlatılsınmı?", "Başarılı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    if (result == DialogResult.Yes)
                    {
                        Process.Start("shutdown", "/r /t 0");
                    }
                }
                else
                {
                    Console.WriteLine("Anahtar bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }

        }

        private void mavikutu_Load(object sender, EventArgs e)
        {
            try
            {
                // Registry anahtarını açın
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Colors");

                if (key != null)
                {
                    // Değeri okuyun
                    string hilightValue = key.GetValue("Hilight") as string;

                    if (!string.IsNullOrEmpty(hilightValue))
                    {
                        // RGB kodunu çözümleyin
                        string[] rgbComponents = hilightValue.Split(' ');
                        if (rgbComponents.Length == 3)
                        {
                            int r = int.Parse(rgbComponents[0]);
                            int g = int.Parse(rgbComponents[1]);
                            int b = int.Parse(rgbComponents[2]);


                          
                            pictureBox1.BackColor = Color.FromArgb(r, g, b);
                       
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz RGB kodu.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hilight değeri bulunamadı.");
                    }

                    // Anahtarı kapatın
                    key.Close();
                }
                else
                {
                    Console.WriteLine("Anahtar bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }
        }
    }
}
