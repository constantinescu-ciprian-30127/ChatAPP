namespace Chat_app_Client
{
    partial class Chat
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat));
            txtInfo = new TextBox();
            txtMessage = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            loggedUsersPanel = new Panel();
            chatsBtn = new Button();
            groupBtn = new Button();
            boxBtn = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            lblWelcome = new Label();
            loggedUsersPanels = new List<Panel>();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtInfo
            // 
            txtInfo.BackColor = Color.White;
            txtInfo.Location = new Point(187, 62);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ReadOnly = true;
            txtInfo.ScrollBars = ScrollBars.Both;
            txtInfo.Size = new Size(715, 424);
            txtInfo.TabIndex = 3;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(187, 535);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(653, 32);
            txtMessage.TabIndex = 5;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // loggedUsersPanel
            // 
            loggedUsersPanel.Location = new Point(5, 62);
            loggedUsersPanel.Name = "loggedUsersPanel";
            loggedUsersPanel.Size = new Size(161, 327);
            loggedUsersPanel.TabIndex = 8;
            // 
            // chatsBtn
            // 
            chatsBtn.BackColor = Color.White;
            chatsBtn.Image = (Image)resources.GetObject("chatsBtn.Image");
            chatsBtn.Location = new Point(4, 6);
            chatsBtn.Name = "chatsBtn";
            chatsBtn.Size = new Size(50, 50);
            chatsBtn.TabIndex = 9;
            chatsBtn.UseVisualStyleBackColor = false;
            chatsBtn.Click += chatsBtn_Click_1;
            // 
            // groupBtn
            // 
            groupBtn.BackColor = Color.White;
            groupBtn.Image = (Image)resources.GetObject("groupBtn.Image");
            groupBtn.Location = new Point(60, 6);
            groupBtn.Name = "groupBtn";
            groupBtn.Size = new Size(50, 50);
            groupBtn.TabIndex = 10;
            groupBtn.UseVisualStyleBackColor = false;
            groupBtn.Click += groupBtn_Click;
            // 
            // boxBtn
            // 
            boxBtn.BackColor = Color.White;
            boxBtn.Image = (Image)resources.GetObject("boxBtn.Image");
            boxBtn.Location = new Point(116, 6);
            boxBtn.Name = "boxBtn";
            boxBtn.Size = new Size(50, 50);
            boxBtn.TabIndex = 11;
            boxBtn.UseVisualStyleBackColor = false;
            boxBtn.Click += boxBtn_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(116, 86, 174);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(782, 13);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(101, 39);
            button1.TabIndex = 30;
            button1.Text = "Logout";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(841, 533);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 34);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 31;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblWelcome.ForeColor = Color.FromArgb(116, 86, 174);
            lblWelcome.Location = new Point(204, 17);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(0, 28);
            lblWelcome.TabIndex = 32;
            // 
            // Chat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 588);
            Controls.Add(lblWelcome);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(boxBtn);
            Controls.Add(groupBtn);
            Controls.Add(chatsBtn);
            Controls.Add(loggedUsersPanel);
            Controls.Add(txtMessage);
            Controls.Add(txtInfo);
            Name = "Chat";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private void InitializeLoggedUsersLabel()
        {
            for (int i = 0; i <= 10; i++) //aici am modificat
            {
                Label label = new Label()
                {
                    Location = new Point(50, 10),
                };
                label.Click += Label_Click;

                PictureBox pictureBox = new PictureBox()
                {
                    Image = new Bitmap("C:\\Users\\carlo\\source\\repos\\Chat-app Cipri v2\\Chat-app Client\\Resources\\profile.png"),
                    Location = new Point(3, 3),
                    Size = new Size(35, 35),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                Panel panel = new Panel()
                {
                    Location = new Point(3, 4 + 40 * i),
                    Size = new Size(150, 40)
                };
                panel.Click += Panel_Click;
                panel.Controls.Add(label);
                panel.Controls.Add(pictureBox);
                loggedUsersPanels.Add(panel);
            }
        }

        #endregion
        private TextBox txtInfo;
        private TextBox txtMessage;
        private System.Windows.Forms.Timer timer1;
        private Panel loggedUsersPanel;
        private Button chatsBtn;
        private Button groupBtn;
        private Button boxBtn;
        private Button button1;
        private PictureBox pictureBox1;
        private Label lblWelcome;
        private List<Panel> loggedUsersPanels;
    }
}