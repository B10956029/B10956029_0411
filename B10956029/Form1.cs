using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.VisualBasic.PowerPacks;

namespace B10956029
{
    public partial class Form1 : Form
    {

        UdpClient U;
        Thread Th;

        ShapeContainer C;//畫布物件
        ShapeContainer D;//畫布物件
        Point stP;//繪圖起點
        string p;//筆畫座標字串

        public Form1()
        {
            InitializeComponent();
        }

        private void Listen()
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try 
            {
                Th.Abort();//關閉監聽執行續
                U.Close();//關閉監聽器
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Th = new Thread(Listen);//建立監聽執行續
            Th.Start();
            button1.Enabled=false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            C = new ShapeContainer();//建立畫布
            this.Controls.Add(C);//加入畫布C到form1
            D = new ShapeContainer();
            this.Controls.Add(D);//加入畫布D到form1
        }
    }
}
