using Chat_app_Client;
using SuperSimpleTcp;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Schema;

namespace Chat_app_Server
{
    public partial class Server : Form
    {
        String localIP;
        String serverIP;
        public Server()
        {
            InitializeComponent();
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            txtIP.Text = localIP;
            txtPort.Text = "500";
            serverIP = localIP + ":500";
        }

        SimpleTcpServer server;


        private void Form1_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer(serverIP);
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;
        }



        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"{e.IpPort} {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
            });

        }
        private void Events_ClientDisconnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"{e.IpPort} disconnected.{Environment.NewLine}";
            });


        }

        private void Events_ClientConnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"{e.IpPort} connected.{Environment.NewLine}";
                Account.updateUserIP(sender.GetType().Name, e.IpPort);
            });


        }

        private void txtInfo_TextChanged_1(object sender, EventArgs e)
        {
            if (txtInfo.Text != "Starting...\r\n")
            {

                if (txtInfo.Lines[txtInfo.Lines.Length - 2].Contains("<"))
                {
                    char[] delimiters = { '<', '>' };
                    var data = txtInfo.Lines[txtInfo.Lines.Length - 2].Split(delimiters);
                    if (!(data[1] == data[0].Split(' ')[0]))//aici am modificat
                    {
                        server.Send(data[1], data[0] + "-" + data[2]);
                    }

                }
            }
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            server.Start();
            txtInfo.Text += $"Starting...{Environment.NewLine}";
            btnStart.Enabled = false;
        }
    }
}