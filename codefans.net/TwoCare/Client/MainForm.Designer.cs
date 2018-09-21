using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.Win32;
using FarsiLibrary.Win;

namespace Jackch
{
    partial class MainForm
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
                try
                {
                    thread.Abort();
                    threadConnected.Abort();
                    threadTrans.Abort();
                }
                catch
                {
                
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("我的电脑", 20, 20);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("远程主机", 20, 20);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("我的电脑", 20, 20);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("远程主机", 20, 20);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("HKEY_CLASSES_ROOT");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("HKEY_CURRENT_USER");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("HKEY_LOCAL_MACHINE");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("HKEY_USERS");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("HKEY_CURRENT_CONFIG");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("我的电脑", 20, 20, new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("HKEY_CLASSES_ROOT");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("HKEY_CURRENT_USER");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("HKEY_LOCAL_MACHINE");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("HKEY_USERS");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("HKEY_CURRENT_CONFIG");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("远程主机", 20, 20, new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("我的电脑", 20, 20);
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("远程主机", 20, 20);
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("应用程序", 18, 18);
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("安全性", 18, 18);
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("系统", 18, 18);
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("我的电脑", 20, 20, new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("应用程序", 18, 18);
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("安全性", 18, 18);
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("系统", 18, 18);
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("远程主机", 20, 20, new System.Windows.Forms.TreeNode[] {
            treeNode23,
            treeNode24,
            treeNode25});
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("我的电脑", 20, 20);
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("远程主机", 20, 20);
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("我的电脑", 20, 20);
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("远程主机", 20, 20);
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton8 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton9 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton35 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton11 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton12 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton10 = new System.Windows.Forms.ToolBarButton();
            this.imageListImg = new System.Windows.Forms.ImageList(this.components);
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemIP = new System.Windows.Forms.MenuItem();
            this.menuItemDuanKou = new System.Windows.Forms.MenuItem();
            this.menuItemPeiZhi = new System.Windows.Forms.MenuItem();
            this.menuItemXieZai = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemSet = new System.Windows.Forms.MenuItem();
            this.menuItemSystem = new System.Windows.Forms.MenuItem();
            this.menuItemSkin = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItemAddDesk = new System.Windows.Forms.MenuItem();
            this.menuItemAddKuai = new System.Windows.Forms.MenuItem();
            this.menuItemAddKai = new System.Windows.Forms.MenuItem();
            this.menuItemView = new System.Windows.Forms.MenuItem();
            this.menuItemToolBar = new System.Windows.Forms.MenuItem();
            this.menuItemIPJiLu = new System.Windows.Forms.MenuItem();
            this.menuItemGong = new System.Windows.Forms.MenuItem();
            this.menuItemHost = new System.Windows.Forms.MenuItem();
            this.menuItemFileManage = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItemPing = new System.Windows.Forms.MenuItem();
            this.menuItemViod = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItemSystemManage = new System.Windows.Forms.MenuItem();
            this.menuItemDOS = new System.Windows.Forms.MenuItem();
            this.menuItemKey = new System.Windows.Forms.MenuItem();
            this.menuItemAllDos = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.menuItemUseHelp = new System.Windows.Forms.MenuItem();
            this.menuItemZhuYe = new System.Windows.Forms.MenuItem();
            this.menuItemMin = new System.Windows.Forms.MenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.cxMenuItemOpen = new System.Windows.Forms.MenuItem();
            this.cxMenuItemZhuYe = new System.Windows.Forms.MenuItem();
            this.cxMenuItemExit = new System.Windows.Forms.MenuItem();
            this.AllImageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton0 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.大图标ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.小图标ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.详细资源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton22 = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.TreeImageList = new System.Windows.Forms.ImageList(this.components);
            this.listViewFile = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenu3 = new System.Windows.Forms.ContextMenu();
            this.menuItem35 = new System.Windows.Forms.MenuItem();
            this.menuItem36 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem29 = new System.Windows.Forms.MenuItem();
            this.menuItem30 = new System.Windows.Forms.MenuItem();
            this.menuItem31 = new System.Windows.Forms.MenuItem();
            this.menuItem32 = new System.Windows.Forms.MenuItem();
            this.menuItem33 = new System.Windows.Forms.MenuItem();
            this.menuItem34 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.menuItem23 = new System.Windows.Forms.MenuItem();
            this.menuItem24 = new System.Windows.Forms.MenuItem();
            this.menuItem25 = new System.Windows.Forms.MenuItem();
            this.menuItem26 = new System.Windows.Forms.MenuItem();
            this.menuItem27 = new System.Windows.Forms.MenuItem();
            this.menuItem28 = new System.Windows.Forms.MenuItem();
            this.LargeimageList = new System.Windows.Forms.ImageList(this.components);
            this.SmallimageList = new System.Windows.Forms.ImageList(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.faTabStrip1 = new FarsiLibrary.Win.FATabStrip();
            this.faTabStripItem1 = new FarsiLibrary.Win.FATabStripItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip11 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton47 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton48 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton57 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton59 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton60 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton62 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton63 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton58 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton61 = new System.Windows.Forms.ToolStripButton();
            this.faTabStripItem2 = new FarsiLibrary.Win.FATabStripItem();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton23 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton24 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.treeView3 = new System.Windows.Forms.TreeView();
            this.listView3 = new System.Windows.Forms.ListView();
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader49 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.faTabStripItem3 = new FarsiLibrary.Win.FATabStripItem();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton25 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton26 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton27 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.treeView4 = new System.Windows.Forms.TreeView();
            this.listView4 = new System.Windows.Forms.ListView();
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.faTabStripItem4 = new FarsiLibrary.Win.FATabStripItem();
            this.toolStrip6 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton28 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton29 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton30 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton52 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton53 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton54 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton55 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton56 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader46 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader47 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader48 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.faTabStripItem5 = new FarsiLibrary.Win.FATabStripItem();
            this.toolStrip7 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton34 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton35 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton36 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton46 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton49 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton50 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton51 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.treeView5 = new System.Windows.Forms.TreeView();
            this.listView5 = new System.Windows.Forms.ListView();
            this.columnHeader41 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader42 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader43 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader44 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader45 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader57 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.faTabStripItem6 = new FarsiLibrary.Win.FATabStripItem();
            this.toolStrip8 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton37 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton38 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton39 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.treeView6 = new System.Windows.Forms.TreeView();
            this.listView6 = new System.Windows.Forms.ListView();
            this.columnHeader33 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader34 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader35 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader36 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader37 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader39 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader40 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.faTabStripItem7 = new FarsiLibrary.Win.FATabStripItem();
            this.toolStrip9 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton40 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton41 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton42 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.treeView7 = new System.Windows.Forms.TreeView();
            this.listView7 = new System.Windows.Forms.ListView();
            this.columnHeader50 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader51 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader52 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader53 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader54 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader55 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader56 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.faTabStripItem8 = new FarsiLibrary.Win.FATabStripItem();
            this.toolStrip10 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton43 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton44 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton45 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer8 = new System.Windows.Forms.SplitContainer();
            this.treeView8 = new System.Windows.Forms.TreeView();
            this.listView8 = new System.Windows.Forms.ListView();
            this.AmoodName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AmoodData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AmoodRoot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton16 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton17 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton18 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton19 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton20 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton21 = new System.Windows.Forms.ToolStripButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton31 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton32 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton33 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.断点续传ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.覆盖模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView9 = new System.Windows.Forms.ListView();
            this.columnHeader58 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ControlImageList = new System.Windows.Forms.ImageList(this.components);
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader32 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.faTabStrip1)).BeginInit();
            this.faTabStrip1.SuspendLayout();
            this.faTabStripItem1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip11.SuspendLayout();
            this.faTabStripItem2.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.faTabStripItem3.SuspendLayout();
            this.toolStrip5.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.faTabStripItem4.SuspendLayout();
            this.toolStrip6.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.faTabStripItem5.SuspendLayout();
            this.toolStrip7.SuspendLayout();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.faTabStripItem6.SuspendLayout();
            this.toolStrip8.SuspendLayout();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            this.faTabStripItem7.SuspendLayout();
            this.toolStrip9.SuspendLayout();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            this.faTabStripItem8.SuspendLayout();
            this.toolStrip10.SuspendLayout();
            this.splitContainer8.Panel1.SuspendLayout();
            this.splitContainer8.Panel2.SuspendLayout();
            this.splitContainer8.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButton1,
            this.toolBarButton5,
            this.toolBarButton2,
            this.toolBarButton6,
            this.toolBarButton3,
            this.toolBarButton8,
            this.toolBarButton4,
            this.toolBarButton9,
            this.toolBarButton35,
            this.toolBarButton11,
            this.toolBarButton7,
            this.toolBarButton12,
            this.toolBarButton10});
            this.toolBar1.ButtonSize = new System.Drawing.Size(60, 55);
            this.toolBar1.CausesValidation = false;
            this.toolBar1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolBar1.ImageList = this.imageListImg;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(795, 57);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ImageIndex = 9;
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Tag = "";
            this.toolBarButton1.Text = "自动上线";
            // 
            // toolBarButton5
            // 
            this.toolBarButton5.Name = "toolBarButton5";
            this.toolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.ImageIndex = 1;
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Text = "配置服务器";
            // 
            // toolBarButton6
            // 
            this.toolBarButton6.Name = "toolBarButton6";
            this.toolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.ImageIndex = 2;
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Text = "远程桌面";
            // 
            // toolBarButton8
            // 
            this.toolBarButton8.Name = "toolBarButton8";
            this.toolBarButton8.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.ImageIndex = 3;
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Text = "视频监控";
            // 
            // toolBarButton9
            // 
            this.toolBarButton9.Name = "toolBarButton9";
            this.toolBarButton9.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton35
            // 
            this.toolBarButton35.ImageIndex = 5;
            this.toolBarButton35.Name = "toolBarButton35";
            this.toolBarButton35.Text = "监视记录";
            // 
            // toolBarButton11
            // 
            this.toolBarButton11.Name = "toolBarButton11";
            this.toolBarButton11.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton7
            // 
            this.toolBarButton7.ImageIndex = 18;
            this.toolBarButton7.Name = "toolBarButton7";
            this.toolBarButton7.Text = "命令提示符";
            // 
            // toolBarButton12
            // 
            this.toolBarButton12.Name = "toolBarButton12";
            this.toolBarButton12.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton10
            // 
            this.toolBarButton10.ImageIndex = 17;
            this.toolBarButton10.Name = "toolBarButton10";
            this.toolBarButton10.Text = "社区帮助";
            // 
            // imageListImg
            // 
            this.imageListImg.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListImg.ImageStream")));
            this.imageListImg.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListImg.Images.SetKeyName(0, "1.png");
            this.imageListImg.Images.SetKeyName(1, "2.png");
            this.imageListImg.Images.SetKeyName(2, "3.png");
            this.imageListImg.Images.SetKeyName(3, "4.png");
            this.imageListImg.Images.SetKeyName(4, "5.png");
            this.imageListImg.Images.SetKeyName(5, "6.png");
            this.imageListImg.Images.SetKeyName(6, "7.png");
            this.imageListImg.Images.SetKeyName(7, "8.png");
            this.imageListImg.Images.SetKeyName(8, "9.png");
            this.imageListImg.Images.SetKeyName(9, "10.png");
            this.imageListImg.Images.SetKeyName(10, "11.png");
            this.imageListImg.Images.SetKeyName(11, "12.png");
            this.imageListImg.Images.SetKeyName(12, "gates.gif");
            this.imageListImg.Images.SetKeyName(13, "5.ico");
            this.imageListImg.Images.SetKeyName(14, "1.ico");
            this.imageListImg.Images.SetKeyName(15, "2.ico");
            this.imageListImg.Images.SetKeyName(16, "3.ico");
            this.imageListImg.Images.SetKeyName(17, "user.ico");
            this.imageListImg.Images.SetKeyName(18, "4.ico");
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemSet,
            this.menuItemView,
            this.menuItemGong,
            this.menuItemHelp,
            this.menuItemMin});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemIP,
            this.menuItemDuanKou,
            this.menuItemPeiZhi,
            this.menuItemXieZai,
            this.menuItem1,
            this.menuItemExit});
            this.menuItemFile.Text = "文件(&F)";
            // 
            // menuItemIP
            // 
            this.menuItemIP.Index = 0;
            this.menuItemIP.Text = "更新IP";
            // 
            // menuItemDuanKou
            // 
            this.menuItemDuanKou.Index = 1;
            this.menuItemDuanKou.Text = "端口映射";
            // 
            // menuItemPeiZhi
            // 
            this.menuItemPeiZhi.Index = 2;
            this.menuItemPeiZhi.Text = "配置服务器";
            // 
            // menuItemXieZai
            // 
            this.menuItemXieZai.Index = 3;
            this.menuItemXieZai.Text = "卸载服务端";
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 4;
            this.menuItem1.Text = "-";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 5;
            this.menuItemExit.Text = "退出(&E)";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemSet
            // 
            this.menuItemSet.Index = 1;
            this.menuItemSet.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemSystem,
            this.menuItemSkin,
            this.menuItem2,
            this.menuItemAddDesk,
            this.menuItemAddKuai,
            this.menuItemAddKai});
            this.menuItemSet.Text = "设置(&S)";
            // 
            // menuItemSystem
            // 
            this.menuItemSystem.Index = 0;
            this.menuItemSystem.Text = "系统设置";
            // 
            // menuItemSkin
            // 
            this.menuItemSkin.Index = 1;
            this.menuItemSkin.Text = "更换皮肤";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "-";
            // 
            // menuItemAddDesk
            // 
            this.menuItemAddDesk.Index = 3;
            this.menuItemAddDesk.Text = "添加到桌面";
            // 
            // menuItemAddKuai
            // 
            this.menuItemAddKuai.Index = 4;
            this.menuItemAddKuai.Text = "添加到快速启动";
            // 
            // menuItemAddKai
            // 
            this.menuItemAddKai.Index = 5;
            this.menuItemAddKai.Text = "添加到开始程序";
            // 
            // menuItemView
            // 
            this.menuItemView.Index = 2;
            this.menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemToolBar,
            this.menuItemIPJiLu});
            this.menuItemView.Text = "查看(&V)";
            // 
            // menuItemToolBar
            // 
            this.menuItemToolBar.Checked = true;
            this.menuItemToolBar.Index = 0;
            this.menuItemToolBar.Text = "工具栏";
            this.menuItemToolBar.Click += new System.EventHandler(this.menuItemToolBar_Click);
            // 
            // menuItemIPJiLu
            // 
            this.menuItemIPJiLu.Index = 1;
            this.menuItemIPJiLu.Text = "IP记录";
            // 
            // menuItemGong
            // 
            this.menuItemGong.Index = 3;
            this.menuItemGong.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemHost,
            this.menuItemFileManage,
            this.menuItem3,
            this.menuItemPing,
            this.menuItemViod,
            this.menuItem4,
            this.menuItemSystemManage,
            this.menuItemDOS,
            this.menuItemKey,
            this.menuItemAllDos});
            this.menuItemGong.Text = "功能(&R)";
            // 
            // menuItemHost
            // 
            this.menuItemHost.Index = 0;
            this.menuItemHost.Text = "主机管理";
            // 
            // menuItemFileManage
            // 
            this.menuItemFileManage.Index = 1;
            this.menuItemFileManage.Text = "文件管理";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "-";
            // 
            // menuItemPing
            // 
            this.menuItemPing.Index = 3;
            this.menuItemPing.Text = "屏幕监控";
            // 
            // menuItemViod
            // 
            this.menuItemViod.Index = 4;
            this.menuItemViod.Text = "视频监控";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 5;
            this.menuItem4.Text = "-";
            // 
            // menuItemSystemManage
            // 
            this.menuItemSystemManage.Index = 6;
            this.menuItemSystemManage.Text = "系统管理";
            // 
            // menuItemDOS
            // 
            this.menuItemDOS.Index = 7;
            this.menuItemDOS.Text = "命令提示符";
            // 
            // menuItemKey
            // 
            this.menuItemKey.Index = 8;
            this.menuItemKey.Text = "键盘记录";
            // 
            // menuItemAllDos
            // 
            this.menuItemAllDos.Index = 9;
            this.menuItemAllDos.Text = "批处理";
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Index = 4;
            this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemAbout,
            this.menuItemUseHelp,
            this.menuItemZhuYe});
            this.menuItemHelp.Text = "帮助(&H)";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Index = 0;
            this.menuItemAbout.Text = "关于我们";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // menuItemUseHelp
            // 
            this.menuItemUseHelp.Index = 1;
            this.menuItemUseHelp.Text = "使用帮助";
            // 
            // menuItemZhuYe
            // 
            this.menuItemZhuYe.Index = 2;
            this.menuItemZhuYe.Text = "盖茨工作室主页";
            this.menuItemZhuYe.Click += new System.EventHandler(this.menuItemZhuYe_Click);
            // 
            // menuItemMin
            // 
            this.menuItemMin.Index = 5;
            this.menuItemMin.Text = "最小化";
            this.menuItemMin.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(-6, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(804, 38);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(703, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 23);
            this.button1.TabIndex = 4;
            this.button1.TabStop = false;
            this.button1.Text = "更改设置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(586, 12);
            this.textBox3.MaxLength = 16;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.Size = new System.Drawing.Size(101, 21);
            this.textBox3.TabIndex = 3;
            this.textBox3.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(408, 12);
            this.textBox2.MaxLength = 5;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(92, 21);
            this.textBox2.TabIndex = 2;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "5761";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(515, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "连接密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "上线端口：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前主机：";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cxMenuItemOpen,
            this.cxMenuItemZhuYe,
            this.cxMenuItemExit});
            // 
            // cxMenuItemOpen
            // 
            this.cxMenuItemOpen.Index = 0;
            this.cxMenuItemOpen.Text = "TwoCare远程管理";
            this.cxMenuItemOpen.Click += new System.EventHandler(this.cxMenuItemOpen_Click);
            // 
            // cxMenuItemZhuYe
            // 
            this.cxMenuItemZhuYe.Index = 1;
            this.cxMenuItemZhuYe.Text = "官方主页";
            this.cxMenuItemZhuYe.Click += new System.EventHandler(this.menuItemZhuYe_Click);
            // 
            // cxMenuItemExit
            // 
            this.cxMenuItemExit.Index = 2;
            this.cxMenuItemExit.Text = "退出(&E)";
            this.cxMenuItemExit.Click += new System.EventHandler(this.cxMenuItemExit_Click);
            // 
            // AllImageList
            // 
            this.AllImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("AllImageList.ImageStream")));
            this.AllImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.AllImageList.Images.SetKeyName(0, "1.png");
            this.AllImageList.Images.SetKeyName(1, "2.png");
            this.AllImageList.Images.SetKeyName(2, "3.png");
            this.AllImageList.Images.SetKeyName(3, "4.png");
            this.AllImageList.Images.SetKeyName(4, "5.png");
            this.AllImageList.Images.SetKeyName(5, "6.png");
            this.AllImageList.Images.SetKeyName(6, "7.png");
            this.AllImageList.Images.SetKeyName(7, "8.png");
            this.AllImageList.Images.SetKeyName(8, "9.png");
            this.AllImageList.Images.SetKeyName(9, "10.png");
            this.AllImageList.Images.SetKeyName(10, "11.png");
            this.AllImageList.Images.SetKeyName(11, "12.png");
            this.AllImageList.Images.SetKeyName(12, "13.png");
            this.AllImageList.Images.SetKeyName(13, "14.png");
            this.AllImageList.Images.SetKeyName(14, "15.png");
            this.AllImageList.Images.SetKeyName(15, "left.ico");
            this.AllImageList.Images.SetKeyName(16, "right.ico");
            this.AllImageList.Images.SetKeyName(17, "parse.ico");
            this.AllImageList.Images.SetKeyName(18, "log.gif");
            this.AllImageList.Images.SetKeyName(19, "msg.gif");
            this.AllImageList.Images.SetKeyName(20, "pc.ico");
            this.AllImageList.Images.SetKeyName(21, "REG_SZ.png");
            this.AllImageList.Images.SetKeyName(22, "REG_OTHER.png");
            this.AllImageList.Images.SetKeyName(23, "user.ico");
            this.AllImageList.Images.SetKeyName(24, "disk.ico");
            this.AllImageList.Images.SetKeyName(25, "ring.ico");
            // 
            // contextMenu2
            // 
            this.contextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5,
            this.menuItem6,
            this.menuItem7,
            this.menuItem8});
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.Text = "大图标";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 1;
            this.menuItem6.Text = "小图标";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 2;
            this.menuItem7.Text = "列表";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Checked = true;
            this.menuItem8.Index = 3;
            this.menuItem8.Text = "详细资源";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.ItemSize = new System.Drawing.Size(60, 20);
            this.tabControl1.Location = new System.Drawing.Point(3, 94);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(790, 407);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 5;
            this.tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.textBox4);
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(782, 379);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "文件管理";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton0,
            this.toolStripSeparator8,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripSeparator2,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripSeparator3,
            this.toolStripButton8,
            this.toolStripButton9,
            this.toolStripSeparator4,
            this.toolStripButton10,
            this.toolStripButton11,
            this.toolStripButton12,
            this.toolStripSplitButton1,
            this.toolStripSeparator5,
            this.toolStripLabel1,
            this.toolStripComboBox1,
            this.toolStripButton22});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(776, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton0
            // 
            this.toolStripButton0.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton0.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton0.Image")));
            this.toolStripButton0.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton0.Name = "toolStripButton0";
            this.toolStripButton0.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton0.Text = "toolStripButton1";
            this.toolStripButton0.ToolTipText = "隐藏";
            this.toolStripButton0.Click += new System.EventHandler(this.toolStripButton0_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton13";
            this.toolStripButton1.ToolTipText = "新建文件";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton11";
            this.toolStripButton2.ToolTipText = "新建文件夹";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "复制";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "粘贴";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.ToolTipText = "删除";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "toolStripButton6";
            this.toolStripButton6.ToolTipText = "上传文件";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.Text = "toolStripButton7";
            this.toolStripButton7.ToolTipText = "下载文件";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton8.Text = "toolStripButton8";
            this.toolStripButton8.ToolTipText = "上传文件夹";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton9.Text = "toolStripButton9";
            this.toolStripButton9.ToolTipText = "下载文件夹";
            this.toolStripButton9.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton10.Text = "toolStripButton12";
            this.toolStripButton10.ToolTipText = "重命名";
            this.toolStripButton10.Click += new System.EventHandler(this.toolStripButton10_Click);
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
            this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton11.Text = "toolStripButton10";
            this.toolStripButton11.ToolTipText = "刷新";
            this.toolStripButton11.Click += new System.EventHandler(this.toolStripButton11_Click);
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
            this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton12.Text = "toolStripButton2";
            this.toolStripButton12.ToolTipText = "后退";
            this.toolStripButton12.Click += new System.EventHandler(this.toolStripButton12_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.大图标ToolStripMenuItem,
            this.小图标ToolStripMenuItem,
            this.列表ToolStripMenuItem,
            this.详细资源ToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            this.toolStripSplitButton1.ToolTipText = "查看";
            // 
            // 大图标ToolStripMenuItem
            // 
            this.大图标ToolStripMenuItem.Name = "大图标ToolStripMenuItem";
            this.大图标ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.大图标ToolStripMenuItem.Text = "大图标";
            this.大图标ToolStripMenuItem.Click += new System.EventHandler(this.大图标ToolStripMenuItem_Click);
            // 
            // 小图标ToolStripMenuItem
            // 
            this.小图标ToolStripMenuItem.Name = "小图标ToolStripMenuItem";
            this.小图标ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.小图标ToolStripMenuItem.Text = "小图标";
            this.小图标ToolStripMenuItem.Click += new System.EventHandler(this.小图标ToolStripMenuItem_Click);
            // 
            // 列表ToolStripMenuItem
            // 
            this.列表ToolStripMenuItem.Name = "列表ToolStripMenuItem";
            this.列表ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.列表ToolStripMenuItem.Text = "列表";
            this.列表ToolStripMenuItem.Click += new System.EventHandler(this.列表ToolStripMenuItem_Click);
            // 
            // 详细资源ToolStripMenuItem
            // 
            this.详细资源ToolStripMenuItem.Checked = true;
            this.详细资源ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.详细资源ToolStripMenuItem.Name = "详细资源ToolStripMenuItem";
            this.详细资源ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.详细资源ToolStripMenuItem.Text = "详细资源";
            this.详细资源ToolStripMenuItem.Click += new System.EventHandler(this.详细资源ToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel1.Text = "当前目录：";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "我的电脑"});
            this.toolStripComboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.toolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "我的电脑"});
            this.toolStripComboBox1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripComboBox1.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(280, 25);
            // 
            // toolStripButton22
            // 
            this.toolStripButton22.Checked = true;
            this.toolStripButton22.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButton22.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton22.Image")));
            this.toolStripButton22.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton22.Name = "toolStripButton22";
            this.toolStripButton22.Size = new System.Drawing.Size(52, 21);
            this.toolStripButton22.Text = "转到";
            this.toolStripButton22.Click += new System.EventHandler(this.toolStripButton22_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(427, 322);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(353, 51);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.BackColor = System.Drawing.SystemColors.Window;
            this.textBox4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox4.Location = new System.Drawing.Point(0, 322);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox4.Size = new System.Drawing.Size(417, 51);
            this.textBox4.TabIndex = 10;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "事件日志>>";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(1, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewFile);
            this.splitContainer1.Size = new System.Drawing.Size(782, 292);
            this.splitContainer1.SplitterDistance = 198;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.TreeImageList;
            this.treeView1.Location = new System.Drawing.Point(0, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(195, 285);
            this.treeView1.TabIndex = 5;
            this.treeView1.TabStop = false;
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // TreeImageList
            // 
            this.TreeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.TreeImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.TreeImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listViewFile
            // 
            this.listViewFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFile.AutoArrange = false;
            this.listViewFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader23});
            this.listViewFile.ContextMenu = this.contextMenu3;
            this.listViewFile.Font = new System.Drawing.Font("宋体", 9F);
            this.listViewFile.GridLines = true;
            this.listViewFile.LargeImageList = this.LargeimageList;
            this.listViewFile.Location = new System.Drawing.Point(3, 3);
            this.listViewFile.MultiSelect = false;
            this.listViewFile.Name = "listViewFile";
            this.listViewFile.Size = new System.Drawing.Size(576, 286);
            this.listViewFile.SmallImageList = this.SmallimageList;
            this.listViewFile.TabIndex = 6;
            this.listViewFile.TabStop = false;
            this.listViewFile.TileSize = new System.Drawing.Size(128, 32);
            this.listViewFile.UseCompatibleStateImageBehavior = false;
            this.listViewFile.View = System.Windows.Forms.View.Details;
            this.listViewFile.ItemActivate += new System.EventHandler(this.listViewFile_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 170;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "文件大小";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "创建时间";
            this.columnHeader3.Width = 135;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "修改时间";
            this.columnHeader23.Width = 135;
            // 
            // contextMenu3
            // 
            this.contextMenu3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem35,
            this.menuItem36,
            this.menuItem9,
            this.menuItem10,
            this.menuItem11,
            this.menuItem12,
            this.menuItem13,
            this.menuItem14,
            this.menuItem15,
            this.menuItem16,
            this.menuItem17,
            this.menuItem18,
            this.menuItem19,
            this.menuItem22,
            this.menuItem23,
            this.menuItem24,
            this.menuItem25,
            this.menuItem26,
            this.menuItem27,
            this.menuItem28});
            this.contextMenu3.Popup += new System.EventHandler(this.contextMenu3_Popup);
            // 
            // menuItem35
            // 
            this.menuItem35.Index = 0;
            this.menuItem35.Text = "后退";
            this.menuItem35.Click += new System.EventHandler(this.menuItem35_Click);
            // 
            // menuItem36
            // 
            this.menuItem36.Index = 1;
            this.menuItem36.Text = "-";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 2;
            this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem29,
            this.menuItem30,
            this.menuItem31,
            this.menuItem32,
            this.menuItem33,
            this.menuItem34});
            this.menuItem9.Text = "远程打开";
            this.menuItem9.Popup += new System.EventHandler(this.menuItem9_Popup);
            // 
            // menuItem29
            // 
            this.menuItem29.Index = 0;
            this.menuItem29.Text = "正常运行";
            this.menuItem29.Click += new System.EventHandler(this.menuItem29_Click);
            // 
            // menuItem30
            // 
            this.menuItem30.Index = 1;
            this.menuItem30.Text = "隐藏运行";
            this.menuItem30.Click += new System.EventHandler(this.menuItem30_Click);
            // 
            // menuItem31
            // 
            this.menuItem31.Index = 2;
            this.menuItem31.Text = "最小化";
            this.menuItem31.Click += new System.EventHandler(this.menuItem31_Click);
            // 
            // menuItem32
            // 
            this.menuItem32.Index = 3;
            this.menuItem32.Text = "最大化";
            this.menuItem32.Click += new System.EventHandler(this.menuItem32_Click);
            // 
            // menuItem33
            // 
            this.menuItem33.Index = 4;
            this.menuItem33.Text = "-";
            // 
            // menuItem34
            // 
            this.menuItem34.Index = 5;
            this.menuItem34.Text = "参数运行";
            this.menuItem34.Click += new System.EventHandler(this.menuItem34_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 3;
            this.menuItem10.Text = "本地打开";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 4;
            this.menuItem11.Text = "-";
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 5;
            this.menuItem12.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.menuItem12.Text = "刷新";
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 6;
            this.menuItem13.Text = "-";
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 7;
            this.menuItem14.Text = "文件上传(&U)";
            this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 8;
            this.menuItem15.Text = "文件下载(&D)";
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 9;
            this.menuItem16.Shortcut = System.Windows.Forms.Shortcut.AltF1;
            this.menuItem16.Text = "文件夹上传";
            this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 10;
            this.menuItem17.Shortcut = System.Windows.Forms.Shortcut.AltF2;
            this.menuItem17.Text = "文件夹下载";
            this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 11;
            this.menuItem18.Text = "-";
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 12;
            this.menuItem19.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem20,
            this.menuItem21});
            this.menuItem19.Text = "新建";
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 0;
            this.menuItem20.Text = "文件夹";
            this.menuItem20.Click += new System.EventHandler(this.menuItem20_Click);
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 1;
            this.menuItem21.Text = "文件";
            this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click);
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 13;
            this.menuItem22.Text = "-";
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 14;
            this.menuItem23.Text = "复制(&C)";
            this.menuItem23.Click += new System.EventHandler(this.menuItem23_Click);
            // 
            // menuItem24
            // 
            this.menuItem24.Index = 15;
            this.menuItem24.Text = "粘贴(&V)";
            this.menuItem24.Click += new System.EventHandler(this.menuItem24_Click);
            // 
            // menuItem25
            // 
            this.menuItem25.Index = 16;
            this.menuItem25.Text = "删除(&D)";
            this.menuItem25.Click += new System.EventHandler(this.menuItem25_Click);
            // 
            // menuItem26
            // 
            this.menuItem26.Index = 17;
            this.menuItem26.Text = "-";
            // 
            // menuItem27
            // 
            this.menuItem27.Index = 18;
            this.menuItem27.Text = "重命名(&R)";
            this.menuItem27.Click += new System.EventHandler(this.menuItem27_Click);
            // 
            // menuItem28
            // 
            this.menuItem28.Index = 19;
            this.menuItem28.Text = "属性";
            this.menuItem28.Click += new System.EventHandler(this.menuItem28_Click);
            // 
            // LargeimageList
            // 
            this.LargeimageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.LargeimageList.ImageSize = new System.Drawing.Size(32, 32);
            this.LargeimageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // SmallimageList
            // 
            this.SmallimageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.SmallimageList.ImageSize = new System.Drawing.Size(16, 16);
            this.SmallimageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.faTabStrip1);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(782, 379);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "控制面板";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // faTabStrip1
            // 
            this.faTabStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.faTabStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.faTabStrip1.Items.AddRange(new FarsiLibrary.Win.FATabStripItem[] {
            this.faTabStripItem1,
            this.faTabStripItem2,
            this.faTabStripItem3,
            this.faTabStripItem4,
            this.faTabStripItem5,
            this.faTabStripItem6,
            this.faTabStripItem7,
            this.faTabStripItem8});
            this.faTabStrip1.Location = new System.Drawing.Point(3, 3);
            this.faTabStrip1.Name = "faTabStrip1";
            this.faTabStrip1.SelectedItem = this.faTabStripItem1;
            this.faTabStrip1.Size = new System.Drawing.Size(776, 373);
            this.faTabStrip1.TabIndex = 0;
            this.faTabStrip1.Text = "faTabStrip1";
            this.faTabStrip1.TabStripItemSelectionChanged += new FarsiLibrary.Win.TabStripItemChangedHandler(this.faTabStrip1_TabStripItemSelectionChanged);
            // 
            // faTabStripItem1
            // 
            this.faTabStripItem1.Controls.Add(this.panel1);
            this.faTabStripItem1.Controls.Add(this.toolStrip11);
            this.faTabStripItem1.IsDrawn = true;
            this.faTabStripItem1.Name = "faTabStripItem1";
            this.faTabStripItem1.Selected = true;
            this.faTabStripItem1.Size = new System.Drawing.Size(774, 352);
            this.faTabStripItem1.TabIndex = 0;
            this.faTabStripItem1.Title = "面板主页";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 327);
            this.panel1.TabIndex = 17;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button8);
            this.groupBox5.Controls.Add(this.button7);
            this.groupBox5.Controls.Add(this.textBox13);
            this.groupBox5.Controls.Add(this.textBox12);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.textBox11);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.comboBox6);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Location = new System.Drawing.Point(399, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(371, 133);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "开启代理";
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button8.Location = new System.Drawing.Point(192, 100);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(53, 23);
            this.button8.TabIndex = 15;
            this.button8.TabStop = false;
            this.button8.Text = "停止";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button7.Location = new System.Drawing.Point(121, 100);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(53, 23);
            this.button7.TabIndex = 14;
            this.button7.TabStop = false;
            this.button7.Text = "开启";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(245, 58);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(106, 21);
            this.textBox13.TabIndex = 13;
            this.textBox13.Text = "1234";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(54, 58);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(131, 21);
            this.textBox12.TabIndex = 12;
            this.textBox12.Text = "Sock5";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(196, 58);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 13);
            this.label18.TabIndex = 11;
            this.label18.Text = "密码：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 66);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "用户：";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(245, 23);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(106, 21);
            this.textBox11.TabIndex = 9;
            this.textBox11.Text = "8080";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(196, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "端口：";
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            "Sock5",
            "Http"});
            this.comboBox6.Location = new System.Drawing.Point(52, 23);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(134, 21);
            this.comboBox6.TabIndex = 7;
            this.comboBox6.Text = "Sock5";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "类型：";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button6);
            this.groupBox4.Controls.Add(this.checkBox3);
            this.groupBox4.Controls.Add(this.textBox10);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.textBox9);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(4, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(371, 133);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "打开网页";
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button6.Location = new System.Drawing.Point(273, 100);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(53, 23);
            this.button6.TabIndex = 9;
            this.button6.TabStop = false;
            this.button6.Text = "打开";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(79, 90);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(110, 17);
            this.checkBox3.TabIndex = 8;
            this.checkBox3.Text = "下载完立即运行";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(79, 63);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(247, 21);
            this.textBox10.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "下载文件：";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(79, 28);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(247, 21);
            this.textBox9.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "打开网页：";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.textBox14);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.textBox7);
            this.groupBox3.Controls.Add(this.comboBox8);
            this.groupBox3.Controls.Add(this.comboBox7);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.comboBox5);
            this.groupBox3.Controls.Add(this.textBox8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(399, 140);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(371, 184);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送文本消息";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(235, 89);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(91, 21);
            this.textBox14.TabIndex = 16;
            this.textBox14.Text = "200";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(204, 92);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(25, 13);
            this.label21.TabIndex = 15;
            this.label21.Text = "Y：";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(80, 89);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(105, 21);
            this.textBox7.TabIndex = 13;
            this.textBox7.Text = "200";
            // 
            // comboBox8
            // 
            this.comboBox8.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(79, 118);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(107, 22);
            this.comboBox8.TabIndex = 12;
            this.comboBox8.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox8_DrawItem);
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.comboBox7.Location = new System.Drawing.Point(235, 55);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(91, 21);
            this.comboBox7.TabIndex = 11;
            this.comboBox7.Text = "48";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(196, 61);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 13);
            this.label19.TabIndex = 10;
            this.label19.Text = "大小：";
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button4.Location = new System.Drawing.Point(192, 155);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(53, 23);
            this.button4.TabIndex = 9;
            this.button4.TabStop = false;
            this.button4.Text = "预览";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button5.Location = new System.Drawing.Point(121, 155);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(53, 23);
            this.button5.TabIndex = 8;
            this.button5.TabStop = false;
            this.button5.Text = "发送";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(79, 53);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(107, 21);
            this.comboBox5.TabIndex = 5;
            this.comboBox5.Text = "楷体_GB2312";
            this.comboBox5.DropDown += new System.EventHandler(this.comboBox5_DropDown);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(79, 24);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(247, 21);
            this.textBox8.TabIndex = 4;
            this.textBox8.Text = "你好";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "颜色：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "屏幕位置X：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "字体：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "文字内容：";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.comboBox3);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(4, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 184);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送窗口消息";
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point(195, 153);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(53, 23);
            this.button3.TabIndex = 9;
            this.button3.TabStop = false;
            this.button3.Text = "预览";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(123, 153);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 23);
            this.button2.TabIndex = 8;
            this.button2.TabStop = false;
            this.button2.Text = "发送";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(79, 123);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(247, 21);
            this.textBox6.TabIndex = 7;
            this.textBox6.Text = "你好";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "确定",
            "确定、取消",
            "是、否",
            "是、否、取消",
            "重试、取消",
            "终止、重试、忽略"});
            this.comboBox3.Location = new System.Drawing.Point(79, 90);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(247, 21);
            this.comboBox3.TabIndex = 6;
            this.comboBox3.Text = "确定";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "普通",
            "询问",
            "错误",
            "警告"});
            this.comboBox1.Location = new System.Drawing.Point(79, 56);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(247, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Text = "普通";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(79, 24);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(247, 21);
            this.textBox5.TabIndex = 4;
            this.textBox5.Text = "窗口";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "消息内容：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "按钮类型：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "图标类型：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "窗口标题：";
            // 
            // toolStrip11
            // 
            this.toolStrip11.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton47,
            this.toolStripButton48,
            this.toolStripButton57,
            this.toolStripSeparator15,
            this.toolStripButton59,
            this.toolStripButton60,
            this.toolStripSeparator16,
            this.toolStripButton62,
            this.toolStripButton63,
            this.toolStripSeparator17,
            this.toolStripButton58,
            this.toolStripButton61});
            this.toolStrip11.Location = new System.Drawing.Point(0, 0);
            this.toolStrip11.Name = "toolStrip11";
            this.toolStrip11.Size = new System.Drawing.Size(774, 25);
            this.toolStrip11.TabIndex = 16;
            this.toolStrip11.Text = "toolStrip11";
            // 
            // toolStripButton47
            // 
            this.toolStripButton47.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton47.Image")));
            this.toolStripButton47.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton47.Name = "toolStripButton47";
            this.toolStripButton47.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton47.Text = "远程重启";
            this.toolStripButton47.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButton48
            // 
            this.toolStripButton48.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton48.Image")));
            this.toolStripButton48.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton48.Name = "toolStripButton48";
            this.toolStripButton48.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton48.Text = "远程关机";
            this.toolStripButton48.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButton57
            // 
            this.toolStripButton57.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton57.Image")));
            this.toolStripButton57.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton57.Name = "toolStripButton57";
            this.toolStripButton57.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton57.Text = "远程注销";
            this.toolStripButton57.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton59
            // 
            this.toolStripButton59.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton59.Image")));
            this.toolStripButton59.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton59.Name = "toolStripButton59";
            this.toolStripButton59.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton59.Text = "锁定鼠标";
            this.toolStripButton59.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButton60
            // 
            this.toolStripButton60.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton60.Image")));
            this.toolStripButton60.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton60.Name = "toolStripButton60";
            this.toolStripButton60.Size = new System.Drawing.Size(88, 22);
            this.toolStripButton60.Text = "锁定任务栏";
            this.toolStripButton60.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton62
            // 
            this.toolStripButton62.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton62.Image")));
            this.toolStripButton62.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton62.Name = "toolStripButton62";
            this.toolStripButton62.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton62.Text = "服务重启";
            this.toolStripButton62.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButton63
            // 
            this.toolStripButton63.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton63.Image")));
            this.toolStripButton63.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton63.Name = "toolStripButton63";
            this.toolStripButton63.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton63.Text = "卸载服务";
            this.toolStripButton63.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton58
            // 
            this.toolStripButton58.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton58.Image")));
            this.toolStripButton58.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton58.Name = "toolStripButton58";
            this.toolStripButton58.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton58.Text = "清除日志";
            this.toolStripButton58.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButton61
            // 
            this.toolStripButton61.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton61.Image")));
            this.toolStripButton61.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton61.Name = "toolStripButton61";
            this.toolStripButton61.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton61.Text = "显示桌面";
            this.toolStripButton61.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // faTabStripItem2
            // 
            this.faTabStripItem2.Controls.Add(this.toolStrip4);
            this.faTabStripItem2.Controls.Add(this.splitContainer3);
            this.faTabStripItem2.IsDrawn = true;
            this.faTabStripItem2.Name = "faTabStripItem2";
            this.faTabStripItem2.Size = new System.Drawing.Size(774, 352);
            this.faTabStripItem2.TabIndex = 2;
            this.faTabStripItem2.Title = "系统信息";
            // 
            // toolStrip4
            // 
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton23,
            this.toolStripButton24});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(774, 25);
            this.toolStrip4.TabIndex = 14;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripButton23
            // 
            this.toolStripButton23.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton23.Image")));
            this.toolStripButton23.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton23.Name = "toolStripButton23";
            this.toolStripButton23.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton23.Text = "导出列表";
            this.toolStripButton23.Click += new System.EventHandler(this.toolStripButton23_Click);
            // 
            // toolStripButton24
            // 
            this.toolStripButton24.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton24.Image")));
            this.toolStripButton24.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton24.Name = "toolStripButton24";
            this.toolStripButton24.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton24.Text = "刷新列表";
            this.toolStripButton24.Click += new System.EventHandler(this.toolStripButton24_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.Location = new System.Drawing.Point(0, 29);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.treeView3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.listView3);
            this.splitContainer3.Size = new System.Drawing.Size(774, 323);
            this.splitContainer3.SplitterDistance = 198;
            this.splitContainer3.TabIndex = 13;
            // 
            // treeView3
            // 
            this.treeView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView3.HideSelection = false;
            this.treeView3.ImageIndex = 0;
            this.treeView3.ImageList = this.AllImageList;
            this.treeView3.Location = new System.Drawing.Point(0, 0);
            this.treeView3.Name = "treeView3";
            treeNode1.ImageIndex = 20;
            treeNode1.Name = "Node1";
            treeNode1.SelectedImageIndex = 20;
            treeNode1.Text = "我的电脑";
            treeNode2.ImageIndex = 20;
            treeNode2.Name = "Node2";
            treeNode2.SelectedImageIndex = 20;
            treeNode2.Text = "远程主机";
            this.treeView3.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.treeView3.SelectedImageIndex = 0;
            this.treeView3.ShowRootLines = false;
            this.treeView3.Size = new System.Drawing.Size(198, 323);
            this.treeView3.TabIndex = 0;
            this.treeView3.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView3_AfterSelect);
            // 
            // listView3
            // 
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader29,
            this.columnHeader49});
            this.listView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView3.GridLines = true;
            this.listView3.Location = new System.Drawing.Point(0, 0);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(572, 323);
            this.listView3.TabIndex = 0;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "名称";
            this.columnHeader29.Width = 100;
            // 
            // columnHeader49
            // 
            this.columnHeader49.Text = "参数";
            this.columnHeader49.Width = 450;
            // 
            // faTabStripItem3
            // 
            this.faTabStripItem3.Controls.Add(this.toolStrip5);
            this.faTabStripItem3.Controls.Add(this.splitContainer4);
            this.faTabStripItem3.IsDrawn = true;
            this.faTabStripItem3.Name = "faTabStripItem3";
            this.faTabStripItem3.Size = new System.Drawing.Size(774, 352);
            this.faTabStripItem3.TabIndex = 3;
            this.faTabStripItem3.Title = "进程";
            // 
            // toolStrip5
            // 
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton25,
            this.toolStripButton26,
            this.toolStripButton27});
            this.toolStrip5.Location = new System.Drawing.Point(0, 0);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Size = new System.Drawing.Size(774, 25);
            this.toolStrip5.TabIndex = 15;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // toolStripButton25
            // 
            this.toolStripButton25.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton25.Image")));
            this.toolStripButton25.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton25.Name = "toolStripButton25";
            this.toolStripButton25.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton25.Text = "导出进程";
            this.toolStripButton25.Click += new System.EventHandler(this.toolStripButton25_Click);
            // 
            // toolStripButton26
            // 
            this.toolStripButton26.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton26.Image")));
            this.toolStripButton26.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton26.Name = "toolStripButton26";
            this.toolStripButton26.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton26.Text = "刷新进程";
            this.toolStripButton26.Click += new System.EventHandler(this.toolStripButton26_Click);
            // 
            // toolStripButton27
            // 
            this.toolStripButton27.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton27.Image")));
            this.toolStripButton27.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton27.Name = "toolStripButton27";
            this.toolStripButton27.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton27.Text = "结束进程";
            this.toolStripButton27.Click += new System.EventHandler(this.toolStripButton27_Click);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer4.Location = new System.Drawing.Point(0, 29);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.treeView4);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.listView4);
            this.splitContainer4.Size = new System.Drawing.Size(774, 323);
            this.splitContainer4.SplitterDistance = 198;
            this.splitContainer4.TabIndex = 14;
            // 
            // treeView4
            // 
            this.treeView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView4.HideSelection = false;
            this.treeView4.ImageIndex = 0;
            this.treeView4.ImageList = this.AllImageList;
            this.treeView4.Location = new System.Drawing.Point(0, 0);
            this.treeView4.Name = "treeView4";
            treeNode3.ImageIndex = 20;
            treeNode3.Name = "Node0";
            treeNode3.SelectedImageIndex = 20;
            treeNode3.Text = "我的电脑";
            treeNode4.ImageIndex = 20;
            treeNode4.Name = "Node1";
            treeNode4.SelectedImageIndex = 20;
            treeNode4.Text = "远程主机";
            this.treeView4.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.treeView4.SelectedImageIndex = 0;
            this.treeView4.ShowRootLines = false;
            this.treeView4.Size = new System.Drawing.Size(198, 323);
            this.treeView4.TabIndex = 0;
            this.treeView4.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView4_AfterSelect);
            // 
            // listView4
            // 
            this.listView4.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader25,
            this.columnHeader26,
            this.columnHeader27,
            this.columnHeader28});
            this.listView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView4.FullRowSelect = true;
            this.listView4.GridLines = true;
            this.listView4.Location = new System.Drawing.Point(0, 0);
            this.listView4.MultiSelect = false;
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(572, 323);
            this.listView4.TabIndex = 0;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "进程ID";
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "映像名称";
            this.columnHeader26.Width = 100;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "内存使用";
            this.columnHeader27.Width = 100;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "文件来源";
            this.columnHeader28.Width = 250;
            // 
            // faTabStripItem4
            // 
            this.faTabStripItem4.Controls.Add(this.toolStrip6);
            this.faTabStripItem4.Controls.Add(this.splitContainer2);
            this.faTabStripItem4.IsDrawn = true;
            this.faTabStripItem4.Name = "faTabStripItem4";
            this.faTabStripItem4.Size = new System.Drawing.Size(774, 352);
            this.faTabStripItem4.TabIndex = 4;
            this.faTabStripItem4.Title = "注册表";
            // 
            // toolStrip6
            // 
            this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton28,
            this.toolStripButton29,
            this.toolStripSeparator12,
            this.toolStripButton30,
            this.toolStripButton52,
            this.toolStripButton53,
            this.toolStripSeparator14,
            this.toolStripButton54,
            this.toolStripButton55,
            this.toolStripButton56});
            this.toolStrip6.Location = new System.Drawing.Point(0, 0);
            this.toolStrip6.Name = "toolStrip6";
            this.toolStrip6.Size = new System.Drawing.Size(774, 25);
            this.toolStrip6.TabIndex = 16;
            this.toolStrip6.Text = "toolStrip6";
            // 
            // toolStripButton28
            // 
            this.toolStripButton28.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton28.Image")));
            this.toolStripButton28.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton28.Name = "toolStripButton28";
            this.toolStripButton28.Size = new System.Drawing.Size(88, 22);
            this.toolStripButton28.Text = "导出注册表";
            this.toolStripButton28.Click += new System.EventHandler(this.toolStripButton28_Click);
            // 
            // toolStripButton29
            // 
            this.toolStripButton29.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton29.Image")));
            this.toolStripButton29.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton29.Name = "toolStripButton29";
            this.toolStripButton29.Size = new System.Drawing.Size(88, 22);
            this.toolStripButton29.Text = "刷新注册表";
            this.toolStripButton29.Click += new System.EventHandler(this.toolStripButton29_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton30
            // 
            this.toolStripButton30.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton30.Image")));
            this.toolStripButton30.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton30.Name = "toolStripButton30";
            this.toolStripButton30.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton30.Text = "创建新项";
            this.toolStripButton30.Click += new System.EventHandler(this.toolStripButton30_Click);
            // 
            // toolStripButton52
            // 
            this.toolStripButton52.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton52.Image")));
            this.toolStripButton52.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton52.Name = "toolStripButton52";
            this.toolStripButton52.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton52.Text = "项重命名";
            this.toolStripButton52.Click += new System.EventHandler(this.toolStripButton52_Click);
            // 
            // toolStripButton53
            // 
            this.toolStripButton53.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton53.Image")));
            this.toolStripButton53.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton53.Name = "toolStripButton53";
            this.toolStripButton53.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton53.Text = "删除项目";
            this.toolStripButton53.Click += new System.EventHandler(this.toolStripButton53_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton54
            // 
            this.toolStripButton54.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton54.Image")));
            this.toolStripButton54.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton54.Name = "toolStripButton54";
            this.toolStripButton54.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton54.Text = "新建键值";
            this.toolStripButton54.Click += new System.EventHandler(this.toolStripButton54_Click);
            // 
            // toolStripButton55
            // 
            this.toolStripButton55.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton55.Image")));
            this.toolStripButton55.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton55.Name = "toolStripButton55";
            this.toolStripButton55.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton55.Text = "修改键值";
            this.toolStripButton55.Click += new System.EventHandler(this.toolStripButton55_Click);
            // 
            // toolStripButton56
            // 
            this.toolStripButton56.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton56.Image")));
            this.toolStripButton56.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton56.Name = "toolStripButton56";
            this.toolStripButton56.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton56.Text = "删除键值";
            this.toolStripButton56.Click += new System.EventHandler(this.toolStripButton56_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(0, 29);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeView2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listView2);
            this.splitContainer2.Size = new System.Drawing.Size(774, 323);
            this.splitContainer2.SplitterDistance = 198;
            this.splitContainer2.TabIndex = 13;
            // 
            // treeView2
            // 
            this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView2.HideSelection = false;
            this.treeView2.ImageIndex = 0;
            this.treeView2.ImageList = this.AllImageList;
            this.treeView2.Location = new System.Drawing.Point(0, 0);
            this.treeView2.Name = "treeView2";
            treeNode5.Name = "Node0";
            treeNode5.Text = "HKEY_CLASSES_ROOT";
            treeNode6.Name = "Node1";
            treeNode6.Text = "HKEY_CURRENT_USER";
            treeNode7.Name = "Node2";
            treeNode7.Text = "HKEY_LOCAL_MACHINE";
            treeNode8.Name = "Node3";
            treeNode8.Text = "HKEY_USERS";
            treeNode9.Name = "Node4";
            treeNode9.Text = "HKEY_CURRENT_CONFIG";
            treeNode10.ImageIndex = 20;
            treeNode10.Name = "Node0";
            treeNode10.SelectedImageIndex = 20;
            treeNode10.Text = "我的电脑";
            treeNode11.Name = "Node0";
            treeNode11.Text = "HKEY_CLASSES_ROOT";
            treeNode12.Name = "Node1";
            treeNode12.Text = "HKEY_CURRENT_USER";
            treeNode13.Name = "Node2";
            treeNode13.Text = "HKEY_LOCAL_MACHINE";
            treeNode14.Name = "Node3";
            treeNode14.Text = "HKEY_USERS";
            treeNode15.Name = "Node4";
            treeNode15.Text = "HKEY_CURRENT_CONFIG";
            treeNode16.ImageIndex = 20;
            treeNode16.Name = "Node1";
            treeNode16.SelectedImageIndex = 20;
            treeNode16.Text = "远程主机";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode16});
            this.treeView2.SelectedImageIndex = 0;
            this.treeView2.Size = new System.Drawing.Size(198, 323);
            this.treeView2.TabIndex = 1;
            this.treeView2.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView2_BeforeExpand);
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader46,
            this.columnHeader47,
            this.columnHeader48});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView2.GridLines = true;
            this.listView2.LargeImageList = this.AllImageList;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(572, 323);
            this.listView2.SmallImageList = this.AllImageList;
            this.listView2.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader46
            // 
            this.columnHeader46.Text = "名称";
            this.columnHeader46.Width = 250;
            // 
            // columnHeader47
            // 
            this.columnHeader47.Text = "类型";
            this.columnHeader47.Width = 100;
            // 
            // columnHeader48
            // 
            this.columnHeader48.Text = "数据";
            this.columnHeader48.Width = 150;
            // 
            // faTabStripItem5
            // 
            this.faTabStripItem5.Controls.Add(this.toolStrip7);
            this.faTabStripItem5.Controls.Add(this.splitContainer5);
            this.faTabStripItem5.IsDrawn = true;
            this.faTabStripItem5.Name = "faTabStripItem5";
            this.faTabStripItem5.Size = new System.Drawing.Size(774, 352);
            this.faTabStripItem5.TabIndex = 5;
            this.faTabStripItem5.Title = "系统服务";
            // 
            // toolStrip7
            // 
            this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton34,
            this.toolStripButton35,
            this.toolStripSeparator9,
            this.toolStripButton36,
            this.toolStripButton46,
            this.toolStripSeparator10,
            this.toolStripButton49,
            this.toolStripButton50,
            this.toolStripButton51});
            this.toolStrip7.Location = new System.Drawing.Point(0, 0);
            this.toolStrip7.Name = "toolStrip7";
            this.toolStrip7.Size = new System.Drawing.Size(774, 25);
            this.toolStrip7.TabIndex = 16;
            this.toolStrip7.Text = "toolStrip7";
            // 
            // toolStripButton34
            // 
            this.toolStripButton34.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton34.Image")));
            this.toolStripButton34.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton34.Name = "toolStripButton34";
            this.toolStripButton34.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton34.Text = "导出服务";
            this.toolStripButton34.Click += new System.EventHandler(this.toolStripButton34_Click);
            // 
            // toolStripButton35
            // 
            this.toolStripButton35.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton35.Image")));
            this.toolStripButton35.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton35.Name = "toolStripButton35";
            this.toolStripButton35.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton35.Text = "刷新服务";
            this.toolStripButton35.Click += new System.EventHandler(this.toolStripButton35_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton36
            // 
            this.toolStripButton36.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton36.Image")));
            this.toolStripButton36.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton36.Name = "toolStripButton36";
            this.toolStripButton36.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton36.Text = "启动服务";
            this.toolStripButton36.Click += new System.EventHandler(this.toolStripButton36_Click);
            // 
            // toolStripButton46
            // 
            this.toolStripButton46.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton46.Image")));
            this.toolStripButton46.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton46.Name = "toolStripButton46";
            this.toolStripButton46.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton46.Text = "停止服务";
            this.toolStripButton46.Click += new System.EventHandler(this.toolStripButton46_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton49
            // 
            this.toolStripButton49.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton49.Image")));
            this.toolStripButton49.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton49.Name = "toolStripButton49";
            this.toolStripButton49.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton49.Text = "设为自动";
            this.toolStripButton49.Click += new System.EventHandler(this.toolStripButton49_Click);
            // 
            // toolStripButton50
            // 
            this.toolStripButton50.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton50.Image")));
            this.toolStripButton50.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton50.Name = "toolStripButton50";
            this.toolStripButton50.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton50.Text = "设为手动";
            this.toolStripButton50.Click += new System.EventHandler(this.toolStripButton50_Click);
            // 
            // toolStripButton51
            // 
            this.toolStripButton51.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton51.Image")));
            this.toolStripButton51.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton51.Name = "toolStripButton51";
            this.toolStripButton51.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton51.Text = "设为禁用";
            this.toolStripButton51.Click += new System.EventHandler(this.toolStripButton51_Click);
            // 
            // splitContainer5
            // 
            this.splitContainer5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer5.Location = new System.Drawing.Point(0, 29);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.treeView5);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.listView5);
            this.splitContainer5.Size = new System.Drawing.Size(774, 323);
            this.splitContainer5.SplitterDistance = 198;
            this.splitContainer5.TabIndex = 15;
            // 
            // treeView5
            // 
            this.treeView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView5.HideSelection = false;
            this.treeView5.ImageIndex = 0;
            this.treeView5.ImageList = this.AllImageList;
            this.treeView5.Location = new System.Drawing.Point(0, 0);
            this.treeView5.Name = "treeView5";
            treeNode17.ImageIndex = 20;
            treeNode17.Name = "Node0";
            treeNode17.SelectedImageIndex = 20;
            treeNode17.Text = "我的电脑";
            treeNode18.ImageIndex = 20;
            treeNode18.Name = "Node1";
            treeNode18.SelectedImageIndex = 20;
            treeNode18.Text = "远程主机";
            this.treeView5.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18});
            this.treeView5.SelectedImageIndex = 0;
            this.treeView5.ShowRootLines = false;
            this.treeView5.Size = new System.Drawing.Size(198, 323);
            this.treeView5.TabIndex = 1;
            this.treeView5.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView5_AfterSelect);
            // 
            // listView5
            // 
            this.listView5.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader41,
            this.columnHeader42,
            this.columnHeader43,
            this.columnHeader44,
            this.columnHeader45,
            this.columnHeader57});
            this.listView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView5.FullRowSelect = true;
            this.listView5.GridLines = true;
            this.listView5.Location = new System.Drawing.Point(0, 0);
            this.listView5.MultiSelect = false;
            this.listView5.Name = "listView5";
            this.listView5.Size = new System.Drawing.Size(572, 323);
            this.listView5.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView5.TabIndex = 0;
            this.listView5.UseCompatibleStateImageBehavior = false;
            this.listView5.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader41
            // 
            this.columnHeader41.Text = "名称";
            this.columnHeader41.Width = 120;
            // 
            // columnHeader42
            // 
            this.columnHeader42.Text = "描述";
            this.columnHeader42.Width = 100;
            // 
            // columnHeader43
            // 
            this.columnHeader43.Text = "状态";
            this.columnHeader43.Width = 80;
            // 
            // columnHeader44
            // 
            this.columnHeader44.Text = "启动类型";
            this.columnHeader44.Width = 100;
            // 
            // columnHeader45
            // 
            this.columnHeader45.Text = "计算机";
            this.columnHeader45.Width = 100;
            // 
            // columnHeader57
            // 
            this.columnHeader57.Text = "服务名称";
            this.columnHeader57.Width = 0;
            // 
            // faTabStripItem6
            // 
            this.faTabStripItem6.Controls.Add(this.toolStrip8);
            this.faTabStripItem6.Controls.Add(this.splitContainer6);
            this.faTabStripItem6.IsDrawn = true;
            this.faTabStripItem6.Name = "faTabStripItem6";
            this.faTabStripItem6.Size = new System.Drawing.Size(774, 352);
            this.faTabStripItem6.TabIndex = 6;
            this.faTabStripItem6.Title = "事件日志";
            // 
            // toolStrip8
            // 
            this.toolStrip8.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton37,
            this.toolStripButton38,
            this.toolStripButton39});
            this.toolStrip8.Location = new System.Drawing.Point(0, 0);
            this.toolStrip8.Name = "toolStrip8";
            this.toolStrip8.Size = new System.Drawing.Size(774, 25);
            this.toolStrip8.TabIndex = 16;
            this.toolStrip8.Text = "toolStrip8";
            // 
            // toolStripButton37
            // 
            this.toolStripButton37.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton37.Image")));
            this.toolStripButton37.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton37.Name = "toolStripButton37";
            this.toolStripButton37.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton37.Text = "导出日志";
            this.toolStripButton37.Click += new System.EventHandler(this.toolStripButton37_Click);
            // 
            // toolStripButton38
            // 
            this.toolStripButton38.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton38.Image")));
            this.toolStripButton38.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton38.Name = "toolStripButton38";
            this.toolStripButton38.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton38.Text = "刷新日志";
            this.toolStripButton38.Click += new System.EventHandler(this.toolStripButton38_Click);
            // 
            // toolStripButton39
            // 
            this.toolStripButton39.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton39.Image")));
            this.toolStripButton39.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton39.Name = "toolStripButton39";
            this.toolStripButton39.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton39.Text = "删除日志";
            this.toolStripButton39.Click += new System.EventHandler(this.toolStripButton39_Click);
            // 
            // splitContainer6
            // 
            this.splitContainer6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer6.Location = new System.Drawing.Point(0, 29);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.treeView6);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.listView6);
            this.splitContainer6.Size = new System.Drawing.Size(774, 323);
            this.splitContainer6.SplitterDistance = 198;
            this.splitContainer6.TabIndex = 15;
            // 
            // treeView6
            // 
            this.treeView6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView6.HideSelection = false;
            this.treeView6.ImageIndex = 0;
            this.treeView6.ImageList = this.AllImageList;
            this.treeView6.Location = new System.Drawing.Point(0, 0);
            this.treeView6.Name = "treeView6";
            treeNode19.ImageIndex = 18;
            treeNode19.Name = "Node0";
            treeNode19.SelectedImageIndex = 18;
            treeNode19.Text = "应用程序";
            treeNode20.ImageIndex = 18;
            treeNode20.Name = "Node1";
            treeNode20.SelectedImageIndex = 18;
            treeNode20.Text = "安全性";
            treeNode21.ImageIndex = 18;
            treeNode21.Name = "Node2";
            treeNode21.SelectedImageIndex = 18;
            treeNode21.Text = "系统";
            treeNode22.ImageIndex = 20;
            treeNode22.Name = "Node0";
            treeNode22.SelectedImageIndex = 20;
            treeNode22.Text = "我的电脑";
            treeNode23.ImageIndex = 18;
            treeNode23.Name = "Node3";
            treeNode23.SelectedImageIndex = 18;
            treeNode23.Text = "应用程序";
            treeNode24.ImageIndex = 18;
            treeNode24.Name = "Node4";
            treeNode24.SelectedImageIndex = 18;
            treeNode24.Text = "安全性";
            treeNode25.ImageIndex = 18;
            treeNode25.Name = "Node5";
            treeNode25.SelectedImageIndex = 18;
            treeNode25.Text = "系统";
            treeNode26.ImageIndex = 20;
            treeNode26.Name = "Node1";
            treeNode26.SelectedImageIndex = 20;
            treeNode26.Text = "远程主机";
            this.treeView6.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode22,
            treeNode26});
            this.treeView6.SelectedImageIndex = 0;
            this.treeView6.Size = new System.Drawing.Size(198, 323);
            this.treeView6.TabIndex = 1;
            this.treeView6.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView6_AfterSelect);
            // 
            // listView6
            // 
            this.listView6.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader33,
            this.columnHeader34,
            this.columnHeader35,
            this.columnHeader36,
            this.columnHeader37,
            this.columnHeader38,
            this.columnHeader39,
            this.columnHeader40});
            this.listView6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView6.FullRowSelect = true;
            this.listView6.Location = new System.Drawing.Point(0, 0);
            this.listView6.MultiSelect = false;
            this.listView6.Name = "listView6";
            this.listView6.Size = new System.Drawing.Size(572, 323);
            this.listView6.TabIndex = 2;
            this.listView6.UseCompatibleStateImageBehavior = false;
            this.listView6.View = System.Windows.Forms.View.Details;
            this.listView6.DoubleClick += new System.EventHandler(this.listView6_DoubleClick);
            // 
            // columnHeader33
            // 
            this.columnHeader33.Text = "类型";
            this.columnHeader33.Width = 80;
            // 
            // columnHeader34
            // 
            this.columnHeader34.Text = "日期";
            this.columnHeader34.Width = 100;
            // 
            // columnHeader35
            // 
            this.columnHeader35.Text = "时间";
            this.columnHeader35.Width = 80;
            // 
            // columnHeader36
            // 
            this.columnHeader36.Text = "来源";
            this.columnHeader36.Width = 100;
            // 
            // columnHeader37
            // 
            this.columnHeader37.Text = "类别";
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "事件";
            // 
            // columnHeader39
            // 
            this.columnHeader39.Text = "用户";
            this.columnHeader39.Width = 100;
            // 
            // columnHeader40
            // 
            this.columnHeader40.Text = "计算机";
            this.columnHeader40.Width = 100;
            // 
            // faTabStripItem7
            // 
            this.faTabStripItem7.Controls.Add(this.toolStrip9);
            this.faTabStripItem7.Controls.Add(this.splitContainer7);
            this.faTabStripItem7.IsDrawn = true;
            this.faTabStripItem7.Name = "faTabStripItem7";
            this.faTabStripItem7.Size = new System.Drawing.Size(774, 352);
            this.faTabStripItem7.TabIndex = 7;
            this.faTabStripItem7.Title = "网络连接";
            // 
            // toolStrip9
            // 
            this.toolStrip9.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton40,
            this.toolStripButton41,
            this.toolStripButton42});
            this.toolStrip9.Location = new System.Drawing.Point(0, 0);
            this.toolStrip9.Name = "toolStrip9";
            this.toolStrip9.Size = new System.Drawing.Size(774, 25);
            this.toolStrip9.TabIndex = 16;
            this.toolStrip9.Text = "toolStrip9";
            // 
            // toolStripButton40
            // 
            this.toolStripButton40.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton40.Image")));
            this.toolStripButton40.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton40.Name = "toolStripButton40";
            this.toolStripButton40.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton40.Text = "导出列表";
            this.toolStripButton40.Click += new System.EventHandler(this.toolStripButton40_Click);
            // 
            // toolStripButton41
            // 
            this.toolStripButton41.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton41.Image")));
            this.toolStripButton41.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton41.Name = "toolStripButton41";
            this.toolStripButton41.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton41.Text = "刷新列表";
            this.toolStripButton41.Click += new System.EventHandler(this.toolStripButton41_Click);
            // 
            // toolStripButton42
            // 
            this.toolStripButton42.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton42.Image")));
            this.toolStripButton42.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton42.Name = "toolStripButton42";
            this.toolStripButton42.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton42.Text = "删除连接";
            this.toolStripButton42.Click += new System.EventHandler(this.toolStripButton42_Click);
            // 
            // splitContainer7
            // 
            this.splitContainer7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer7.Location = new System.Drawing.Point(0, 29);
            this.splitContainer7.Name = "splitContainer7";
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.treeView7);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.listView7);
            this.splitContainer7.Size = new System.Drawing.Size(774, 323);
            this.splitContainer7.SplitterDistance = 198;
            this.splitContainer7.TabIndex = 15;
            // 
            // treeView7
            // 
            this.treeView7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView7.HideSelection = false;
            this.treeView7.ImageIndex = 0;
            this.treeView7.ImageList = this.AllImageList;
            this.treeView7.Location = new System.Drawing.Point(0, 0);
            this.treeView7.Name = "treeView7";
            treeNode27.ImageIndex = 20;
            treeNode27.Name = "Node0";
            treeNode27.SelectedImageIndex = 20;
            treeNode27.Text = "我的电脑";
            treeNode28.ImageIndex = 20;
            treeNode28.Name = "Node1";
            treeNode28.SelectedImageIndex = 20;
            treeNode28.Text = "远程主机";
            this.treeView7.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode27,
            treeNode28});
            this.treeView7.SelectedImageIndex = 0;
            this.treeView7.ShowRootLines = false;
            this.treeView7.Size = new System.Drawing.Size(198, 323);
            this.treeView7.TabIndex = 1;
            this.treeView7.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView7_AfterSelect);
            // 
            // listView7
            // 
            this.listView7.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader50,
            this.columnHeader51,
            this.columnHeader52,
            this.columnHeader53,
            this.columnHeader54,
            this.columnHeader55,
            this.columnHeader56});
            this.listView7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView7.FullRowSelect = true;
            this.listView7.GridLines = true;
            this.listView7.Location = new System.Drawing.Point(0, 0);
            this.listView7.MultiSelect = false;
            this.listView7.Name = "listView7";
            this.listView7.Size = new System.Drawing.Size(572, 323);
            this.listView7.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView7.TabIndex = 0;
            this.listView7.UseCompatibleStateImageBehavior = false;
            this.listView7.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader50
            // 
            this.columnHeader50.Text = "协议";
            this.columnHeader50.Width = 50;
            // 
            // columnHeader51
            // 
            this.columnHeader51.Text = "进程";
            this.columnHeader51.Width = 80;
            // 
            // columnHeader52
            // 
            this.columnHeader52.Text = "本机IP:端口";
            this.columnHeader52.Width = 120;
            // 
            // columnHeader53
            // 
            this.columnHeader53.Text = "远程IP:端口";
            this.columnHeader53.Width = 120;
            // 
            // columnHeader54
            // 
            this.columnHeader54.Text = "状态";
            this.columnHeader54.Width = 80;
            // 
            // columnHeader55
            // 
            this.columnHeader55.Text = "进程ID";
            this.columnHeader55.Width = 50;
            // 
            // columnHeader56
            // 
            this.columnHeader56.Text = "路径";
            this.columnHeader56.Width = 200;
            // 
            // faTabStripItem8
            // 
            this.faTabStripItem8.Controls.Add(this.toolStrip10);
            this.faTabStripItem8.Controls.Add(this.splitContainer8);
            this.faTabStripItem8.IsDrawn = true;
            this.faTabStripItem8.Name = "faTabStripItem8";
            this.faTabStripItem8.Size = new System.Drawing.Size(774, 352);
            this.faTabStripItem8.TabIndex = 8;
            this.faTabStripItem8.Title = "开机启动";
            // 
            // toolStrip10
            // 
            this.toolStrip10.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton43,
            this.toolStripButton44,
            this.toolStripButton45});
            this.toolStrip10.Location = new System.Drawing.Point(0, 0);
            this.toolStrip10.Name = "toolStrip10";
            this.toolStrip10.Size = new System.Drawing.Size(774, 25);
            this.toolStrip10.TabIndex = 16;
            this.toolStrip10.Text = "toolStrip10";
            // 
            // toolStripButton43
            // 
            this.toolStripButton43.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton43.Image")));
            this.toolStripButton43.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton43.Name = "toolStripButton43";
            this.toolStripButton43.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton43.Text = "导出列表";
            this.toolStripButton43.Click += new System.EventHandler(this.toolStripButton43_Click);
            // 
            // toolStripButton44
            // 
            this.toolStripButton44.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton44.Image")));
            this.toolStripButton44.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton44.Name = "toolStripButton44";
            this.toolStripButton44.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton44.Text = "刷新列表";
            this.toolStripButton44.Click += new System.EventHandler(this.toolStripButton44_Click);
            // 
            // toolStripButton45
            // 
            this.toolStripButton45.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton45.Image")));
            this.toolStripButton45.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton45.Name = "toolStripButton45";
            this.toolStripButton45.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton45.Text = "删除启动";
            this.toolStripButton45.Click += new System.EventHandler(this.toolStripButton45_Click);
            // 
            // splitContainer8
            // 
            this.splitContainer8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer8.Location = new System.Drawing.Point(0, 29);
            this.splitContainer8.Name = "splitContainer8";
            // 
            // splitContainer8.Panel1
            // 
            this.splitContainer8.Panel1.Controls.Add(this.treeView8);
            // 
            // splitContainer8.Panel2
            // 
            this.splitContainer8.Panel2.Controls.Add(this.listView8);
            this.splitContainer8.Size = new System.Drawing.Size(774, 323);
            this.splitContainer8.SplitterDistance = 198;
            this.splitContainer8.TabIndex = 15;
            // 
            // treeView8
            // 
            this.treeView8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView8.HideSelection = false;
            this.treeView8.ImageIndex = 0;
            this.treeView8.ImageList = this.AllImageList;
            this.treeView8.Location = new System.Drawing.Point(0, 0);
            this.treeView8.Name = "treeView8";
            treeNode29.ImageIndex = 20;
            treeNode29.Name = "Node0";
            treeNode29.SelectedImageIndex = 20;
            treeNode29.Text = "我的电脑";
            treeNode30.ImageIndex = 20;
            treeNode30.Name = "Node1";
            treeNode30.SelectedImageIndex = 20;
            treeNode30.Text = "远程主机";
            this.treeView8.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode29,
            treeNode30});
            this.treeView8.SelectedImageIndex = 0;
            this.treeView8.ShowRootLines = false;
            this.treeView8.Size = new System.Drawing.Size(198, 323);
            this.treeView8.TabIndex = 1;
            this.treeView8.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView8_AfterSelect);
            // 
            // listView8
            // 
            this.listView8.AutoArrange = false;
            this.listView8.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AmoodName,
            this.AmoodData,
            this.AmoodRoot});
            this.listView8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView8.FullRowSelect = true;
            this.listView8.GridLines = true;
            this.listView8.Location = new System.Drawing.Point(0, 0);
            this.listView8.MultiSelect = false;
            this.listView8.Name = "listView8";
            this.listView8.Size = new System.Drawing.Size(572, 323);
            this.listView8.TabIndex = 2;
            this.listView8.UseCompatibleStateImageBehavior = false;
            this.listView8.View = System.Windows.Forms.View.Details;
            // 
            // AmoodName
            // 
            this.AmoodName.Text = "名称";
            this.AmoodName.Width = 100;
            // 
            // AmoodData
            // 
            this.AmoodData.Text = "来源";
            this.AmoodData.Width = 200;
            // 
            // AmoodRoot
            // 
            this.AmoodRoot.Text = "命令参数";
            this.AmoodRoot.Width = 250;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Transparent;
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.checkBox5);
            this.tabPage4.Controls.Add(this.comboBox2);
            this.tabPage4.Controls.Add(this.checkBox2);
            this.tabPage4.Controls.Add(this.checkBox1);
            this.tabPage4.Controls.Add(this.toolStrip2);
            this.tabPage4.Controls.Add(this.listView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(782, 379);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "命令广播";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(756, 436);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 47;
            this.label6.Text = "台";
            // 
            // checkBox5
            // 
            this.checkBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(189, 357);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(72, 16);
            this.checkBox5.TabIndex = 44;
            this.checkBox5.Text = "选择系统";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Windows XP",
            "Windows 2000",
            "Windows Server 2003"});
            this.comboBox2.Location = new System.Drawing.Point(267, 355);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(132, 20);
            this.comboBox2.TabIndex = 43;
            this.comboBox2.Text = "Windows XP";
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(93, 358);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 16);
            this.checkBox2.TabIndex = 39;
            this.checkBox2.Text = "反向选择";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 357);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 38;
            this.checkBox1.Text = "选择全部";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton13,
            this.toolStripButton14,
            this.toolStripButton15,
            this.toolStripSeparator6,
            this.toolStripButton16,
            this.toolStripButton17,
            this.toolStripSeparator7,
            this.toolStripButton18,
            this.toolStripButton19,
            this.toolStripSeparator13,
            this.toolStripButton20,
            this.toolStripButton21});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(782, 25);
            this.toolStrip2.TabIndex = 37;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
            this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton13.Text = "远程重启";
            // 
            // toolStripButton14
            // 
            this.toolStripButton14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton14.Image")));
            this.toolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton14.Name = "toolStripButton14";
            this.toolStripButton14.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton14.Text = "远程关机";
            // 
            // toolStripButton15
            // 
            this.toolStripButton15.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton15.Image")));
            this.toolStripButton15.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton15.Name = "toolStripButton15";
            this.toolStripButton15.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton15.Text = "远程注销";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton16
            // 
            this.toolStripButton16.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton16.Image")));
            this.toolStripButton16.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton16.Name = "toolStripButton16";
            this.toolStripButton16.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton16.Text = "窗体消息";
            // 
            // toolStripButton17
            // 
            this.toolStripButton17.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton17.Image")));
            this.toolStripButton17.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton17.Name = "toolStripButton17";
            this.toolStripButton17.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton17.Text = "文本消息";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton18
            // 
            this.toolStripButton18.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton18.Image")));
            this.toolStripButton18.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton18.Name = "toolStripButton18";
            this.toolStripButton18.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton18.Text = "远程卸载";
            // 
            // toolStripButton19
            // 
            this.toolStripButton19.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton19.Image")));
            this.toolStripButton19.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton19.Name = "toolStripButton19";
            this.toolStripButton19.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton19.Text = "服务重启";
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton20
            // 
            this.toolStripButton20.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton20.Image")));
            this.toolStripButton20.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton20.Name = "toolStripButton20";
            this.toolStripButton20.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton20.Text = "开启代理";
            // 
            // toolStripButton21
            // 
            this.toolStripButton21.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton21.Image")));
            this.toolStripButton21.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton21.Name = "toolStripButton21";
            this.toolStripButton21.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton21.Text = "批量命令";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(4, 28);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(785, 320);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 7;
            this.listView1.TabStop = false;
            this.listView1.TileSize = new System.Drawing.Size(128, 32);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "主机IP地址";
            this.columnHeader7.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "所在地区";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "电脑名称";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "用户名";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "操作系统";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "CPU";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "内存";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "硬盘";
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "显示器";
            this.columnHeader15.Width = 50;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "视频";
            this.columnHeader16.Width = 50;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "状态";
            this.columnHeader17.Width = 50;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.toolStrip3);
            this.tabPage9.Controls.Add(this.listView9);
            this.tabPage9.Location = new System.Drawing.Point(4, 24);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(782, 379);
            this.tabPage9.TabIndex = 4;
            this.tabPage9.Text = "文件传输";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton31,
            this.toolStripButton32,
            this.toolStripButton33,
            this.toolStripSeparator11,
            this.toolStripLabel2,
            this.toolStripLabel3,
            this.toolStripProgressBar1,
            this.toolStripSplitButton2});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(782, 25);
            this.toolStrip3.TabIndex = 12;
            this.toolStrip3.Text = "toolStrip4";
            // 
            // toolStripButton31
            // 
            this.toolStripButton31.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton31.Image")));
            this.toolStripButton31.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton31.Name = "toolStripButton31";
            this.toolStripButton31.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton31.Text = "正常启动";
            // 
            // toolStripButton32
            // 
            this.toolStripButton32.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton32.Image")));
            this.toolStripButton32.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton32.Name = "toolStripButton32";
            this.toolStripButton32.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton32.Text = "任务暂停";
            // 
            // toolStripButton33
            // 
            this.toolStripButton33.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton33.Image")));
            this.toolStripButton33.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton33.Name = "toolStripButton33";
            this.toolStripButton33.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton33.Text = "删除任务";
            this.toolStripButton33.Click += new System.EventHandler(this.toolStripButton33_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel3.Text = "传输进度：";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.BackColor = System.Drawing.SystemColors.Window;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(250, 22);
            this.toolStripProgressBar1.Step = 1;
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.断点续传ToolStripMenuItem,
            this.覆盖模式ToolStripMenuItem});
            this.toolStripSplitButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton2.Image")));
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(64, 22);
            this.toolStripSplitButton2.Text = "模式";
            this.toolStripSplitButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // 断点续传ToolStripMenuItem
            // 
            this.断点续传ToolStripMenuItem.Checked = true;
            this.断点续传ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.断点续传ToolStripMenuItem.Name = "断点续传ToolStripMenuItem";
            this.断点续传ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.断点续传ToolStripMenuItem.Text = "断点续传";
            this.断点续传ToolStripMenuItem.Click += new System.EventHandler(this.断点续传ToolStripMenuItem_Click);
            // 
            // 覆盖模式ToolStripMenuItem
            // 
            this.覆盖模式ToolStripMenuItem.Name = "覆盖模式ToolStripMenuItem";
            this.覆盖模式ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.覆盖模式ToolStripMenuItem.Text = "覆盖模式";
            this.覆盖模式ToolStripMenuItem.Click += new System.EventHandler(this.覆盖模式ToolStripMenuItem_Click);
            // 
            // listView9
            // 
            this.listView9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView9.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader58,
            this.columnHeader19,
            this.columnHeader18,
            this.columnHeader22,
            this.columnHeader24});
            this.listView9.ContextMenu = this.contextMenu3;
            this.listView9.FullRowSelect = true;
            this.listView9.GridLines = true;
            this.listView9.LargeImageList = this.AllImageList;
            this.listView9.Location = new System.Drawing.Point(5, 28);
            this.listView9.Name = "listView9";
            this.listView9.Size = new System.Drawing.Size(771, 348);
            this.listView9.SmallImageList = this.AllImageList;
            this.listView9.TabIndex = 7;
            this.listView9.TabStop = false;
            this.listView9.TileSize = new System.Drawing.Size(128, 32);
            this.listView9.UseCompatibleStateImageBehavior = false;
            this.listView9.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader58
            // 
            this.columnHeader58.Text = "状态";
            this.columnHeader58.Width = 40;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "远程主机";
            this.columnHeader19.Width = 120;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "文件名";
            this.columnHeader18.Width = 100;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "本地路径";
            this.columnHeader22.Width = 220;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "远程路径";
            this.columnHeader24.Width = 220;
            // 
            // ControlImageList
            // 
            this.ControlImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ControlImageList.ImageStream")));
            this.ControlImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ControlImageList.Images.SetKeyName(0, "user.ico");
            this.ControlImageList.Images.SetKeyName(1, "disk.ico");
            this.ControlImageList.Images.SetKeyName(2, "ring.ico");
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "名称";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "类型";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "数据";
            this.columnHeader6.Width = 150;
            // 
            // statusBar1
            // 
            this.statusBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusBar1.Location = new System.Drawing.Point(0, 500);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(798, 29);
            this.statusBar1.TabIndex = 6;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = " 本地IP：";
            this.statusBarPanel1.Width = 250;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Text = "打开本地监听端口5761成功，等待主机上线！";
            this.statusBarPanel2.Width = 331;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Text = "上线主机：0台";
            this.statusBarPanel3.Width = 200;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "名称";
            this.columnHeader30.Width = 100;
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "类型";
            this.columnHeader31.Width = 120;
            // 
            // columnHeader32
            // 
            this.columnHeader32.Text = "数据";
            this.columnHeader32.Width = 300;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(795, 527);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TwoCare";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.faTabStrip1)).EndInit();
            this.faTabStrip1.ResumeLayout(false);
            this.faTabStripItem1.ResumeLayout(false);
            this.faTabStripItem1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip11.ResumeLayout(false);
            this.toolStrip11.PerformLayout();
            this.faTabStripItem2.ResumeLayout(false);
            this.faTabStripItem2.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.faTabStripItem3.ResumeLayout(false);
            this.faTabStripItem3.PerformLayout();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.faTabStripItem4.ResumeLayout(false);
            this.faTabStripItem4.PerformLayout();
            this.toolStrip6.ResumeLayout(false);
            this.toolStrip6.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.faTabStripItem5.ResumeLayout(false);
            this.faTabStripItem5.PerformLayout();
            this.toolStrip7.ResumeLayout(false);
            this.toolStrip7.PerformLayout();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.ResumeLayout(false);
            this.faTabStripItem6.ResumeLayout(false);
            this.faTabStripItem6.PerformLayout();
            this.toolStrip8.ResumeLayout(false);
            this.toolStrip8.PerformLayout();
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            this.splitContainer6.ResumeLayout(false);
            this.faTabStripItem7.ResumeLayout(false);
            this.faTabStripItem7.PerformLayout();
            this.toolStrip9.ResumeLayout(false);
            this.toolStrip9.PerformLayout();
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            this.splitContainer7.ResumeLayout(false);
            this.faTabStripItem8.ResumeLayout(false);
            this.faTabStripItem8.PerformLayout();
            this.toolStrip10.ResumeLayout(false);
            this.toolStrip10.PerformLayout();
            this.splitContainer8.Panel1.ResumeLayout(false);
            this.splitContainer8.Panel2.ResumeLayout(false);
            this.splitContainer8.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.ToolBarButton toolBarButton3;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItemFile;
        private System.Windows.Forms.MenuItem menuItemSet;
        private System.Windows.Forms.MenuItem menuItemView;
        private System.Windows.Forms.MenuItem menuItemGong;
        private System.Windows.Forms.MenuItem menuItemHelp;
        private System.Windows.Forms.MenuItem menuItemMin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem cxMenuItemExit;
        private System.Windows.Forms.MenuItem cxMenuItemOpen;
        private System.Windows.Forms.MenuItem cxMenuItemZhuYe;
        private System.Windows.Forms.MenuItem menuItemZhuYe;
        private System.Windows.Forms.MenuItem menuItemAbout;
        private System.Windows.Forms.ImageList imageListImg;
        private System.Windows.Forms.ToolBarButton toolBarButton4;
        private System.Windows.Forms.ToolBarButton toolBarButton7;
        private System.Windows.Forms.ToolBarButton toolBarButton10;
        private System.Windows.Forms.MenuItem menuItemIP;
        private System.Windows.Forms.MenuItem menuItemPeiZhi;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.MenuItem menuItemSystem;
        private System.Windows.Forms.MenuItem menuItemSkin;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItemAddDesk;
        private System.Windows.Forms.MenuItem menuItemAddKuai;
        private System.Windows.Forms.MenuItem menuItemAddKai;
        private System.Windows.Forms.MenuItem menuItemToolBar;
        private System.Windows.Forms.MenuItem menuItemIPJiLu;
        private System.Windows.Forms.MenuItem menuItemHost;
        private System.Windows.Forms.MenuItem menuItemFileManage;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItemPing;
        private System.Windows.Forms.MenuItem menuItemViod;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItemSystemManage;
        private System.Windows.Forms.MenuItem menuItemDOS;
        private System.Windows.Forms.MenuItem menuItemKey;
        private System.Windows.Forms.MenuItem menuItemAllDos;
        private System.Windows.Forms.MenuItem menuItemUseHelp;
        private System.Windows.Forms.MenuItem menuItemDuanKou;
        private System.Windows.Forms.MenuItem menuItemXieZai;
        private System.Windows.Forms.ImageList AllImageList;
        private System.Windows.Forms.ContextMenu contextMenu2;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView listViewFile;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ToolBarButton toolBarButton13;
        private System.Windows.Forms.ImageList TreeImageList;
        private System.Windows.Forms.ImageList SmallimageList;
        private System.Windows.Forms.ImageList LargeimageList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ContextMenu contextMenu3;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.MenuItem menuItem14;
        private System.Windows.Forms.MenuItem menuItem15;
        private System.Windows.Forms.MenuItem menuItem16;
        private System.Windows.Forms.MenuItem menuItem17;
        private System.Windows.Forms.MenuItem menuItem18;
        private System.Windows.Forms.MenuItem menuItem29;
        private System.Windows.Forms.MenuItem menuItem30;
        private System.Windows.Forms.MenuItem menuItem31;
        private System.Windows.Forms.MenuItem menuItem32;
        private System.Windows.Forms.MenuItem menuItem33;
        private System.Windows.Forms.MenuItem menuItem19;
        private System.Windows.Forms.MenuItem menuItem20;
        private System.Windows.Forms.MenuItem menuItem21;
        private System.Windows.Forms.MenuItem menuItem22;
        private System.Windows.Forms.MenuItem menuItem23;
        private System.Windows.Forms.MenuItem menuItem24;
        private System.Windows.Forms.MenuItem menuItem25;
        private System.Windows.Forms.MenuItem menuItem26;
        private System.Windows.Forms.MenuItem menuItem27;
        private System.Windows.Forms.MenuItem menuItem28;
        private System.Windows.Forms.MenuItem menuItem34;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton0;
        private System.Windows.Forms.ToolStripButton toolStripButton12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton11;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem 大图标ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 小图标ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 详细资源ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.MenuItem menuItem35;
        private System.Windows.Forms.MenuItem menuItem36;
        private System.Windows.Forms.TabPage tabPage9;
        private FarsiLibrary.Win.FATabStrip faTabStrip1;
        private FarsiLibrary.Win.FATabStripItem faTabStripItem1;
        private FarsiLibrary.Win.FATabStripItem faTabStripItem3;
        private FarsiLibrary.Win.FATabStripItem faTabStripItem4;
        private FarsiLibrary.Win.FATabStripItem faTabStripItem5;
        private FarsiLibrary.Win.FATabStripItem faTabStripItem6;
        private FarsiLibrary.Win.FATabStripItem faTabStripItem7;
        private FarsiLibrary.Win.FATabStripItem faTabStripItem8;
        private FarsiLibrary.Win.FATabStripItem faTabStripItem2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TreeView treeView3;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TreeView treeView4;
        private System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.ListView listView5;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.ListView listView7;
        private System.Windows.Forms.SplitContainer splitContainer8;
        private System.Windows.Forms.TreeView treeView5;
        private System.Windows.Forms.TreeView treeView6;
        private System.Windows.Forms.TreeView treeView7;
        private System.Windows.Forms.TreeView treeView8;
        private System.Windows.Forms.ListView listView9;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton13;
        private System.Windows.Forms.ToolStripButton toolStripButton14;
        private System.Windows.Forms.ToolStripButton toolStripButton15;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButton16;
        private System.Windows.Forms.ToolStripButton toolStripButton17;
        private System.Windows.Forms.ToolStripButton toolStripButton18;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripButton19;
        private System.Windows.Forms.ToolStripButton toolStripButton20;
        private System.Windows.Forms.ToolStripButton toolStripButton21;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton31;
        private System.Windows.Forms.ToolStripButton toolStripButton32;
        private System.Windows.Forms.ToolStripButton toolStripButton33;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ListView listView6;
        private System.Windows.Forms.ColumnHeader columnHeader33;
        private System.Windows.Forms.ColumnHeader columnHeader34;
        private System.Windows.Forms.ColumnHeader columnHeader35;
        private System.Windows.Forms.ColumnHeader columnHeader36;
        private System.Windows.Forms.ColumnHeader columnHeader37;
        private System.Windows.Forms.ColumnHeader columnHeader38;
        private System.Windows.Forms.ColumnHeader columnHeader39;
        private System.Windows.Forms.ColumnHeader columnHeader40;
        private System.Windows.Forms.ColumnHeader columnHeader41;
        private System.Windows.Forms.ColumnHeader columnHeader42;
        private System.Windows.Forms.ColumnHeader columnHeader43;
        private System.Windows.Forms.ColumnHeader columnHeader44;
        private System.Windows.Forms.ColumnHeader columnHeader45;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private System.Windows.Forms.ColumnHeader columnHeader30;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.ColumnHeader columnHeader32;
        private System.Windows.Forms.ListView listView8;
        private System.Windows.Forms.ColumnHeader AmoodName;
        private System.Windows.Forms.ColumnHeader AmoodData;
        private System.Windows.Forms.ColumnHeader AmoodRoot;
        private System.Windows.Forms.ToolBarButton toolBarButton5;
        private System.Windows.Forms.ToolBarButton toolBarButton6;
        private System.Windows.Forms.ToolBarButton toolBarButton8;
        private System.Windows.Forms.ToolBarButton toolBarButton9;
        private System.Windows.Forms.ToolBarButton toolBarButton11;
        private System.Windows.Forms.ToolBarButton toolBarButton12;
        private System.Windows.Forms.ToolBarButton toolBarButton35;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.ColumnHeader columnHeader49;
        private System.Windows.Forms.ImageList ControlImageList;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader46;
        private System.Windows.Forms.ColumnHeader columnHeader47;
        private System.Windows.Forms.ColumnHeader columnHeader48;
        private System.Windows.Forms.ColumnHeader columnHeader50;
        private System.Windows.Forms.ColumnHeader columnHeader51;
        private System.Windows.Forms.ColumnHeader columnHeader52;
        private System.Windows.Forms.ColumnHeader columnHeader53;
        private System.Windows.Forms.ColumnHeader columnHeader54;
        private System.Windows.Forms.ColumnHeader columnHeader55;
        private System.Windows.Forms.ColumnHeader columnHeader56;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton22;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton toolStripButton23;
        private System.Windows.Forms.ToolStripButton toolStripButton24;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton toolStripButton25;
        private System.Windows.Forms.ToolStripButton toolStripButton26;
        private System.Windows.Forms.ToolStripButton toolStripButton27;
        private System.Windows.Forms.ToolStrip toolStrip6;
        private System.Windows.Forms.ToolStripButton toolStripButton28;
        private System.Windows.Forms.ToolStripButton toolStripButton29;
        private System.Windows.Forms.ToolStripButton toolStripButton30;
        private System.Windows.Forms.ToolStrip toolStrip7;
        private System.Windows.Forms.ToolStripButton toolStripButton34;
        private System.Windows.Forms.ToolStripButton toolStripButton35;
        private System.Windows.Forms.ToolStripButton toolStripButton36;
        private System.Windows.Forms.ToolStrip toolStrip8;
        private System.Windows.Forms.ToolStripButton toolStripButton37;
        private System.Windows.Forms.ToolStripButton toolStripButton38;
        private System.Windows.Forms.ToolStripButton toolStripButton39;
        private System.Windows.Forms.ToolStrip toolStrip9;
        private System.Windows.Forms.ToolStripButton toolStripButton40;
        private System.Windows.Forms.ToolStripButton toolStripButton41;
        private System.Windows.Forms.ToolStripButton toolStripButton42;
        private System.Windows.Forms.ToolStrip toolStrip10;
        private System.Windows.Forms.ToolStripButton toolStripButton43;
        private System.Windows.Forms.ToolStripButton toolStripButton44;
        private System.Windows.Forms.ToolStripButton toolStripButton45;
        private System.Windows.Forms.ToolStripButton toolStripButton46;
        private System.Windows.Forms.ToolStripButton toolStripButton49;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton toolStripButton50;
        private System.Windows.Forms.ToolStripButton toolStripButton51;
        private System.Windows.Forms.ToolStripButton toolStripButton52;
        private System.Windows.Forms.ToolStripButton toolStripButton53;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton toolStripButton54;
        private System.Windows.Forms.ToolStripButton toolStripButton55;
        private System.Windows.Forms.ToolStripButton toolStripButton56;
        private System.Windows.Forms.ToolStrip toolStrip11;
        private System.Windows.Forms.ColumnHeader columnHeader57;
        private System.Windows.Forms.ColumnHeader columnHeader58;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem 断点续传ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 覆盖模式ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripButton toolStripButton47;
        private System.Windows.Forms.ToolStripButton toolStripButton48;
        private System.Windows.Forms.ToolStripButton toolStripButton57;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.ToolStripButton toolStripButton58;
        private System.Windows.Forms.ToolStripButton toolStripButton59;
        private System.Windows.Forms.ToolStripButton toolStripButton60;
        private System.Windows.Forms.ToolStripButton toolStripButton61;
        private System.Windows.Forms.ToolStripButton toolStripButton62;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripButton toolStripButton63;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Label label21;
    }
}

