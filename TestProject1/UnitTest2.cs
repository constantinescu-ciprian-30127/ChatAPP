using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using XUnitPriorityOrderer;
using Chat_app_Server;

namespace TestProject1
{
    [TestCaseOrderer(CasePriorityOrderer.TypeName, CasePriorityOrderer.AssembyName)]
    public class UnitTest2
    {
        SimpleTcpServer server;
        SimpleTcpClient client;
        String localIP;
        String localServerPort = ":100";
        String remoteServerIP;

        
        public UnitTest2()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            remoteServerIP = localIP + localServerPort;
            server = new SimpleTcpServer(remoteServerIP);
            client = new SimpleTcpClient(remoteServerIP);
        }

        public void Dispose()
        {
            server.Dispose();
            server = null;
            client = null;
            remoteServerIP = String.Empty;
            localIP= String.Empty;
        }

        [Fact, Order(1)]
        public void StartServerTest()
        {
            server.Start();
            Assert.Equal(true, server.IsListening);
            client.Connect();
            Assert.Equal(true, client.IsConnected);
            Dispose();
        }

        [Fact, Order(2)]
        public void ConnectToServerTest()
        {
            server = new SimpleTcpServer(localIP + ":101");
            client = new SimpleTcpClient(localIP + ":101");
            server.Start();
            client.Connect();
            Assert.Equal(true, client.IsConnected);
            Dispose();
        }
        [Fact, Order(3)]
        public void DisconnectFromServerTest()
        {
            server = new SimpleTcpServer(localIP + ":102");
            client = new SimpleTcpClient(localIP + ":102");
            server.Start();
            client.Connect();
            client.Disconnect();
            Assert.False(client.IsConnected && (server.Connections == 0));
            Dispose();
        }

        [Fact, Order(4)]
        public void StopServerTest()
        {
            server = new SimpleTcpServer(localIP + ":104");
            client = new SimpleTcpClient(localIP + ":104");
            server.Start();
            server.Stop();
            Assert.Equal(false, server.IsListening);
            Dispose();
        }
    }
}
