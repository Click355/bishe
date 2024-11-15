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
    public partial class Form7 : Form
    {
        private static string search;
        public Form7()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Switch_Num", "道岔编号");
            dataGridView1.Columns.Add("Switch_ID", "道岔名称");
            dataGridView1.Columns.Add("Switch_Mile", "里程信息");
            dataGridView1.Columns.Add("Switch_Status", "道岔状态");
            dataGridView1.Columns[0].Width = 123;
            dataGridView1.Columns[1].Width = 123;
            dataGridView1.Columns[2].Width = 123;
            dataGridView1.Columns[3].Width = 123;

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;

            for (int i = 0; i < Form1.counts; i++)
            {
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                cell.Items.Add("定位");
                cell.Items.Add("反位");
                cell.Items.Add("定位锁闭");
                cell.Items.Add("反位锁闭");
                cell.Items.Add("四开");
                cell.Items.Add("失表");
                cell.Items.Add("封锁");
                if (Form1.Switch_Status[i * 5 + 1] == 0)                
                    cell.Value = "定位";
                if (Form1.Switch_Status[i * 5 + 1] == 1)
                    cell.Value = "反位";
                if (Form1.Switch_Status[i * 5 + 1] == 2)
                    cell.Value = "定位锁闭";
                if (Form1.Switch_Status[i * 5 + 1] == 3)
                    cell.Value = "反位锁闭";
                if (Form1.Switch_Status[i * 5 + 1] == 4)
                    cell.Value = "四开";
                if (Form1.Switch_Status[i * 5 + 1] == 5)
                    cell.Value = "失表";
                if (Form1.Switch_Status[i * 5 + 1] == 6)
                    cell.Value = "封锁";
                dataGridView1.Rows.Add(Form1.Switch_Num[i], Form1.Switch_ID[i*5], Form1.Switch_Pos[i * 5]);
                dataGridView1.Rows[i].Cells[3] = cell;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                for (int i = 0; i < Form1.rowscount6 + Form1.counts; i++)
                {
                    for (int j = 0; j < 4; j++)
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
            for (int i = 0; i < Form1.counts; i++)
            {
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                cell.Items.Add("定位");
                cell.Items.Add("反位");
                cell.Items.Add("定位锁闭");
                cell.Items.Add("反位锁闭");
                cell.Items.Add("四开");
                cell.Items.Add("失表");
                cell.Items.Add("封锁");
                if (Form1.Switch_Status[i * 5 + 1] == 0)
                    cell.Value = "定位";
                if (Form1.Switch_Status[i * 5 + 1] == 1)
                    cell.Value = "反位";
                if (Form1.Switch_Status[i * 5 + 1] == 2)
                    cell.Value = "定位锁闭";
                if (Form1.Switch_Status[i * 5 + 1] == 3)
                    cell.Value = "反位锁闭";
                if (Form1.Switch_Status[i * 5 + 1] == 4)
                    cell.Value = "四开";
                if (Form1.Switch_Status[i * 5 + 1] == 5)
                    cell.Value = "失表";
                if (Form1.Switch_Status[i * 5 + 1] == 6)
                    cell.Value = "封锁";
                dataGridView1.Rows.Add(Form1.Switch_Num[i], Form1.Switch_ID[i], Form1.Switch_Pos[i * 5]);
                dataGridView1.Rows[i].Cells[3] = cell;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1.counts; i++)
            {
                if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "定位")
                {
                    Form1.Switch_Status[i * 5 + 1] = 0;
                    Form1.Switch_Status[i * 5 + 3] = 0;
                }
                if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "反位")
                {
                    Form1.Switch_Status[i * 5 + 1] = 1;
                    Form1.Switch_Status[i * 5 + 3] = 1;
                }
                if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "定位锁闭")
                {
                    Form1.Switch_Status[i * 5 + 1] = 2;
                    Form1.Switch_Status[i * 5 + 3] = 2;
                }
                if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "反位锁闭")
                {
                    Form1.Switch_Status[i * 5 + 1] = 3;
                    Form1.Switch_Status[i * 5 + 3] = 3;
                }
                if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "四开")
                {
                    Form1.Switch_Status[i * 5 + 1] = 4;
                    Form1.Switch_Status[i * 5 + 3] = 4;
                }
                if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "失表")
                {
                    Form1.Switch_Status[i * 5 + 1] = 5;
                    Form1.Switch_Status[i * 5 + 3] = 5;
                }
                if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "封锁")
                {
                    Form1.Switch_Status[i * 5 + 1] = 6;
                    Form1.Switch_Status[i * 5 + 3] = 6;
                }
            }
            this.Close();
        }
    }
}
