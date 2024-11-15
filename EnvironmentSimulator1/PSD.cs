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
    class PSD
    {


        public static void DrawPSD(Graphics g)
        {
            int i;
            int i1 = Form1.rowscount8;
            int i2 = Form1.rowscount5;
            string tag;
            Pen p = new Pen(Color.Yellow, 1);
            Pen p1 = new Pen(Color.White, 1);
            Pen p2 = new Pen(Color.Blue, 1);
            Brush b = new SolidBrush(Color.White);
            Brush b1 = new SolidBrush(Color.Yellow);
            Font font = new Font("宋体", 12);
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center; // 更正： 垂直居中
            format.Alignment = StringAlignment.Center; // 水平居中



            for (i = 0; i < i1; i++)//表格数据存入数组
            {

                if (Convert.ToInt32(Form1.PSD_ID[i].Substring(8)) % 2 == 0)

                {
                    if (Form1.PSD_Mouse[i] == 0)
                    {
                        if (Form1.PSD_Status[i] == 0)
                        {
                            g.FillRectangle(b, Form1.PSD_startposx[i], Form1.PSD_startposy[i] - 130, Form1.PSD_endposx[i] - Form1.PSD_startposx[i], 20);
                            g.DrawRectangle(p1, Form1.PSD_startposx[i], Form1.PSD_startposy[i] - 130, Form1.PSD_endposx[i] - Form1.PSD_startposx[i], 20);
                        }
                        else if (Form1.PSD_Status[i] == 1)
                        {
                            g.FillRectangle(b1, Form1.PSD_startposx[i], Form1.PSD_startposy[i] - 130, Form1.PSD_endposx[i] - Form1.PSD_startposx[i], 20);
                            g.DrawRectangle(p, Form1.PSD_startposx[i], Form1.PSD_startposy[i] - 130, Form1.PSD_endposx[i] - Form1.PSD_startposx[i], 20);
                        }
                    }
                    else if (Form1.PSD_Mouse[i] == 1)
                    {
                        g.DrawRectangle(p2, Form1.PSD_startposx[i], Form1.PSD_startposy[i] - 130, Form1.PSD_endposx[i] - Form1.PSD_startposx[i], 20);
                    }

                }
                else
                {
                    if (Form1.PSD_Mouse[i] == 0)
                    {
                        if (Form1.PSD_Status[i] == 0)
                        {
                            g.FillRectangle(b, Form1.PSD_startposx[i], Form1.PSD_startposy[i] + 130, Form1.PSD_endposx[i] - Form1.PSD_startposx[i], 20);
                            g.DrawRectangle(p1, Form1.PSD_startposx[i], Form1.PSD_startposy[i] + 130, Form1.PSD_endposx[i] - Form1.PSD_startposx[i], 20);
                            g.DrawString(Form1.PSD_StationID[i], font, b, new Rectangle(Form1.PSD_startposx[i] - 60, 50, 170, 50), format);
                        }
                        else if (Form1.PSD_Status[i] == 1)
                        {
                            g.FillRectangle(b1, Form1.PSD_startposx[i], Form1.PSD_startposy[i] + 130, Form1.PSD_endposx[i] - Form1.PSD_startposx[i], 20);
                            g.DrawRectangle(p, Form1.PSD_startposx[i], Form1.PSD_startposy[i] + 130, Form1.PSD_endposx[i] - Form1.PSD_startposx[i], 20);
                        }

                    }
                    else if (Form1.PSD_Mouse[i] == 1)
                    {
                        g.DrawRectangle(p2, Form1.PSD_startposx[i], Form1.PSD_startposy[i] + 130, Form1.PSD_endposx[i] - Form1.PSD_startposx[i], 20);
                        g.DrawString(Form1.PSD_StationID[i], font, b, new Rectangle(Form1.PSD_startposx[i] - 60, 50, 170, 50), format);


                    }

                }









            }


        }
    }
}
