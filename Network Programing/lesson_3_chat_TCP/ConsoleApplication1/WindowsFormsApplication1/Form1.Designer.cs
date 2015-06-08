namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.send_message = new System.Windows.Forms.Button();
            this.chat = new System.Windows.Forms.TextBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.start_server = new System.Windows.Forms.Button();
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.create_user = new System.Windows.Forms.Button();
            this.tbPortServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMyPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(15, 291);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(260, 18);
            this.tbMessage.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // send_message
            // 
            this.send_message.Location = new System.Drawing.Point(339, 312);
            this.send_message.Name = "send_message";
            this.send_message.Size = new System.Drawing.Size(75, 23);
            this.send_message.TabIndex = 2;
            this.send_message.Text = "Send";
            this.send_message.UseVisualStyleBackColor = true;
            this.send_message.Click += new System.EventHandler(this.send_message_Click);
            // 
            // chat
            // 
            this.chat.Location = new System.Drawing.Point(15, 96);
            this.chat.Multiline = true;
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(260, 189);
            this.chat.TabIndex = 3;
            this.chat.TextChanged += new System.EventHandler(this.chat_TextChanged);
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(333, 35);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(81, 20);
            this.tbIP.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "IP (server)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Message";
            // 
            // start_server
            // 
            this.start_server.Location = new System.Drawing.Point(200, 67);
            this.start_server.Name = "start_server";
            this.start_server.Size = new System.Drawing.Size(75, 23);
            this.start_server.TabIndex = 9;
            this.start_server.Text = "start server";
            this.start_server.UseVisualStyleBackColor = true;
            this.start_server.Click += new System.EventHandler(this.start_server_Click);
            // 
            // tbxUsername
            // 
            this.tbxUsername.Location = new System.Drawing.Point(12, 25);
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(100, 20);
            this.tbxUsername.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Username";
            // 
            // create_user
            // 
            this.create_user.Location = new System.Drawing.Point(15, 68);
            this.create_user.Name = "create_user";
            this.create_user.Size = new System.Drawing.Size(75, 23);
            this.create_user.TabIndex = 12;
            this.create_user.Text = "create user";
            this.create_user.UseVisualStyleBackColor = true;
            this.create_user.Click += new System.EventHandler(this.create_user_Click);
            // 
            // tbPortServer
            // 
            this.tbPortServer.Location = new System.Drawing.Point(333, 83);
            this.tbPortServer.Name = "tbPortServer";
            this.tbPortServer.Size = new System.Drawing.Size(81, 20);
            this.tbPortServer.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Port (server)";
            // 
            // tbMyPort
            // 
            this.tbMyPort.Location = new System.Drawing.Point(333, 127);
            this.tbMyPort.Name = "tbMyPort";
            this.tbMyPort.Size = new System.Drawing.Size(81, 20);
            this.tbMyPort.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Port (my)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 356);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbMyPort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPortServer);
            this.Controls.Add(this.create_user);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxUsername);
            this.Controls.Add(this.start_server);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.chat);
            this.Controls.Add(this.send_message);
            this.Controls.Add(this.tbMessage);
            this.Name = "Form1";
            this.Text = "Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button send_message;
        private System.Windows.Forms.TextBox chat;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button start_server;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button create_user;
        private System.Windows.Forms.TextBox tbPortServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMyPort;
        private System.Windows.Forms.Label label5;
    }
}

