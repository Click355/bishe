using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvironmentSimulator1
{
    public partial class Form8 : Form
    {
        public static string OCIP;
        public static int OCPort;

        public Socket socketOC = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Form8()
        {
            InitializeComponent();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text)&&!string.IsNullOrEmpty(textBox1.Text))
            {
                socketOC.SendTimeout = 10;
                try
                {
                    socketOC.Connect(textBox2.Text.Trim(),Convert.ToInt32(textBox1.Text.Trim()));
                    MessageBox.Show("连接成功");
                    OCIP = textBox2.Text.Trim();
                    OCPort = Convert.ToInt32(textBox1.Text.Trim());
                }
                catch (SocketException ex)
                {
                    MessageBox.Show($"连接失败");
                }
            }
            else
                MessageBox.Show($"请输入信息");
        }
    }
}
