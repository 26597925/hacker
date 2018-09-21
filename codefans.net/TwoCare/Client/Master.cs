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
using System.ServiceProcess;
using System.Management;
using Jackch;

//*********************************************************************************
//文件操作相关函数
namespace Jackch
{
    public partial class MainForm
    {
        private bool isFirstInit = true;
        private void faTabStrip1_TabStripItemSelectionChanged(TabStripItemChangedEventArgs e)
        {
            if (isFirstInit)
            {
                isFirstInit = false;
                return;
            }
            if (e.Item == faTabStripItem1)
            {
                //MessageBox.Show(faTabStripItem1.ToString());
            }
            else if (e.Item == faTabStripItem2)
            {
                //MessageBox.Show(faTabStripItem2.ToString());
            }
            else if (e.Item == faTabStripItem3)
            {
                //MessageBox.Show(faTabStripItem3.ToString());
            }
            else if (e.Item == faTabStripItem4)
            {

            }
            else if (e.Item == faTabStripItem5)
            {

            }
            else if (e.Item == faTabStripItem6)
            {

            }
            else if (e.Item == faTabStripItem6)
            {

            }
            else if (e.Item == faTabStripItem7)
            {

            }
            else if (e.Item == faTabStripItem8)
            {

            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region 注册表
        /// <summary>
        /// 注册表编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private TreeViewEventArgs treeView2e = null;
        private TreeViewCancelEventArgs treeView2e2 = null;
        private void treeView2_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {//添加注册表子节点
            treeView2e2 = e;
            if (e == null)
                return; 
            statusBarPanel2.Text = "正在获取注册表,请稍等...";
            for (int i = 0; i < e.Node.Nodes.Count; i++)
            {
                try
                {
                    this.AddSubRegKey(e.Node.Nodes[i]);
                }
                catch { }
            }
            if(statusBarPanel2.Text != "远程主机没有连接或已断开连接,获取注册表失败")
                statusBarPanel2.Text = "获取注册表成功";
        }
        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)//在列表视图中填充注册表键值数据
        {
            treeView2e = e;
            if (e == null || e.Node.Parent == null)
            {
                this.listView2.Items.Clear();
                return;
            }
            statusBarPanel2.Text = "正在获取注册表,请稍等...";
            try
            {
                this.listView2.Items.Clear();
                bool isMyPc = true;
                string[] Values = GetValueNames(this.treeView2.SelectedNode, out isMyPc);
                string MyRegValueName;
                object MyRegValueType;
                object MyRegValueData;
                int length = Values.Length;
                if (!isMyPc)
                    length -= 1;
                for (int i = 0; i < length; i++)
                {
                    string []str=Values[i].Split('\t');
                    MyRegValueName = str[0];
                    MyRegValueType = str[1];
                    MyRegValueData = str[2];
                    
                    MyRegValueName = MyRegValueName == "" ? "(默认)" : MyRegValueName;

                    ListViewItem MySubItem;
                    if (MyRegValueType.ToString() == "System.String")
                    {
                        MyRegValueType = "REG_SZ";
                        MySubItem = new ListViewItem(new String[] { MyRegValueName, MyRegValueType.ToString(), MyRegValueData.ToString() }, 21);
                    }
                    else
                    {
                        MyRegValueType = "REG_DWORD";
                        MySubItem = new ListViewItem(new String[] { MyRegValueName, MyRegValueType.ToString(), MyRegValueData.ToString() }, 22);
                    }
                    this.listView2.Items.Add(MySubItem);
                }
            }
            catch { }
            if (statusBarPanel2.Text != "远程主机没有连接或已断开连接,获取注册表失败")
                statusBarPanel2.Text = "获取注册表成功";
        }
        private string[] GetValueNames(TreeNode node, out bool isMyPc)
        {
            isMyPc = true;
            RegistryKey MyReg = GetRegKey(node, out isMyPc);
            if (isMyPc)
            {
                string []Values=MyReg.GetValueNames();
                int length = Values.Length;
                string[] arr = new string[length];
                string MyRegValueName;
                object MyRegValueType;
                object MyRegValueData;
                for (int i = 0; i < length; ++i)
                {
                    MyRegValueName = Values[i];
                    MyRegValueData = MyReg.GetValue(MyRegValueName);
                    MyRegValueType = MyRegValueData.GetType();
                    arr[i]=MyRegValueName + "\t" + MyRegValueType + "\t" + MyRegValueData;
                }
                return arr;
            }
            else
            {
                if (isLocal)
                {
                    foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                        tn.Nodes.Clear();
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取注册表失败";
                    this.listView2.Items.Clear(); 
                    return null;
                }
                if(!chickens.CurrentChicken.WriteToServer("Regedit getkeyvalue " + MyReg.ToString()))
                {
                    foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                        tn.Nodes.Clear();
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取注册表失败";
                    this.listView2.Items.Clear();
                    return null;
                }
                bool isConnected = true;
                string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (isConnected)
                    return str.Split('\b');
                else
                {
                    foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                        tn.Nodes.Clear();
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取注册表失败";
                    this.listView2.Items.Clear();
                    return null;
                }
            }
        }
        private string[] GetNodes(TreeNode node, out bool isMyPc)
        {
            isMyPc = true;
            RegistryKey MyReg = GetRegKey(node, out isMyPc);
            if (isMyPc)
            {
                return MyReg.GetSubKeyNames();
            }
            else
            {
                if (isLocal)
                {
                    foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                        tn.Nodes.Clear();
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取注册表失败";
                    this.listView2.Items.Clear(); 
                    return null;
                }
                if(!chickens.CurrentChicken.WriteToServer("Regedit getsubkey " + MyReg.ToString()))
                {
                    foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                        tn.Nodes.Clear();
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取注册表失败";
                    this.listView2.Items.Clear();
                    return null;
                }
                bool isConnected = true;
                string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (isConnected)
                    return str.Split('\t');
                else
                {
                    foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                        tn.Nodes.Clear();
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取注册表失败";
                    this.listView2.Items.Clear();
                    return null;
                }
            }
        }
        private RegistryKey GetRegKey(TreeNode node, out bool isMyPc)//取得注册表节点信息
        {
            string MyPath = node.FullPath;
            RegistryKey MyReg = Registry.LocalMachine;
            isMyPc = true;
            //取得五个注册表主键
            if (MyPath.Length > 4)
            {
                string[] KeyName = MyPath.Split(new Char[] { '\\' });
                switch (KeyName[1])
                {
                    case "HKEY_CLASSES_ROOT":
                        MyReg = Registry.ClassesRoot;
                        break;
                    case "HKEY_CURRENT_USER":
                        MyReg = Registry.CurrentUser;
                        break;
                    case "HKEY_LOCAL_MACHINE":
                        MyReg = Registry.LocalMachine;
                        break;
                    case "HKEY_USERS":
                        MyReg = Registry.Users;
                        break;
                    case "HKEY_CURRENT_CONFIG":
                        MyReg = Registry.CurrentConfig;
                        break;
                    case "HKEY_DYN_DATA":
                        MyReg = Registry.DynData;
                        break;
                }
                string Pnode = MyPath.Substring(0, 4);
                MyPath = MyPath.Substring(6);
                
                if (Pnode == "我的电脑")
                {
                    isMyPc = true;
                }
                else
                {
                    isMyPc = false;
                }
                if (MyPath.IndexOf("\\") > 0)
                {
                    MyPath = MyPath.Substring(MyPath.IndexOf("\\") + 1);
                    try
                    {
                        MyReg = MyReg.OpenSubKey(MyPath,true);
                    }
                    catch { }
                }
            }
            return MyReg;
        }
        private void AddSubRegKey(TreeNode node)
        {//增加注册表新节点
            if (node.Nodes.Count == 0)
            {
                bool isMyPc = true;
                string[] MyReg = GetNodes(node,out isMyPc);
                int length = MyReg.Length;
                if (!isMyPc)
                    length -= 1;
                for (int i = 0; i < length; i++)
                {
                    node.Nodes.Add(MyReg[i]);
                }
            }
        }

        /// <summary>
        /// 导出注册表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton28_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = @"Registry" + System.DateTime.Now.ToShortDateString() + @".txt";

           
            if (sf.ShowDialog() == DialogResult.OK)
            {
                SaveData(listView2, sf.FileName);
                MessageBox.Show("导出文件列表成功", "导出列表", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }
        /// <summary>
        /// 刷新注册表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton29_Click(object sender, EventArgs e)
        {
            treeView2_AfterSelect(sender,treeView2e);
        }
        /// <summary>
        /// 创建新项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton30_Click(object sender, EventArgs e)
        {
            bool isMyPc = true;
            if (treeView2e == null || treeView2e.Node.Parent==null)
                return;
            RegistryKey reg = GetRegKey(treeView2e.Node, out isMyPc);
            NewForm nf = new NewForm();
            nf.label1.Text = "新项目名称";
            nf.textBox1.Text = "新项 #1";
            if (nf.ShowDialog() == DialogResult.OK)
            {
                if (nf.textBox1.Text == "")
                    return;
                if (isMyPc)
                {
                    try
                    {
                        reg.CreateSubKey(nf.textBox1.Text);
                        treeView2e.Node.Nodes.Add(nf.textBox1.Text);
                    }
                    catch { }
                }
                else
                {
                    if (isLocal)
                    {
                        foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                            tn.Nodes.Clear();
                        statusBarPanel2.Text = "远程主机没有连接或已断开连接,创建远程项目失败";
                        this.listView2.Items.Clear();
                        return;
                    }
                    if(!chickens.CurrentChicken.WriteToServer("Regedit new " +reg.ToString()+"\t"+ nf.textBox1.Text))
                    {
                        foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                            tn.Nodes.Clear();
                        statusBarPanel2.Text = "远程主机没有连接或已断开连接,创建远程项目失败";
                        this.listView2.Items.Clear();
                        return;
                    }
                    bool isConnected = true;
                    string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                    if (!isConnected)
                    {
                        foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                            tn.Nodes.Clear();
                        statusBarPanel2.Text = "远程主机没有连接或已断开连接,创建远程项目失败";
                        this.listView2.Items.Clear();
                        return;
                    }
                    if(str=="1")
                        treeView2e.Node.Nodes.Add(nf.textBox1.Text);
                }
                toolStripButton29_Click(null, null);
            }
        }
        /// <summary>
        /// 项重命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton52_Click(object sender, EventArgs e)
        {
            bool isMyPc = true;
            if (treeView2e == null || treeView2e.Node.Parent == null)
                return;
            RegistryKey reg = GetRegKey(treeView2e.Node.Parent, out isMyPc);
            RenameForm rf = new RenameForm();
            rf.label1.Text = "原项目名称";
            rf.label2.Text = "新项目名称";
            rf.textBox1.Text = treeView2e.Node.Text;
            rf.textBox2.Text = "新项目名称";
            if (rf.ShowDialog() == DialogResult.OK)
            {
                if (rf.textBox2.Text == "")
                    return;
                if (isMyPc)
                {
                    try
                    {
                        reg.CreateSubKey(rf.textBox2.Text);
                        RegistryKey reg1 = reg.OpenSubKey(rf.textBox1.Text, true);
                        RegistryKey reg2 = reg.OpenSubKey(rf.textBox2.Text, true);
                        RegistryCopy(reg1, reg2);

                        reg.DeleteSubKey(treeView2e.Node.Text);
                        treeView2e.Node.Text = rf.textBox2.Text;
                    }
                    catch (System.InvalidOperationException)
                    {
                        try
                        {
                            reg.DeleteSubKeyTree(treeView2e.Node.Text);
                        }
                        catch { }
                    }
                    catch { }

                }
                else
                {
                    if (isLocal)
                    {
                        foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                            tn.Nodes.Clear();
                        statusBarPanel2.Text = "远程主机没有连接或已断开连接,远程项重命名失败";
                        this.listView2.Items.Clear();
                        return;
                    }
                    if(!chickens.CurrentChicken.WriteToServer("Regedit rename " + reg.ToString() + "\t" + rf.textBox1.Text + "\t" + rf.textBox2.Text))
                    {
                        foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                            tn.Nodes.Clear();
                        statusBarPanel2.Text = "远程主机没有连接或已断开连接,远程项重命名失败";
                        this.listView2.Items.Clear();
                        return;
                    }
                    bool isConnected = true;
                    string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                    if (!isConnected)
                    {
                        foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                            tn.Nodes.Clear();
                        statusBarPanel2.Text = "远程主机没有连接或已断开连接,远程项重命名失败";
                        this.listView2.Items.Clear();
                        return;
                    }
                    if(str=="1")
                        treeView2e.Node.Text = rf.textBox2.Text;
                }
                toolStripButton29_Click(null, null);
            }
        }
        private void RegistryCopy(RegistryKey key1, RegistryKey key2)
        {
            foreach (string s in key1.GetValueNames())
            {
                key2.SetValue(s, key1.GetValue(s), key1.GetValueKind(s));
            }
            foreach (string key in key1.GetSubKeyNames())
            {
                key2.CreateSubKey(key);
                RegistryKey key3 = key1.OpenSubKey(key, true);
                RegistryKey key4 = key2.OpenSubKey(key, true);
                RegistryCopy( key3,  key4);
            }
        }
        /// <summary>
        /// 删除项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton53_Click(object sender, EventArgs e)
        {
            bool isMyPc = true;
            if (treeView2e == null || treeView2e.Node.Parent == null)
                return;
            RegistryKey reg = GetRegKey(treeView2e.Node.Parent, out isMyPc);
            if (MessageBox.Show("确定删除注册表项目？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (isMyPc)
                {
                    try
                    {
                        reg.DeleteSubKey(treeView2e.Node.Text);
                        treeView2e.Node.Parent.Nodes.Remove(treeView2e.Node);
                    }
                    catch (System.InvalidOperationException)
                    {
                        try
                        {
                            reg.DeleteSubKeyTree(treeView2e.Node.Text);
                            treeView2e.Node.Parent.Nodes.Remove(treeView2e.Node);
                        }
                        catch { }
                    }
                    catch { }
                }
                else
                {
                    if (isLocal)
                    {
                        foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                            tn.Nodes.Clear();
                        statusBarPanel2.Text = "远程主机没有连接或已断开连接,删除远程项目失败";
                        this.listView2.Items.Clear();
                        return;
                    }
                    if (!chickens.CurrentChicken.WriteToServer("Regedit del " + reg.ToString() + "\t" + treeView2e.Node.Text))
                    {
                        foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                            tn.Nodes.Clear();
                        statusBarPanel2.Text = "远程主机没有连接或已断开连接,删除远程项目失败";
                        this.listView2.Items.Clear();
                        return;
                    }
                    bool isConnected = true;
                    string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                    if (!isConnected)
                    {
                        foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                            tn.Nodes.Clear();
                        statusBarPanel2.Text = "远程主机没有连接或已断开连接,删除远程项目失败";
                        this.listView2.Items.Clear();
                        return;
                    }
                    if(str=="1")
                        treeView2e.Node.Parent.Nodes.Remove(treeView2e.Node);
                }
                toolStripButton29_Click(null, null);
            }
        }
        /// <summary>
        /// 创建键值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton54_Click(object sender, EventArgs e)
        {
            bool isMyPc = true;
            if (treeView2e == null || treeView2e.Node.Parent==null)
                return;
            RegistryKey reg = GetRegKey(treeView2e.Node, out isMyPc);
            NewForm nf = new NewForm();
            nf.label1.Text = "新键值名称";
            nf.textBox1.Text = "新值 #1";
            if (nf.ShowDialog() == DialogResult.OK)
            {
                if (nf.textBox1.Text == "")
                    return;
                if (isMyPc)
                {
                    try
                    {
                        reg.SetValue(nf.textBox1.Text, "");
                    }
                    catch { }
                }
                else
                {
                    if (isLocal)
                    {
                        foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                            tn.Nodes.Clear();
                        statusBarPanel2.Text = "远程主机没有连接或已断开连接,创建远程键值失败";
                        this.listView2.Items.Clear();
                        return;
                    }
                    if(!chickens.CurrentChicken.WriteToServer("Regedit new1 " + reg.ToString() + "\t" + nf.textBox1.Text))
                    {
                        foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                            tn.Nodes.Clear();
                        statusBarPanel2.Text = "远程主机没有连接或已断开连接,创建远程键值失败";
                        this.listView2.Items.Clear();
                        return;
                    }
                    bool isConnected = true;
                    string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                    if (!isConnected)
                    {
                        foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                            tn.Nodes.Clear();
                        statusBarPanel2.Text = "远程主机没有连接或已断开连接,创建远程键值失败";
                        this.listView2.Items.Clear();
                        return;
                    }
                }
                toolStripButton29_Click(null, null);
            }
        }
        /// <summary>
        /// 修改键值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton55_Click(object sender, EventArgs e)
        {
            bool isMyPc = true;
            if (listView2.SelectedItems.Count == 0 || treeView2e == null || treeView2e.Node.Parent == null)
                return;
            RegistryKey reg = GetRegKey(treeView2e.Node, out isMyPc);
            RenameForm rf = new RenameForm();
            rf.Text = "修改键值";
            rf.label1.Text = "键值名称";
            rf.label2.Text = "数值数据";
            rf.textBox1.Text = listView2.SelectedItems[0].SubItems[0].Text;
            rf.textBox1.ReadOnly = false;
            rf.textBox2.Text = "";
            try
            {
                rf.textBox2.Text = reg.GetValue(rf.textBox1.Text).ToString();
            }
            catch { }
            if (rf.ShowDialog() == DialogResult.OK)
            {
                if (isMyPc)
                {
                    try
                    {
                        reg.SetValue(rf.textBox1.Text, rf.textBox2.Text, reg.GetValueKind(listView2.SelectedItems[0].SubItems[0].Text));
                        if (rf.textBox1.Text != listView2.SelectedItems[0].SubItems[0].Text)
                            reg.DeleteValue(listView2.SelectedItems[0].SubItems[0].Text);
                    }
                    catch
                    { 
                        MessageBox.Show("设置的键值不符合","错误",MessageBoxButtons.OK,MessageBoxIcon.Error); 
                    }
                }
                else 
                {
                    if (isLocal)
                    {
                        foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                            tn.Nodes.Clear();
                        statusBarPanel2.Text = "远程主机没有连接或已断开连接,修改远程键值失败";
                        this.listView2.Items.Clear();
                        return ;
                    }
                    if (!chickens.CurrentChicken.WriteToServer("Regedit rename1 " + reg.ToString() + "\t" + listView2.SelectedItems[0].SubItems[0].Text + "\t" + rf.textBox1.Text + "\t" + rf.textBox2.Text))
                    {
                        foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                            tn.Nodes.Clear();
                        statusBarPanel2.Text = "远程主机没有连接或已断开连接,修改远程键值失败";
                        this.listView2.Items.Clear();
                        return;
                    }
                    bool isConnected = true;
                    string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                    if (!isConnected)
                    {
                        foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                            tn.Nodes.Clear();
                        statusBarPanel2.Text = "远程主机没有连接或已断开连接,修改远程键值失败";
                        this.listView2.Items.Clear();
                        return;
                    }
                }
                toolStripButton29_Click(null, null);
            }
        }
        /// <summary>
        /// 删除键值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton56_Click(object sender, EventArgs e)
        {
            bool isMyPc = true;
            if (listView2.SelectedItems.Count==0||treeView2e == null || treeView2e.Node.Parent == null)
                return;
            RegistryKey reg = GetRegKey(treeView2e.Node, out isMyPc);
            if (MessageBox.Show("确定删除注册表键值？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (isMyPc)
                {
                    try
                    {
                        reg.DeleteValue(listView2.SelectedItems[0].SubItems[0].Text);
                    }
                    catch { }
                }
                else 
                {
                    if (isLocal)
                    {
                        foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                            tn.Nodes.Clear();
                        statusBarPanel2.Text = "远程主机没有连接或已断开连接,删除远程键值失败";
                        this.listView2.Items.Clear();
                        return ;
                    }
                    if (!chickens.CurrentChicken.WriteToServer("Regedit del1 " + reg.ToString() + "\t" + listView2.SelectedItems[0].SubItems[0].Text))
                    {
                        foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                            tn.Nodes.Clear();
                        statusBarPanel2.Text = "远程主机没有连接或已断开连接,删除远程键值失败";
                        this.listView2.Items.Clear();
                        return;
                    }
                    bool isConnected = true;
                    string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                    if (!isConnected)
                    {
                        foreach (TreeNode tn in treeView2.Nodes[1].Nodes)
                            tn.Nodes.Clear();
                        statusBarPanel2.Text = "远程主机没有连接或已断开连接,删除远程键值失败";
                        this.listView2.Items.Clear();
                        return;
                    }
                }
                toolStripButton29_Click(null, null);
            }

        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region 系统信息
        /// <summary>
        /// 系统信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private TreeViewEventArgs treeView3e = null;
        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeView3e = e;
            if (e == null)
                return;
            statusBarPanel2.Text = "正在获取系统信息,请稍等...";
            if (e.Node.Text == "我的电脑")
            {
                SetSystem(true);
            }
            else
            {
                if (isLocal)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取系统信息失败";
                    this.listView3.Items.Clear();
                    return;
                }
                SetSystem(false);
            }
            statusBarPanel2.Text = "获取系统信息成功";
        }
        private void SetSystem(bool isMyPc)
        {
            listView3.Items.Clear();
            if (isMyPc)
            {
                SystemInfo systemInfo = new SystemInfo();
                AddlistView3Items("计算机",   systemInfo.GetMyComputerName());
                AddlistView3Items("显示器",   systemInfo.GetMyScreens());
                AddlistView3Items("CPU",      systemInfo.GetMyCpuInfo());
                AddlistView3Items("内存大小", systemInfo.GetMyMemoryInfo());
                AddlistView3Items("硬盘大小", systemInfo.GetMyDriveInfo());
                AddlistView3Items("系统版本", systemInfo.GetMyOSName());
                AddlistView3Items("当前用户", systemInfo.GetMyUserName());
                AddlistView3Items("环境变量", systemInfo.GetMyPaths());
            }
            else
            {
                AddlistView3Items("计算机",   chickens.CurrentChicken.ComputerName);
                AddlistView3Items("显示器",   chickens.CurrentChicken.Screens);
                AddlistView3Items("CPU",      chickens.CurrentChicken.Cpu);
                AddlistView3Items("内存大小", chickens.CurrentChicken.Memory);
                AddlistView3Items("硬盘大小", chickens.CurrentChicken.Drive);
                AddlistView3Items("系统版本", chickens.CurrentChicken.OSName);
                AddlistView3Items("当前用户", chickens.CurrentChicken.UserName);
                AddlistView3Items("环境变量", chickens.CurrentChicken.Paths);
            }
        }
        private void AddlistView3Items(string s1, string s2)
        {
            ListViewItem lv = new ListViewItem();
            lv.Text = s1;
            ListViewItem.ListViewSubItem l1 = new ListViewItem.ListViewSubItem();
            l1.Text = s2;
            lv.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { l1 });
            listView3.Items.Add(lv);
        }
        private void toolStripButton23_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = @"SystemInfo" + System.DateTime.Now.ToShortDateString() + @".txt";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                SaveData(listView3, sf.FileName);
                MessageBox.Show("导出文件列表成功", "导出列表", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void toolStripButton24_Click(object sender, EventArgs e)
        {
            treeView3_AfterSelect(sender, treeView3e);
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region 进程列表
        /// <summary>
        /// 进程列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private TreeViewEventArgs treeView4e = null;
        private void treeView4_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeView4e = e;
            if (e == null)
                return;
            statusBarPanel2.Text = "正在获取进程列表,请稍等...";
            if (e.Node.Text == "我的电脑")
            {
                SetProcess(true);
            }
            else
            {
                if (isLocal)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取进程列表失败";
                    this.listView4.Items.Clear();
                    return;
                }
                SetProcess(false);
            }
            statusBarPanel2.Text = "获取进程列表成功";
        }
        private void SetProcess(bool isMyPc)
        {
            listView4.Items.Clear();
            if (isMyPc)
            {
                Process[] processes = Process.GetProcesses();
                Process instance;
                for (int i = 0; i < processes.Length; i++)
                {
                    instance = processes[i];
                    string[] title = new string[5];
                    try
                    {
                        title[0] = instance.Id.ToString();
                        title[2] = instance.PrivateMemorySize.ToString() + " K";
                        title[1] = instance.MainModule.ModuleName;
                        title[3] = instance.MainModule.FileName;    
                    }
                    catch 
                    {
                        title[1] = "System";
                        title[3] = "[System Process]";
                    }
                    ListViewItem lv = new ListViewItem();
                    lv.Text = title[0];
                    ListViewItem.ListViewSubItem s1 = new ListViewItem.ListViewSubItem();
                    s1.Text = title[1];
                    ListViewItem.ListViewSubItem s2 = new ListViewItem.ListViewSubItem();
                    s2.Text = title[2];
                    ListViewItem.ListViewSubItem s3 = new ListViewItem.ListViewSubItem();
                    s3.Text = title[3];
                    lv.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { s1, s2, s3});
                    listView4.Items.Add(lv);
                }
            }
            else
            {
                if (!chickens.CurrentChicken.WriteToServer("Process list"))
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取进程列表失败";
                    this.listView4.Items.Clear();
                    return;
                }
                bool isConnected = true;
                string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (!isConnected)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取进程列表失败";
                    this.listView4.Items.Clear();
                    return;
                }
                string[] s = str.Split('\b');
                int length = s.Length;
                for (int i = 0; i < length - 1; ++i)
                {
                    string[] tempPro = s[i].Split('\t');
                    ListViewItem lv = new ListViewItem();
                    lv.Text = tempPro[0];
                    ListViewItem.ListViewSubItem s1 = new ListViewItem.ListViewSubItem();
                    s1.Text = tempPro[1];
                    ListViewItem.ListViewSubItem s2 = new ListViewItem.ListViewSubItem();
                    s2.Text = tempPro[2];
                    ListViewItem.ListViewSubItem s3 = new ListViewItem.ListViewSubItem();
                    s3.Text = tempPro[3];
                    lv.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { s1, s2, s3});
                    listView4.Items.Add(lv);
                }
            }
            return;
        }
        /// <summary>
        /// 获取进程用户
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        private string GetUserById(int pID)
        {
            SelectQuery query1 = new SelectQuery("Select   *   from   Win32_Process Where ProcessID=" + pID);
            ManagementObjectSearcher searcher1 = new ManagementObjectSearcher(query1);
            string text1 = null;
            try
            {
                foreach (ManagementObject disk in searcher1.Get())
                {

                    ManagementBaseObject inPar = null;
                    ManagementBaseObject outPar = null;

                    inPar = disk.GetMethodParameters("GetOwner");
                    outPar = disk.InvokeMethod("GetOwner", inPar, null);
                    text1 = outPar["User"].ToString();
                    break;
                }
            }
            catch (Exception e)
            {
                text1 = e.Message;
            }

            return text1;
        }
        /// <summary>
        /// 导出进程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton25_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = @"Process" + System.DateTime.Now.ToShortDateString() + @".txt";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                SaveData(listView4, sf.FileName);
                MessageBox.Show("导出文件列表成功", "导出列表", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 刷新进程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton26_Click(object sender, EventArgs e)
        {
            treeView4_AfterSelect(sender,treeView4e);
        }
        /// <summary>
        /// 结束进程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton27_Click(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count == 0)
                return;
            int pid=int.Parse(listView4.SelectedItems[0].Text);
            if (treeView4e == null)
                return;
            statusBarPanel2.Text = "正在结束进程,请稍等...";
            if (treeView4e.Node.Text == "我的电脑")
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process pro in processes)
                {
                    if (pro.Id == pid)
                    {
                        pro.Kill();
                        break;
                    }
                }
            }
            else
            {
                if (isLocal)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,结束进程失败";
                    this.listView4.Items.Clear();
                    return;
                }
                if (!chickens.CurrentChicken.WriteToServer("Process kill " + pid))
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,结束进程失败";
                    this.listView4.Items.Clear();
                    return;
                }
                bool isConnected = true;
                string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (!isConnected)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,结束进程失败";
                    this.listView4.Items.Clear();
                    return;
                }
            }
            statusBarPanel2.Text =listView4.SelectedItems[0].SubItems[0].Text+ "进程被结束";
            toolStripButton26_Click(null, null);
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region 系统服务
        /// <summary>
        /// 系统服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private TreeViewEventArgs treeView5e = null;
        private void treeView5_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeView5e = e;
            if (e == null)
                return; 
            statusBarPanel2.Text = "正在获取系统服务,请稍等..."; 
            if (e.Node.Text == "我的电脑")
            {
                SetService(true);
            }
            else
            {
                if (isLocal)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取系统服务失败";
                    this.listView5.Items.Clear();
                    return;
                }
                SetService(false);
            }
            statusBarPanel2.Text = "获取系统服务成功";
        }
        private void SetService(bool isMyPc)
        {
            listView5.Items.Clear();  
            if (isMyPc)
            {
                string TempMachineName = System.Environment.MachineName;
                ServiceController[] ArraySrvCtrl= ServiceController.GetServices(TempMachineName);
                foreach (ServiceController tempSC in ArraySrvCtrl)
                {
                    RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\" + tempSC.ServiceName);
                    string str1 = null;
                    string str2 = null;
                    try
                    {
                        str1 = reg.GetValue("Description").ToString();
                        str2 = reg.GetValue("Start").ToString(); 
                        if (str2 == "2")
                            str2 = "自动";
                        else if (str2 == "3")
                            str2 = "手动";
                        else
                            str2 = "禁用";
                    }
                    catch { }
                    ListViewItem lv = new ListViewItem();
                    lv.Text = tempSC.DisplayName;
                    ListViewItem.ListViewSubItem s1 = new ListViewItem.ListViewSubItem();
                    s1.Text = str1;
                    ListViewItem.ListViewSubItem s2 = new ListViewItem.ListViewSubItem();
                    switch (tempSC.Status)
                    {
                        case ServiceControllerStatus.Running: s2.Text = "启动"; break;
                        case ServiceControllerStatus.Paused: s2.Text = "暂停"; break;
                        case ServiceControllerStatus.Stopped: s2.Text = "停止"; break;
                        case ServiceControllerStatus.ContinuePending: s2.Text = "准备"; break;
                        case ServiceControllerStatus.StartPending: s2.Text = "准备开始"; break;
                        case ServiceControllerStatus.PausePending: s2.Text = "准备暂停"; break;
                        case ServiceControllerStatus.StopPending: s2.Text = "准备停止"; break;
                        default: s2.Text = "停止"; break;
                    }
                    ListViewItem.ListViewSubItem s3 = new ListViewItem.ListViewSubItem();
                    s3.Text = str2;
                    ListViewItem.ListViewSubItem s4 = new ListViewItem.ListViewSubItem();
                    s4.Text = tempSC.MachineName;
                    ListViewItem.ListViewSubItem s5 = new ListViewItem.ListViewSubItem();
                    s5.Text = tempSC.ServiceName;
                    lv.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { s1, s2, s3, s4,s5 });
                    listView5.Items.Add(lv);
                }  
                try
                { }
                catch { }
            }
            else
            {
                if (!chickens.CurrentChicken.WriteToServer("Service list"))
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取系统服务失败";
                    this.listView5.Items.Clear();
                    return;
                }
                bool isConnected = true;
                string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (!isConnected)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取系统服务失败";
                    this.listView5.Items.Clear();
                    return;
                }
                string[] s = str.Split('\b');
                int length=s.Length;
                for (int i = 0; i < length - 1;++i )
                {
                    string[] tempSC = s[i].Split('\t');
                    ListViewItem lv = new ListViewItem();
                    lv.Text = tempSC[0];
                    ListViewItem.ListViewSubItem s1 = new ListViewItem.ListViewSubItem();
                    s1.Text = tempSC[1];
                    ListViewItem.ListViewSubItem s2 = new ListViewItem.ListViewSubItem();
                    switch (tempSC[2])
                    {
                        case "Running": s2.Text = "启动"; break;
                        case "Paused": s2.Text = "暂停"; break;
                        case "Stopped": s2.Text = "停止"; break;
                        case "ContinuePending": s2.Text = "准备"; break;
                        case "StartPending": s2.Text = "准备开始"; break;
                        case "PausePending": s2.Text = "准备暂停"; break;
                        case "StopPending": s2.Text = "准备停止"; break;
                        default: s2.Text = tempSC[2]; break;
                    }
                    ListViewItem.ListViewSubItem s3 = new ListViewItem.ListViewSubItem();
                    switch (tempSC[3])
                    {
                        case "2": s3.Text = "自动"; break;
                        case "3": s3.Text = "手动"; break;
                        default : s3.Text = "禁用"; break;
                    }
                    ListViewItem.ListViewSubItem s4 = new ListViewItem.ListViewSubItem();
                    s4.Text = tempSC[4];
                    ListViewItem.ListViewSubItem s5 = new ListViewItem.ListViewSubItem();
                    s5.Text = tempSC[5];
                    lv.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { s1, s2, s3, s4,s5 });
                    listView5.Items.Add(lv);
                }
            }
            return;
        }
        /// <summary>
        /// 导出服务列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton34_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = @"Service" + System.DateTime.Now.ToShortDateString() + @".txt";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                SaveData(listView5, sf.FileName);
                MessageBox.Show("导出文件列表成功", "导出列表", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }
        /// <summary>
        /// 刷新服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton35_Click(object sender, EventArgs e)
        {
            treeView5_AfterSelect(sender,treeView5e);
        }
        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton36_Click(object sender, EventArgs e)
        {
            if (listView5.SelectedItems.Count == 0 || treeView5e == null)
                return;
            statusBarPanel2.Text = "正在启动服务,请稍等...";
            string s0 = listView5.SelectedItems[0].SubItems[5].Text;
            if (treeView5e.Node.Text == "我的电脑")
            {
                ServiceController tempSC = new ServiceController(s0);
                try
                {
                    tempSC.Start();
                }
                catch { }
            }
            else
            {
                if (isLocal)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,启动服务失败";
                    this.listView8.Items.Clear();
                    return;
                }
                if (!chickens.CurrentChicken.WriteToServer("Service start " + s0))
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,启动服务失败";
                    this.listView8.Items.Clear();
                    return;
                }
                bool isConnected = true;
                string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (!isConnected)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,启动服务失败";
                    this.listView8.Items.Clear();
                    return;
                }
            }
            statusBarPanel2.Text = s0 + "服务已启动";
            toolStripButton35_Click(null, null);
        }
        /// <summary>
        /// 停止服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton46_Click(object sender, EventArgs e)
        {
            if (listView5.SelectedItems.Count == 0 || treeView5e == null)
                return;
            statusBarPanel2.Text = "正在停止服务,请稍等...";
            string s0 = listView5.SelectedItems[0].SubItems[5].Text;
            if (treeView5e.Node.Text == "我的电脑")
            {
                ServiceController tempSC = new ServiceController(s0);
                try
                {
                    tempSC.Stop();
                }
                catch { }
            }
            else
            {
                if (isLocal)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,停止服务失败";
                    this.listView8.Items.Clear();
                    return;
                }
                if(!chickens.CurrentChicken.WriteToServer("Service stop " + s0))
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,停止服务失败";
                    this.listView8.Items.Clear();
                    return;
                }
                bool isConnected = true;
                string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (!isConnected)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,停止服务失败";
                    this.listView8.Items.Clear();
                    return;
                }
            }
            statusBarPanel2.Text = s0 + "服务已停止";
            toolStripButton35_Click(null, null);
        }
        
        /// <summary>
        /// 设为自动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton49_Click(object sender, EventArgs e)
        {
            SetServiceStart(2);
        }
        /// <summary>
        /// 设为手动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton50_Click(object sender, EventArgs e)
        {
            SetServiceStart(3);
        }
        /// <summary>
        /// 设为禁用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton51_Click(object sender, EventArgs e)
        {
            SetServiceStart(1);
        }
        private void SetServiceStart(int i)
        {
            if (listView5.SelectedItems.Count == 0 || treeView5e == null)
                return;
            statusBarPanel2.Text = "正在设置服务启动类型,请稍等...";
            string s0 = listView5.SelectedItems[0].SubItems[5].Text;
            if (treeView5e.Node.Text == "我的电脑")
            {
                ServiceController tempSC = new ServiceController(s0);
                RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\" + tempSC.ServiceName, true);
                try
                {
                    reg.SetValue("Start", i);
                }
                catch { }
            }
            else
            {
                if (isLocal)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,设置服务启动类型失败";
                    this.listView8.Items.Clear();
                    return;
                } 
                if(!chickens.CurrentChicken.WriteToServer("Service autostart " + s0 + "\t" + i.ToString()))
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,设置服务启动类型失败";
                    this.listView8.Items.Clear();
                    return;
                }
                bool isConnected = true;
                string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (!isConnected)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,设置服务启动类型失败";
                    this.listView8.Items.Clear();
                    return;
                }
            }
            string s = "禁用";
            switch(i)
            {
                case 1:s="禁用";break;
                case 2:s="自动";break;
                case 3:s="手动";break;
            }
            statusBarPanel2.Text = s0 + "服务已设置为"+s;
            toolStripButton35_Click(null, null);
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region 事件日志
        /// <summary>
        /// 事件日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private TreeViewEventArgs treeView6e = null;
        private void treeView6_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeView6e = e;
            if (e == null)
                return;
            string mod = null;
            switch (e.Node.Text)
            {
                case "应用程序": mod = "Application"; break;
                case "安全性": mod = "Security"; break;
                case "系统": mod = "System"; break;
                default: mod = null; break;
            }
            if (mod == null)
                return;
            statusBarPanel2.Text = "正在获取事件日志,请稍等...";
            if (e.Node.Parent!=null&&e.Node.Parent.Text == "我的电脑")
            {
                SetEventLog(mod,true);
            }
            else if (e.Node.Parent!=null&&e.Node.Parent.Text == "远程主机")
            {
                if (isLocal)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取事件日志失败";
                    this.listView6.Items.Clear();
                    return;
                }
                SetEventLog(mod, false);
            }
            statusBarPanel2.Text = "获取事件日志成功";
        }
        /// <summary>
        /// 获取事件日志并填冲列表视图
        /// </summary>
        /// <param name="mod"></param>
        /// <param name="isMyPc"></param>
        private void SetEventLog(string mod, bool isMyPc)
        {
            listView6.Items.Clear();
            if (isMyPc)
            {
                EventLogEntryCollection eventCollection;
                EventLog systemEvent;
                systemEvent = new EventLog();
                systemEvent.Log = mod;
                eventCollection = systemEvent.Entries;
                int length = eventCollection.Count;
                for (int i = length - 1; i >= 0; --i)
                {
                    EventLogEntry entry = eventCollection[i];
                    ListViewItem lv = new ListViewItem();        
                    switch (entry.EntryType.ToString())
                    {
                        case "Information": lv.Text = "信息"; break;
                        case "Warning": lv.Text = "警告"; break;
                        case "Error": lv.Text = "错误"; break;
                        case "SuccessAudit": lv.Text = "审核成功"; break;
                        default: lv.Text = entry.EntryType.ToString(); break;
                    }
                    ListViewItem.ListViewSubItem s1 = new ListViewItem.ListViewSubItem();
                    s1.Text = entry.TimeGenerated.ToLongDateString();
                    ListViewItem.ListViewSubItem s2 = new ListViewItem.ListViewSubItem();
                    s2.Text = entry.TimeGenerated.ToLongTimeString();
                    ListViewItem.ListViewSubItem s3 = new ListViewItem.ListViewSubItem();
                    s3.Text = entry.Source;
                    ListViewItem.ListViewSubItem s4 = new ListViewItem.ListViewSubItem();
                    s4.Text = entry.Category;
                    ListViewItem.ListViewSubItem s5 = new ListViewItem.ListViewSubItem();
                    s5.Text = entry.EventID.ToString();
                    ListViewItem.ListViewSubItem s6 = new ListViewItem.ListViewSubItem();
                    s6.Text = entry.UserName;
                    ListViewItem.ListViewSubItem s7 = new ListViewItem.ListViewSubItem();
                    s7.Text = entry.MachineName;
                    ListViewItem.ListViewSubItem s8 = new ListViewItem.ListViewSubItem();
                    s8.Text = entry.Message;
                    lv.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { s1, s2, s3, s4, s5, s6, s7, s8 });
                    listView6.Items.Add(lv);
                }
            }
            else
            {
                if (!chickens.CurrentChicken.WriteToServer("EventLog list " + mod))
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取事件日志失败";
                    this.listView6.Items.Clear();
                    return;
                }
                bool isConnected = true;
                string ss = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (!isConnected)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取事件日志失败";
                    this.listView6.Items.Clear();
                    return;
                }
                string[]s = ss.Split('\b');
                int length = s.Length;
                for (int i = 0; i < length - 1; ++i)
                {
                    string[] str = s[i].Split('\t');
                    ListViewItem lv = new ListViewItem();        
                    switch (str[0])
                    {
                        case "Information": lv.Text = "信息"; break;
                        case "Warning": lv.Text = "警告"; break;
                        case "Error": lv.Text = "错误"; break;
                        case "SuccessAudit": lv.Text = "审核成功"; break;
                        default: lv.Text = str[0]; break;
                    }
                    ListViewItem.ListViewSubItem s1 = new ListViewItem.ListViewSubItem();
                    s1.Text = str[1];
                    ListViewItem.ListViewSubItem s2 = new ListViewItem.ListViewSubItem();
                    s2.Text = str[2];
                    ListViewItem.ListViewSubItem s3 = new ListViewItem.ListViewSubItem();
                    s3.Text = str[3];
                    ListViewItem.ListViewSubItem s4 = new ListViewItem.ListViewSubItem();
                    s4.Text = str[4];
                    ListViewItem.ListViewSubItem s5 = new ListViewItem.ListViewSubItem();
                    s5.Text = str[5];
                    ListViewItem.ListViewSubItem s6 = new ListViewItem.ListViewSubItem();
                    s6.Text = str[6];
                    ListViewItem.ListViewSubItem s7 = new ListViewItem.ListViewSubItem();
                    s7.Text = str[7];
                    ListViewItem.ListViewSubItem s8 = new ListViewItem.ListViewSubItem();
                    s8.Text = str[8];
                    lv.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { s1, s2, s3, s4, s5, s6, s7, s8 });
                    listView6.Items.Add(lv);
                }
            }
            return;
        }
        /// <summary>
        /// 单一事件属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView6_DoubleClick(object sender, EventArgs e)
        {
            if (listView6.SelectedItems.Count == 0)
                return;
            ShowLogForm f = new ShowLogForm();
            f.label10.Text = listView6.SelectedItems[0].SubItems[1].Text;
            f.label11.Text = listView6.SelectedItems[0].SubItems[3].Text;
            f.label12.Text = listView6.SelectedItems[0].SubItems[2].Text;
            f.label13.Text = listView6.SelectedItems[0].SubItems[4].Text;
            f.label14.Text = listView6.SelectedItems[0].SubItems[0].Text;
            f.label15.Text = listView6.SelectedItems[0].SubItems[5].Text;
            f.label16.Text = listView6.SelectedItems[0].SubItems[6].Text;
            f.label17.Text = listView6.SelectedItems[0].SubItems[7].Text;
            f.textBox1.Text = listView6.SelectedItems[0].SubItems[8].Text;
            f.ShowDialog();
        }
        private void toolStripButton37_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = @"EventLog" + System.DateTime.Now.ToShortDateString() + @".txt";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                SaveData(listView6, sf.FileName);
                MessageBox.Show("导出文件列表成功", "导出列表", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton38_Click(object sender, EventArgs e)
        {
            treeView6_AfterSelect(sender,treeView6e);
        }

        private void toolStripButton39_Click(object sender, EventArgs e)
        {
            if (treeView6e == null || treeView6e.Node.Parent == null)
                return;
            statusBarPanel2.Text = "正在删除事件日志,请稍等...";
            string mod = null;
            switch (treeView6e.Node.Text)
            {
                case "应用程序": mod = "Application"; break;
                case "安全性": mod = "Security"; break;
                case "系统": mod = "System"; break;
                default: mod = null; break;
            }
            if (mod == null)
            {
                statusBarPanel2.Text = "删除事件日志失败";
                return;
            }
            if (treeView6e.Node.Parent.Text == "我的电脑")
            {
                if (MessageBox.Show("确定全部删除" + treeView6e.Node.Text + "事件日志？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    statusBarPanel2.Text = "已取消删除事件日志";
                    return;
                }
                EventLog systemEvent = new EventLog();
                systemEvent.Log = mod;
                systemEvent.Clear();
            }
            else if (treeView6e.Node.Parent.Text == "远程主机")
            {
                if (isLocal)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,删除事件日志失败";
                    this.listView6.Items.Clear();
                    return;
                }
                if (MessageBox.Show("确定全部删除" + treeView6e.Node.Text + "事件日志？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    statusBarPanel2.Text = "已取消删除事件日志";
                    return;
                }
                if(!chickens.CurrentChicken.WriteToServer("EventLog del " + mod))
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,删除事件日志失败";
                    this.listView6.Items.Clear();
                    return;
                } 
                bool isConnected = true;
                string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (!isConnected)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,删除事件日志失败";
                    this.listView6.Items.Clear();
                    return;
                } 
            }
            statusBarPanel2.Text = "删除事件日志成功";
            toolStripButton38_Click(null,null);
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region 网络连接
        private TreeViewEventArgs treeView7e = null;
        private void treeView7_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeView7e = e;
            if (e == null)
                return; 
            statusBarPanel2.Text = "正在获取网络连接,请稍等..."; 
            if (e.Node.Text == "我的电脑")
            {
                SetNetWork(true);
            }
            else
            {
                if (isLocal)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取网络连接失败";
                    this.listView7.Items.Clear();
                    return;
                }
                SetNetWork(false);
            }
            statusBarPanel2.Text = "获取网络连接成功";
        }
        private void SetNetWork(bool isMyPc)
        {
            listView7.Items.Clear();
            if (isMyPc)
            {
                ArrayList arr = GetNetstart();
                foreach (string a in arr)
                {
                    string[] str = a.Split('\n');
                    ArrayList arr1 = GetProcess(int.Parse(str[4]));
                    try
                    {
                        ListViewItem lv = new ListViewItem(new string[] { str[0], arr1[0].ToString(), str[1], str[2], str[3], str[4], arr1[1].ToString() });
                        listView7.Items.Add(lv);
                    }
                    catch { }
                }
            }
            else
            {
                if (!chickens.CurrentChicken.WriteToServer("NetWork"))
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取网络连接失败";
                    this.listView7.Items.Clear();
                    return;
                }
                bool isConnected = true;
                string ss = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (!isConnected)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取网络连接失败";
                    this.listView7.Items.Clear();
                    return;
                }
                string[] s = ss.Split('\n');
                int length = s.Length;
                for (int i = 0; i < length - 1; ++i)
                {
                    string[] str = s[i].Split('\t');
                    try
                    {
                        ListViewItem lv = new ListViewItem(new string[] { str[0], str[1], str[2], str[3], str[4], str[5], str[6], });
                        listView7.Items.Add(lv);
                    }
                    catch { }
                }
            }
        }
        private ArrayList GetNetstart()
        {
            ArrayList arr = new ArrayList();
            string str = Jackch.Cmd.RunCmd("netstat -ano");
            string[] s = str.Split('\n');
            for (int i = 4; i < s.Length; ++i)
            {
                string now = "";
                string all = "";
                int count = 0;
                for (int j = 0; j < s[i].Length; ++j)
                {
                    if (s[i][j] == ' ')
                    {
                        if (now != "")
                        {
                            ++count;
                            all += now + "\n";
                        }
                        now = "";
                    }
                    else
                        now += s[i][j];
                }
                all += now;
                if (count < 4)
                    break;
                arr.Add(all);
            }
            return arr;
        }
        private ArrayList GetProcess(int pid)
        {
            ArrayList arr = new ArrayList();
            Process[] processes = Process.GetProcesses();
            for (int i = 0; i < processes.Length; i++)
            {
                if (pid == processes[i].Id)
                {
                    try
                    {
                        arr.Add(processes[i].MainModule.ModuleName);
                        arr.Add(processes[i].MainModule.FileName);
                    }
                    catch 
                    {
                        arr.Clear();
                        arr.Add("System");
                        arr.Add("[System Process]");
                    }
                    break;
                }
            }
            return arr;
        }
        private void toolStripButton40_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = @"NetWork" + System.DateTime.Now.ToShortDateString() + @".txt";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                SaveData(listView7, sf.FileName);
                MessageBox.Show("导出文件列表成功", "导出列表", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void toolStripButton41_Click(object sender, EventArgs e)
        {
            treeView7_AfterSelect(sender, treeView7e);
        }

        private void toolStripButton42_Click(object sender, EventArgs e)
        {
            if (listView7.SelectedItems.Count == 0 || treeView7e == null)
                return;
            int pid = int.Parse(listView7.SelectedItems[0].SubItems[5].Text);
             statusBarPanel2.Text = "正在删除网络连接,请稍等...";
            if (treeView7e.Node.Text == "我的电脑")
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process pro in processes)
                {
                    if (pro.Id == pid)
                    {
                        pro.Kill();
                        break;
                    }
                }
            }
            else
            {
                if (isLocal)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,删除网络连接失败";
                    this.listView7.Items.Clear();
                    return;
                }
                if(!chickens.CurrentChicken.WriteToServer("Process kill " + pid))
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,删除网络连接失败";
                    this.listView7.Items.Clear();
                    return;
                }
                bool isConnected = true;
                string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (!isConnected)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,删除网络连接失败";
                    this.listView7.Items.Clear();
                    return;
                }
            }
            statusBarPanel2.Text = listView7.SelectedItems[0].SubItems[0].Text + "连接被删除";
            toolStripButton41_Click(null, null);
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region 开机启动
        /// <summary>
        /// 开机启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private TreeViewEventArgs treeView8e = null;
        private void treeView8_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeView8e = e;
            if (e == null)
                return; 
            statusBarPanel2.Text = "正在获取开机启动,请稍等..."; 
            if (e.Node.Text == "我的电脑")
            {
                SetStartUp(true);
            }
            else
            {
                if (isLocal)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取开机启动失败";
                    this.listView8.Items.Clear();
                    return;
                }
                SetStartUp(false);
            }
            statusBarPanel2.Text = "获取开机启动成功";
        }
        private void SetStartUp(bool isMyPc)
        {
            listView8.Items.Clear();
            if (isMyPc)
            {
                ReadStartUpRegistry("HKEY_LOCAL_MACHINE", "Run");
                ReadStartUpRegistry("HKEY_LOCAL_MACHINE", "RunOnce");
                ReadStartUpRegistry("HKEY_LOCAL_MACHINE", "RunOnceEx");
                ReadStartUpRegistry("HKEY_LOCAL_MACHINE", "RunServices");
                ReadStartUpRegistry("HKEY_LOCAL_MACHINE", "RunServicesOnce");
                ReadStartUpRegistry("HKEY_CURRENT_USER", "Run");
                ReadStartUpRegistry("HKEY_CURRENT_USER", "RunOnce");
                ReadStartUpFolder("User Name Enabled");
                ReadStartUpFolder("All Users Enabled");
                ReadStartUpFolder("User Name Disabled");
                ReadStartUpFolder("All Users Disabled");
            }
            else
            {
                if (!chickens.CurrentChicken.WriteToServer("StartUp list"))
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取开机启动失败";
                    this.listView8.Items.Clear();
                    return;
                }
                bool isConnected = true;
                string ss = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (!isConnected)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,获取开机启动失败";
                    this.listView8.Items.Clear();
                    return;
                }
                string[]s = ss.Split('\n');
                int length = s.Length;
                for (int i = 0; i < length - 1; ++i)
                {
                    string[] str = s[i].Split('\b');
                    ListViewItem lv = new ListViewItem();
                    lv.Text = str[0];
                    ListViewItem.ListViewSubItem s1 = new ListViewItem.ListViewSubItem();
                    s1.Text = str[1];
                    ListViewItem.ListViewSubItem s2 = new ListViewItem.ListViewSubItem();
                    s2.Text = str[2];
                    lv.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { s1, s2 });
                    listView8.Items.Add(lv);
                }
            }
        }
        private void ReadStartUpRegistry(string hkey, string Suffix)
        {
            RegistryKey GlobalReg = Registry.LocalMachine;
            string TheKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\";
            try
            {
                switch (hkey)
                {
                    case "HKEY_LOCAL_MACHINE":
                        GlobalReg = Registry.LocalMachine.OpenSubKey(TheKey + Suffix);
                        break;

                    case "HKEY_CURRENT_USER":
                        GlobalReg = Registry.CurrentUser.OpenSubKey(TheKey + Suffix);
                        break;

                    case "HKEY_CLASSES_ROOT":
                        GlobalReg = Registry.ClassesRoot.OpenSubKey(TheKey + Suffix);
                        break;

                    case "HKEY_CURRENT_CONFIG":
                        GlobalReg = Registry.CurrentConfig.OpenSubKey(TheKey + Suffix);
                        break;

                    case "HKEY_USERS":
                        GlobalReg = Registry.Users.OpenSubKey(TheKey + Suffix);
                        break;
                }
                if (GlobalReg.ValueCount != 0)
                {
                    foreach (string s in GlobalReg.GetValueNames())
                    {
                        ListViewItem lv = new ListViewItem();
                        lv.Text = s;
                        ListViewItem.ListViewSubItem s1 = new ListViewItem.ListViewSubItem();
                        s1.Text = hkey + "\\" + TheKey + Suffix;
                        ListViewItem.ListViewSubItem s2 = new ListViewItem.ListViewSubItem();
                        s2.Text = GlobalReg.GetValue(s).ToString();
                        lv.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { s1, s2 });
                        listView8.Items.Add(lv);
                    }
                }
            }
            catch { }
        }
        private void ReadStartUpFolder(string Root)
        {
            RegistryKey GlobalReg = Registry.LocalMachine;
            DirectoryInfo GlobalDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Startup));
            try
            {
                switch (Root)
                {
                    case "All Users Enabled":
                        Root = "All Users";
                        GlobalReg = Registry.LocalMachine.OpenSubKey
                            (@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", true);
                        GlobalDir = new DirectoryInfo(GlobalReg.GetValue("Common Startup", "C:\\").ToString());

                        GlobalReg.Close();
                        break;

                    case "User Name Enabled":
                        Root = Environment.UserName;
                        GlobalDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Startup));
                        break;

                    case "All Users Disabled":
                        Root = "All Users";
                        GlobalDir = new DirectoryInfo(Application.StartupPath + @"\BackUps\All Users");
                        break;

                    case "User Name Disabled":
                        Root = Environment.UserName;
                        GlobalDir = new DirectoryInfo(Application.StartupPath + @"\BackUps\" + Environment.UserName);

                        break;
                }
                if (GlobalDir.Exists)
                {
                    foreach (FileInfo SingleIt in GlobalDir.GetFiles("*.*"))
                    {
                        if (SingleIt.Name != "desktop.ini")
                        {
                            ListViewItem lv = new ListViewItem();
                            lv.Text = SingleIt.Name;
                            ListViewItem.ListViewSubItem s1 = new ListViewItem.ListViewSubItem();
                            s1.Text = SingleIt.FullName;
                            ListViewItem.ListViewSubItem s2 = new ListViewItem.ListViewSubItem();
                            s2.Text = SingleIt.FullName;
                            lv.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { s1, s2 });
                            listView8.Items.Add(lv);
                        }
                    }
                }
            }
            catch { }
        }
        
        private void toolStripButton43_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = @"StartUp" + System.DateTime.Now.ToShortDateString() + @".txt";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                SaveData(listView8, sf.FileName);
                MessageBox.Show("导出文件列表成功", "导出列表", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }
        private void toolStripButton44_Click(object sender, EventArgs e)
        {
            treeView8_AfterSelect(sender, treeView8e);
        }
        private void toolStripButton45_Click(object sender, EventArgs e)
        {
            if (listView8.SelectedItems.Count == 0 || treeView8e == null)
                return;
            statusBarPanel2.Text = "正在删除开机启动,请稍等...";
            string s0 = listView8.SelectedItems[0].SubItems[0].Text;
            string s1 = listView8.SelectedItems[0].SubItems[1].Text;
            if (treeView8e.Node.Text == "我的电脑")
            {
                if (File.Exists(s1))
                    File.Delete(s1);
                else
                {
                    RegistryKey GlobalReg = Registry.LocalMachine;
                    string hkey = s1.Split('\\')[0];
                    string TheKey = s1.Substring(s1.IndexOf('\\')+1);
                    try
                    {
                        switch (hkey)
                        {
                            case "HKEY_LOCAL_MACHINE":
                                GlobalReg = Registry.LocalMachine.OpenSubKey(TheKey, true);
                                break;

                            case "HKEY_CURRENT_USER":
                                GlobalReg = Registry.CurrentUser.OpenSubKey(TheKey, true);
                                break;

                            case "HKEY_CLASSES_ROOT":
                                GlobalReg = Registry.ClassesRoot.OpenSubKey(TheKey, true);
                                break;

                            case "HKEY_CURRENT_CONFIG":
                                GlobalReg = Registry.CurrentConfig.OpenSubKey(TheKey, true);
                                break;

                            case "HKEY_USERS":
                                GlobalReg = Registry.Users.OpenSubKey(TheKey, true);
                                break;
                        }
                        GlobalReg.DeleteValue(s0);
                    }
                    catch { }
                }
            }
            else
            {
                if (isLocal)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,删除开机启动失败";
                    this.listView8.Items.Clear();
                    return;
                }
                if(!chickens.CurrentChicken.WriteToServer("StartUp kill " + s0 + "\t" + s1))
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,删除开机启动失败";
                    this.listView8.Items.Clear();
                    return;
                }
                bool isConnected = true;
                string str = chickens.CurrentChicken.ReadFromServer(out isConnected);
                if (!isConnected)
                {
                    statusBarPanel2.Text = "远程主机没有连接或已断开连接,删除开机启动失败";
                    this.listView8.Items.Clear();
                    return;
                }
            }
            statusBarPanel2.Text = listView8.SelectedItems[0].SubItems[0].Text + "开机启动被删除";
            toolStripButton44_Click(null, null);
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void SaveData(ListView lv, string file)
        {
            FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            foreach (ListViewItem l in lv.Items)
            {
                //sw.Write(l.Text + "\t");
                foreach (ListViewItem.ListViewSubItem ll in l.SubItems)
                    sw.Write(ll.Text + "\t");
                sw.Write("\r\n");
            }
            sw.Close();
            fs.Close();
        }
    }
}