using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_LinuxSetupUtility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
            }
            else
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                label5.Visible = true;
                textBox5.Visible = true;
            }
            else
            {
                label5.Visible = false;
                textBox5.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string update;
            string mariadbserver;
            string mariasetup;
            string tararchive;

            if (checkBox3.Checked == true) tararchive = textBox5.Text;
            else tararchive = "https://runtime.fivem.net/artifacts/fivem/build_proot_linux/master/5369-d1a48fc1af5b16650a7b60a3c840114da7dbe033/fx.tar.xz";


            if (checkBox1.Checked == true)
            {
                update = "// UBUNTU UPDATE //\r\n" +
                    "\r\n" +
                    "sudo apt-get update\r\n" +
                    "sudo apt update\r\n" +
                    "sudo apt upgrade\r\n";
                
            }
            else
            {
                update = "";
            }

            if (checkBox2.Checked == true)
            {
                mariadbserver = "mariadb-server";
                mariasetup = $"\r\n\r\n// DATABASE-SETUP //\r\n" +
                    $"\r\n" +
                    $"sudo mysql_secure_installation\r\n" +
                    $"ENTER\r\n" +
                    $"N\r\n" +
                    $"Y\r\n" +
                    $"Y\r\n" +
                    $"Y\r\n" +
                    $"Y\r\n" +
                    $"sudo mysql\r\n" +
                    $"CREATE USER '{textBox2.Text}'@'%' IDENTIFIED BY '{textBox1.Text}';\r\n" +
                    $"CREATE USER '{textBox3.Text}'@'localhost' IDENTIFIED BY '{textBox4.Text}';\r\n" +
                    $"GRANT ALL PRIVILEGES ON *.* TO '{textBox2.Text}'@'%';\r\n" +
                    $"GRANT ALL PRIVILEGES ON *.* TO '{textBox3.Text}'@'localhost';\r\n" +
                    $"FLUSH PRIVILEGES;\r\n";
            }
            else
            {
                mariadbserver = "";
                mariasetup = "";
            }

            richTextBox1.Text = $"// BEFORE PROCEEDING - The Curl Line sometimes wraps into the next line due to the length of the link. //\r\n" +
                    $"\r\n" +
                    $"\r\n" +
                    $"{update}" +
                    $"sudo apt-get install screen curl {mariadbserver}\r\n" +
                    $"{mariasetup}" +
                    $"\r\n\r\n// FX-SERVER SETUP //\r\n" +
                    $"\r\n" +
                    $"sudo mkdir /home/FiveM/\r\n" +
                    $"sudo mkdir /home/FiveM/server/\r\n" +
                    $"sudo curl {tararchive} -o /home/FiveM/server/fx.tar.xz\r\n" +
                    $"cd /home/FiveM/server/fx.tar.xz\r\n" +
                    $"sudo tar -xf fx.tar.xz\r\n" +
                    $"sudo rm fx.tar.xz\r\n" +
                    $"sudo screen -S FXServer\r\n" +
                    $"sudo ./run.sh\r\n";
            textBox6.Text = $"mysql://{textBox3.Text}:{textBox4.Text}@127.0.0.1/es_extended?charset=utf8mb4";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true) textBox6.Visible = true;
            else textBox6.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/overextended/oxmysql/releases");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://runtime.fivem.net/artifacts/fivem/build_proot_linux/master/");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.heidisql.com/download.php");
        }
    }
}
