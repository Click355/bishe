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
    public partial class Form3 : Form
    {
        private static string ID;
        private static string[] Sta = new string[Form1.rowscount9];
        public Form3()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Tag_Num", "应答器编号");
            dataGridView1.Columns.Add("Tag_ID", "应答器名称");
            dataGridView1.Columns.Add("Tag_Mile", "里程信息（单位：m）");
            dataGridView1.Columns.Add("Tag_Type", "应答器类型");
            dataGridView1.Columns.Add("Tag_Status", "应答器状态");

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;

            for (int i = 0; i < Form1.rowscount9; i++)
            {
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                cell.Items.Add("正常");
                cell.Items.Add("故障");
                if (Form1.Tag_Status[i] == 0)
                    cell.Value = "正常";
                if (Form1.Tag_Status[i] == 1)
                    cell.Value = "故障";
                if (Form1.Tag_Type[i] == 0)
                    ID = "固定应答器";
                dataGridView1.Rows.Add(Form1.Tag_Num[i], Form1.Tag_ID[i], Form1.Tag_Check[i], ID, Form1.Tag_Status[i]);
                dataGridView1.Rows[i].Cells[4] = cell;

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1.rowscount9; i++)
            {
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "正常")
                {
                    Form1.Tag_Status[i] = 0;
                }
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "故障")
                {
                    Form1.Tag_Status[i] = 1;
                }
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                for (int i = 0; i < Form1.rowscount9; i++)
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

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < Form1.rowscount9; i++)
            {
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                cell.Items.Add("正常");
                cell.Items.Add("故障");
                if (Form1.Tag_Status[i] == 0)
                    cell.Value = "正常";
                if (Form1.Tag_Status[i] == 1)
                    cell.Value = "故障";

                dataGridView1.Rows.Add(Form1.Tag_Num[i], Form1.Tag_ID[i], Form1.Tag_Check[i], Form1.Tag_Type[i], Form1.Tag_Status[i]);
                dataGridView1.Rows[i].Cells[4] = cell;
            }
        }
    }
}
