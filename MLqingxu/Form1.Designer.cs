namespace MLqingxu
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
            this.tbMsg = new System.Windows.Forms.TextBox();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.btnCs = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnyc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbMsg
            // 
            this.tbMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbMsg.Location = new System.Drawing.Point(0, 89);
            this.tbMsg.Multiline = true;
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMsg.Size = new System.Drawing.Size(800, 361);
            this.tbMsg.TabIndex = 0;
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(38, 48);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(496, 28);
            this.tbInput.TabIndex = 1;
            // 
            // btnCs
            // 
            this.btnCs.Location = new System.Drawing.Point(550, 48);
            this.btnCs.Name = "btnCs";
            this.btnCs.Size = new System.Drawing.Size(189, 28);
            this.btnCs.TabIndex = 2;
            this.btnCs.Text = "输入内容单条预测";
            this.btnCs.UseVisualStyleBackColor = true;
            this.btnCs.Click += new System.EventHandler(this.btnCs_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(169, 12);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(173, 30);
            this.btnInit.TabIndex = 3;
            this.btnInit.Text = "初始化训练数据";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnyc
            // 
            this.btnyc.Location = new System.Drawing.Point(550, 12);
            this.btnyc.Name = "btnyc";
            this.btnyc.Size = new System.Drawing.Size(189, 30);
            this.btnyc.TabIndex = 4;
            this.btnyc.Text = "多条预测";
            this.btnyc.UseVisualStyleBackColor = true;
            this.btnyc.Click += new System.EventHandler(this.btnyc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnyc);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.btnCs);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.tbMsg);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMsg;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button btnCs;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnyc;
    }
}

