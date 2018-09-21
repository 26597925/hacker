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
using System.Diagnostics;

namespace Jackch
{
    public static class Cmd
    {
        static Cmd() { }
        public static string RunCmd(string command)//运行一个cmd命令
        { 
             Process p = new Process();

             //Process0有一0StartInfo0性，00是ProcessStartInfo0，包括了一些0性和方法，下面我0用到了他的000性：p.StartInfo.WorkingDirectory = "c:\\";
             p.StartInfo.FileName = "cmd.exe";           //設定程序名
             p.StartInfo.Arguments = "/c " + command;    //設定程式執行參數
             p.StartInfo.UseShellExecute = false;        //關閉Shell的使用
             p.StartInfo.RedirectStandardInput = true;   //重定向標準輸入
             p.StartInfo.RedirectStandardOutput = true;  //重定向標準輸出
             p.StartInfo.RedirectStandardError = true;   //重定向錯誤輸出
             p.StartInfo.CreateNoWindow = true;          //設置不顯示窗口
 
             p.Start();   //啟動
             
            //p.StandardInput.WriteLine(command);       //也可以用這種方式輸入要執行的命令
            //p.StandardInput.WriteLine("exit");        //不過要記得加上Exit要不然下一行程式執行的時候會當機
             
             return p.StandardOutput.ReadToEnd();        //從輸出流取得命令執行結果

        }
        public static void RunFile(string f)//打开一个外部文件
        {

            //声明一个程序类
            System.Diagnostics.Process Proc; 
            try
            {
                //
                //启动外部程序
                //
                Proc = System.Diagnostics.Process.Start(f);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                //Console.WriteLine("系统找不到指定的程序文件。\r{0}", e);
                return;
            }


        }
        public static void RunIE(string command)//打开指定网页
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "iexplore.exe";
            myProcess.StartInfo.Arguments = command;
            myProcess.Start();
            return;       

        }
        public static void RunOther(string name, string command)//打开其他程序
        {
            Process myProcess = new Process();

            myProcess.StartInfo.FileName = name;
            myProcess.StartInfo.Arguments = command;
            myProcess.Start();
            return;

        }
    }
}


