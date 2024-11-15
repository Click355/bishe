using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvironmentSimulator1
{
    class SocketHelper
    {

        private int SocketServerPort = 123;
        //处理连接请求的线程
        private Thread acceptConnectReqThd;

        Dictionary<int, Socket> ClintDataDictionary = new Dictionary<int, Socket>();
        Dictionary<string, Socket> ClintIPDictionary1 = new Dictionary<string, Socket>();

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
                socketWatch.Listen(20);  //设定最大的挂起长度
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
            byte[] buffer = new byte[1024 * 1024];  //数据缓冲区。
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

                    Message.VOBCtoESStruct VTE = new Message.VOBCtoESStruct();//定义列车状态信息解析报文结构                      
                    VTE = (Message.VOBCtoESStruct)structANDbyte.BytesToStruct(buffer, typeof(Message.VOBCtoESStruct));//解码列车发来的消息
                    MessageBox.Show($"{VTE.Train_Y}");
                    Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();


                    //form1.AppendText2(("收：" + VTE.Train_ID.ToString() + " " + VTE.Train_Dir.ToString() + "  " + VTE.Train_X.ToString()) + " / r/n");
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
        public void Sendbyte(int TrainNumber, string IP, byte[] buffer)

        {
            //获得发送客户端IP
            //ClintDataDictionary[IP].
            //ClintDataDictionary[TrainNumber].Send(buffer);
            //ClintIPDictionary1[IP].Send(buffer);
            Socket socketsend = ClintDataDictionary[TrainNumber];
            socketsend.Send(buffer);

        }
    }
}
