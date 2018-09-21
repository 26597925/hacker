namespace CameraServer
{
    partial class frmServer
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
            this.pictureBoxShow = new System.Windows.Forms.PictureBox();
            this.lblShow = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tSave = new System.Windows.Forms.Timer(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBeginListen = new System.Windows.Forms.Button();
            this.btnEndListen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShow)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxShow
            // 
            this.pictureBoxShow.Location = new System.Drawing.Point(34, 42);
            this.pictureBoxShow.Name = "pictureBoxShow";
            this.pictureBoxShow.Size = new System.Drawing.Size(387, 320);
            this.pictureBoxShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxShow.TabIndex = 1;
            this.pictureBoxShow.TabStop = false;
            this.pictureBoxShow.Click += new System.EventHandler(this.pictureBoxShow_Click);
            // 
            // lblShow
            // 
            this.lblShow.AutoSize = true;
            this.lblShow.Location = new System.Drawing.Point(12, 9);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(65, 12);
            this.lblShow.TabIndex = 2;
            this.lblShow.Text = "视频显示区";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(376, 383);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tSave
            // 
            this.tSave.Enabled = true;
            this.tSave.Interval = 2000;
            this.tSave.Tick += new System.EventHandler(this.tSave_Tick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(265, 383);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBeginListen
            // 
            this.btnBeginListen.Location = new System.Drawing.Point(51, 383);
            this.btnBeginListen.Name = "btnBeginListen";
            this.btnBeginListen.Size = new System.Drawing.Size(75, 23);
            this.btnBeginListen.TabIndex = 5;
            this.btnBeginListen.Text = "开始监听";
            this.btnBeginListen.UseVisualStyleBackColor = true;
            this.btnBeginListen.Click += new System.EventHandler(this.btnBeginListen_Click);
            // 
            // btnEndListen
            // 
            this.btnEndListen.Enabled = false;
            this.btnEndListen.Location = new System.Drawing.Point(156, 383);
            this.btnEndListen.Name = "btnEndListen";
            this.btnEndListen.Size = new System.Drawing.Size(75, 23);
            this.btnEndListen.TabIndex = 6;
            this.btnEndListen.Text = "停止监听";
            this.btnEndListen.UseVisualStyleBackColor = true;
            this.btnEndListen.Click += new System.EventHandler(this.btnEndListen_Click);
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 415);
            this.Controls.Add(this.btnEndListen);
            this.Controls.Add(this.btnBeginListen);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblShow);
            this.Controls.Add(this.pictureBoxShow);
            this.Name = "frmServer";
            this.Text = "QQ显示服务端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServer_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxShow;
        private System.Windows.Forms.Label lblShow;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer tSave;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBeginListen;
        private System.Windows.Forms.Button btnEndListen;
    }
}

