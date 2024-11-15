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
    class Switch
    {
        public static void DrawSwitch(Graphics g)
        {
            int i,j;
            int i1 = Form1.rowscount7;
            int i2 = Form1.rowscount5;
            int i3 = Form1.counts;
            Pen p = new Pen(Color.White, 3);
            Pen p1 = new Pen(Color.White, 1);
            Pen p2 = new Pen(Color.Green, 3);
            Pen p3 = new Pen(Color.Red, 3);
            Pen p4 = new Pen(Color.Blue, 3);
            Pen p5 = new Pen(Color.White, 1);
            Pen p6 = new Pen(Color.Gray, 3);
            Pen p7 = new Pen(Color.Red, 1);
            Pen p8 = new Pen(Color.Gray, 1);
            Pen p9 = new Pen(Color.GreenYellow, 3);
            Pen p10 = new Pen(Color.Black, 3);
            Pen p11 = new Pen(Color.Green, 2);
            Pen p12 = new Pen(Color.Black, 3);
            Pen p13 = new Pen(Color.Blue, 2);
            Brush b = new SolidBrush(Color.Red);
            Brush b1 = new SolidBrush(Color.Black);
            Font font = new Font("TimesNewRoman", 7);
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center; // 更正： 垂直居中
            format.Alignment = StringAlignment.Center; // 水平居中


            for (i = 0; i < i1; i++)                        //画短线
            {

                if (Form1.Switch_ID2[i] == 1)
                {
                    for (j = 0; j < i2; j++)
                    {
                        if (Form1.Switch_Startedge[i] == Form1.Edge_ID[j]&& Form1.Edge_Dir[j] == 0)
                        {
                            if (Form1.Switch_Type[i] == 0 || Form1.Switch_Type[i] == 2)
                            {
                                g.DrawLine(p1, Form1.Switch_shiduanx[i], Form1.Switch_shiduany[i] - 4, Form1.Switch_shiduanx[i], Form1.Switch_shiduany[i] + 4);
                            }
                            else
                            {
                                g.DrawLine(p1, Form1.Switch_zhongduanx[i], Form1.Switch_zhongduany[i] - 4, Form1.Switch_zhongduanx[i], Form1.Switch_zhongduany[i] + 4);
                            }
                        }
                    }

                }
                else if (Form1.Switch_ID2[i] == 3)
                {
                    if (Form1.Switch_Type[i] == 0 || Form1.Switch_Type[i] == 2)
                    {
                        g.DrawLine(p1, Form1.Switch_zhongduanx[i], Form1.Switch_zhongduany[i] - 4, Form1.Switch_zhongduanx[i], Form1.Switch_zhongduany[i] + 4);

                    }
                    else
                    {
                        g.DrawLine(p1, Form1.Switch_shiduanx[i], Form1.Switch_shiduany[i] - 4, Form1.Switch_shiduanx[i], Form1.Switch_shiduany[i] + 4);
                    }
                }

                else if (Form1.Switch_ID2[i] == 5)
                {
                    if (Form1.Switch_Type[i] == 0 )
                    {
                        g.DrawLine(p1, Form1.Switch_zhongduanx[i]-3, Form1.Switch_zhongduany[i] -3, Form1.Switch_zhongduanx[i]+3, Form1.Switch_zhongduany[i] +3);
                    }
                    else if(Form1.Switch_Type[i] == 1)
                    {
                        g.DrawLine(p1, Form1.Switch_shiduanx[i]-3, Form1.Switch_shiduany[i] +3, Form1.Switch_shiduanx[i]+3, Form1.Switch_shiduany[i] -3);
                    }
                    else if (Form1.Switch_Type[i] == 2)
                    {
                        g.DrawLine(p1, Form1.Switch_zhongduanx[i] - 3, Form1.Switch_zhongduany[i] + 3, Form1.Switch_zhongduanx[i] + 3, Form1.Switch_zhongduany[i] - 3);
                    }
                    else if (Form1.Switch_Type[i] == 3)
                    {
                        g.DrawLine(p1, Form1.Switch_shiduanx[i] - 3, Form1.Switch_shiduany[i] - 3, Form1.Switch_shiduanx[i] + 3, Form1.Switch_shiduany[i] + 3);
                    }
                }
            }

            /*for (i = 0; i < i1; i++)                                                     //画有岔区段
            {
                if (Form1.Switch_ID2[i] == 1 || Form1.Switch_ID2[i] == 3 || Form1.Switch_ID2[i] == 5)
                {
                    if (Form1.Switch_Mouse[i] == 0)
                    {
                        if (Form1.Switch_Trackstatus[i] == 0)
                            g.DrawLine(p, Form1.Switch_shiduanx[i], Form1.Switch_shiduany[i], Form1.Switch_zhongduanx[i], Form1.Switch_zhongduany[i]);
                        else if (Form1.Switch_Trackstatus[i] == 1)
                            g.DrawLine(p3, Form1.Switch_shiduanx[i], Form1.Switch_shiduany[i], Form1.Switch_zhongduanx[i], Form1.Switch_zhongduany[i]);
                        else if (Form1.Switch_Trackstatus[i] == 2)
                        {
                            g.DrawLine(p3, Form1.Switch_shiduanx[i], Form1.Switch_shiduany[i], Form1.Switch_zhongduanx[i], Form1.Switch_zhongduany[i]);
                        }
                        else if (Form1.Switch_Trackstatus[i] == 3)
                            g.DrawLine(p6, Form1.Switch_shiduanx[i], Form1.Switch_shiduany[i], Form1.Switch_zhongduanx[i], Form1.Switch_zhongduany[i]);

                    }
                    else if (Form1.Switch_Mouse[i] == 1)
                    {
                        g.DrawLine(p4, Form1.Switch_shiduanx[i], Form1.Switch_shiduany[i], Form1.Switch_zhongduanx[i], Form1.Switch_zhongduany[i]);
                        if (Form1.Switch_Trackstatus[i] == 0)
                            g.DrawLine(p5, Form1.Switch_shiduanx[i], Form1.Switch_shiduany[i], Form1.Switch_zhongduanx[i], Form1.Switch_zhongduany[i]);
                        else if (Form1.Switch_Trackstatus[i] == 1)
                            g.DrawLine(p7, Form1.Switch_shiduanx[i], Form1.Switch_shiduany[i], Form1.Switch_zhongduanx[i], Form1.Switch_zhongduany[i]);
                        else if (Form1.Switch_Trackstatus[i] == 2)
                        {
                            g.DrawLine(p7, Form1.Switch_shiduanx[i], Form1.Switch_shiduany[i], Form1.Switch_zhongduanx[i], Form1.Switch_zhongduany[i]);
                        }
                        else if (Form1.Switch_Trackstatus[i] == 3)
                            g.DrawLine(p8, Form1.Switch_shiduanx[i], Form1.Switch_shiduany[i], Form1.Switch_zhongduanx[i], Form1.Switch_zhongduany[i]);

                    }

                }

            }*/
            for (i = 0; i < i3; i++)                            //画有岔区段
            {
                if (Form1.Switch_ID2[5 * i] == 1)
                {
                    if (Form1.Switch_Mouse[5 * i] == 0 && Form1.Switch_Mouse[5 * i + 2] == 0 && Form1.Switch_Mouse[5 * i + 4] == 0)
                    {
                        if (Form1.Switch_Trackstatus[5 * i] == 0)
                        {
                            g.DrawLine(p, Form1.Switch_shiduanx[5 * i], Form1.Switch_shiduany[5 * i], Form1.Switch_zhongduanx[5 * i], Form1.Switch_zhongduany[5 * i]);
                            g.DrawLine(p, Form1.Switch_shiduanx[5 * i + 2], Form1.Switch_shiduany[5 * i + 2], Form1.Switch_zhongduanx[5 * i + 2], Form1.Switch_zhongduany[5 * i + 2]);
                            g.DrawLine(p, Form1.Switch_shiduanx[5 * i + 4], Form1.Switch_shiduany[5 * i + 4], Form1.Switch_zhongduanx[5 * i + 4], Form1.Switch_zhongduany[5 * i + 4]);
                            g.FillRectangle(b1, (int)(0.5 * (Form1.Switch_zhongduanx[5 * i + 2] + Form1.Switch_shiduanx[5 * i + 2])) - 15, Form1.Switch_zhongduany[5 * i + 2] + 8, 30, 8);
                        }
                        if (Form1.Switch_Trackstatus[5 * i] == 1)
                        {
                            g.DrawLine(p3, Form1.Switch_shiduanx[5 * i], Form1.Switch_shiduany[5 * i], Form1.Switch_zhongduanx[5 * i], Form1.Switch_zhongduany[5 * i]);
                            g.DrawLine(p3, Form1.Switch_shiduanx[5 * i + 2], Form1.Switch_shiduany[5 * i + 2], Form1.Switch_zhongduanx[5 * i + 2], Form1.Switch_zhongduany[5 * i + 2]);
                            g.DrawLine(p3, Form1.Switch_shiduanx[5 * i + 4], Form1.Switch_shiduany[5 * i + 4], Form1.Switch_zhongduanx[5 * i + 4], Form1.Switch_zhongduany[5 * i + 4]);
                            g.FillRectangle(b1, (int)(0.5 * (Form1.Switch_zhongduanx[5 * i + 2] + Form1.Switch_shiduanx[5 * i + 2])) - 15, Form1.Switch_zhongduany[5 * i + 2] + 8, 30, 8);
                        }
                        if (Form1.Switch_Trackstatus[5 * i] == 2)
                        {
                            g.DrawLine(p3, Form1.Switch_shiduanx[5 * i], Form1.Switch_shiduany[5 * i], Form1.Switch_zhongduanx[5 * i], Form1.Switch_zhongduany[5 * i]);
                            g.DrawLine(p3, Form1.Switch_shiduanx[5 * i + 2], Form1.Switch_shiduany[5 * i + 2], Form1.Switch_zhongduanx[5 * i + 2], Form1.Switch_zhongduany[5 * i + 2]);
                            g.DrawLine(p3, Form1.Switch_shiduanx[5 * i + 4], Form1.Switch_shiduany[5 * i + 4], Form1.Switch_zhongduanx[5 * i + 4], Form1.Switch_zhongduany[5 * i + 4]);
                            g.DrawString("ERR", font, b, new Rectangle((int)(0.5 * (Form1.Switch_zhongduanx[5 * i+2] + Form1.Switch_shiduanx[5 * i+2])) - 15, Form1.Switch_zhongduany[5 * i + 2] + 8, 30, 8), format);
                        }
                        if (Form1.Switch_Trackstatus[5 * i] == 3)
                        {
                            g.DrawLine(p6, Form1.Switch_shiduanx[5 * i], Form1.Switch_shiduany[5 * i], Form1.Switch_zhongduanx[5 * i], Form1.Switch_zhongduany[5 * i]);
                            g.DrawLine(p6, Form1.Switch_shiduanx[5 * i + 2], Form1.Switch_shiduany[5 * i + 2], Form1.Switch_zhongduanx[5 * i + 2], Form1.Switch_zhongduany[5 * i + 2]);
                            g.DrawLine(p6, Form1.Switch_shiduanx[5 * i + 4], Form1.Switch_shiduany[5 * i + 4], Form1.Switch_zhongduanx[5 * i + 4], Form1.Switch_zhongduany[5 * i + 4]);
                            g.FillRectangle(b1, (int)(0.5 * (Form1.Switch_zhongduanx[5 * i + 2] + Form1.Switch_shiduanx[5 * i + 2])) - 15, Form1.Switch_zhongduany[5 * i + 2] + 8, 30, 8);
                        }
                    }
                    else
                    {
                        g.DrawLine(p4, Form1.Switch_shiduanx[5 * i], Form1.Switch_shiduany[5 * i], Form1.Switch_zhongduanx[5 * i], Form1.Switch_zhongduany[5 * i]);
                        g.DrawLine(p4, Form1.Switch_shiduanx[5 * i + 2], Form1.Switch_shiduany[5 * i + 2], Form1.Switch_zhongduanx[5 * i + 2], Form1.Switch_zhongduany[5 * i + 2]);
                        g.DrawLine(p4, Form1.Switch_shiduanx[5 * i + 4], Form1.Switch_shiduany[5 * i + 4], Form1.Switch_zhongduanx[5 * i + 4], Form1.Switch_zhongduany[5 * i + 4]);
                        if (Form1.Switch_Trackstatus[5 * i] == 0)
                        {
                            g.DrawLine(p5, Form1.Switch_shiduanx[5 * i], Form1.Switch_shiduany[5 * i], Form1.Switch_zhongduanx[5 * i], Form1.Switch_zhongduany[5 * i]);
                            g.DrawLine(p5, Form1.Switch_shiduanx[5 * i + 2], Form1.Switch_shiduany[5 * i + 2], Form1.Switch_zhongduanx[5 * i + 2], Form1.Switch_zhongduany[5 * i + 2]);
                            g.DrawLine(p5, Form1.Switch_shiduanx[5 * i + 4], Form1.Switch_shiduany[5 * i + 4], Form1.Switch_zhongduanx[5 * i + 4], Form1.Switch_zhongduany[5 * i + 4]);
                            g.FillRectangle(b1, (int)(0.5 * (Form1.Switch_zhongduanx[5 * i + 2] + Form1.Switch_shiduanx[5 * i + 2])) - 15, Form1.Switch_zhongduany[5 * i + 2] + 8, 30, 8);
                        }
                        if (Form1.Switch_Trackstatus[5 * i] == 1)
                        {
                            g.DrawLine(p7, Form1.Switch_shiduanx[5 * i], Form1.Switch_shiduany[5 * i], Form1.Switch_zhongduanx[5 * i], Form1.Switch_zhongduany[5 * i]);
                            g.DrawLine(p7, Form1.Switch_shiduanx[5 * i + 2], Form1.Switch_shiduany[5 * i + 2], Form1.Switch_zhongduanx[5 * i + 2], Form1.Switch_zhongduany[5 * i + 2]);
                            g.DrawLine(p7, Form1.Switch_shiduanx[5 * i + 4], Form1.Switch_shiduany[5 * i + 4], Form1.Switch_zhongduanx[5 * i + 4], Form1.Switch_zhongduany[5 * i + 4]);
                            g.FillRectangle(b1, (int)(0.5 * (Form1.Switch_zhongduanx[5 * i + 2] + Form1.Switch_shiduanx[5 * i + 2])) - 15, Form1.Switch_zhongduany[5 * i + 2] + 8, 30, 8);
                        }
                        if (Form1.Switch_Trackstatus[5 * i] == 2)
                        {
                            g.DrawLine(p7, Form1.Switch_shiduanx[5 * i], Form1.Switch_shiduany[5 * i], Form1.Switch_zhongduanx[5 * i], Form1.Switch_zhongduany[5 * i]);
                            g.DrawLine(p7, Form1.Switch_shiduanx[5 * i + 2], Form1.Switch_shiduany[5 * i + 2], Form1.Switch_zhongduanx[5 * i + 2], Form1.Switch_zhongduany[5 * i + 2]);
                            g.DrawLine(p7, Form1.Switch_shiduanx[5 * i + 4], Form1.Switch_shiduany[5 * i + 4], Form1.Switch_zhongduanx[5 * i + 4], Form1.Switch_zhongduany[5 * i + 4]);
                            g.DrawString("ERR", font, b, new Rectangle((int)(0.5 * (Form1.Switch_zhongduanx[5 * i + 2] + Form1.Switch_shiduanx[5 * i + 2])) - 15, Form1.Switch_zhongduany[5 * i + 2] + 8, 30, 8), format);
                        }
                        if (Form1.Switch_Trackstatus[5 * i] == 3)
                        {
                            g.DrawLine(p8, Form1.Switch_shiduanx[5 * i], Form1.Switch_shiduany[5 * i], Form1.Switch_zhongduanx[5 * i], Form1.Switch_zhongduany[5 * i]);
                            g.DrawLine(p8, Form1.Switch_shiduanx[5 * i + 2], Form1.Switch_shiduany[5 * i + 2], Form1.Switch_zhongduanx[5 * i + 2], Form1.Switch_zhongduany[5 * i + 2]);
                            g.DrawLine(p8, Form1.Switch_shiduanx[5 * i + 4], Form1.Switch_shiduany[5 * i + 4], Form1.Switch_zhongduanx[5 * i + 4], Form1.Switch_zhongduany[5 * i + 4]);
                            g.FillRectangle(b1, (int)(0.5 * (Form1.Switch_zhongduanx[5 * i + 2] + Form1.Switch_shiduanx[5 * i + 2])) - 15, Form1.Switch_zhongduany[5 * i + 2] + 8, 30, 8);
                        }

                    }

                }


            }






            for (i = 0; i < i3; i++)                                                      //画道岔
            {

                if (Form1.Switch_Mouse[1 + 5 * i] == 0 || Form1.Switch_Mouse[3 + 5 * i] == 0) 
                {
                    g.DrawLine(p10, Form1.Switch_shiduanx[1 + 5 * i], Form1.Switch_shiduany[1 + 5 * i], Form1.Switch_zhongduanx[1 + 5 * i], Form1.Switch_zhongduany[1 + 5 * i]);
                    g.DrawLine(p10, Form1.Switch_shiduanx[3 + 5 * i], Form1.Switch_shiduany[3 + 5 * i], Form1.Switch_zhongduanx[3 + 5 * i], Form1.Switch_zhongduany[3 + 5 * i]);
                    if (Form1.Switch_Status[1 + 5 * i] == 0)
                    {
                        g.DrawLine(p2, Form1.Switch_shiduanx[1 + 5 * i], Form1.Switch_shiduany[1 + 5 * i], Form1.Switch_zhongduanx[1 + 5 * i], Form1.Switch_zhongduany[1 + 5 * i]);
                    }
                    else if (Form1.Switch_Status[1 + 5 * i] == 1)
                    {
                        g.DrawLine(p2, Form1.Switch_shiduanx[3 + 5 * i], Form1.Switch_shiduany[3 + 5 * i], Form1.Switch_zhongduanx[3 + 5 * i], Form1.Switch_zhongduany[3 + 5 * i]);
                    }
                    if (Form1.Switch_Status[1 + 5 * i] == 2)
                    {
                        g.DrawLine(p9, Form1.Switch_shiduanx[1 + 5 * i], Form1.Switch_shiduany[1 + 5 * i], Form1.Switch_zhongduanx[1 + 5 * i], Form1.Switch_zhongduany[1 + 5 * i]);
                    }
                    else if (Form1.Switch_Status[1 + 5 * i] == 3)
                    {
                        g.DrawLine(p9, Form1.Switch_shiduanx[3 + 5 * i], Form1.Switch_shiduany[3 + 5 * i], Form1.Switch_zhongduanx[3 + 5 * i], Form1.Switch_zhongduany[3 + 5 * i]);
                    }
                    if (Form1.Switch_Status[1 + 5 * i] == 4)
                    {
                        g.DrawLine(p3, Form1.Switch_shiduanx[1 + 5 * i], Form1.Switch_shiduany[1 + 5 * i], Form1.Switch_zhongduanx[1 + 5 * i], Form1.Switch_zhongduany[1 + 5 * i]);
                        g.DrawLine(p3, Form1.Switch_shiduanx[3 + 5 * i], Form1.Switch_shiduany[3 + 5 * i], Form1.Switch_zhongduanx[3 + 5 * i], Form1.Switch_zhongduany[3 + 5 * i]);
                    }
                    else if (Form1.Switch_Status[1 + 5 * i] == 5)
                    {
                        g.DrawLine(p12, Form1.Switch_shiduanx[1 + 5 * i], Form1.Switch_shiduany[1 + 5 * i], Form1.Switch_zhongduanx[1 + 5 * i], Form1.Switch_zhongduany[1 + 5 * i]);
                        g.DrawLine(p12, Form1.Switch_shiduanx[3 + 5 * i], Form1.Switch_shiduany[3 + 5 * i], Form1.Switch_zhongduanx[3 + 5 * i], Form1.Switch_zhongduany[3 + 5 * i]);
                    }
                    else if (Form1.Switch_Status[1 + 5 * i] == 6)
                    {
                        g.DrawLine(p6, Form1.Switch_shiduanx[1 + 5 * i], Form1.Switch_shiduany[1 + 5 * i], Form1.Switch_zhongduanx[1 + 5 * i], Form1.Switch_zhongduany[1 + 5 * i]);
                        g.DrawLine(p6, Form1.Switch_shiduanx[3 + 5 * i], Form1.Switch_shiduany[3 + 5 * i], Form1.Switch_zhongduanx[3 + 5 * i], Form1.Switch_zhongduany[3 + 5 * i]);
                    }

                }
                else if (Form1.Switch_Mouse[1 + 5 * i] == 1 || Form1.Switch_Mouse[3 + 5 * i] == 1)
                {  
                    g.DrawLine(p13, Form1.Switch_shiduanx[1 + 5 * i], Form1.Switch_shiduany[1 + 5 * i], Form1.Switch_zhongduanx[1 + 5 * i], Form1.Switch_zhongduany[1 + 5 * i]);
                    g.DrawLine(p13, Form1.Switch_shiduanx[3 + 5 * i], Form1.Switch_shiduany[3 + 5 * i], Form1.Switch_zhongduanx[3 + 5 * i], Form1.Switch_zhongduany[3 + 5 * i]);                   
                }

                



            }



        }
    }
}
