using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;
namespace ClassClient
{
    public class Client
    {
        private static TcpClient client;//新加的
        private static int i;//新加的
        private static NetworkStream netStream;//新加的
        private static FileStream filestream = null;//新加的
        private static string downFile;
        public static bool beginConnection(string cName,string ip,string p)
        {
            int port = 0;
            IPAddress myIP = IPAddress.Parse("127.0.0.1");

            try
            {
                myIP = IPAddress.Parse(ip);
            }
            catch 
            {
                return false;
            }
            client = new TcpClient();
            try
            {
                port = Int32.Parse(p);
            }
            catch 
            {
                return false; 
            }
            try
            {
                if (cName != "" && ip == "")
                {
                    client.Connect(cName, port);
                    netStream = client.GetStream();
                    byte[] bb = new byte[6400];

                    i = netStream.Read(bb, 0, 6400);
                    downFile = System.Text.Encoding.BigEndianUnicode.GetString(bb);
                    return true;
                   
                }
                if (ip != "" && p == "")
                {
                    client.Connect(myIP, port);
                    netStream = client.GetStream();
                    byte[] bb = new byte[6400];

                    int i = netStream.Read(bb, 0, 6400);
                    downFile = System.Text.Encoding.BigEndianUnicode.GetString(bb);
                    return true;
                    
                }

                if (ip != "" && p != "")
                {
                    client.Connect(myIP, port);
                    netStream = client.GetStream();
                    byte[] bb = new byte[6400];
                    int i = netStream.Read(bb, 0, 6400);
                    downFile = bb.ToString();
                    downFile = System.Text.Encoding.BigEndianUnicode.GetString(bb);
                    downFile = downFile.Replace("\0","");
                    return true;
                    
                }


            }
            catch (Exception ee) 
            {
                return false;
            }
            return false;

        }
        public static bool getFile()
        {
            try
            {
                //构造新的文件流
                filestream = new FileStream(Application.StartupPath + "\\test.jpg", FileMode.OpenOrCreate, FileAccess.Write);
                //获取服务器网络流
                netStream = client.GetStream();
                byte[] by = System.Text.Encoding.BigEndianUnicode.GetBytes(downFile.ToCharArray());
                //向服务器发送要下载的文件名
                netStream.Write(by, 0, by.Length);
                //刷新流
                netStream.Flush();
                //启动接收文件的线程
                Thread thread = new Thread(new ThreadStart(download));
                thread.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
                
            }
            return false;
        
        }
        public static bool endConnection()
        {
            try
            {
                netStream = client.GetStream();
                string clo = "@@@@@@" + "\r\n";
                byte[] by = System.Text.Encoding.BigEndianUnicode.GetBytes(clo.ToCharArray());
                netStream.Write(by, 0, by.Length);
                netStream.Flush();
                client.Close();
                return true;
            }
            catch 
            {
                return false;
            }
            return false;
        }



        private static void download()
        {
            try
            {
                down(ref netStream);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }
        private static void down(ref NetworkStream stream)
        {
            try
            {
                int length = 1024;
                byte[] bye = new byte[1024];

                int tt = stream.Read(bye, 0, length);

                //下行循环读取网络流并写进文件
                while (tt > 0)
                {
                    string ss = System.Text.Encoding.ASCII.GetString(bye);
                    int x = ss.IndexOf("<EOF>");
                    if (x != -1)
                    {

                        filestream.Write(bye, 0, x);
                        filestream.Flush();
                        break;
                    }
                    else
                    {
                        filestream.Write(bye, 0, tt);
                        filestream.Flush();
                    }
                    tt = stream.Read(bye, 0, length);

                }

                filestream.Close();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }



        }

    }
    
		

}
