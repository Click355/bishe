using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;
using System.IO;


using System.ComponentModel;

using System.Drawing;

using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace EnvironmentSimulator1
{
    class Track
    {
        public static void DrawTrack(Graphics g)
        {
            int i;
            int i1 = Form1.rowscount6;
            int i2 = Form1.rowscount5;
            Pen p = new Pen(Color.White, 3);
            Pen p1 = new Pen(Color.White, 1);
            Pen p2 = new Pen(Color.Blue, 1);
            Pen p3 = new Pen(Color.Red, 3);
            Pen p4 = new Pen(Color.Red, 1);
            Pen p5 = new Pen(Color.Gray, 3);
            Pen p6 = new Pen(Color.Gray, 1);
            Brush b = new SolidBrush(Color.Red);
            Brush b1 = new SolidBrush(Color.Black);
            Font font = new Font("TimesNewRoman", 7);
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center; // 更正： 垂直居中
            format.Alignment = StringAlignment.Center; // 水平居中









            for (i = 0; i < i1; i++)//表格数据存入数组
            {

                if (Form1.Track_Mouse[i] == 0)
                {
                    g.FillRectangle(b1, (int)(0.5 * (Form1.Track_endposx1[i] + Form1.Track_startposx1[i])) - 20, Form1.Track_endposy1[i] + 8, 40, 8);
                    g.DrawLine(p1, Form1.Track_startposx1[i], Form1.Track_startposy1[i] - 4, Form1.Track_startposx1[i], Form1.Track_startposy1[i] + 4);
                    g.DrawLine(p1, Form1.Track_endposx1[i], Form1.Track_endposy1[i] - 4, Form1.Track_endposx1[i], Form1.Track_endposy1[i] + 4);
                    if (Form1.Track_Status[i] == 0)
                    {
                        g.DrawLine(p, Form1.Track_startposx1[i], Form1.Track_startposy1[i], Form1.Track_endposx1[i], Form1.Track_endposy1[i]);
                        
                        
                    }
                    else if (Form1.Track_Status[i] == 1)
                    {
                        g.DrawLine(p3, Form1.Track_startposx1[i], Form1.Track_startposy1[i], Form1.Track_endposx1[i], Form1.Track_endposy1[i]);
                       
                        
                    }
                    else if (Form1.Track_Status[i] == 2)
                    {
                        g.DrawLine(p3, Form1.Track_startposx1[i], Form1.Track_startposy1[i], Form1.Track_endposx1[i], Form1.Track_endposy1[i]);
                        g.DrawString("ERR", font, b, new Rectangle((int)(0.5 * (Form1.Track_endposx1[i] + Form1.Track_startposx1[i])) - 20, Form1.Track_endposy1[i] + 8, 40, 8), format);
                    }
                    else if (Form1.Track_Status[i] == 3)
                    {
                        g.DrawLine(p5, Form1.Track_startposx1[i], Form1.Track_startposy1[i], Form1.Track_endposx1[i], Form1.Track_endposy1[i]);
                        
                    }

                }
                else if (Form1.Track_Mouse[i] == 1)
                {
                    g.DrawLine(p2, Form1.Track_startposx1[i], Form1.Track_startposy1[i] - 4, Form1.Track_startposx1[i], Form1.Track_startposy1[i] + 4);
                    g.DrawLine(p2, Form1.Track_endposx1[i], Form1.Track_endposy1[i] - 4, Form1.Track_endposx1[i], Form1.Track_endposy1[i] + 4);
                    g.DrawLine(p2, Form1.Track_startposx1[i] + 1, Form1.Track_startposy1[i] - 1, Form1.Track_endposx1[i] - 1, Form1.Track_startposy1[i] - 1);
                    g.DrawLine(p2, Form1.Track_startposx1[i], Form1.Track_startposy1[i] + 1, Form1.Track_endposx1[i] - 1, Form1.Track_startposy1[i] + 1);
                }
            }


        }
    }
}
