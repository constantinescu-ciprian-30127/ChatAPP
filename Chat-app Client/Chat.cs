using SuperSimpleTcp;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Chat_app_Client
{
    public partial class Chat : Form
    {

        private String userName;
        private String localServerIP;
        private String localServerPort = "500";
        private String ServerAddress;
        private String userIPSendTo;

        public Chat(String userName)
        {
            InitializeComponent();
            InitializeLoggedUsersLabel();
            lblWelcome.Text = "Welcome back, " + userName;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localServerIP = endPoint.Address.ToString();
            }
            ServerAddress = localServerIP + ":" + localServerPort;
            this.userName = userName;
        }

        SimpleTcpClient client;

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new(ServerAddress);
            client.Events.Connected += Events_Connected;
            client.Events.DataReceived += Events_DataReceived;
            client.Events.Disconnected += Events_Disconnected;
            chatsBtn.Image = new Bitmap("C:\\Users\\carlo\\source\\repos\\Chat-app Cipri\\Chat-app Client\\Resources\\message_selected.png");

            try
            {
                client.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void UpdateLoggedUsers()
        {
            loggedUsersPanel.Controls.Clear();
            Dictionary<String, String> loggedUsers = Account.getAllLoggedUsers();//aici am modificat
            if (loggedUsers != null && loggedUsersPanels != null)
            {
                for (int i = 0; i < loggedUsers.Keys.Count; i++)
                {
                    //loggedUsersLabels[i].Text = loggedUsers.Keys.ToArray()[i];
                    var controls = loggedUsersPanels[i].Controls;
                    foreach (Control control in controls)
                    {
                        if (control is Label)
                            control.Text = loggedUsers.Keys.ToArray()[i];
                    }
                    loggedUsersPanel.Controls.Add(loggedUsersPanels[i]);
                }
            }
        }

        private void Panel_Click(object? sender, EventArgs e)
        {
            var panel = sender as Panel;
            var controls = panel.Controls;
            foreach (Control control in controls)
            {
                if (control is Label)
                {
                    userIPSendTo = Account.getUserIPByUsername(control.Text);
                    break;
                }
            }
            for (int i = 0; i <= 10; i++)
            {
                loggedUsersPanels[i].BackColor = Color.White;
            }
            if (panel != null)
            {
                panel.BackColor = Color.AliceBlue;
            }
        }

        private void Label_Click(object? sender, EventArgs e)
        {
            userIPSendTo = Account.getUserIPByUsername(sender.ToString().Split(',', ' ')[3]);//aici am modificat
            var label = sender as Label;
            var controls = loggedUsersPanels.ToArray();
            for (int i = 0; i <= 10; i++)
            {
                loggedUsersPanels[i].BackColor = Color.White;
            }
            foreach (Panel p in loggedUsersPanels.ToArray())
            {
                foreach (Control c in p.Controls)
                {
                    if (c is Label && c.Text.Equals(sender.ToString().Split(',', ' ')[3]))
                    {
                        p.BackColor = Color.AliceBlue;
                        break;
                    }
                }
            }
        }

        private void L_Click(object? sender, EventArgs e)
        {
            userIPSendTo = Account.getUserIPByUsername(sender.ToString().Split(',', ' ')[3]);
        }


        private void Events_Disconnected(object? sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"Server disconnected.{Environment.NewLine}";

            });
            Account.updateUserStatus(userName, false);
        }

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                char[] delimiters = { '-' };
                var data = Encoding.UTF8.GetString(e.Data).Split(delimiters);
                txtInfo.Text += $"{Account.getUsernameByIP(data[0])}: {data[1]}{Environment.NewLine}";
            });

        }

        private void Events_Connected(object? sender, EventArgs e)
        {

            Account.updateUserStatus(userName, true);
            Account.updateUserIP(userName, localServerIP + ":" + client.LocalEndpoint.Port);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
            UpdateLoggedUsers();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Account.updateUserStatus(userName, false);
        }

        private void chatsBtn_Click_1(object sender, EventArgs e)
        {
            chatsBtn.Image = new Bitmap("C:\\Users\\carlo\\source\\repos\\Chat-app Cipri\\Chat-app Client\\Resources\\message_selected.png");
            groupBtn.Image = new Bitmap("C:\\Users\\carlo\\source\\repos\\Chat-app Cipri\\Chat-app Client\\Resources\\group.png");
            boxBtn.Image = new Bitmap("C:\\Users\\carlo\\source\\repos\\Chat-app Cipri\\Chat-app Client\\Resources\\box.png");
            loggedUsersPanel.Visible = true;
        }

        private void groupBtn_Click(object sender, EventArgs e)
        {
            chatsBtn.Image = new Bitmap("C:\\Users\\carlo\\source\\repos\\Chat-app Cipri\\Chat-app Client\\Resources\\message.png");
            groupBtn.Image = new Bitmap("C:\\Users\\carlo\\source\\repos\\Chat-app Cipri\\Chat-app Client\\Resources\\group_selected.png");
            boxBtn.Image = new Bitmap("C:\\Users\\carlo\\source\\repos\\Chat-app Cipri\\Chat-app Client\\Resources\\box.png");
            loggedUsersPanel.Visible = false;
        }

        private void boxBtn_Click(object sender, EventArgs e)
        {
            chatsBtn.Image = new Bitmap("C:\\Users\\carlo\\source\\repos\\Chat-app Cipri\\Chat-app Client\\Resources\\message.png");
            groupBtn.Image = new Bitmap("C:\\Users\\carlo\\source\\repos\\Chat-app Cipri\\Chat-app Client\\Resources\\group.png");
            boxBtn.Image = new Bitmap("C:\\Users\\carlo\\source\\repos\\Chat-app Cipri\\Chat-app Client\\Resources\\box_selected.png");
            loggedUsersPanel.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                if (!string.IsNullOrEmpty(txtMessage.Text))
                {
                    client.Send("<" + userIPSendTo + ">" + txtMessage.Text);
                    txtInfo.Text += $"Me: {txtMessage.Text}{Environment.NewLine}";
                    txtMessage.Text = string.Empty;
                }
            }
        }


    }
}