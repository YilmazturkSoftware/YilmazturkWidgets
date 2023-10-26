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
    public partial class YeniWidget : Form
    {
        public YeniWidget()
        {
            InitializeComponent();
        }

        private void YeniWidget_Load(object sender, EventArgs e)
        {

        }

        private void defaultacek(Panel panel)
        {
            panel.Visible = true;
            panel.BringToFront();
            panel.Size = new Size(865, 347);
            panel.Location = new Point(19, 134);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "Saat")
            {
                defaultacek(saat);
            }
            else if (comboBox1.SelectedItem.ToString() == "Analog Saat")
            {
                defaultacek(panel2);
            }
            else if (comboBox1.SelectedItem.ToString() == "Resim")
            {
                defaultacek(panel3);
            }
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ColorDialog color = new ColorDialog(); color.Color = panel1.BackColor;
            if (color.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = color.Color;   

            }
        }
        public Point sonuc = new Point();
        private void timeLBL_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog(); color.Color = timeLBL.ForeColor;
            if (color.ShowDialog() == DialogResult.OK)
            {
                timeLBL.ForeColor = color.Color;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog(); font.Font = date.Font;
            if(font.ShowDialog() == DialogResult.OK)
            {
                date.Font = font.Font;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog(); font.Font = timeLBL.Font;
            if (font.ShowDialog() == DialogResult.OK)
            {
                timeLBL.Font = font.Font;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "Saat")
            {
                if (textBox1.Text != "")
                {
                    try
                    {
                        string alt = @"C:\Users\" + Environment.UserName + @"\YWidget\" + textBox1.Text + @"\";
                        Directory.CreateDirectory(alt);
                        File.WriteAllText(alt + "tur", "Saat");
                        File.WriteAllText(alt + "bgrenk", ColorToHex(panel1.BackColor));
                        File.WriteAllText(alt + "arenk", ColorToHex(timeLBL.ForeColor));
                        File.WriteAllText(alt + "daterenk", ColorToHex(date.ForeColor));
                        File.WriteAllText(alt + "font", timeLBL.Font.Name);
                        File.WriteAllText(alt + "datefont", date.Font.Name);
                        File.WriteAllText(alt + "ky", sonuc.Y + "");
                        File.WriteAllText(alt + "kx", sonuc.X + "");
                        File.WriteAllText(alt + "fontsize", Convert.ToInt32(timeLBL.Font.Size) + "");
                        File.WriteAllText(alt + "datefontsize", Convert.ToInt32(date.Font.Size) + ""); 
                        if(timeLBL.Text != "saat")
                        {
                            File.WriteAllText(alt + "saatyazi", timeLBL.Text);
                        }
                        if (date.Text != "takvim")
                        {
                            File.WriteAllText(alt + "dateyazi", date.Text);
                        }
                        Application.Restart();
                        
                    }
                    catch
                    {
                        MessageBox.Show("Konum belirleyin");
                    }
                }
                else
                {
                    MessageBox.Show("Widget'a bir isim verin.");
                }

            }
            else if(comboBox1.SelectedItem.ToString() == "Analog Saat")
            {

                string alt = @"C:\Users\" + Environment.UserName + @"\YWidget\" + textBox2.Text + @"\";
                Directory.CreateDirectory(alt);
                File.WriteAllText(alt + "tur", "Analog");
                File.WriteAllText(alt + "font", label5.Text);
                File.WriteAllText(alt + "color", label6.Text);
                File.WriteAllText(alt + "ky", sonuc.Y + "");
                File.WriteAllText(alt + "kx", sonuc.X + ""); Application.Restart();
            }
            else if (comboBox1.SelectedItem.ToString() == "Resim")
            {
                if (textBox3.Text != "")
                {
                    string alt = @"C:\Users\" + Environment.UserName + @"\YWidget\" + textBox3.Text + @"\";
                    Directory.CreateDirectory(alt);
                    File.WriteAllText(alt + "tur", "Resim");
                    File.WriteAllText(alt + "konum", pictureBox1.ImageLocation);
                    File.WriteAllText(alt + "s1", pictureBox1.Size.Width + "");
                    File.WriteAllText(alt + "s2", pictureBox1.Size.Height + "");
                    File.WriteAllText(alt + "ky", sonuc.Y + "");
                    File.WriteAllText(alt + "kx", sonuc.X + ""); Application.Restart();
                }
                else
                {
                    MessageBox.Show("Widget'a bir isim verin.");
                }
            }


        }
        static string ColorToHex(Color color)
        {
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KonumBelirle konum = new KonumBelirle();
            konum.yeniWidget = this;
            konum.panel1.Size = panel1.Size;
            konum.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KonumBelirle konum = new KonumBelirle();
            konum.yeniWidget = this;
            konum.panel1.Size = new Size(221, 214);
            konum.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            font.Font = new Font("Microsoft Tai Le", 12);
            if(font.ShowDialog() == DialogResult.OK)
            {
                label5.Text = font.Font.Name;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            ColorDialog font = new ColorDialog();
            font.Color = Color.Black;
            if (font.ShowDialog() == DialogResult.OK)
            {
                label6.Text = ColorToHex(font.Color);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Size = new Size(Convert.ToInt32(textBox4.Text), pictureBox1.Size.Height);
            }
            catch { }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Size = new Size(pictureBox1.Size.Width, Convert.ToInt32(textBox5.Text));
            }
            catch { }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            KonumBelirle konum = new KonumBelirle();
            konum.yeniWidget = this;
            konum.panel1.Size = pictureBox1.Size;
            konum.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if(open.ShowDialog() == DialogResult.OK)
            {
                string uzanti = "";
                if(open.FileName.EndsWith(".png")) { uzanti = ".png"; } else if (open.FileName.EndsWith(".jpg")) { uzanti = ".jpg"; } else if (open.FileName.EndsWith(".jpeg")) { uzanti = ".jpeg"; } else if (open.FileName.EndsWith(".webp")) { uzanti = ".webp"; } else if (open.FileName.EndsWith(".gif")) { uzanti = ".gif"; }
                File.Copy(open.FileName, @"C:\Users\" + Environment.UserName + @"\YWidget\" + Path.GetFileName(open.FileName), true) ;
    
                pictureBox1.ImageLocation = @"C:\Users\" + Environment.UserName + @"\YWidget\" + Path.GetFileName(open.FileName) ;
            }
        }

        private void yazıyıDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            input irw = new input();
            irw.textBox1.Text = date.Text;
            irw.button1.Click += (sn, ar) =>
            {
                date.Text = irw.textBox1.Text;
          
            };
            irw.ShowDialog();
        }

        private void yazıyıDeğiştirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            input irw = new input();
            irw.textBox1.Text = timeLBL.Text;
            irw.button1.Click += (sn, ar) =>
            {
                timeLBL.Text = irw.textBox1.Text;
               
            };
            irw.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            timeLBL.Text = "saat";
            date.Text = "takvim";
        }
    }
}
