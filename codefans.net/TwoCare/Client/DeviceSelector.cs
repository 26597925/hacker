/******************************************
 * 版权所有jackch
 * QQ:106050555
 * E-mail:jackch88@hotmail.com
 * 个人Blog:http://www.jackch.cn
 * CSDN_Blog:http://blog.csdn.net/jackch88/
 * ****************************************/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using Jackch;

namespace Jackch
{
    /// <summary>
    /// Luoz： 用户选择捕捉视频设备
    /// </summary>
    public partial class DeviceSelector : System.Windows.Forms.Form
    {
         /// <summary> Required designer variable. </summary>
       
        public DeviceSelector(ArrayList devs)
        {
            // Required for Windows Form Designer support
            InitializeComponent();

            ListViewItem item = null;
            foreach (DsDevice d in devs)
            {
                item = new ListViewItem(d.Name);
                item.Tag = d;
                deviceListVw.Items.Add(item);
            }
        }






        private void deviceListVw_DoubleClick(object sender, System.EventArgs e)
        {
            this.okButton_Click(sender, e);
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            if (deviceListVw.SelectedItems.Count != 1)
                return;
            ListViewItem selitem = deviceListVw.SelectedItems[0];
            SelectedDevice = selitem.Tag as DsDevice;
            Close();
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        public DsDevice SelectedDevice;
    }

}
