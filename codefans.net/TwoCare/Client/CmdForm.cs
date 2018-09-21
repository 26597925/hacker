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

namespace Jackch
{
    public partial class CmdForm : Form
    {
        public CmdForm()
        {
            InitializeComponent();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string str = Cmd.RunCmd(richTextBox1.Lines[richTextBox1.Lines.Length - 1]);
                    richTextBox1.AppendText("\n"+str);
                }
                catch (Exception)
                {
                    richTextBox1.AppendText("ERROR\n");
                }
            }

        }
    }
}