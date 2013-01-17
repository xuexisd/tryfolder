namespace TrafficViolationManage
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtUnProcessed = new System.Windows.Forms.TextBox();
            this.txtCompleted = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.webResultUnProcessed = new System.Windows.Forms.WebBrowser();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.webResultCompleted = new System.Windows.Forms.WebBrowser();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUnProcessed
            // 
            this.txtUnProcessed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnProcessed.Location = new System.Drawing.Point(186, 44);
            this.txtUnProcessed.Name = "txtUnProcessed";
            this.txtUnProcessed.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtUnProcessed.Size = new System.Drawing.Size(846, 21);
            this.txtUnProcessed.TabIndex = 1;
            // 
            // txtCompleted
            // 
            this.txtCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompleted.Location = new System.Drawing.Point(186, 83);
            this.txtCompleted.Name = "txtCompleted";
            this.txtCompleted.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCompleted.Size = new System.Drawing.Size(846, 21);
            this.txtCompleted.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "↓↓↓↓↓↓↓↓↓未处理↓↓↓↓↓↓↓";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "↓↓↓↓↓↓↓↓↓已处理↓↓↓↓↓↓↓";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(180, 487);
            this.listBox1.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(186, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 16);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "使用代理服务器";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(186, 130);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(835, 323);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.webResultUnProcessed);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(827, 297);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "未处理详情";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // webResultUnProcessed
            // 
            this.webResultUnProcessed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webResultUnProcessed.Location = new System.Drawing.Point(3, 3);
            this.webResultUnProcessed.MinimumSize = new System.Drawing.Size(20, 20);
            this.webResultUnProcessed.Name = "webResultUnProcessed";
            this.webResultUnProcessed.Size = new System.Drawing.Size(821, 291);
            this.webResultUnProcessed.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.webResultCompleted);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(827, 297);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "已处理详情";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // webResultCompleted
            // 
            this.webResultCompleted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webResultCompleted.Location = new System.Drawing.Point(3, 3);
            this.webResultCompleted.MinimumSize = new System.Drawing.Size(20, 20);
            this.webResultCompleted.Name = "webResultCompleted";
            this.webResultCompleted.Size = new System.Drawing.Size(821, 291);
            this.webResultCompleted.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(186, 459);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(835, 23);
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(186, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(371, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "↓↓↓↓↓↓↓↓↓未付费用户仅显示前3条违章详情↓↓↓↓↓↓↓";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 487);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCompleted);
            this.Controls.Add(this.txtUnProcessed);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "交通违规查询";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUnProcessed;
        private System.Windows.Forms.TextBox txtCompleted;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.WebBrowser webResultUnProcessed;
        private System.Windows.Forms.WebBrowser webResultCompleted;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label3;
    }
}

