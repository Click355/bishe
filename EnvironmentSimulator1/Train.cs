using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace EnvironmentSimulator1
{
    class Train
    {
        public static int[] Xcor = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
        public static int[] Ycor = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
        public static int Num = 0;
        public static void DrawTrain(Graphics g)
        {


            int i;
            int i1 = 20;
            int i2 = 0;
            string tag;
            Pen p = new Pen(Color.White, 3);
            Pen p1 = new Pen(Color.White, 1);
            Brush b = new SolidBrush(Color.Yellow);
            Brush c = new SolidBrush(Color.Black);
            Brush d = new SolidBrush(Color.Black);
            Font font = new Font("宋体", 10);
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center; // 更正： 垂直居中
            format.Alignment = StringAlignment.Center; // 水平居中

            if (Form1.TrainState.Rows.Count == 0)
            {

            }
            else
            {
                int[] startposx1 = new int[i1];
                int[] startposy1 = new int[i1];
                int[] endposx1 = new int[i1];
                int[] endposy1 = new int[i1];
                int[] Track_Num = new int[i1];
                string[] Track_ID = new string[i1];


                for (i1 = 0; i1 < Form1.TrainState.Rows.Count; i1++)
                {

                    if (Form1.tag0 == 1)
                    {
                        startposx1[i1] = Convert.ToInt32(Form1.TrainState.Rows[i1][4]);
                        startposy1[i1] = Convert.ToInt32(Form1.TrainState.Rows[i1][6]);
                        endposx1[i1] = Convert.ToInt32(Form1.TrainState.Rows[i1][5]);
                        endposy1[i1] = Convert.ToInt32(Form1.TrainState.Rows[i1][6]);

                        if (380 > startposx1[i1] / 4)
                        {
                            startposx1[i1] = startposx1[i1] / 4;
                            g.FillRectangle(b, startposx1[i1], startposy1[i1] - 20, 50, 20);
                            if (Xcor[i1] != startposx1[i1] || Ycor[i1] != startposy1[i1])
                            {
                                g.FillRectangle(c, Xcor[i1], startposy1[i1] - 20, startposx1[i1] - Xcor[i1], 20);
                                g.FillRectangle(c, Xcor[i1], Ycor[i1] - 20, 50 + startposx1[i1] - Xcor[i1], startposy1[i1] - Ycor[i1]);
                                g.DrawString(Form1.TrainState.Rows[i1][0].ToString(), font, d, startposx1[i1], startposy1[i1] - 15);
                            }

                        }
                        else if (380 <= startposx1[i1] / 4 && startposx1[i1] / 4 <= 410)
                        {
                            startposx1[i1] = 350 + startposx1[i1] - 1400;
                            startposy1[i1] = startposy1[i1] + Num;
                            Num = Num + 3;
                            if (Num > 100)
                            {
                                Num = 100;
                            }
                            g.FillRectangle(b, startposx1[i1], startposy1[i1] - 20, 50, 20);
                            if (Xcor[i1] != startposx1[i1] || Ycor[i1] != startposy1[i1])
                            {
                                g.FillRectangle(c, Xcor[i1], startposy1[i1] - 20, startposx1[i1] - Xcor[i1], 20);
                                g.FillRectangle(c, Xcor[i1], Ycor[i1] - 20, 50 + startposx1[i1] - Xcor[i1], startposy1[i1] - Ycor[i1]);
                                g.DrawString(Form1.TrainState.Rows[i1][0].ToString(), font, d, startposx1[i1], startposy1[i1] - 15);
                            }
                        }
                        else if (410 < startposx1[i1] / 4 && startposx1[i1] / 4 <= 1175)
                        {
                            startposx1[i1] = startposx1[i1] / 4 + 150;
                            g.FillRectangle(b, startposx1[i1], startposy1[i1] - 20, 50, 20);
                            if (Xcor[i1] != startposx1[i1] || Ycor[i1] != startposy1[i1])
                            {
                                g.FillRectangle(c, Xcor[i1], startposy1[i1] - 20, startposx1[i1] - Xcor[i1], 20);
                                g.FillRectangle(c, Xcor[i1], Ycor[i1] - 20, 50 + startposx1[i1] - Xcor[i1], startposy1[i1] - Ycor[i1]);
                                g.DrawString(Form1.TrainState.Rows[i1][0].ToString(), font, d, startposx1[i1], startposy1[i1] - 15);
                            }
                        }
                        else if (startposx1[i1] / 4 > 1175 && startposx1[i1] <= 1275)
                        {
                            if (Convert.ToInt32(Form1.TrainState.Rows[i1][0]) == SocketHelper.dir)
                            {
                                Num = 0;
                                startposx1[i1] = startposx1[i1] / 4 - 1175;
                                startposy1[i1] = startposy1[i1] - Num;
                                Num = Num + 3;
                                if (Num > 100)
                                {
                                    Num = 100;
                                }
                                g.FillRectangle(b, startposx1[i1], startposy1[i1] - 20, 50, 20);
                                if (Xcor[i1] != startposx1[i1] || Ycor[i1] != startposy1[i1])
                                {
                                    g.FillRectangle(c, Xcor[i1], startposy1[i1] - 20, startposx1[i1] - Xcor[i1], 20);
                                    g.FillRectangle(c, Xcor[i1], Ycor[i1] - (Ycor[i1] - startposy1[i1]), 50 + startposx1[i1] - Xcor[i1], Ycor[i1] - startposy1[i1]);
                                    g.DrawString(Form1.TrainState.Rows[i1][0].ToString(), font, d, startposx1[i1], startposy1[i1] - 15);
                                }
                            }
                            else
                            {
                                startposx1[i1] = startposx1[i1] / 4 + 150;
                                g.FillRectangle(b, startposx1[i1], startposy1[i1] - 20, 50, 20);
                                if (Xcor[i1] != startposx1[i1] || Ycor[i1] != startposy1[i1])
                                {
                                    g.FillRectangle(c, Xcor[i1], startposy1[i1] - 20, startposx1[i1] - Xcor[i1], 20);
                                    g.FillRectangle(c, Xcor[i1], Ycor[i1] - 20, 50 + startposx1[i1] - Xcor[i1], startposy1[i1] - Ycor[i1]);
                                    g.DrawString(Form1.TrainState.Rows[i1][0].ToString(), font, d, startposx1[i1], startposy1[i1] - 15);
                                }
                            }
                        }
                        else if (startposx1[i1] > 1275)
                        {
                            startposx1[i1] = startposx1[i1] / 4 + 300;
                            g.FillRectangle(b, startposx1[i1], startposy1[i1] - 20, 50, 20);
                            if (Xcor[i1] != startposx1[i1] || Ycor[i1] != startposy1[i1])
                            {
                                g.FillRectangle(c, Xcor[i1], startposy1[i1] - 20, startposx1[i1] - Xcor[i1], 20);
                                g.FillRectangle(c, Xcor[i1], Ycor[i1] - 20, 50 + startposx1[i1] - Xcor[i1], startposy1[i1] - Ycor[i1]);
                                g.DrawString(Form1.TrainState.Rows[i1][0].ToString(), font, d, startposx1[i1], startposy1[i1] - 15);
                            }
                        }


                        Xcor[i1] = startposx1[i1];
                        Ycor[i1] = startposy1[i1];
                    }
                }
            }
         } 
    }
}*/
