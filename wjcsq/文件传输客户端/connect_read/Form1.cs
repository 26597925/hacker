using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace connect
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private TcpClient client;//新加的
		private int i;//新加的
		private NetworkStream netStream;//新加的
		private FileStream filestream=null;//新加的
		//private Stream stream =null;//新加的
 
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 23);
			this.label4.TabIndex = 1;
			this.label4.Text = "服务器IP地址：";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 216);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(104, 23);
			this.label5.TabIndex = 1;
			this.label5.Text = "选择下载文件：";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(120, 144);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(312, 64);
			this.richTextBox1.TabIndex = 4;
			this.richTextBox1.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "服务器名称：";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "端口：";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 144);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 23);
			this.label3.TabIndex = 1;
			this.label3.Text = "服务器文件列表：";
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.Width = 300;
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.FileName = "doc1";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(160, 56);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(184, 21);
			this.textBox2.TabIndex = 2;
			this.textBox2.Text = "";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(160, 80);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(184, 21);
			this.textBox3.TabIndex = 2;
			this.textBox3.Text = "";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(160, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(184, 21);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.label1,
																					this.textBox1,
																					this.textBox3,
																					this.textBox2,
																					this.label4,
																					this.label2});
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(432, 120);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "服务器（名称与IP地址任输其一）";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownWidth = 312;
			this.comboBox1.Location = new System.Drawing.Point(120, 216);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(312, 20);
			this.comboBox1.TabIndex = 6;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(40, 280);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 24);
			this.button1.TabIndex = 0;
			this.button1.Text = "连接";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(344, 280);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 24);
			this.button2.TabIndex = 0;
			this.button2.Text = "关闭连接";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(192, 280);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(72, 24);
			this.button3.TabIndex = 0;
			this.button3.Text = "下载";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 313);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusBarPanel1});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(456, 20);
			this.statusBar1.TabIndex = 3;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(456, 333);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button3,
																		  this.label5,
																		  this.comboBox1,
																		  this.groupBox1,
																		  this.richTextBox1,
																		  this.label3,
																		  this.statusBar1,
																		  this.button2,
																		  this.button1});
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Connect_read";
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{   int port=0;
			IPAddress myIP=IPAddress.Parse("127.0.0.1");
		 
			try
			{
				myIP=IPAddress.Parse(textBox2.Text);}
			catch{MessageBox.Show("您输入的IP地址格式不正确！");}
			client =new TcpClient();
			try{
			port=Int32.Parse(textBox3.Text);
			}
			catch{MessageBox.Show("请输入整数。");}
			try
			{
					if(textBox1.Text!=""&&textBox2.Text=="")
				{
					client.Connect(textBox1.Text,port);
					statusBarPanel1.Text="与服务器建立连接";
						netStream=client.GetStream();
						byte[] bb=new byte[6400];
					
						i=netStream.Read(bb,0,6400);
						string ss=System.Text.Encoding.BigEndianUnicode.GetString(bb);
						richTextBox1.AppendText(ss);
						int j=richTextBox1.Lines.Length;
				   
						for(int k=0;k<j-1;k++)
						{
							comboBox1.Items.Add(richTextBox1.Lines[k]);
						
						}
						comboBox1.Text=comboBox1.Items[0].ToString();	
					
						
						
						
					}
				 if(textBox2.Text!=""&&textBox1.Text==""){
						client.Connect(myIP,port);
						statusBarPanel1.Text="与服务器建立连接";
						netStream=client.GetStream();
					
						byte[] bb=new byte[6400];
					
						int i=netStream.Read(bb,0,6400);
						string ss=System.Text.Encoding.BigEndianUnicode.GetString(bb);
						richTextBox1.AppendText(ss);
					 int j=richTextBox1.Lines.Length;
				   
					 for(int k=0;k<j-1;k++)
					 {
						 comboBox1.Items.Add(richTextBox1.Lines[k]);
						
					 }
					 comboBox1.Text=comboBox1.Items[0].ToString();	
					
					
						
					
					}


				if(textBox2.Text!=""&&textBox1.Text!=""){
					client.Connect(myIP,port);
					statusBarPanel1.Text="与服务器建立连接";
					netStream=client.GetStream();
					
					byte[] bb=new byte[6400];
					
					int i=netStream.Read(bb,0,6400);
					string ss=System.Text.Encoding.BigEndianUnicode.GetString(bb);
					richTextBox1.AppendText(ss);
					int j=richTextBox1.Lines.Length;
				   
					for(int k=0;k<j-1;k++)
					{
						comboBox1.Items.Add(richTextBox1.Lines[k]);
						
					}
					comboBox1.Text=comboBox1.Items[0].ToString();	
					
				}
					
			}
			catch(Exception ee){MessageBox.Show(ee.Message);}


		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			try
			{netStream=client.GetStream();
			string clo="@@@@@@"+"\r\n";
			byte[]  by=System.Text.Encoding.BigEndianUnicode.GetBytes(clo.ToCharArray());
			netStream.Write(by,0,by.Length);
			netStream.Flush();

				client.Close();
				statusBarPanel1.Text="与服务器断开连接";
			}
			catch{}

		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			 
			 
				if(saveFileDialog1.ShowDialog()==DialogResult.OK)
				{   //构造新的文件流
					filestream=new FileStream(saveFileDialog1.FileName,FileMode.OpenOrCreate,FileAccess.Write);
					//获取服务器网络流
					netStream=client.GetStream();
					string down=comboBox1.Text+"\r\n";
					byte[]  by=System.Text.Encoding.BigEndianUnicode.GetBytes(down.ToCharArray());
					//向服务器发送要下载的文件名
					netStream.Write(by,0,by.Length);
					//刷新流
					netStream.Flush();
					//启动接收文件的线程
					Thread thread=new Thread(new ThreadStart(download));
					thread.Start();
				}//对应if(saveFileDialog1.ShowDialog()==DialogResult.OK)


		}
		private void download()
		{ 
			down(ref netStream);
		
		}
		private void down(ref NetworkStream stream)
		{ 
			int length=1024;
			byte[] bye=new byte[1024];

			int tt=stream.Read(bye,0,length);
		
			//下行循环读取网络流并写进文件
			while(tt>0)
			{ 
				
				
				
				
			   string ss=System.Text.Encoding.ASCII.GetString(bye);
			   int x=ss.IndexOf("<EOF>");
				if(x!=-1)
				{
					
					filestream.Write(bye,0,x);
					filestream.Flush();	
					break;
				}
				else
				{
					filestream.Write(bye,0,tt);
					filestream.Flush();
				}
				tt=stream.Read(bye,0,length);
				 
			}//对用于while(!control)的“｛”
		
			filestream.Close();
			 
	 
			MessageBox.Show("下载完毕！");
		 
		}
		
	}
}
