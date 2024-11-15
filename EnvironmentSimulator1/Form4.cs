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
    public partial class Form4 : Form
    {
        private static string ID;
        private static string[] Sta = new string[Form1.rowscount8];
        public Form4()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("PSD_Num", "屏蔽门编号");
            dataGridView1.Columns.Add("PSD_ID", "屏蔽门名称");
            dataGridView1.Columns.Add("PSD_StationID", "所属车站");
            dataGridView1.Columns.Add("PSD_Track", "对应轨道区段");
            dataGridView1.Columns.Add("PSD_Mile", "站台长度（单位：m）");
            dataGridView1.Columns.Add("PSD_Status", "屏蔽门状态");
            
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;

            for (int i = 0; i < Form1.rowscount8; i++)
            {
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                cell.Items.Add("关闭");
                cell.Items.Add("开启");
                if (Form1.PSD_Status[i] == 0)
                cell.Value = "关闭";
                if (Form1.PSD_Status[i] == 1)
                cell.Value = "开启";
                
                dataGridView1.Rows.Add(Form1.PSD_Num[i], Form1.PSD_ID[i], Form1.PSD_StationID[i], Form1.PSD_Track[i], Form1.PSD_Mile[i]);
                dataGridView1.Rows[i].Cells[5] = cell;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string searchText = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                for(int i = 0; i<Form1.rowscount8;i++)
                {
                    for (int j = 0; j < 6; j++)
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

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < Form1.rowscount8; i++)
            { 
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                cell.Items.Add("关闭");
                cell.Items.Add("开启");
                if (Form1.PSD_Status[i] == 0)
                    cell.Value = "关闭";
                if (Form1.PSD_Status[i] == 1)
                    cell.Value = "开启";

                dataGridView1.Rows.Add(Form1.PSD_Num[i], Form1.PSD_ID[i], Form1.PSD_StationID[i], Form1.PSD_Track[i], Form1.PSD_Mile[i]);
                dataGridView1.Rows[i].Cells[5] = cell;
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1.rowscount8; i++)
            {
                if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "关闭")
                {
                    Form1.PSD_Status[i] = 0;
                }
                if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "开启")
                {
                    Form1.PSD_Status[i] = 1;
                }
            }
            this.Close();
        }
    }
}
