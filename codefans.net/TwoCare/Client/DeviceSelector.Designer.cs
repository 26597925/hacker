namespace Jackch
{
    partial class DeviceSelector
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

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.deviceListVw = new System.Windows.Forms.ListView();
            this.nameColHd = new System.Windows.Forms.ColumnHeader();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deviceListVw
            // 
            this.deviceListVw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColHd});
            this.deviceListVw.FullRowSelect = true;
            this.deviceListVw.GridLines = true;
            this.deviceListVw.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.deviceListVw.HideSelection = false;
            this.deviceListVw.Location = new System.Drawing.Point(10, 9);
            this.deviceListVw.MultiSelect = false;
            this.deviceListVw.Name = "deviceListVw";
            this.deviceListVw.Size = new System.Drawing.Size(326, 113);
            this.deviceListVw.TabIndex = 0;
            this.deviceListVw.UseCompatibleStateImageBehavior = false;
            this.deviceListVw.View = System.Windows.Forms.View.Details;
            this.deviceListVw.DoubleClick += new System.EventHandler(this.deviceListVw_DoubleClick);
            // 
            // nameColHd
            // 
            this.nameColHd.Text = "Name";
            this.nameColHd.Width = 400;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(130, 128);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(65, 26);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(226, 128);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(63, 26);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // DeviceSelector
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(360, 159);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.deviceListVw);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceSelector";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择一个视频设备";
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ListView deviceListVw;
        private System.Windows.Forms.ColumnHeader nameColHd;
       
    }
}