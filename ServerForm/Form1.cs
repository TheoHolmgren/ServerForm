﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerForm
{
    using System.Net;
    using System.Net.Sockets;
    public partial class Form1 : Form
    {
        TcpListener lyssnare;
        TcpClient klient;
        int port = 12345;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lyssnare = new TcpListener(IPAddress.Any, port);
            lyssnare.Start();
            //Väntar på connect i klienten
            klient = lyssnare.AcceptTcpClient();

            byte[] inData = new byte[256];
            //Väntar på send i klienten
            int antalByte = klient.GetStream().Read(inData, 0, inData.Length);
        }
    }
}