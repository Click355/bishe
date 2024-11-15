using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvironmentSimulator1
{
    public partial class Form6 : Form
    {
        private static int[] Num = new int[Form1.rowscount6 + Form1.counts];
        private static string[] ID = new string[Form1.rowscount6 + Form1.counts];
        private static string[] Mile1 = new string[Form1.rowscount6 + Form1.counts];
        private static string[] Mile2 = new string[Form1.rowscount6 + Form1.counts];
        private static string search;
        public Form6()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Signal_Num", "轨道区段编号");
            dataGridView1.Columns.Add("Signal_ID", "轨道区段名称");
            dataGridView1.Columns.Add("Signal_Dir", "道岔定位区段长度（单位：m）");
            dataGridView1.Columns.Add("Signal_Type", "道岔反位区段长度（单位：m）");
            dataGridView1.Columns.Add("Signal_Status", "轨道区段状态");
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 120;

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;


            

            for (int i = 0; i < Form1.rowscount6 + Form1.counts; i++)
            {
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                cell.Items.Add("空闲");
                cell.Items.Add("正常占用");
                cell.Items.Add("故障占用");
                cell.Items.Add("封锁");
                Num[i] = i + 1;

                if (i < Form1.rowscount6)
                {
                    if (Form1.Track_Status[i] == 0)
                        cell.Value = "空闲";
                    if (Form1.Track_Status[i] == 1)
                        cell.Value = "正常占用";
                    if (Form1.Track_Status[i] == 2)
                        cell.Value = "故障占用";
                    if (Form1.Track_Status[i] == 3)
                        cell.Value = "封锁";
                    ID[i] = Form1.Track_ID[i];
                    Mile1[i] = Form1.Track_Mile[i].ToString();
                    Mile2[i] = "无";
                    dataGridView1.Rows.Add(Num[i], ID[i], Mile1[i], Mile2[i]);
                    dataGridView1.Rows[i].Cells[4] = cell;
                }
                else 
                {
                    if (Form1.Switch_Trackstatus[5 * (i - Form1.rowscount6)] == 0)
                        cell.Value = "空闲";
                    if (Form1.Switch_Trackstatus[5 * (i - Form1.rowscount6)] == 1)
                        cell.Value = "正常占用";
                    if (Form1.Switch_Trackstatus[5 * (i - Form1.rowscount6)] == 2)
                        cell.Value = "故障占用";
                    if (Form1.Switch_Trackstatus[5 * (i - Form1.rowscount6)] == 3)
                        cell.Value = "封锁";
                    ID[i] = Form1.Switch_namefortrack[i- Form1.rowscount6];
                    Mile1[i] = (Form1.Switch_Mile[5 * (i - Form1.rowscount6)] + Form1.Switch_Mile[1 + 5 * (i - Form1.rowscount6)] + Form1.Switch_Mile[2 + 5 * (i - Form1.rowscount6)]).ToString();
                    Mile2[i] = (Form1.Switch_Mile[5 * (i - Form1.rowscount6)] + Form1.Switch_Mile[3 + 5 * (i - Form1.rowscount6)] + Form1.Switch_Mile[4 + 5 * (i - Form1.rowscount6)]).ToString();
                    dataGridView1.Rows.Add(Num[i], ID[i], Mile1[i], Mile2[i]);
                    dataGridView1.Rows[i].Cells[4] = cell;
                }


            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                for (int i = 0; i < Form1.rowscount6 + Form1.counts; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        search = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        if (search != null && search.Contains(searchText))
                        {
                            dataGridView1.Rows[i].Visible = true;
                            break;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Visible = false;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < Form1.rowscount6 + Form1.counts; i++)
            {
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                cell.Items.Add("空闲");
                cell.Items.Add("正常占用");
                cell.Items.Add("故障占用");
                cell.Items.Add("封锁");
                Num[i] = i + 1;

                if (i < Form1.rowscount6)
                {
                    if (Form1.Track_Status[i] == 0)
                        cell.Value = "空闲";
                    if (Form1.Track_Status[i] == 1)
                        cell.Value = "正常占用";
                    if (Form1.Track_Status[i] == 2)
                        cell.Value = "故障占用";
                    if (Form1.Track_Status[i] == 3)
                        cell.Value = "封锁";
                    ID[i] = Form1.Track_ID[i];
                    Mile1[i] = Form1.Track_Mile[i].ToString();
                    Mile2[i] = "无";
                    dataGridView1.Rows.Add(Num[i], ID[i], Mile1[i], Mile2[i]);
                    dataGridView1.Rows[i].Cells[4] = cell;
                }
                else
                {
                    if (Form1.Switch_Trackstatus[5 * (i - Form1.rowscount6)] == 0)
                        cell.Value = "空闲";
                    if (Form1.Switch_Trackstatus[5 * (i - Form1.rowscount6)] == 1)
                        cell.Value = "正常占用";
                    if (Form1.Switch_Trackstatus[5 * (i - Form1.rowscount6)] == 2)
                        cell.Value = "故障占用";
                    if (Form1.Switch_Trackstatus[5 * (i - Form1.rowscount6)] == 3)
                        cell.Value = "封锁";
                    ID[i] = Form1.Switch_namefortrack[i - Form1.rowscount6];
                    Mile1[i] = (Form1.Switch_Mile[5 * (i - Form1.rowscount6)] + Form1.Switch_Mile[1 + 5 * (i - Form1.rowscount6)] + Form1.Switch_Mile[2 + 5 * (i - Form1.rowscount6)]).ToString();
                    Mile2[i] = (Form1.Switch_Mile[5 * (i - Form1.rowscount6)] + Form1.Switch_Mile[3 + 5 * (i - Form1.rowscount6)] + Form1.Switch_Mile[4 + 5 * (i - Form1.rowscount6)]).ToString();
                    dataGridView1.Rows.Add(Num[i], ID[i], Mile1[i], Mile2[i]);
                    dataGridView1.Rows[i].Cells[4] = cell;
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1.rowscount6 + Form1.counts; i++)
            {
                if (i < Form1.rowscount6)
                {
                    if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "空闲")
                    {
                        Form1.Track_Status[i] = 0;
                    }
                    if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "正常占用")
                    {
                        Form1.Track_Status[i] = 1;
                    }
                    if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "故障占用")
                    {
                        Form1.Track_Status[i] = 2;
                    }
                    if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "封锁")
                    {
                        Form1.Track_Status[i] = 3;
                    }
                }
                else
                {
                    if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "空闲")
                    {
                        Form1.Switch_Trackstatus[5 * (i - Form1.rowscount6)] = 0;
                        Form1.Switch_Trackstatus[2 + 5 * (i - Form1.rowscount6)] = 0;
                        Form1.Switch_Trackstatus[4 + 5 * (i - Form1.rowscount6)] = 0;
                    }
                    if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "正常占用")
                    {
                        Form1.Switch_Trackstatus[5 * (i - Form1.rowscount6)] = 1;
                        Form1.Switch_Trackstatus[2 + 5 * (i - Form1.rowscount6)] = 1;
                        Form1.Switch_Trackstatus[4 + 5 * (i - Form1.rowscount6)] = 1;
                    }
                    if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "故障占用")
                    {
                        Form1.Switch_Trackstatus[5 * (i - Form1.rowscount6)] = 2;
                        Form1.Switch_Trackstatus[2 + 5 * (i - Form1.rowscount6)] = 2;
                        Form1.Switch_Trackstatus[4 + 5 * (i - Form1.rowscount6)] = 2;
                    }
                    if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "封锁")
                    {
                        Form1.Switch_Trackstatus[5 * (i - Form1.rowscount6)] = 3;
                        Form1.Switch_Trackstatus[2 + 5 * (i - Form1.rowscount6)] = 3;
                        Form1.Switch_Trackstatus[4 + 5 * (i - Form1.rowscount6)] = 3;
                    }

                }
            }
            this.Close();
        }
    }
}
