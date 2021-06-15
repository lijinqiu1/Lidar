namespace lidar
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
            this.workstatus = new System.Windows.Forms.Label();
            this.label_lidarstatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_startangle = new System.Windows.Forms.TextBox();
            this.textBox_stopangle = new System.Windows.Forms.TextBox();
            this.textBox_distance1 = new System.Windows.Forms.TextBox();
            this.label_point1 = new System.Windows.Forms.Label();
            this.label_point2 = new System.Windows.Forms.Label();
            this.label_point3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_distance3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_distance2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // workstatus
            // 
            this.workstatus.AutoSize = true;
            this.workstatus.Location = new System.Drawing.Point(13, 13);
            this.workstatus.Name = "workstatus";
            this.workstatus.Size = new System.Drawing.Size(41, 12);
            this.workstatus.TabIndex = 0;
            this.workstatus.Text = "label1";
            // 
            // label_lidarstatus
            // 
            this.label_lidarstatus.AutoSize = true;
            this.label_lidarstatus.Location = new System.Drawing.Point(13, 29);
            this.label_lidarstatus.Name = "label_lidarstatus";
            this.label_lidarstatus.Size = new System.Drawing.Size(41, 12);
            this.label_lidarstatus.TabIndex = 1;
            this.label_lidarstatus.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "侦测起始角度 °";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "侦测结束角度 °";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "侦测距离1(mm)";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(445, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_startangle
            // 
            this.textBox_startangle.Location = new System.Drawing.Point(13, 104);
            this.textBox_startangle.Name = "textBox_startangle";
            this.textBox_startangle.Size = new System.Drawing.Size(100, 21);
            this.textBox_startangle.TabIndex = 4;
            // 
            // textBox_stopangle
            // 
            this.textBox_stopangle.Location = new System.Drawing.Point(130, 104);
            this.textBox_stopangle.Name = "textBox_stopangle";
            this.textBox_stopangle.Size = new System.Drawing.Size(100, 21);
            this.textBox_stopangle.TabIndex = 5;
            // 
            // textBox_distance1
            // 
            this.textBox_distance1.Location = new System.Drawing.Point(15, 166);
            this.textBox_distance1.Name = "textBox_distance1";
            this.textBox_distance1.Size = new System.Drawing.Size(100, 21);
            this.textBox_distance1.TabIndex = 6;
            // 
            // label_point1
            // 
            this.label_point1.AutoSize = true;
            this.label_point1.Location = new System.Drawing.Point(13, 204);
            this.label_point1.Name = "label_point1";
            this.label_point1.Size = new System.Drawing.Size(35, 12);
            this.label_point1.TabIndex = 7;
            this.label_point1.Text = "检测1";
            // 
            // label_point2
            // 
            this.label_point2.AutoSize = true;
            this.label_point2.Location = new System.Drawing.Point(54, 204);
            this.label_point2.Name = "label_point2";
            this.label_point2.Size = new System.Drawing.Size(35, 12);
            this.label_point2.TabIndex = 7;
            this.label_point2.Text = "检测2";
            // 
            // label_point3
            // 
            this.label_point3.AutoSize = true;
            this.label_point3.Location = new System.Drawing.Point(95, 204);
            this.label_point3.Name = "label_point3";
            this.label_point3.Size = new System.Drawing.Size(35, 12);
            this.label_point3.TabIndex = 7;
            this.label_point3.Text = "检测3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "顺时针方向设置扫描范围";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "侦测距离3(mm)";
            this.label5.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox_distance3
            // 
            this.textBox_distance3.Location = new System.Drawing.Point(245, 166);
            this.textBox_distance3.Name = "textBox_distance3";
            this.textBox_distance3.Size = new System.Drawing.Size(100, 21);
            this.textBox_distance3.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(128, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "侦测距离2(mm)";
            this.label6.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox_distance2
            // 
            this.textBox_distance2.Location = new System.Drawing.Point(130, 166);
            this.textBox_distance2.Name = "textBox_distance2";
            this.textBox_distance2.Size = new System.Drawing.Size(100, 21);
            this.textBox_distance2.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 225);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_point3);
            this.Controls.Add(this.label_point2);
            this.Controls.Add(this.label_point1);
            this.Controls.Add(this.textBox_distance2);
            this.Controls.Add(this.textBox_distance3);
            this.Controls.Add(this.textBox_distance1);
            this.Controls.Add(this.textBox_stopangle);
            this.Controls.Add(this.textBox_startangle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_lidarstatus);
            this.Controls.Add(this.workstatus);
            this.Name = "Form1";
            this.Text = "传感器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label workstatus;
        private System.Windows.Forms.Label label_lidarstatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_startangle;
        private System.Windows.Forms.TextBox textBox_stopangle;
        private System.Windows.Forms.TextBox textBox_distance1;
        private System.Windows.Forms.Label label_point1;
        private System.Windows.Forms.Label label_point2;
        private System.Windows.Forms.Label label_point3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_distance3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_distance2;
    }
}

