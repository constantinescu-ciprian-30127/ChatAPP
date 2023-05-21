namespace Chat_app_Server
{
    partial class Server
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
            txtPort = new TextBox();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnStart = new Button();
            txtInfo = new RichTextBox();
            txtIP = new TextBox();
            SuspendLayout();
            // 
            // txtPort
            // 
            txtPort.Location = new Point(12, 171);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(246, 27);
            txtPort.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(12, 149);
            label1.Name = "label1";
            label1.Size = new Size(40, 19);
            label1.TabIndex = 17;
            label1.Text = "Port";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(12, 85);
            label3.Name = "label3";
            label3.Size = new Size(84, 19);
            label3.TabIndex = 16;
            label3.Text = "IP Address";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(116, 86, 174);
            label2.Location = new Point(12, 28);
            label2.Name = "label2";
            label2.Size = new Size(246, 39);
            label2.TabIndex = 15;
            label2.Text = "Server Chat-app";
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.DarkGray;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnStart.ForeColor = Color.FromArgb(116, 86, 174);
            btnStart.Location = new Point(24, 222);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(225, 32);
            btnStart.TabIndex = 14;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click_1;
            // 
            // txtInfo
            // 
            txtInfo.Enabled = false;
            txtInfo.Location = new Point(24, 270);
            txtInfo.Name = "txtInfo";
            txtInfo.Size = new Size(225, 248);
            txtInfo.TabIndex = 13;
            txtInfo.Text = "";
            txtInfo.TextChanged += txtInfo_TextChanged_1;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(12, 107);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(246, 27);
            txtIP.TabIndex = 12;
            // 
            // ServerConn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(283, 533);
            Controls.Add(txtPort);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnStart);
            Controls.Add(txtInfo);
            Controls.Add(txtIP);
            MaximizeBox = false;
            Name = "ServerConn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Server";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPort;
        private Label label1;
        private Label label3;
        private Label label2;
        private Button btnStart;
        private RichTextBox txtInfo;
        private TextBox txtIP;
    }
}