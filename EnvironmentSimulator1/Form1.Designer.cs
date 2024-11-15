
namespace EnvironmentSimulator1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.初始化站场图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.屏蔽门设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.信号机设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.无岔区段设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.有岔区段设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.通信设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建服务端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建客户端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(3100, 400);
            this.panel1.Location = new System.Drawing.Point(12, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1358, 526);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.初始化站场图ToolStripMenuItem,
            this.数据修改ToolStripMenuItem,
            this.屏蔽门设置ToolStripMenuItem,
            this.信号机设置ToolStripMenuItem,
            this.无岔区段设置ToolStripMenuItem,
            this.有岔区段设置ToolStripMenuItem,
            this.通信设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1378, 32);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 初始化站场图ToolStripMenuItem
            // 
            this.初始化站场图ToolStripMenuItem.Name = "初始化站场图ToolStripMenuItem";
            this.初始化站场图ToolStripMenuItem.Size = new System.Drawing.Size(170, 28);
            this.初始化站场图ToolStripMenuItem.Text = "初始化轨旁模拟器";
            this.初始化站场图ToolStripMenuItem.Click += new System.EventHandler(this.初始化站场图ToolStripMenuItem_Click);
            // 
            // 数据修改ToolStripMenuItem
            // 
            this.数据修改ToolStripMenuItem.Name = "数据修改ToolStripMenuItem";
            this.数据修改ToolStripMenuItem.Size = new System.Drawing.Size(116, 28);
            this.数据修改ToolStripMenuItem.Text = "应答器设置";
            this.数据修改ToolStripMenuItem.Click += new System.EventHandler(this.数据修改ToolStripMenuItem_Click);
            // 
            // 屏蔽门设置ToolStripMenuItem
            // 
            this.屏蔽门设置ToolStripMenuItem.Name = "屏蔽门设置ToolStripMenuItem";
            this.屏蔽门设置ToolStripMenuItem.Size = new System.Drawing.Size(116, 28);
            this.屏蔽门设置ToolStripMenuItem.Text = "屏蔽门设置";
            this.屏蔽门设置ToolStripMenuItem.Click += new System.EventHandler(this.屏蔽门设置ToolStripMenuItem_Click);
            // 
            // 信号机设置ToolStripMenuItem
            // 
            this.信号机设置ToolStripMenuItem.Name = "信号机设置ToolStripMenuItem";
            this.信号机设置ToolStripMenuItem.Size = new System.Drawing.Size(116, 28);
            this.信号机设置ToolStripMenuItem.Text = "信号机设置";
            this.信号机设置ToolStripMenuItem.Click += new System.EventHandler(this.信号机设置ToolStripMenuItem_Click);
            // 
            // 无岔区段设置ToolStripMenuItem
            // 
            this.无岔区段设置ToolStripMenuItem.Name = "无岔区段设置ToolStripMenuItem";
            this.无岔区段设置ToolStripMenuItem.Size = new System.Drawing.Size(134, 28);
            this.无岔区段设置ToolStripMenuItem.Text = "轨道区段设置";
            this.无岔区段设置ToolStripMenuItem.Click += new System.EventHandler(this.无岔区段设置ToolStripMenuItem_Click);
            // 
            // 有岔区段设置ToolStripMenuItem
            // 
            this.有岔区段设置ToolStripMenuItem.Name = "有岔区段设置ToolStripMenuItem";
            this.有岔区段设置ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.有岔区段设置ToolStripMenuItem.Text = "道岔设置";
            this.有岔区段设置ToolStripMenuItem.Click += new System.EventHandler(this.有岔区段设置ToolStripMenuItem_Click);
            // 
            // 通信设置ToolStripMenuItem
            // 
            this.通信设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建服务端ToolStripMenuItem,
            this.创建客户端ToolStripMenuItem});
            this.通信设置ToolStripMenuItem.Name = "通信设置ToolStripMenuItem";
            this.通信设置ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.通信设置ToolStripMenuItem.Text = "通信设置";
            // 
            // 创建服务端ToolStripMenuItem
            // 
            this.创建服务端ToolStripMenuItem.Name = "创建服务端ToolStripMenuItem";
            this.创建服务端ToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.创建服务端ToolStripMenuItem.Text = "创建服务端";
            this.创建服务端ToolStripMenuItem.Click += new System.EventHandler(this.创建服务端ToolStripMenuItem_Click);
            // 
            // 创建客户端ToolStripMenuItem
            // 
            this.创建客户端ToolStripMenuItem.Name = "创建客户端ToolStripMenuItem";
            this.创建客户端ToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.创建客户端ToolStripMenuItem.Text = "创建客户端";
            this.创建客户端ToolStripMenuItem.Click += new System.EventHandler(this.创建客户端ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 588);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "通信状态：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 643);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "与车载控制器通信";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 678);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "与目标控制器通信";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(267, 628);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "设备类型：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(267, 663);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "设备编号：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(267, 698);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 24);
            this.label7.TabIndex = 12;
            this.label7.Text = "设备状态：";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(382, 618);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(116, 35);
            this.textBox1.TabIndex = 18;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(382, 653);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(116, 35);
            this.textBox2.TabIndex = 19;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.Location = new System.Drawing.Point(382, 689);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(116, 35);
            this.textBox3.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(267, 588);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 24);
            this.label8.TabIndex = 21;
            this.label8.Text = "轨旁设备信息：";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(565, 618);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(361, 100);
            this.richTextBox2.TabIndex = 22;
            this.richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(986, 618);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(361, 100);
            this.richTextBox3.TabIndex = 23;
            this.richTextBox3.Text = "";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(197, 647);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Red;
            this.pictureBox3.Location = new System.Drawing.Point(197, 682);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.TabIndex = 25;
            this.pictureBox3.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(561, 588);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(250, 24);
            this.label10.TabIndex = 27;
            this.label10.Text = "车载控制器交互数据：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(982, 588);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(250, 24);
            this.label11.TabIndex = 28;
            this.label11.Text = "目标控制器交互数据：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 719);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 30);
            this.label2.TabIndex = 29;
            this.label2.Text = "label2";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(1378, 744);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.MaximumSize = new System.Drawing.Size(1400, 800);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "轨旁模拟器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 初始化站场图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据修改ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem 屏蔽门设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 信号机设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 无岔区段设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 有岔区段设置ToolStripMenuItem;
        public System.Windows.Forms.RichTextBox richTextBox2;
        public System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripMenuItem 通信设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建服务端ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建客户端ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}

