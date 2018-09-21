using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassClient;
using System.IO;
namespace CameraClient
{
    public partial class frmClient : Form
    {
       
        public frmClient()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            if (!Client.beginConnection(txtCname.Text.Trim(),txtIP.Text.Trim(),txtPort.Text.Trim()))
            {
                MessageBox.Show( "连接失败！！");
            }
            else
            {
                btnBegin.Enabled = false;
                btnClose.Enabled = true;
                btnDownload.Enabled = true;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (!Client.getFile())
            {
                MessageBox.Show("下载失败！！");
            }
            else
            {
                //MessageBox.Show("下载成功！！");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!Client.endConnection())
            {
                MessageBox.Show("关闭失败！！");
            }
            else
            {
                MessageBox.Show("连接成功关闭！！");
                this.btnClose.Enabled = false;
                this.btnBegin.Enabled = true;
            }
        }

        private void tAuto_Tick(object sender, EventArgs e)
        {
            if (!Client.getFile())
            {
                MessageBox.Show("下载失败！！");
            }
            else
            {
                if (File.Exists(Application.StartupPath + "\\test.jpg"))
                  { 
                //picShow.Image = Image.FromFile(Application.StartupPath + "\\test.jpg"); 
            
                 }
            }
            
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            tAuto.Enabled = true;
        }
    }
}