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

namespace Jackch
{
    public class Chickens:IEnumerable
    {
        private ArrayList chickens = new ArrayList();
        private Chicken _currentChicken = null;

        public Chickens()
        {

        }
        public void AddChicken(Chicken chicken)
        {
            chickens.Add(chicken); 
        }
        public void DelChicken(Chicken chicken)
        {
            chickens.Remove(chicken);
        }
        public void UpdataChicken(Chicken chicken)
        {

        }
        public int Count
        {
            get
            {
                return chickens.Count;
            }
        }
        public Chicken this[int index]
        {
            get
            {
                return (Chicken)chickens[index];
            }
            set
            {
                chickens[index] = value;
            }
        }
        public IEnumerator GetEnumerator()
        {
            return chickens.GetEnumerator();
        }
        public Chicken CurrentChicken
        {
            get
            {
                return _currentChicken;
            }
            set
            {
                _currentChicken = value;
            }
        }
    }
}


