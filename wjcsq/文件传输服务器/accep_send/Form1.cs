using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
namespace accep_so
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private bool control =false;
		private int port;//新加的
		private Socket sock;//新加的
		private int number;//新加的
		
		private int j;//新加的
		private TcpListener listener;//新加的
		private FileStream filestream;//新加的
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.RichTextBox richTextBox2;
		private System.Windows.Forms.Label label3;
	

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			string[] str=new string[1024];
			for(int i=0;i<Directory.GetFiles("e:\\aa").Length;i++)
			{
				str[i]=Directory.GetFiles("e:\\aa")[i];
				richTextBox1.AppendText(str[i]+"\r\n");
			}


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
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.richTextBox2 = new System.Windows.Forms.RichTextBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			this.SuspendLayout();
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.Width = 300;
			// 
			// richTextBox2
			// 
			this.richTextBox2.Location = new System.Drawing.Point(96, 168);
			this.richTextBox2.Name = "richTextBox2";
			this.richTextBox2.Size = new System.Drawing.Size(320, 96);
			this.richTextBox2.TabIndex = 4;
			this.richTextBox2.Text = "";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(96, 64);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(320, 96);
			this.richTextBox1.TabIndex = 4;
			this.richTextBox1.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "监听端口：";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "文件列表：";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 168);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 1;
			this.label3.Text = "客户信息：";
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 305);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusBarPanel1});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(432, 20);
			this.statusBar1.TabIndex = 3;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(96, 32);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(320, 21);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(56, 272);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "开始服务";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(192, 272);
			this.button2.Name = "button2";
			this.button2.TabIndex = 0;
			this.button2.Text = "关闭服务";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(328, 272);
			this.button3.Name = "button3";
			this.button3.TabIndex = 0;
			this.button3.Text = "退出程序";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(432, 325);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label3,
																		  this.richTextBox2,
																		  this.button3,
																		  this.label2,
																		  this.richTextBox1,
																		  this.statusBar1,
																		  this.button2,
																		  this.textBox1,
																		  this.label1,
																		  this.button1});
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "accep_send";
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
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
		{
			try
			{
				port =Int32.Parse(textBox1.Text);
			}
			catch{MessageBox.Show("您输入的格式不对！请输入正整数。");}
				
			try
			{
				listener=new TcpListener(port);
				listener.Start();
				statusBarPanel1.Text="开始监听......";
				
			
					Thread thread=new Thread(new ThreadStart(recieve));
					thread.Start();
				
				


			}
			catch(Exception ee){MessageBox.Show(ee.Message);}
				

		}
	

		

		private void button2_Click(object sender, System.EventArgs e)
		{
				try
		 {  
			 listener.Stop();
			 statusBarPanel1.Text="停止监听";
		 }
		 catch{MessageBox.Show("监听还未开始，关闭无效。");}


		}

		private void label1_Click(object sender, System.EventArgs e)
		{

		}

		private void button3_Click(object sender, System.EventArgs e)
		{ 
			Application.Exit();

			

		}
		private void recieve()
		{
			sock=listener.AcceptSocket();
			if(sock.Connected)
			{
				//statusBarPanel1.Text="与客户建立连接";
				//string str=richTextBox1.Text;
                string str = "";
				byte[]  bytee=System.Text.Encoding.BigEndianUnicode.GetBytes(str.ToCharArray());
				sock.Send(bytee,bytee.Length,0);
			
				//接受信息＋＋＋＋
				while(!control)
				{   NetworkStream stream=new NetworkStream(sock);
					byte[] by=new Byte[1024];
					int i=sock.Receive(by,by.Length,0);
					string ss=System.Text.Encoding.BigEndianUnicode.GetString(by);
				    
					richTextBox2.AppendText(ss);
					j=richTextBox2.Lines.Length;
					
					if(j>=2)
					{
						 
						transfer(ref stream);
						 
						 
					 
	}//对应于if(j>=2)的“{”
}//对应于while(!control)的“｛”

			
}//对应于if(sock.Connected)的“｛”		
}//对应于private void recieve()的“{”
		private void transfer(ref NetworkStream stream)
		{
			filestream=new FileStream(richTextBox2.Lines[j-2].ToString(),FileMode.Open,FileAccess.Read);
							
			//定义缓冲区
			byte[] bb=new byte[1024];	
			//循环读文件
			 
			while((number=filestream.Read(bb,0,1024))!=0)
			{//向客户端发送流
				//sock.Send(bb,bb.Length,0);
				
				stream.Write(bb,0,1024);
				//刷新流
				stream.Flush();
								
				bb=new byte[1024];
				
							  
			}
			bb=new byte[1024];
			bb=System.Text.Encoding.ASCII.GetBytes("<EOF>");
			sock.Send(bb);
			stream.Flush();
		 			
			filestream.Close();
			//sock.Close();
			stream.Close();
			 
		
		}
	}
}
