namespace CameraClient
{
    partial class frmClient
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCname = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBegin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.picShow = new System.Windows.Forms.PictureBox();
            this.btnAuto = new System.Windows.Forms.Button();
            this.tAuto = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCname);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(33, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 120);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器（名称与IP地址任输其一）";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "服务器名称：";
            // 
            // txtCname
            // 
            this.txtCname.Location = new System.Drawing.Point(160, 24);
            this.txtCname.Name = "txtCname";
            this.txtCname.Size = new System.Drawing.Size(184, 21);
            this.txtCname.TabIndex = 2;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(160, 80);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(184, 21);
            this.txtPort.TabIndex = 2;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(160, 56);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(184, 21);
            this.txtIP.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "服务器IP地址：";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "端口：";
            // 
            // btnDownload
            // 
            this.btnDownload.Enabled = false;
            this.btnDownload.Location = new System.Drawing.Point(137, 183);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(72, 24);
            this.btnDownload.TabIndex = 9;
            this.btnDownload.Text = "下载";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(215, 183);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 24);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关闭连接";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(59, 183);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(72, 24);
            this.btnBegin.TabIndex = 7;
            this.btnBegin.Text = "连接";
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(293, 184);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "关闭窗体";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // picShow
            // 
            this.picShow.Location = new System.Drawing.Point(239, 224);
            this.picShow.Name = "picShow";
            this.picShow.Size = new System.Drawing.Size(200, 155);
            this.picShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picShow.TabIndex = 11;
            this.picShow.TabStop = false;
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(62, 269);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 12;
            this.btnAuto.Text = "实时截获";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // tAuto
            // 
            this.tAuto.Interval = 2000;
            this.tAuto.Tick += new System.EventHandler(this.tAuto_Tick);
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 391);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.picShow);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmClient";
            this.Text = "视频连接端";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCname;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox picShow;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Timer tAuto;
    }
}

