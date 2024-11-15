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
    public partial class Form2 : Form
    {
        public Socket socketOC = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private Form1 f1;

        public byte[] apart(string a)
        {
            byte[] bytes = new byte[3];
            string s = a.Substring(0, 2);
            bytes[0] = Convert.ToByte(s, 16);
            s = a.Substring(2, 2);
            bytes[1] = Convert.ToByte(s, 16);
            s = a.Substring(a.Length - 2);
            bytes[2] = Convert.ToByte(s, 16);
            return bytes;
        }


        public Form2(Form1 f)
        {
            InitializeComponent();
            f1 = f;
            socketOC.SendTimeout = 500;
            try
            {
                socketOC.Connect(Form8.OCIP, Form8.OCPort);
               
            }
            catch (SocketException ex)
            {
                MessageBox.Show( $"连接失败");
            }
            if (Form1.jsqPSD == 1)
            {
                label4.Text = "屏蔽门";
                label5.Text = Form1.PSD_ID[Form1.jsqPSDtag];
                comboBox1.Items.Add("关闭");
                comboBox1.Items.Add("开启");
                if (Form1.PSD_Status[Form1.jsqPSDtag] == 0)
                {
                    comboBox1.Text = "关闭";
                }
                else if (Form1.PSD_Status[Form1.jsqPSDtag] == 1)
                {
                    comboBox1.Text = "开启";
                }
                

            }
            else if (Form1.jsqResponder == 1)
            {
                if (Form1.Tag_Status[Form1.jsqRespondertag] == 0)
                {
                    comboBox1.Text = "正常";
                }
                else if (Form1.Tag_Status[Form1.jsqRespondertag] == 1)
                {
                    comboBox1.Text = "故障";
                }
                label4.Text = "固定应答器";
                label5.Text = Form1.Tag_ID[Form1.jsqRespondertag];
                comboBox1.Items.Add("故障");
                comboBox1.Items.Add("故障还原");
                
                

            }
            else if (Form1.jsqSignal == 1)
            {
                label4.Text = "信号机";
                label5.Text = Form1.Signal_ID[Form1.jsqSignaltag];
                comboBox1.Items.Add("灭灯");
                comboBox1.Items.Add("灯丝断丝");
                comboBox1.Items.Add("灯丝熔丝");
                comboBox1.Items.Add("封锁");
                comboBox1.Items.Add("红灯");
                comboBox1.Items.Add("黄灯");
                comboBox1.Items.Add("绿灯");
                if (Form1.Signal_Status[Form1.jsqSignaltag] == 0)
                {
                    comboBox1.Text = "灭灯";
                }
                else if (Form1.Signal_Status[Form1.jsqSignaltag] == 1)
                {
                    comboBox1.Text = "灯丝断丝";
                }
                else if (Form1.Signal_Status[Form1.jsqSignaltag] == 2)
                {
                    comboBox1.Text = "灯丝熔丝";
                }
                else if (Form1.Signal_Status[Form1.jsqSignaltag] == 3)
                {
                    comboBox1.Text = "封锁";
                }
                else if (Form1.Signal_Status[Form1.jsqSignaltag] == 4)
                {
                    comboBox1.Text = "红灯";
                }
                else if (Form1.Signal_Status[Form1.jsqSignaltag] == 5)
                {
                    comboBox1.Text = "黄灯";
                }
                else if (Form1.Signal_Status[Form1.jsqSignaltag] == 6)
                {
                    comboBox1.Text = "绿灯";
                }
            }
            else if (Form1.jsqTrack == 1)
            {
                label4.Text = "无岔区段";
                label5.Text = Form1.Track_ID[Form1.jsqTracktag];
                comboBox1.Items.Add("空闲");
                comboBox1.Items.Add("正常占用");
                comboBox1.Items.Add("故障占用");
                comboBox1.Items.Add("封锁");
                if (Form1.Track_Status[Form1.jsqTracktag] == 0)
                {
                    comboBox1.Text = "空闲";
                }
                else if (Form1.Track_Status[Form1.jsqTracktag] == 1)
                {
                    comboBox1.Text = "正常占用";
                }
                else if (Form1.Track_Status[Form1.jsqTracktag] == 2)
                {
                    comboBox1.Text = "故障占用";
                }
                else if (Form1.Track_Status[Form1.jsqTracktag] == 3)
                {
                    comboBox1.Text = "封锁";
                }
            }
            else if (Form1.jsqSwitchtrack == 1)
            {
                label4.Text = "有岔区段";
                label5.Text = Form1.Switch_namefortrack[Form1.jsqSwitchtracktag];
                comboBox1.Items.Add("空闲");
                comboBox1.Items.Add("正常占用");
                comboBox1.Items.Add("故障占用");
                comboBox1.Items.Add("封锁");
                if (Form1.Switch_Trackstatus[Form1.jsqSwitchtracktag * 5] == 0)
                {
                    comboBox1.Text = "空闲";
                }
                else if (Form1.Switch_Trackstatus[Form1.jsqSwitchtracktag * 5] == 1)
                {
                    comboBox1.Text = "正常占用";
                }
                else if (Form1.Switch_Trackstatus[Form1.jsqSwitchtracktag] == 2)
                {
                    comboBox1.Text = "故障占用";
                }
                else if (Form1.Switch_Trackstatus[Form1.jsqSwitchtracktag] == 3)
                {
                    comboBox1.Text = "封锁";
                }
            }
            else if (Form1.jsqSwitch == 1)
            {
                label4.Text = "道岔";
                label5.Text = Form1.Switch_nameforswitch[Form1.jsqSwitchtag];
                comboBox1.Items.Add("定位");
                comboBox1.Items.Add("反位");
                comboBox1.Items.Add("定位锁闭");
                comboBox1.Items.Add("反位锁闭");
                comboBox1.Items.Add("四开");
                comboBox1.Items.Add("失表");
                comboBox1.Items.Add("封锁");
                if (Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 1] == 0)
                {
                    comboBox1.Text = "定位";
                }
                else if (Form1.Switch_Status[Form1.jsqSwitchtracktag * 5 + 1] == 1)
                {
                    comboBox1.Text = "反位";
                }
                else if (Form1.Switch_Status[Form1.jsqSwitchtracktag + 1] == 2)
                {
                    comboBox1.Text = "定位锁闭";
                }
                else if (Form1.Switch_Status[Form1.jsqSwitchtracktag + 1] == 3)
                {
                    comboBox1.Text = "反位锁闭";
                }
                else if (Form1.Switch_Status[Form1.jsqSwitchtracktag * 5 + 1] == 4)
                {
                    comboBox1.Text = "四开";
                }
                else if (Form1.Switch_Status[Form1.jsqSwitchtracktag + 1] == 5)
                {
                    comboBox1.Text = "失表";
                }
                else if (Form1.Switch_Status[Form1.jsqSwitchtracktag + 1] == 6)
                {
                    comboBox1.Text = "封锁";
                }
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (Form1.jsqPSD == 1)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        {
                            Form1.PSD_Status[Form1.jsqPSDtag] = 0;
                            
                            break;
                        }
                    case 1:
                        {
                            Form1.PSD_Status[Form1.jsqPSDtag] = 1;
                            break;
                        }
                }
            }
            else if (Form1.jsqResponder == 1)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        Form1.Tag_Status[Form1.jsqRespondertag] = 1;
                        break;
                    case 1:
                        Form1.Tag_Status[Form1.jsqRespondertag] = 0;
                        break;

                }
            }
            else if (Form1.jsqSignal == 1)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        Form1.Signal_Status[Form1.jsqSignaltag] = 0;
                        break;
                    case 1:
                        Form1.Signal_Status[Form1.jsqSignaltag] = 1;
                        break;
                    case 2:
                        Form1.Signal_Status[Form1.jsqSignaltag] = 2;
                        break;
                    case 3:
                        Form1.Signal_Status[Form1.jsqSignaltag] = 3;
                        break;
                    case 4:
                        Form1.Signal_Status[Form1.jsqSignaltag] = 4;
                        break;
                    case 5:
                        Form1.Signal_Status[Form1.jsqSignaltag] = 5;
                        break;
                    case 6:
                        Form1.Signal_Status[Form1.jsqSignaltag] = 6;
                        break;
                }
            }
            else if (Form1.jsqTrack == 1)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        Form1.Track_Status[Form1.jsqTracktag] = 0;
                        break;
                    case 1:
                        Form1.Track_Status[Form1.jsqTracktag] = 1;
                        break;
                    case 2:
                        Form1.Track_Status[Form1.jsqTracktag] = 2;
                        break;
                    case 3:
                        Form1.Track_Status[Form1.jsqTracktag] = 3;
                        break;
                }
            }
            else if (Form1.jsqSwitchtrack == 1)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        {
                            Form1.Switch_Trackstatus[Form1.jsqSwitchtracktag * 5] = 0;
                            Form1.Switch_Trackstatus[Form1.jsqSwitchtracktag * 5 + 2] = 0;
                            Form1.Switch_Trackstatus[Form1.jsqSwitchtracktag * 5 + 4] = 0;
                            break;
                        }
                    case 1:
                        {
                            Form1.Switch_Trackstatus[Form1.jsqSwitchtracktag * 5] = 1;
                            Form1.Switch_Trackstatus[Form1.jsqSwitchtracktag * 5] = 1;
                            Form1.Switch_Trackstatus[Form1.jsqSwitchtracktag * 5] = 1;
                            break;
                        }
                    case 2:
                        {
                            Form1.Switch_Trackstatus[Form1.jsqSwitchtracktag * 5] = 2;
                            Form1.Switch_Trackstatus[Form1.jsqSwitchtracktag * 5 + 2] = 2;
                            Form1.Switch_Trackstatus[Form1.jsqSwitchtracktag * 5 + 4] = 2;
                            break;
                        }
                    case 3:
                        {
                            Form1.Switch_Trackstatus[Form1.jsqSwitchtracktag * 5] = 3;
                            Form1.Switch_Trackstatus[Form1.jsqSwitchtracktag * 5 + 2] = 3;
                            Form1.Switch_Trackstatus[Form1.jsqSwitchtracktag * 5 + 4] = 3;
                            break;
                        }
                }
            }
            else if (Form1.jsqSwitch == 1)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        {
                            Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 1] = 0;
                            Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 3] = 0;
                            break;
                        }
                    case 1:
                        {
                            Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 1] = 1;
                            Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 3] = 1;
                            break;
                        }
                    case 2:
                        {
                            Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 1] = 2;
                            Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 3] = 2;
                            break;
                        }
                    case 3:
                        {
                            Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 1] = 3;
                            Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 3] = 3;
                            break;
                        }
                    case 4:
                        {
                            Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 1] = 4;
                            Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 3] = 4;
                            break;
                        }
                    case 5:
                        {
                            Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 1] = 5;
                            Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 3] = 5;
                            break;
                        }
                    case 6:
                        {
                            Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 1] = 6;
                            Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 3] = 6;
                            break;
                        }
                }
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.jsqSwitch != 0)
            {
                Message mes = new Message();
                if (Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 1] == 0)
                { 
                    byte[] send = mes.ETOStacmd(0xAA, apart(Form1.Switch_IDSub[Form1.jsqSwitchtag * 5 + 1]), 0xF0);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " + Environment.NewLine);
                }
                if (Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 1] == 1)
                {
                    byte[] send = mes.ETOStacmd(0xAA, apart(Form1.Switch_IDSub[Form1.jsqSwitchtag * 5 + 1]), 0x0F);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " + Environment.NewLine);  
                }
                if (Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 1] == 2)
                {
                    byte[] send = mes.ETOStacmd(0xAA, apart(Form1.Switch_IDSub[Form1.jsqSwitchtag * 5 + 1]), 0x02);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " +  Environment.NewLine);
                }
                if (Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 1] == 3)
                {
                    byte[] send = mes.ETOStacmd(0xAA, apart(Form1.Switch_IDSub[Form1.jsqSwitchtag * 5 + 1]), 0x03);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " + Environment.NewLine);
                }
                if (Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 1] == 4)
                {
                    byte[] send = mes.ETOStacmd(0xAA, apart(Form1.Switch_IDSub[Form1.jsqSwitchtag * 5 + 1]), 0x04);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " + Environment.NewLine);
                }
                if (Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 1] == 5)
                {
                    byte[] send = mes.ETOStacmd(0xAA, apart(Form1.Switch_IDSub[Form1.jsqSwitchtag * 5 + 1]), 0x05);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " + Environment.NewLine);
                }
                if (Form1.Switch_Status[Form1.jsqSwitchtag * 5 + 1] == 6)
                {
                    byte[] send = mes.ETOStacmd(0xAA, apart(Form1.Switch_IDSub[Form1.jsqSwitchtag * 5 + 1]), 0x06);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " + Environment.NewLine);
                }
            }
            if (Form1.jsqPSD != 0)
            {
                Message mes = new Message();
                if (Form1.PSD_Status[Form1.jsqPSDtag] == 0)
                {
                    byte[] send = mes.ETOStacmd(0x55, apart(Form1.PSD_IDSub[Form1.jsqPSDtag]), 0xF0);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " + Environment.NewLine);
                }
                if (Form1.PSD_Status[Form1.jsqPSDtag] == 1)
                {
                    byte[] send = mes.ETOStacmd(0x55, apart(Form1.PSD_IDSub[Form1.jsqPSDtag]), 0x0F);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " +  Environment.NewLine);
                }
            }
            if (Form1.jsqSwitchtrack != 0)
            {
                Message mes = new Message();
                if (Form1.Switch_Trackstatus[Form1.jsqSwitchtracktag * 5] == 0)
                {
                    byte[] send = mes.ETOStacmd(0x22, apart(Form1.Switch_TracknameSub[Form1.jsqSwitchtracktag * 5]), 0x00);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " + Environment.NewLine);
                }
                if (Form1.Switch_Trackstatus[Form1.jsqSwitchtracktag * 5] == 1)
                {
                    byte[] send = mes.ETOStacmd(0x22, apart(Form1.Switch_TracknameSub[Form1.jsqSwitchtracktag * 5]), 0x01);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " + Environment.NewLine);
                }
                if (Form1.Switch_Trackstatus[Form1.jsqSwitchtracktag * 5] == 2)
                {
                    byte[] send = mes.ETOStacmd(0x22, apart(Form1.Switch_TracknameSub[Form1.jsqSwitchtracktag * 5]), 0x02);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " +Environment.NewLine);
                }
                if (Form1.Switch_Trackstatus[Form1.jsqSwitchtracktag * 5] == 3)
                {
                    byte[] send = mes.ETOStacmd(0x22, apart(Form1.Switch_TracknameSub[Form1.jsqSwitchtracktag * 5]), 0x03);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " +Environment.NewLine);
                }
            }
            if (Form1.jsqTrack != 0)
            {
                Message mes = new Message();
                if (Form1.Track_Status[Form1.jsqTracktag] == 0)
                {
                    byte[] send = mes.ETOStacmd(0x11, apart(Form1.Track_IDSub[Form1.jsqTracktag]), 0x00);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  "+ Environment.NewLine);
                }
                if (Form1.Track_Status[Form1.jsqTracktag] == 1)
                {
                    byte[] send = mes.ETOStacmd(0x11, apart(Form1.Track_IDSub[Form1.jsqTracktag]), 0x01);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " + Environment.NewLine);
                }
                if (Form1.Track_Status[Form1.jsqTracktag] == 2)
                {
                    byte[] send = mes.ETOStacmd(0x11, apart(Form1.Track_IDSub[Form1.jsqTracktag]), 0x02);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " +Environment.NewLine);
                }
                if (Form1.Track_Status[Form1.jsqTracktag] == 3)
                {
                    byte[] send = mes.ETOStacmd(0x11, apart(Form1.Track_IDSub[Form1.jsqTracktag]), 0x03);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " + Environment.NewLine);
                }
            }
            if (Form1.jsqResponder != 0)
            {
                Message mes = new Message();
                if (Form1.Tag_Status[Form1.jsqRespondertag] == 0)
                {
                    byte[] send = mes.ETOStacmd(0x33, apart(Form1.Tag_IDSub[Form1.jsqRespondertag]), 0x00);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " +  Environment.NewLine);
                }
                if (Form1.Tag_Status[Form1.jsqRespondertag] == 1)
                {
                    byte[] send = mes.ETOStacmd(0x33, apart(Form1.Tag_IDSub[Form1.jsqRespondertag]), 0x01);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " + Environment.NewLine);
                }
            }
            if (Form1.jsqSignal != 0)
            {
                Message mes = new Message();
                if (Form1.Signal_Status[Form1.jsqSignaltag] == 0)
                {
                    byte[] send = mes.ETOStacmd(0x44, apart(Form1.Signal_IDSub[Form1.jsqSignaltag]), 0x00);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " +  Environment.NewLine);
                }
                if (Form1.Signal_Status[Form1.jsqSignaltag] == 1)
                {
                    byte[] send = mes.ETOStacmd(0x44, apart(Form1.Signal_IDSub[Form1.jsqSignaltag]), 0x01);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " + Environment.NewLine);
                }
                if (Form1.Signal_Status[Form1.jsqSignaltag] == 2)
                {
                    byte[] send = mes.ETOStacmd(0x44, apart(Form1.Signal_IDSub[Form1.jsqSignaltag]), 0x02);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " + Environment.NewLine);
                }
                if (Form1.Signal_Status[Form1.jsqSignaltag] == 3)
                {
                    byte[] send = mes.ETOStacmd(0x44, apart(Form1.Signal_IDSub[Form1.jsqSignaltag]), 0x03);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " + Environment.NewLine);
                }
                if (Form1.Signal_Status[Form1.jsqSignaltag] == 4)
                {
                    byte[] send = mes.ETOStacmd(0x44, apart(Form1.Signal_IDSub[Form1.jsqSignaltag]), 0x04);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " + Environment.NewLine);
                }
                if (Form1.Signal_Status[Form1.jsqSignaltag] == 5)
                {
                    byte[] send = mes.ETOStacmd(0x44, apart(Form1.Signal_IDSub[Form1.jsqSignaltag]), 0x05);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " + Environment.NewLine);
                }
                if (Form1.Signal_Status[Form1.jsqSignaltag] == 6)
                {
                    byte[] send = mes.ETOStacmd(0x44, apart(Form1.Signal_IDSub[Form1.jsqSignaltag]), 0x06);
                    socketOC.Send(send);
                    f1.richTextBox3.AppendText("发：" + BitConverter.ToString(send).Replace("-", " ") + "  " + Environment.NewLine);
                }
                else { }
            }
            Form1.jsqPSD = 0;
            Form1.jsqResponder = 0;
            Form1.jsqSignal = 0;
            Form1.jsqTrack = 0;
            Form1.jsqSwitchtrack = 0;
            Form1.jsqSwitch = 0;
            socketOC.Close();
            socketOC.Dispose();
            this.Close();
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.jsqPSD = 0;
            Form1.jsqResponder = 0;
            Form1.jsqSignal = 0;
            Form1.jsqTrack = 0;
            Form1.jsqSwitchtrack = 0;
            Form1.jsqSwitch = 0;
            socketOC.Close();
            socketOC.Dispose();
        }


    }
}
