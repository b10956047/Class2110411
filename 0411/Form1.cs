﻿using System;
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

namespace _0411
{
    public partial class Form1 : Form
    {
        UdpClient U;
        Thread Th;

        ShapeContainer C;
        ShapeContainer D;
        Point stP;
        string P;

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
            button1.Enabled = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            C = new ShapeContainer();//建立畫布
            this.Controls.Add(C);//加入畫布C到Form1
            D = new ShapeContainer();
            this.Controls.Add(D);//加入畫布D到Form1
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            stP = e.Location;
            P = stP.X.ToString() + "," + stP.Y.ToString();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                LineShape L = new LineShape();//建立線段物件
                L.StartPoint = stP;//線段起點
                L.EndPoint = e.Location;//線段終點
                L.Parent = C;//線段加入畫布C
                stP = e.Location;//終點變起點
                P += "/" +stP.X.ToString() + "," + stP.Y.ToString();//持續記錄座標
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
