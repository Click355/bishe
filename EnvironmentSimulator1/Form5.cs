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
    public partial class Form5 : Form
    {
        private static string ID;
        private static string[] Type = new string[Form1.rowscount10];
        private static string[] Dir = new string[Form1.rowscount10];

       private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < Form1.rowscount10; i++)
            {
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                cell.Items.Add("灭灯");
                cell.Items.Add("灯丝断丝");
                cell.Items.Add("灯丝熔丝");
                cell.Items.Add("封锁");
                cell.Items.Add("红灯");
                cell.Items.Add("黄灯");
                cell.Items.Add("绿灯");
                if (Form1.Signal_Status[i] == 0)
                    cell.Value = "灭灯";
                if (Form1.Signal_Status[i] == 1)
                    cell.Value = "灯丝断丝";
                if (Form1.Signal_Status[i] == 2)
                    cell.Value = "灯丝熔丝";
                if (Form1.Signal_Status[i] == 3)
                    cell.Value = "封锁";
                if (Form1.Signal_Status[i] == 4)
                    cell.Value = "红灯";
                if (Form1.Signal_Status[i] == 5)
                    cell.Value = "黄灯";
                if (Form1.Signal_Status[i] == 6)
                    cell.Value = "绿灯";

                dataGridView1.Rows.Add(Form1.Signal_Num[i], Form1.Signal_ID[i],Dir[i],Type[i]);
                dataGridView1.Rows[i].Cells[4] = cell;

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1.rowscount10; i++)
            {
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "灭灯")
                {
                    Form1.Signal_Status[i] = 0;
                }
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "灯丝断丝")
                {
                    Form1.Signal_Status[i] = 1;
                }
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "灯丝熔丝")
                {
                    Form1.Signal_Status[i] = 2;
                }
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "封锁")
                {
                    Form1.Signal_Status[i] = 3;
                }
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "红灯")
                {
                    Form1.Signal_Status[i] = 4;
                }
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "黄灯")
                {
                    Form1.Signal_Status[i] = 5;
                }
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "绿灯")
                {
                    Form1.Signal_Status[i] = 6;
                }
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                for (int i = 0; i < Form1.rowscount10; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        ID = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        if (ID != null && ID.Contains(searchText))
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

        public Form5()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Signal_Num", "信号机编号");
            dataGridView1.Columns.Add("Signal_ID", "信号机名称");
            dataGridView1.Columns.Add("Signal_Dir", "信号机方向");
            dataGridView1.Columns.Add("Signal_Type", "信号机类型");
            dataGridView1.Columns.Add("Signal_Status", "信号机状态");
            dataGridView1.Columns[4].Width = 150;


            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;

            for (int i = 0; i < Form1.rowscount10; i++)
            {
                if (Form1.Signal_Dir[i] == 0)
                    Dir[i] = "下行";
                else if(Form1.Signal_Dir[i] == 1)
                    Dir[i] = "上行";

            }

            for (int i = 0; i < Form1.rowscount10; i++)
            {
                if (Form1.Signal_Type[i] == 0)
                    Type[i] = "普通信号机";
                if (Form1.Signal_Type[i] == 1)
                    Type[i] = "自动信号机";
                if (Form1.Signal_Type[i] == 2)
                    Type[i] = "连续通过信号机";
            }

            for (int i = 0; i < Form1.rowscount10; i++)
            {
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                cell.Items.Add("灭灯");
                cell.Items.Add("灯丝断丝");
                cell.Items.Add("灯丝熔丝");
                cell.Items.Add("封锁");
                cell.Items.Add("红灯");
                cell.Items.Add("黄灯");
                cell.Items.Add("绿灯");
                if (Form1.Signal_Status[i] == 0)
                    cell.Value = "灭灯";
                if (Form1.Signal_Status[i] == 1)
                    cell.Value = "灯丝断丝";
                if (Form1.Signal_Status[i] == 2)
                    cell.Value = "灯丝熔丝";
                if (Form1.Signal_Status[i] == 3)
                    cell.Value = "封锁";
                if (Form1.Signal_Status[i] == 4)
                    cell.Value = "红灯";
                if (Form1.Signal_Status[i] == 5)
                    cell.Value = "黄灯";
                if (Form1.Signal_Status[i] == 6)
                    cell.Value = "绿灯";

                dataGridView1.Rows.Add(Form1.Signal_Num[i], Form1.Signal_ID[i], Dir[i], Type[i]);
                dataGridView1.Rows[i].Cells[4] = cell;

            }
        }
    }
}
