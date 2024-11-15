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
    class Signal
    {
        public static void DrawSignal(Graphics g)
        {
            int i,j;
            float offset;
            int i1 = Form1.rowscount10;
            int i2 = Form1.rowscount5;
            string tag;
            Pen p = new Pen(Color.White, 3);
            Pen p1 = new Pen(Color.White, 1);
            Pen p2 = new Pen(Color.Blue, 1);
            Pen p3 = new Pen(Color.Black, 1);
            Brush b = new SolidBrush(Color.LightGray);
            Brush b1 = new SolidBrush(Color.Gray);
            Brush b2 = new SolidBrush(Color.Black);
            Brush b3 = new SolidBrush(Color.Red);
            Brush b4 = new SolidBrush(Color.Yellow);
            Brush b5 = new SolidBrush(Color.Green);
            Font font = new Font("宋体", 9);
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center; // 更正： 垂直居中
            format.Alignment = StringAlignment.Center; // 水平居中





            for (i = 0; i < i1; i++)
            {
                for (j = 0; j < i2; j++)
                {
                    if (Form1.Signal_Edge[i] == Form1.Edge_ID[j])
                    {

                        offset = (float)Form1.Signal_Offset[i] / Form1.Edge_Mile[j] * Math.Abs(Form1.Edge_endposx[j] - Form1.Edge_startposx[j]) + Form1.Edge_startposx[j];


                        if (Form1.Signal_Dir[i] == 0)//下行
                        {
                            if (Form1.Signal_Mouse[i] == 0)
                            {
                                g.DrawLine(p1, offset, Form1.Edge_endposy[j] + 18, offset, Form1.Edge_endposy[j] + 28);
                                g.DrawLine(p1, offset, Form1.Edge_endposy[j] + 23, offset + 10, Form1.Edge_endposy[j] + 23);
                                g.DrawEllipse(p3, offset + 10, Form1.Edge_endposy[j] + 16, 14, 14);
                                
                                if (Form1.Signal_Status[i] == 0)
                                {
                                    g.FillEllipse(b, offset + 10, Form1.Edge_endposy[j] + 16, 14, 14);
                                    g.FillRectangle(b2,(int)offset, Form1.Edge_endposy[j] + 30, 30, 12);   
                                }
                                if (Form1.Signal_Status[i] == 1)
                                {
                                    g.FillEllipse(b1, offset + 10, Form1.Edge_endposy[j] + 16, 14, 14);
                                    g.DrawString("DSBJ", font, b, new Rectangle((int)offset, Form1.Edge_endposy[j] + 30, 30, 12), format);
                                }
                                if (Form1.Signal_Status[i] == 2)
                                {
                                    g.FillEllipse(b1, offset + 10, Form1.Edge_endposy[j] + 16, 14, 14);
                                    g.DrawString("RSBJ", font, b, new Rectangle((int)offset , Form1.Edge_endposy[j] + 30, 30, 12), format);
                                }
                                if (Form1.Signal_Status[i] == 3)
                                {
                                    g.FillRectangle(b2, (int)offset, Form1.Edge_endposy[j] + 30, 30, 12);
                                    g.FillEllipse(b1, offset + 10, Form1.Edge_endposy[j] + 16, 14, 14);
                                    g.DrawLine(p3, offset + 10, Form1.Edge_endposy[j] + 16, offset + 24, Form1.Edge_endposy[j] + 30);
                                    g.DrawLine(p3, offset + 10, Form1.Edge_endposy[j] + 30, offset + 24, Form1.Edge_endposy[j] + 16);
                                }
                                if (Form1.Signal_Status[i] == 4)
                                {
                                    g.FillEllipse(b3, offset + 10, Form1.Edge_endposy[j] + 16, 14, 14);
                                    g.FillRectangle(b2, (int)offset, Form1.Edge_endposy[j] + 30, 30, 12);
                                }
                                if (Form1.Signal_Status[i] == 5)
                                {
                                    g.FillEllipse(b4, offset + 10, Form1.Edge_endposy[j] + 16, 14, 14);
                                    g.FillRectangle(b2, (int)offset, Form1.Edge_endposy[j] + 30, 30, 12);
                                }
                                if (Form1.Signal_Status[i] == 6)
                                {
                                    g.FillEllipse(b5, offset + 10, Form1.Edge_endposy[j] + 16, 14, 14);
                                    g.FillRectangle(b2, (int)offset, Form1.Edge_endposy[j] + 30, 30, 12);
                                }
                            }
                            else if (Form1.Signal_Mouse[i] == 1)
                            {
                                g.DrawEllipse(p2, offset + 10, Form1.Edge_endposy[j] + 16, 14, 14);
                            }



                        }
                        else
                        {
                            if (Form1.Signal_Mouse[i] == 0)
                            {
                                g.DrawLine(p1, offset, Form1.Edge_endposy[j] - 18, offset, Form1.Edge_endposy[j] - 28);
                                g.DrawLine(p1, offset, Form1.Edge_endposy[j] - 23, offset - 10, Form1.Edge_endposy[j] - 23);
                                g.DrawEllipse(p3, offset - 24, Form1.Edge_endposy[j] - 30, 14, 14);
                                if (Form1.Signal_Status[i] == 0)
                                {
                                    g.FillRectangle(b2, (int)offset - 34, Form1.Edge_endposy[j] - 41, 30, 12);
                                    g.FillEllipse(b, offset - 24, Form1.Edge_endposy[j] - 30, 14, 14);
                                }
                                if (Form1.Signal_Status[i] == 1)
                                {
                                    g.FillEllipse(b1, offset - 24, Form1.Edge_endposy[j] - 30, 14, 14);
                                    g.DrawString("DSBJ", font, b, new Rectangle((int)offset - 34, Form1.Edge_endposy[j] - 41, 30, 12), format);
                                }
                                if (Form1.Signal_Status[i] == 2)
                                {
                                    g.FillEllipse(b1, offset - 24, Form1.Edge_endposy[j] - 30, 14, 14);
                                    g.DrawString("RSBJ", font, b, new Rectangle((int)offset - 34, Form1.Edge_endposy[j] - 41, 30, 12), format);
                                }
                                if (Form1.Signal_Status[i] == 3)
                                {
                                    g.FillRectangle(b2, (int)offset - 34, Form1.Edge_endposy[j] - 41, 30, 12);
                                    g.FillEllipse(b1, offset - 24, Form1.Edge_endposy[j] - 30, 14, 14);
                                    g.DrawLine(p3, offset - 24, Form1.Edge_endposy[j] - 30, offset - 10, Form1.Edge_endposy[j] - 16);
                                    g.DrawLine(p3, offset - 24, Form1.Edge_endposy[j] - 16, offset - 10, Form1.Edge_endposy[j] - 30);
                                }
                                if (Form1.Signal_Status[i] == 4)
                                {
                                    g.FillRectangle(b2, (int)offset - 34, Form1.Edge_endposy[j] - 41, 30, 12);
                                    g.FillEllipse(b3, offset - 24, Form1.Edge_endposy[j] - 30, 14, 14);
                                }
                                if (Form1.Signal_Status[i] == 5)
                                {
                                    g.FillRectangle(b2, (int)offset - 34, Form1.Edge_endposy[j] - 41, 30, 12);
                                    g.FillEllipse(b4, offset - 24, Form1.Edge_endposy[j] - 30, 14, 14);
                                }
                                if (Form1.Signal_Status[i] == 6)
                                {
                                    g.FillRectangle(b2, (int)offset - 34, Form1.Edge_endposy[j] - 41, 30, 12);
                                    g.FillEllipse(b5, offset - 24, Form1.Edge_endposy[j] - 30, 14, 14);
                                }

                            }
                            else if (Form1.Signal_Mouse[i] == 1)
                            {
                                g.DrawEllipse(p2, offset - 24, Form1.Edge_endposy[j] - 30, 14, 14);
                            }

                        }




































                    }
                    
                
                }
            
            
            }










        }


















    }
}
