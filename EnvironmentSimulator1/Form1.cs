using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace EnvironmentSimulator1
{
    public partial class Form1 : Form
    {
        public string OCIP;
        public int SocketServerPort = 123;
        //处理连接请求的线程
        public Thread acceptConnectReqThd;

        Dictionary<int, Socket> ClintDataDictionary = new Dictionary<int, Socket>();
        Dictionary<string, Socket> ClintIPDictionary1 = new Dictionary<string, Socket>();
        //创建Socket字典
        Dictionary<string, Socket> diSocket = new Dictionary<string, Socket>();

        /// <summary>
        /// 启动服务器
        /// </summary>
        public bool Start()
        {
            try
            {
                //创建一个socket对象
                Socket socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //获取IP
                IPAddress ip = IPAddress.Any;
                
                //创建端口号
                IPEndPoint port = new IPEndPoint(ip, SocketServerPort);
                //监听
                socketWatch.Bind(port);
                socketWatch.Listen(30);  //设定最大的挂起长度
                                            //新建线程来处理连接请求
                acceptConnectReqThd = new Thread(AcceptConnectReqHandler);
                acceptConnectReqThd.IsBackground = true;
                acceptConnectReqThd.Start(socketWatch);  //把socket对象当做参数传递给到线程里面的方法

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        Socket socketsend;
        /// <summary>
        /// 连接请求的处理函数
        /// </summary>
        /// <param name="_socket"></param>
        public void AcceptConnectReqHandler(object _socket)
        {
            try
            {
                //服务端的socket对象
                Socket serverSocket = _socket as Socket;

                while (true)
                {
                    //获取客户端socket。Accept方法处理任何传入的连接请求，并返回可用于与远程主机通信数据的Socket对象，即客户端的socket。
                    //这一句话会卡主线程。只要没有新的链接进来，就会一直卡主不动（等待中）。
                    //收到连接事件后，会往下执行，通过while又回到这里继续等待
                    socketsend = serverSocket.Accept();
                    //将运城客户端的IP地址和Socket存入集合中
                    ClintIPDictionary1.Add(socketsend.RemoteEndPoint.ToString(), socketsend);


                    //创建接受客户端消息的线程
                    Thread acceptMsgReqThd = new Thread(ReciveMsgReqHandler);
                    acceptMsgReqThd.IsBackground = true;
                    acceptMsgReqThd.Start(socketsend);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("服务端处理连接事件异常:" + e.ToString());
            }
        }

        /// <summary>
        /// 接收客户端socket消息
        /// </summary>
        /// <param name="_socket"></param>
        public void ReciveMsgReqHandler(object _socket)
        {

            Socket clientSocket = (Socket)_socket;
            byte[] buffer = new byte[1024];  //数据缓冲区。
            try
            {
                while (true)
                {
                    //客户端连接成功后，接受来自客户端的消息

                    if (clientSocket == null)
                    {
                        continue;
                    }
                    //实际接收到的有效字节数
                    //Receive也是个卡线程的方法
                    int dataLength = clientSocket.Receive(buffer);
                    //如果客户端关闭，发送的数据就为空，就跳出循环
                    if (dataLength == 0)
                    {
                        break;
                    }

                    if (buffer[3]==0x07)
                    {
                        Graphics g = panel1.CreateGraphics();
                        g.TranslateTransform(panel1.AutoScrollPosition.X, panel1.AutoScrollPosition.Y);
                        pictureBox2.BackColor = Color.Green;
                        Message.VOBCtoESStruct VTE = new Message.VOBCtoESStruct();//定义列车状态信息解析报文结构                      
                        VTE = (Message.VOBCtoESStruct)structANDbyte.BytesToStruct(buffer, typeof(Message.VOBCtoESStruct));//解码列车发来的消息
                        if (buffer[8] == 0xAA)//下行
                        {
                            //Train.DrawTrain(g);
                            richTextBox2.SelectionStart = richTextBox2.Text.Length;
                            richTextBox2.ScrollToCaret();
                            richTextBox2.AppendText("收：下行  车次" + VTE.Train_ID.ToString() + "  位置" + VTE.Train_X.ToString() + " " + VTE.Train_Y.ToString() + Environment.NewLine);                           
                        }
                        if (buffer[8] == 0x55)
                        {
                            richTextBox2.SelectionStart = richTextBox2.Text.Length;
                            richTextBox2.ScrollToCaret();
                            richTextBox2.AppendText("收：上行  车次" + VTE.Train_ID.ToString() + "  位置"+ VTE.Train_X.ToString()+ Environment.NewLine);
                        }
                        if (buffer[8] == 0xFF)
                        {
                            richTextBox2.SelectionStart = richTextBox2.Text.Length;
                            richTextBox2.ScrollToCaret();
                            richTextBox2.AppendText("收：    车次" + VTE.Train_ID.ToString() + "  位置" + VTE.Train_X.ToString() + Environment.NewLine);
                        }

                    }
                    if (buffer[3] == 0xF6)
                    {
                        pictureBox3.BackColor = Color.Green;
                        Message.OCtoESStruct OTE = new Message.OCtoESStruct();                     
                        OTE = (Message.OCtoESStruct)structANDbyte.BytesToStruct(buffer, typeof(Message.OCtoESStruct));//解码OC发来的消息
                        Message mes = new Message();

                        if (buffer[4] == 0xAA)//控制道岔
                        {
                            Graphics g = panel1.CreateGraphics();
                            g.TranslateTransform(panel1.AutoScrollPosition.X, panel1.AutoScrollPosition.Y);
                            richTextBox3.SelectionStart = richTextBox2.Text.Length;
                            richTextBox3.ScrollToCaret();
                            richTextBox3.AppendText("收： 道岔P" + OTE.Source_ID12.ToString("X2") + OTE.Source_ID34.ToString("X2") + OTE.Source_ID56.ToString("X2"));
                            if (buffer[8] == 0xF0)
                            {
                                richTextBox3.AppendText("  定位" + DateTime.Now.ToLongTimeString() + " " + Environment.NewLine);
                                for (int i = 0; i < counts; i++)
                                {
                                    if (Switch_nameforswitch[i] == "P" + OTE.Source_ID12.ToString("X2") + OTE.Source_ID34.ToString("X2") + OTE.Source_ID56.ToString("X2"))
                                    {
                                        Switch_Status[5 * i] = 0;
                                        Switch_Status[5 * i + 1] = 0;
                                        Switch_Status[5 * i + 2] = 0;
                                        Switch_Status[5 * i + 3] = 0;
                                        Switch_Status[5 * i + 4] = 0;
                                        Switch.DrawSwitch(g);
                                        byte[] send = mes.ETORescmd(0xAA, apart(Form1.Switch_IDSub[5 * i + 1]), 0xF0);
                                        clientSocket.Send(send);
                                        clientSocket.Send(send);
                                        clientSocket.Send(send);
                                        clientSocket.Send(send);
                                        richTextBox3.SelectionStart = richTextBox2.Text.Length;
                                        richTextBox3.ScrollToCaret();
                                        richTextBox3.AppendText("回执：" + BitConverter.ToString(send).Replace("-", " ") + " " + DateTime.Now.ToLongTimeString() + Environment.NewLine);
                                    }
                                }
                            }
                            if (buffer[8] == 0x0F)
                            {
                                richTextBox3.AppendText("  反位" + " " + Environment.NewLine);
                                for (int i = 0; i < counts; i++)
                                {
                                    if (Switch_nameforswitch[i] == "P" + OTE.Source_ID12.ToString("X2") + OTE.Source_ID34.ToString("X2") + OTE.Source_ID56.ToString("X2"))
                                    {
                                        Switch_Status[5 * i] = 1;
                                        Switch_Status[5 * i + 1] = 1;
                                        Switch_Status[5 * i + 2] = 1;
                                        Switch_Status[5 * i + 3] = 1;
                                        Switch_Status[5 * i + 4] = 1;
                                        Switch.DrawSwitch(g);
                                        byte[] send = mes.ETORescmd(0xAA, apart(Form1.Switch_IDSub[5 * i + 1]), 0x0F);
                                        clientSocket.Send(send);
                                        clientSocket.Send(send);
                                        clientSocket.Send(send);
                                        clientSocket.Send(send);
                                        richTextBox3.AppendText("回执：" + BitConverter.ToString(send).Replace("-", " ") + " " +     Environment.NewLine);
                                    }

                                }
                            }
                            if (buffer[8] == 0x02)
                            {
                                richTextBox3.AppendText("  定位锁闭" + " " + Environment.NewLine);
                                for (int i = 0; i < counts; i++)
                                {
                                    if (Switch_nameforswitch[i] == "P" + OTE.Source_ID12.ToString("X2") + OTE.Source_ID34.ToString("X2") + OTE.Source_ID56.ToString("X2"))
                                    {
                                        Switch_Status[5 * i] = 2;
                                        Switch_Status[5 * i + 1] = 2;
                                        Switch_Status[5 * i + 2] = 2;
                                        Switch_Status[5 * i + 3] = 2;
                                        Switch_Status[5 * i + 4] = 2;
                                        Switch.DrawSwitch(g);
                                        byte[] send = mes.ETORescmd(0xAA, apart(Form1.Switch_IDSub[5 * i + 1]), 0x02);
                                        clientSocket.Send(send);
                                        clientSocket.Send(send);
                                        clientSocket.Send(send);
                                        clientSocket.Send(send);
                                        richTextBox3.AppendText("回执：" + BitConverter.ToString(send).Replace("-", " ") + " " +Environment.NewLine);
                                    }

                                }
                            }
                            if (buffer[8] == 0x03)
                            {
                                richTextBox3.AppendText("  反位锁闭" + " " + Environment.NewLine);
                                for (int i = 0; i < counts; i++)
                                {
                                    if (Switch_nameforswitch[i] == "P" + OTE.Source_ID12.ToString("X2") + OTE.Source_ID34.ToString("X2") + OTE.Source_ID56.ToString("X2"))
                                    {
                                        Switch_Status[5 * i] = 3;
                                        Switch_Status[5 * i + 1] = 3;
                                        Switch_Status[5 * i + 2] = 3;
                                        Switch_Status[5 * i + 3] = 3;
                                        Switch_Status[5 * i + 4] = 3;
                                        Switch.DrawSwitch(g);
                                        byte[] send = mes.ETORescmd(0xAA, apart(Form1.Switch_IDSub[5 * i + 1]), 0x03);
                                        clientSocket.Send(send);
                                        clientSocket.Send(send);
                                        clientSocket.Send(send);
                                        clientSocket.Send(send);
                                        richTextBox3.AppendText("回执：" + BitConverter.ToString(send).Replace("-", " ")+ " "+ Environment.NewLine);
                                    }

                                }
                            }
                            
                        }



                        if (buffer[4] == 0x55)//控制屏蔽门
                        {
                            Graphics g = panel1.CreateGraphics();
                            g.TranslateTransform(panel1.AutoScrollPosition.X, panel1.AutoScrollPosition.Y);
                            richTextBox3.SelectionStart = richTextBox2.Text.Length;
                            richTextBox3.ScrollToCaret();
                            richTextBox3.AppendText("收： 屏蔽门PSD" + OTE.Source_ID12.ToString("X2") + OTE.Source_ID34.ToString("X2") + OTE.Source_ID56.ToString("X2"));
                            if (buffer[8] == 0xF0)//关门
                            {
                                richTextBox3.AppendText("  关闭" +  " " + Environment.NewLine);
                                for (int i = 0; i < rowscount8; i++)
                                {
                                    if (PSD_ID[i] == "PSD" + OTE.Source_ID12.ToString("X2") + OTE.Source_ID34.ToString("X2") + OTE.Source_ID56.ToString("X2"))
                                    {
                                        PSD_Status[i] = 0;
                                        PSD.DrawPSD(g);
                                        byte[] send = mes.ETORescmd(0x55, apart(Form1.PSD_IDSub[i]), 0xF0);
                                        clientSocket.Send(send);
                                        clientSocket.Send(send);
                                        clientSocket.Send(send);
                                        clientSocket.Send(send);
                                        richTextBox3.AppendText("回执：" + BitConverter.ToString(send).Replace("-", " ") +Environment.NewLine);
                                    }
                                }
                            }
                            if (buffer[8] == 0x0F)//开门
                            {
                                richTextBox3.AppendText("  开启" + " " + Environment.NewLine);
                                for (int i = 0; i < rowscount8; i++)
                                {
                                    if (PSD_ID[i] == "PSD" + OTE.Source_ID12.ToString("X2") + OTE.Source_ID34.ToString("X2") + OTE.Source_ID56.ToString("X2"))
                                    {
                                        PSD_Status[i] = 1;
                                        PSD.DrawPSD(g);
                                        byte[] send = mes.ETORescmd(0x55, apart(Form1.PSD_IDSub[i]), 0x0F);
                                        clientSocket.Send(send);
                                        clientSocket.Send(send);
                                        clientSocket.Send(send);
                                        clientSocket.Send(send);
                                        richTextBox3.AppendText("回执：" + BitConverter.ToString(send).Replace("-", " ") + " " + Environment.NewLine);
                                    }
                                }
                            }
                        }
                    }

                }
                //中止当前线程
                Thread.CurrentThread.Abort();
            }
            catch (Exception e)
            {
                SocketException socketExp = e as SocketException;
                if (socketExp != null && socketExp.NativeErrorCode == 10054)
                {
                    Console.WriteLine("socket客户端关闭:" + e.ToString());
                }
                else
                {
                    Console.WriteLine("======接受消息异常：" + e.ToString());
                }
                //中止当前线程
                Thread.CurrentThread.Abort();
            }

        }


        public static List<string> GetIpAddress()
        {
            List<string> ipAddresses = new List<string>();
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ipAddress in host.AddressList)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork) // IPv4地址
                {
                    ipAddresses.Add(ipAddress.ToString());
                }
            }
            return ipAddresses;
        }


        public static DataTable excel, excel0, excel1, excel2, excel3, excel4, excel5, excel6, excel7, excel8, excel9, excel10, excel11, excel12;
        public string ATSip;
        public string OCip;
        private bool buttonclick = false;

        internal static void appendtext(object richTetBox1)
        {
            throw new NotImplementedException();
        }

        
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


        public static int tag0 = 0, jsqPSD = 0, jsqResponder = 0, jsqSignal = 0, jsqSwitch = 0, jsqTrack = 0, jsqSwitchtrack = 0, jsqPSDtag = 0, jsqRespondertag = 0, jsqSignaltag = 0, jsqSwitchtag = 0, jsqTracktag = 0, jsqSwitchtracktag = 0;



        public static int i = 0, i1;
        public static int counts = 0;

        public static int rowscount1 = 0, rowscount2 = 0, rowscount3 = 0, rowscount4 = 0, rowscount5 = 0, rowscount6 = 0, rowscount7 = 0, rowscount8 = 0, rowscount9 = 0, rowscount10 = 0, rowscount11 = 0, rowscount12 = 0;



        public static List<int> PSD_Num = new List<int>();                      //PSD相关数据
        public static List<string> PSD_ID = new List<string>();
        public static List<string> PSD_IDSub = new List<string>();
        public static List<string> PSD_StationID = new List<string>();
        public static List<int> PSD_Stationnum = new List<int>();
        public static List<string> PSD_Track = new List<string>();
        public static List<int> PSD_startposx = new List<int>();
        public static List<int> PSD_startposy = new List<int>();
        public static List<int> PSD_endposx = new List<int>();
        public static List<int> PSD_endposy = new List<int>();
        public static List<int> PSD_Mile = new List<int>();
        public static List<int> PSD_Dir = new List<int>();
        public static List<int> PSD_Status = new List<int>();
        public static List<int> PSD_Mouse = new List<int>();
        public List<Rectangle> PSD_shapes = new List<Rectangle>();


        public static List<int> Tag_Num = new List<int>();                      //应答器相关数据
        public static List<string> Tag_ID = new List<string>();
        public static List<string> Tag_IDSub = new List<string>();
        public static List<int> Tag_Type = new List<int>();
        public static List<int> Tag_Check = new List<int>();
        public static List<int> Tag_Status = new List<int>();
        public static List<int> Tag_Edge = new List<int>();
        public static List<int> Tag_Offset = new List<int>();
        public static List<int> Tag_Dir = new List<int>();
        public static List<int> Tag_posx = new List<int>();
        public static List<int> Tag_posy = new List<int>();
        public static List<int> Tag_Mouse = new List<int>();
        public List<Rectangle> Tag_shapes = new List<Rectangle>();


        public static List<int> Signal_Num = new List<int>();                //信号机数据
        public static List<string> Signal_ID = new List<string>();
        public static List<string> Signal_IDSub = new List<string>();
        public static List<int> Signal_Dir = new List<int>();
        public static List<int> Signal_Type = new List<int>();
        public static List<int> Signal_Status = new List<int>();
        public static List<int> Signal_Edge = new List<int>();
        public static List<int> Signal_Offset = new List<int>();
        public static List<int> Signal_Mouse = new List<int>();
        public List<Rectangle> Signal_shapes = new List<Rectangle>();




        public static List<int> Edge_ID = new List<int>();                 //拓扑数据
        public static List<int> Edge_Mile = new List<int>();
        public static List<int> Edge_Dir = new List<int>();
        public static List<int> Edge_startposx = new List<int>();
        public static List<int> Edge_startposy = new List<int>();
        public static List<int> Edge_endposx = new List<int>();
        public static List<int> Edge_endposy = new List<int>();


        public static List<int> Track_startposx1 = new List<int>();                                   //轨道区段数据
        public static List<int> Track_startposy1 = new List<int>();
        public static List<int> Track_endposx1 = new List<int>();
        public static List<int> Track_endposy1 = new List<int>();
        public static List<int> Track_Num = new List<int>();
        public static List<string> Track_ID = new List<string>();
        public static List<string> Track_IDSub = new List<string>();
        public static List<int> Track_Mile = new List<int>();
        public static List<int> Track_Status = new List<int>();


        public static List<int> Track_Startedge = new List<int>();

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;//取消程序间线程调用的检查



        }

        private void abel_AfterInstall(object sender, System.Configuration.Install.InstallEventArgs e)
        {

        }

        private void 信号机设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void 无岔区段设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void 有岔区段设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
        }

        private void 创建服务端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Conn = Start();
            if (Conn == true)
            {
                pictureBox2.BackColor = Color.Green;
                List<string> ipAddresses = new List<string>();
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ipAddress in host.AddressList)
                {
                    if (ipAddress.AddressFamily == AddressFamily.InterNetwork) // IPv4地址
                    {
                        ipAddresses.Add(ipAddress.ToString());
                    }
                }
                MessageBox.Show("当前服务端地址："+ipAddresses[0]);
            }
        }




        private void 创建客户端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
        }

        public static List<int> Track_Startoffset = new List<int>();
        public static List<int> Track_Endedge = new List<int>();

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        public static List<int> rack_Endoffset = new List<int>();
        public static List<int> Track_Mouse = new List<int>();
        public List<Rectangle> Track_shapes = new List<Rectangle>();


        public static List<int> Switch_Num = new List<int>();                                           //道岔数据
        public static List<string> Switch_ID = new List<string>();
        public static List<string> Switch_IDSub = new List<string>();
        public static List<int> Switch_ID2 = new List<int>();
        public static List<int> Switch_Mile = new List<int>();
        public static List<int> Switch_Startedge = new List<int>();
        public static List<int> Switch_Startoffset = new List<int>();
        public static List<int> Switch_Endedge = new List<int>();
        public static List<int> Switch_Endoffset = new List<int>();
        public static List<string> Switch_Trackname = new List<string>();
        public static List<string> Switch_TracknameSub = new List<string>();
        public static List<int> Switch_Status = new List<int>();
        public static List<int> Switch_Trackstatus = new List<int>();
        public static List<int> Switch_Pos = new List<int>();
        public static List<int> Switch_X = new List<int>();
        public static List<int> Switch_Y = new List<int>();
        public static List<int> Switch_Type = new List<int>();
        public static List<int> Switch_Mouse = new List<int>();
        public static List<int> Switch_Trackmouse = new List<int>();
        public static List<int> Switch_shiduanx = new List<int>();
        public static List<int> Switch_shiduany = new List<int>();
        public static List<int> Switch_zhongduanx = new List<int>();
        public static List<int> Switch_zhongduany = new List<int>();
        public List<Rectangle> Switch_shapes = new List<Rectangle>();
        public static List<string> Switch_nameforswitch = new List<string>();
        public static List<string> Switch_namefortrack = new List<string>();


        private void 屏蔽门设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }


        private void 数据修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }



        private void 初始化站场图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!buttonclick)
            {
               
                DataSet Edge = new DataSet();
                Edge = SQLCon.select("select * from 拓扑信息表");
                Form1.excel5 = Edge.Tables[0];
                Form1.excel5.Rows.Add();
                DataSet PSD = new DataSet();
                PSD = SQLCon.select("select * from 屏蔽门信息表");
                Form1.excel8 = PSD.Tables[0];
                Form1.excel8.Rows.Add();
                DataSet Responder = new DataSet();
                Responder = SQLCon.select("select * from 应答器位置表");
                Form1.excel9 = Responder.Tables[0];
                Form1.excel9.Rows.Add();
                DataSet Signal = new DataSet();
                Signal = SQLCon.select("select * from 信号机信息表");
                Form1.excel10 = Signal.Tables[0];
                Form1.excel10.Rows.Add();
                DataSet Switch = new DataSet();
                Switch = SQLCon.select("select * from 道岔信息表");
                Form1.excel7 = Switch.Tables[0];
                Form1.excel7.Rows.Add();
                DataSet Track = new DataSet();
                Track = SQLCon.select("select * from 轨道区段信息表");
                Form1.excel6 = Track.Tables[0];
                Form1.excel6.Rows.Add();
                DataSet Coordinate = new DataSet();
                Coordinate = SQLCon.select("select * from 坐标信息表");
                Form1.excel1 = Coordinate.Tables[0];
                DataSet Stationpos = new DataSet();
                Stationpos = SQLCon.select("select * from 站台侧信息表");
                Form1.excel2 = Stationpos.Tables[0];
                DataSet Speedx = new DataSet();
                Speedx = SQLCon.select("select * from 线路速度表下行正向");
                Form1.excel3 = Speedx.Tables[0];
                DataSet Speeds = new DataSet();
                Speeds = SQLCon.select("select * from 线路速度表上行正向");
                Form1.excel4 = Speeds.Tables[0];
                DataSet Gradientx = new DataSet();
                Gradientx = SQLCon.select("select * from 线路坡度表下行线");
                Form1.excel11 = Gradientx.Tables[0];
                DataSet Gradienty = new DataSet();
                Gradienty = SQLCon.select("select * from 线路坡度表上行线");
                Form1.excel12 = Gradienty.Tables[0];

                for (i = 0; Form1.excel5.Rows[i][0] != DBNull.Value; i++)//i1为有效行数（从0开始）
                {
                    rowscount5++;
                }
                for (i = 0; Form1.excel6.Rows[i][0] != DBNull.Value; i++)//i1为有效行数（从0开始）
                {
                    rowscount6++;
                }
                for (i = 0; Form1.excel7.Rows[i][0] != DBNull.Value; i++)//i1为有效行数（从0开始）
                {
                    rowscount7++;
                }
                for (i = 0; Form1.excel8.Rows[i][0] != DBNull.Value; i++)//i1为有效行数（从0开始）
                {
                    rowscount8++;
                }
                for (i = 0; Form1.excel9.Rows[i][0] != DBNull.Value; i++)//i1为有效行数（从0开始）
                {
                    rowscount9++;
                }
                for (i = 0; Form1.excel10.Rows[i][0] != DBNull.Value; i++)//i1为有效行数（从0开始）
                {
                    rowscount10++;
                }







                for (i = 0; i < rowscount8; i++)                                                    //PSD表格数据存入数组
                {
                    PSD_Num.Add(Convert.ToInt32(Form1.excel8.Rows[i][0].ToString()));
                    PSD_ID.Add(Form1.excel8.Rows[i][1].ToString());
                    PSD_IDSub.Add((Form1.excel8.Rows[i][1].ToString()).Substring(3));
                    PSD_StationID.Add(Form1.excel8.Rows[i][2].ToString());
                    PSD_Stationnum.Add(Convert.ToInt32(Form1.excel8.Rows[i][3].ToString()));
                    PSD_Track.Add(Form1.excel8.Rows[i][4].ToString());
                    PSD_startposx.Add(Convert.ToInt32(Form1.excel8.Rows[i][5].ToString()));
                    PSD_startposy.Add(Convert.ToInt32(Form1.excel8.Rows[i][6].ToString()));
                    PSD_endposx.Add(Convert.ToInt32(Form1.excel8.Rows[i][7].ToString()));
                    PSD_endposy.Add(Convert.ToInt32(Form1.excel8.Rows[i][8].ToString()));
                    PSD_Mile.Add(Convert.ToInt32(Form1.excel8.Rows[i][9].ToString()));
                    PSD_Dir.Add(Convert.ToInt32(Form1.excel8.Rows[i][10].ToString()));
                    PSD_Status.Add(Convert.ToInt32(Form1.excel8.Rows[i][11].ToString()));
                    PSD_Mouse.Add(0);

                    int a = Convert.ToInt32(PSD_ID[i].Substring(8));
                    if (a % 2 == 1)
                    {
                        Rectangle PSDshape = new Rectangle(PSD_startposx[i], PSD_startposy[i] + 130, PSD_endposx[i] - PSD_startposx[i], 20);
                        PSD_shapes.Add(PSDshape);
                    }
                    else
                    {
                        Rectangle PSDshape = new Rectangle(PSD_startposx[i], PSD_startposy[i] - 130, PSD_endposx[i] - PSD_startposx[i], 20);
                        PSD_shapes.Add(PSDshape);
                    }




                }


                for (i = 0; i < rowscount9; i++)                                                                //应答器表格数据存入数组
                {
                    Tag_Num.Add(Convert.ToInt32(Form1.excel9.Rows[i][0].ToString()));
                    Tag_ID.Add(Form1.excel9.Rows[i][1].ToString());
                    Tag_IDSub.Add((Form1.excel9.Rows[i][1].ToString()).Substring(2));
                    Tag_Type.Add(Convert.ToInt32(Form1.excel9.Rows[i][2].ToString()));
                    Tag_Check.Add(Convert.ToInt32(Form1.excel9.Rows[i][3].ToString()));
                    Tag_Status.Add(Convert.ToInt32(Form1.excel9.Rows[i][4].ToString()));
                    Tag_Edge.Add(Convert.ToInt32(Form1.excel9.Rows[i][5].ToString()));
                    Tag_Offset.Add(Convert.ToInt32(Form1.excel9.Rows[i][6].ToString()));
                    Tag_Dir.Add(Convert.ToInt32(Form1.excel9.Rows[i][7].ToString()));
                    Tag_posx.Add(Convert.ToInt32(Form1.excel9.Rows[i][8].ToString()));
                    Tag_posy.Add(Convert.ToInt32(Form1.excel9.Rows[i][9].ToString()));
                    Tag_Mouse.Add(0);
                    Rectangle Tagshape = new Rectangle(Tag_posx[i] - 9, Tag_posy[i] - 7, 18, 14);
                    Tag_shapes.Add(Tagshape);

                }


                for (i = 0; i < rowscount5; i++)                                                                        //拓扑数据存入数组
                {
                    Edge_startposx.Add(Convert.ToInt32(Form1.excel5.Rows[i][10].ToString()));
                    Edge_startposy.Add(Convert.ToInt32(Form1.excel5.Rows[i][11].ToString()));
                    Edge_endposx.Add(Convert.ToInt32(Form1.excel5.Rows[i][12].ToString()));
                    Edge_endposy.Add(Convert.ToInt32(Form1.excel5.Rows[i][13].ToString()));
                    Edge_ID.Add(Convert.ToInt32(Form1.excel5.Rows[i][0].ToString()));
                    Edge_Mile.Add(Convert.ToInt32(Form1.excel5.Rows[i][1].ToString()));
                    Edge_Dir.Add(Convert.ToInt32(Form1.excel5.Rows[i][2].ToString()));

                }

                for (i = 0; i < rowscount10; i++)                                                                   //信号机表格数据存入数组
                {
                    Signal_Num.Add(Convert.ToInt32(Form1.excel10.Rows[i][0].ToString()));
                    Signal_ID.Add(Form1.excel10.Rows[i][1].ToString());
                    Signal_IDSub.Add((Form1.excel10.Rows[i][1].ToString()).Substring(1));
                    Signal_Dir.Add(Convert.ToInt32(Form1.excel10.Rows[i][2].ToString()));
                    Signal_Type.Add(Convert.ToInt32(Form1.excel10.Rows[i][3].ToString()));
                    Signal_Status.Add(Convert.ToInt32(Form1.excel10.Rows[i][4].ToString()));
                    Signal_Edge.Add(Convert.ToInt32(Form1.excel10.Rows[i][5].ToString()));
                    Signal_Offset.Add(Convert.ToInt32(Form1.excel10.Rows[i][6].ToString()));
                    Signal_Mouse.Add(0);
                }
                for (i = 0; i < rowscount10; i++)
                {
                    for (int j = 0; j < rowscount5; j++)
                    {
                        if (Form1.Signal_Edge[i] == Form1.Edge_ID[j])
                        {

                            float offset = (float)Form1.Signal_Offset[i] / Form1.Edge_Mile[j] * Math.Abs(Form1.Edge_endposx[j] - Form1.Edge_startposx[j]) + Form1.Edge_startposx[j];


                            if (Form1.Signal_Dir[i] == 0)//下行
                            {
                                Rectangle Signalshape = new Rectangle((int)offset + 10, Form1.Edge_endposy[j] + 13, 14, 14);
                                Signal_shapes.Add(Signalshape);
                            }
                            else
                            {
                                Rectangle Signalshape = new Rectangle((int)offset - 24, Form1.Edge_endposy[j] - 27, 14, 14);
                                Signal_shapes.Add(Signalshape);
                            }
                        }
                    }
                }


                for (i = 0; i < rowscount6; i++)                                    //轨道区段数据存入数组
                {
                    Track_Num.Add(Convert.ToInt32(Form1.excel6.Rows[i][0].ToString()));
                    Track_ID.Add(Form1.excel6.Rows[i][1].ToString());
                    Track_IDSub.Add((Form1.excel6.Rows[i][1].ToString()).Substring(1));
                    Track_Mile.Add(Convert.ToInt32(Form1.excel6.Rows[i][2].ToString()));
                    Track_Startedge.Add(Convert.ToInt32(Form1.excel6.Rows[i][3].ToString()));
                    Track_Startoffset.Add(Convert.ToInt32(Form1.excel6.Rows[i][4].ToString()));
                    Track_Endedge.Add(Convert.ToInt32(Form1.excel6.Rows[i][5].ToString()));
                    rack_Endoffset.Add(Convert.ToInt32(Form1.excel6.Rows[i][6].ToString()));
                    Track_Status.Add(Convert.ToInt32(Form1.excel6.Rows[i][7].ToString()));
                    Track_startposx1.Add(Convert.ToInt32(Form1.excel6.Rows[i][8].ToString()));
                    Track_startposy1.Add(Convert.ToInt32(Form1.excel6.Rows[i][9].ToString()));
                    Track_endposx1.Add(Convert.ToInt32(Form1.excel6.Rows[i][10].ToString()));
                    Track_endposy1.Add(Convert.ToInt32(Form1.excel6.Rows[i][11].ToString()));
                    Track_Mouse.Add(0);
                    Rectangle Trackshape = new Rectangle(Track_startposx1[i], Track_startposy1[i] - 4, Track_endposx1[i] - Track_startposx1[i], 8);
                    Track_shapes.Add(Trackshape);

                }

                for (i = 0; i < rowscount7; i++)                                                    //道岔数据存入数组
                {
                    Switch_Num.Add(Convert.ToInt32(Form1.excel7.Rows[i][0].ToString()));
                    Switch_ID.Add(Form1.excel7.Rows[i][1].ToString());
                    Switch_IDSub.Add((Form1.excel7.Rows[i][1].ToString()).Substring(1));
                    Switch_ID2.Add(Convert.ToInt32(Form1.excel7.Rows[i][2].ToString()));
                    Switch_Mile.Add(Convert.ToInt32(Form1.excel7.Rows[i][3].ToString()));
                    Switch_Startedge.Add(Convert.ToInt32(Form1.excel7.Rows[i][4].ToString()));
                    Switch_Startoffset.Add(Convert.ToInt32(Form1.excel7.Rows[i][5].ToString()));
                    Switch_Endedge.Add(Convert.ToInt32(Form1.excel7.Rows[i][6].ToString()));
                    Switch_Endoffset.Add(Convert.ToInt32(Form1.excel7.Rows[i][7].ToString()));
                    Switch_Trackname.Add(Form1.excel7.Rows[i][8].ToString());
                    Switch_TracknameSub.Add((Form1.excel7.Rows[i][8].ToString()).Substring(2));
                    Switch_Status.Add(Convert.ToInt32(Form1.excel7.Rows[i][9].ToString()));
                    Switch_Trackstatus.Add(Convert.ToInt32(Form1.excel7.Rows[i][10].ToString()));
                    Switch_Pos.Add(Convert.ToInt32(Form1.excel7.Rows[i][11].ToString()));
                    Switch_X.Add(Convert.ToInt32(Form1.excel7.Rows[i][12].ToString()));
                    Switch_Y.Add(Convert.ToInt32(Form1.excel7.Rows[i][13].ToString()));
                    Switch_Type.Add(Convert.ToInt32(Form1.excel7.Rows[i][14].ToString()));
                    Switch_Mouse.Add(0);



                    for (int j = 0; j < rowscount5; j++)
                    {
                        if (Switch_Startedge[i] == Edge_ID[j])
                        {

                            int shiduanx = (int)((float)Switch_Startoffset[i] / Edge_Mile[j] * Math.Abs(Edge_endposx[j] - Edge_startposx[j]) + Edge_startposx[j]);
                            int zhongduanx = (int)((float)Switch_Endoffset[i] / Edge_Mile[j] * Math.Abs(Edge_endposx[j] - Edge_startposx[j]) + Edge_startposx[j]);
                            int shiduanyp = (int)((float)Edge_startposy[j] - (float)Switch_Startoffset[i] / Edge_Mile[j] * Math.Abs(Edge_endposy[j] - Edge_startposy[j]));
                            int shiduanyn = (int)((float)Switch_Startoffset[i] / Edge_Mile[j] * Math.Abs(Edge_endposy[j] - Edge_startposy[j]) + Edge_startposy[j]);
                            int zhongduanyp = (int)((float)Edge_startposy[j] - (float)Switch_Endoffset[i] / Edge_Mile[j] * Math.Abs(Edge_endposy[j] - Edge_startposy[j]));
                            int zhongduanyn = (int)((float)Switch_Endoffset[i] / Edge_Mile[j] * Math.Abs(Edge_endposy[j] - Edge_startposy[j]) + Edge_startposy[j]);

                            if (Edge_Dir[j] == 0)
                            {
                                if (Switch_ID2[i] == 1)
                                {

                                    Switch_shiduanx.Add(shiduanx);
                                    Switch_shiduany.Add(Edge_startposy[j]);
                                    Switch_zhongduanx.Add(zhongduanx);
                                    Switch_zhongduany.Add(Edge_endposy[j]);

                                }
                                else if (Switch_ID2[i] == 2)
                                {
                                    if (Switch_Type[i] == 0 || Switch_Type[i] == 2)
                                    {
                                        Switch_shiduanx.Add(shiduanx);
                                        Switch_shiduany.Add(Edge_startposy[j]);
                                        Switch_zhongduanx.Add(shiduanx + Switch_Mile[i]);
                                        Switch_zhongduany.Add(Edge_endposy[j]);

                                    }
                                    else
                                    {
                                        Switch_shiduanx.Add(zhongduanx - Switch_Mile[i]);
                                        Switch_shiduany.Add(Edge_startposy[j]);
                                        Switch_zhongduanx.Add(zhongduanx);
                                        Switch_zhongduany.Add(Edge_endposy[j]);

                                    }
                                }

                                else if (Switch_ID2[i] == 3)
                                {
                                    if (i - 1 >= 0)
                                    {
                                        if (Switch_Type[i] == 0 || Switch_Type[i] == 2)
                                        {

                                            Switch_shiduanx.Add(Edge_startposx[j] + Switch_Mile[i - 1]);
                                            Switch_shiduany.Add(Edge_startposy[j]);
                                            Switch_zhongduanx.Add(zhongduanx);
                                            Switch_zhongduany.Add(Edge_endposy[j]);

                                        }
                                        else
                                        {
                                            Switch_shiduanx.Add(shiduanx);
                                            Switch_shiduany.Add(Edge_startposy[j]);
                                            Switch_zhongduanx.Add(Edge_endposx[j] - Switch_Mile[i - 1]);
                                            Switch_zhongduany.Add(Edge_endposy[j]);

                                        }
                                    }
                                }

                            }


                            if (Edge_Dir[j] == 1)//"/"型
                            {

                                Switch_shiduanx.Add(shiduanx);
                                Switch_shiduany.Add(shiduanyp);
                                Switch_zhongduanx.Add(zhongduanx);
                                Switch_zhongduany.Add(zhongduanyp);


                            }

                            if (Edge_Dir[j] == 2)//"\"型
                            {
                                Switch_shiduanx.Add(shiduanx);
                                Switch_shiduany.Add(shiduanyn);
                                Switch_zhongduanx.Add(zhongduanx);
                                Switch_zhongduany.Add(zhongduanyn);

                            }




                        }
                    }







                }



                for (i = 0; i < rowscount7; i++)
                {
                    if (Switch_ID2[i] == 1)
                        counts++;
                }

                for (i = 0; i < counts; i++)                                                    //道岔数据作为矩形存入数组
                {

                    if (Switch_Type[1 + 5 * i] == 0 || Switch_Type[1 + 5 * i] == 3)
                    {
                        Rectangle Switchshape = new Rectangle(Switch_shiduanx[1 + 5 * i], Switch_zhongduany[3 + 5 * i], Math.Abs(Switch_shiduanx[1 + 5 * i] - Switch_zhongduanx[1 + 5 * i]), Math.Abs(Switch_shiduany[3 + 5 * i] - Switch_zhongduany[3 + 5 * i]));
                        Switch_shapes.Add(Switchshape);
                        Switch_nameforswitch.Add(Switch_ID[5 * i]);
                        Switch_namefortrack.Add(Switch_Trackname[5 * i]);
                    }
                    if (Switch_Type[1 + 5 * i] == 1 || Switch_Type[1 + 5 * i] == 2)
                    {
                        Rectangle Switchshape = new Rectangle(Switch_shiduanx[1 + 5 * i], Switch_shiduany[3 + 5 * i], Math.Abs(Switch_shiduanx[1 + 5 * i] - Switch_zhongduanx[1 + 5 * i]), Math.Abs(Switch_shiduany[3 + 5 * i] - Switch_zhongduany[3 + 5 * i]));
                        Switch_shapes.Add(Switchshape);
                        Switch_nameforswitch.Add(Switch_ID[5 * i]);
                        Switch_namefortrack.Add(Switch_Trackname[5 * i]);
                    }

                }
                panel1.AutoScroll = true;
                panel1.AutoScrollMinSize = new Size(3100, 400);
                tag0 = 1;
                panel1.Invalidate();
                buttonclick = true;
            }
            else
            { }
        }
        
        public Form1()
        {
            InitializeComponent();
            label2.Text = DateTime.Now.ToLongTimeString();


        }





            private void panel1_Paint(object sender, PaintEventArgs e)
            {
                Graphics g = panel1.CreateGraphics();
                g.TranslateTransform(panel1.AutoScrollPosition.X, panel1.AutoScrollPosition.Y);
                if (tag0 == 1)
                {

                    Track.DrawTrack(g);
                    Switch.DrawSwitch(g);
                    PSD.DrawPSD(g);
                    Signal.DrawSignal(g);
                    Responder.DrawTag(g);




                }




            }





            private void panel1_MouseUp(object sender, MouseEventArgs e)
            {

            }



            private void panel1_MouseClick(object sender, MouseEventArgs e)
            {
            if (Form8.OCIP != null && Form8.OCPort != 0)
            {
                for (i = 0; i < PSD_shapes.Count; i++)
                {
                    if (PSD_Mouse[i] == 1)
                    {
                        jsqPSD = 1;
                        jsqPSDtag = i;
                        Form2 f2 = new Form2(this);
                        f2.Show();

                    }
                }


                for (i = 0; i < Tag_shapes.Count; i++)
                {
                    if (Tag_Mouse[i] == 1)
                    {
                        jsqResponder = 1;
                        jsqRespondertag = i;
                        Form2 f2 = new Form2(this);
                        f2.Show();

                    }
                }
                for (i = 0; i < Signal_shapes.Count; i++)
                {
                    if (Signal_Mouse[i] == 1)
                    {
                        jsqSignal = 1;
                        jsqSignaltag = i;
                        Form2 f2 = new Form2(this);
                        f2.Show();

                    }
                }
                for (i = 0; i < Track_shapes.Count; i++)
                {
                    if (Track_Mouse[i] == 1)
                    {
                        jsqTrack = 1;
                        jsqTracktag = i;
                        Form2 f2 = new Form2(this);
                        f2.Show();

                    }
                }
                for (i = 0; i < counts; i++)
                {
                    if (Switch_Mouse[5 * i] == 1 || Switch_Mouse[5 * i + 2] == 1 || Switch_Mouse[5 * i + 4] == 1)
                    {
                        jsqSwitchtrack = 1;
                        jsqSwitchtracktag = i;
                        Form2 f2 = new Form2(this);
                        f2.Show();

                    }
                }
                for (i = 0; i < counts; i++)
                {
                    if (Switch_Mouse[5 * i + 1] == 1 || Switch_Mouse[5 * i + 3] == 1)
                    {
                        jsqSwitch = 1;
                        jsqSwitchtag = i;
                        Form2 f2 = new Form2(this);
                        f2.Show();

                    }
                }
            }
            else
            {
                MessageBox.Show("请先完成通信设置");
            }
            }
    }

    
} 
 