/******************************************
 * 版权所有jackch
 * QQ:106050555
 * E-mail:jackch88@hotmail.com
 * 个人Blog:http://www.jackch.cn
 * CSDN_Blog:http://blog.csdn.net/jackch88/
 * ****************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Jackch
{
    public class FileTrans
    {
        private long fileSize=0;            //文件大小
        private long nSize=0;               //已传输大小
        private string localFile = null;    //本地文件名，含路径
        private string remoteFile = null;   //远程文件名
        private long iStart=0;              //传输起始位置,断点续传
        private int status=0;               //传输状态，0：传输 1：暂停 2：取消
        private TcpListener tcpListener = null; //TCP监听
        private Socket socket = null;       //网络套接字
        private int port = 0;               //传输端口
        private FileInfo file = null;

        public FileTrans(string localFile,long fileSize, string remoteFile,int port)
        {
            this.localFile = localFile;
            this.remoteFile = remoteFile;
            this.fileSize = fileSize;
            this.file = new FileInfo(this.localFile);
            this.port = port;
        }
        public FileTrans(string localFile, long fileSize, string remoteFile, int port,long iStart)
        {
            this.localFile = localFile;
            this.remoteFile = remoteFile;
            this.fileSize = fileSize;
            this.iStart = iStart;
            this.file = new FileInfo(this.localFile);
            this.port = port;
        }
        public long NSize
        {
            get
            {
                return nSize;
            }
        }
        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        public bool UpLoad()
        {
            try
            {
                tcpListener = new TcpListener(port);
                tcpListener.Start();
                socket = tcpListener.AcceptSocket();
                FileStream fileStream = new FileStream(localFile, FileMode.Open, FileAccess.Read);
                if (socket.Connected)
                {
                    int number = 0;
                    byte[] by = new byte[1024];
                    while ((number = fileStream.Read(by, 0, 1024)) > 0)
                    {
                        socket.Send(by);
                        fileStream.Flush();
                        by = new byte[1024];
                        nSize += number / 8;
                    }
                    fileStream.Close();
                }
                socket.Close();
                tcpListener.Stop();
            }
            catch 
            {
                return false;
            }
            return true;
        }
        public bool DownLoad()
        {
            try
            {
                tcpListener = new TcpListener(port);
                tcpListener.Start();
                socket = tcpListener.AcceptSocket();
                FileStream fileStream = new FileStream(localFile, FileMode.Open, FileAccess.Read);
                if (socket.Connected)
                {
                    int number = 0;
                    byte[] by = new byte[1024];
                    while ((number = socket.Receive(by)) > 0)
                    {
                        fileStream.Write(by, 0, by.Length);
                        fileStream.Flush();
                        by = new byte[1024];
                        nSize += number / 8;
                    }
                    fileStream.Close();
                }
                socket.Close();
                tcpListener.Stop();
            }
            catch 
            {
                return false;
            }
            return true;
        }

    }
}
