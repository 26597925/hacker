using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Windows.Forms;
namespace ListenerDLL
{

    public class Listener
    {
        private static int port;//新加的
        private static Socket sock;//新加的
        private static int number;//新加的

        private static int j;//新加的
        private static TcpListener listener;//新加的
        private static FileStream filestream;//新加的
        private static string fileStr = Application.StartupPath + "\\test.jpg";
        private static bool control = false;
        private static Thread thread;
        public static bool beginListen()
        {
            try
            {
                port = 8888;//默认端口号
                listener=  new TcpListener(port);
                listener.Start();
                Thread thread = new Thread(new ThreadStart(recieve));
                thread.Start();
                return true;
            }
            catch (Exception ee)
            {
                return false;
            }
            return false;

        }
        public static bool endListen()
        {
            try
            {
                if (listener != null)
                {
                    listener.Stop();
                    listener = null;
                    
                    return true;
                }
            }
            catch
            {

            }
            return false;
        }
        private static void recieve()
        {
            //CheckForIllegalCrossThreadCalls
            //System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;//在线程中调用控件

            try
            {
                sock = listener.AcceptSocket();
                if (sock.Connected)
                {

                    byte[] bytee = System.Text.Encoding.BigEndianUnicode.GetBytes(fileStr.ToCharArray());
                    sock.Send(bytee, bytee.Length, 0);

                    //接受信息＋＋＋＋
                    while (!control)
                    {
                        NetworkStream stream = new NetworkStream(sock);
                        byte[] by = new Byte[1024];
                        int i = sock.Receive(by, by.Length, 0);

                        transfer(ref stream);
                    }

                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private static void transfer(ref NetworkStream stream)
        {
            try
            {
                filestream = new FileStream(fileStr, FileMode.Open, FileAccess.Read);
                //定义缓冲区
                byte[] bb = new byte[1024];
                //循环读文件

                while ((number = filestream.Read(bb, 0, 1024)) != 0)
                {//向客户端发送流
                    //sock.Send(bb,bb.Length,0);

                    stream.Write(bb, 0, 1024);
                    //刷新流
                    stream.Flush();

                    bb = new byte[1024];


                }
                bb = new byte[1024];
                bb = System.Text.Encoding.ASCII.GetBytes("<EOF>");
                sock.Send(bb);
                stream.Flush();
                filestream.Close();
                //sock.Close();
                stream.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                
            
            }


        }
    }
}
