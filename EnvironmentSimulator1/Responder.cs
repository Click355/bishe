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
    class Responder
    {
        public static void DrawTag(Graphics g)
        {
            int i;
            int i1 = Form1.rowscount9;
            int i2 = Form1.rowscount5;
            Pen p = new Pen(Color.Red, 1);
            Pen p1 = new Pen(Color.White, 1);
            Pen p2 = new Pen(Color.Blue, 1);
            Pen p3 = new Pen(Color.Black, 1);
            Brush b = new SolidBrush(Color.White);
            Font font = new Font("宋体", 12);
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center; // 更正： 垂直居中
            format.Alignment = StringAlignment.Center; // 水平居中

            
            


            for (i = 0; i < i1; i++)//表格数据存入数组
            {
                if (Form1.Tag_Mouse[i] == 0)
                {
                    g.DrawRectangle(p3, Form1.Tag_posx[i] - 9, Form1.Tag_posy[i] - 7, 18, 14);
                    if (Form1.Tag_Status[i] == 0)
                    {
                        g.DrawLine(p1, Form1.Tag_posx[i] - 8, Form1.Tag_posy[i] - 6, Form1.Tag_posx[i] + 8, Form1.Tag_posy[i] + 6);
                        g.DrawLine(p1, Form1.Tag_posx[i] + 8, Form1.Tag_posy[i] - 6, Form1.Tag_posx[i] - 8, Form1.Tag_posy[i] + 6);
                        g.DrawRectangle(p1, Form1.Tag_posx[i] - 8, Form1.Tag_posy[i] - 6, 16, 12);
                        
                    }
                    else if (Form1.Tag_Status[i] == 1)
                    {
                        g.DrawLine(p, Form1.Tag_posx[i] - 8, Form1.Tag_posy[i] - 6, Form1.Tag_posx[i] + 8, Form1.Tag_posy[i] + 6);
                        g.DrawLine(p, Form1.Tag_posx[i] + 8, Form1.Tag_posy[i] - 6, Form1.Tag_posx[i] - 8, Form1.Tag_posy[i] + 6);
                        g.DrawRectangle(p, Form1.Tag_posx[i] - 8, Form1.Tag_posy[i] - 6, 16, 12);
                    }

                }
                else if (Form1.Tag_Mouse[i] == 1)
                    g.DrawRectangle(p2, Form1.Tag_posx[i] - 9, Form1.Tag_posy[i] - 7, 18, 14);
            }










        }



    }
}
