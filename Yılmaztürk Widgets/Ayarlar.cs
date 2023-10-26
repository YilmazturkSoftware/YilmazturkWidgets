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
    public partial class Ayarlar : Form
    {
        public Ayarlar()
        {
            InitializeComponent();
        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            if(File.Exists(@"C:\Users\" + Environment.UserName + @"\Widgetların Arkaplanını Silme.ayar"))
            {
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }
            if (File.Exists(@"C:\Users\" + Environment.UserName + @"\Widgetlar Alt F4 ile kapansın.ayar"))
            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }
            if (File.Exists(@"C:\Users\" + Environment.UserName + @"\Başlatıldığında sadece widgetlar açılsın.ayar"))
            {
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Checked = false;
            }
            panel1.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == false)
            {
               File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Widgetların Arkaplanını Silme.ayar","");
            }
            else
            {
                if(File.Exists(@"C:\Users\" + Environment.UserName + @"\Widgetların Arkaplanını Silme.ayar"))
                {
                    File.Delete(@"C:\Users\" + Environment.UserName + @"\Widgetların Arkaplanını Silme.ayar");
                }
            }
            panel1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Widgetlar Alt F4 ile kapansın.ayar", "");
            }
            else
            {
                if (File.Exists(@"C:\Users\" + Environment.UserName + @"\Widgetlar Alt F4 ile kapansın.ayar"))
                {
                    File.Delete(@"C:\Users\" + Environment.UserName + @"\Widgetlar Alt F4 ile kapansın.ayar");
                }
            }
            panel1.Visible = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Başlatıldığında sadece widgetlar açılsın.ayar", "");
            }
            else
            {
                if (File.Exists(@"C:\Users\" + Environment.UserName + @"\Başlatıldığında sadece widgetlar açılsın.ayar"))
                {
                    File.Delete(@"C:\Users\" + Environment.UserName + @"\Başlatıldığında sadece widgetlar açılsın.ayar");
                }
            }
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
