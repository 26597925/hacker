using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ServerDLL;
using ListenerDLL;
using System.Drawing.Imaging;
namespace CameraServer
{
    public partial class frmServer : Form
    {
        private ClassVedioCapture VC = new ClassVedioCapture();
        public frmServer()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.tSave.Enabled = false;
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                VC.Initialize(this.pictureBoxShow, this.pictureBoxShow.Width, this.pictureBoxShow.Height);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tSave_Tick(object sender, EventArgs e)
        {
            VC.CopyToClipBorad();
            ClassSave.Save(VC.getCaptureImage());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            VC.CopyToClipBorad();
            ClassSave.Save(VC.getCaptureImage());
        }

        private void btnBeginListen_Click(object sender, EventArgs e)
        {
            if (!Listener.beginListen())
            {
                MessageBox.Show("监听失败");
            }
            else
            {
                this.btnEndListen.Enabled = true;
                this.btnBeginListen.Enabled = false;
            }
        }

        private void btnEndListen_Click(object sender, EventArgs e)
        {
            if (!Listener.endListen())
            {
                MessageBox.Show("关闭失败");
            }
            else
            {
                this.btnBeginListen.Enabled = true;
                this.btnEndListen.Enabled = false;
            }
        }

        private void frmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.tSave.Enabled = false;
            Application.Exit();
        }

        private void pictureBoxShow_Click(object sender, EventArgs e)
        {

        }
    }
}