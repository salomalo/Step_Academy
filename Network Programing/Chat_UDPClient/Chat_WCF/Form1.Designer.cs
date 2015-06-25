namespace Chat_WCF
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
            this.tbxRemoteIP = new System.Windows.Forms.TextBox();
            this.tbxRemotePort = new System.Windows.Forms.TextBox();
            this.tbxLocalPort = new System.Windows.Forms.TextBox();
            this.tbxClientNick = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxChatWindow = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbxEnterMessage = new System.Windows.Forms.TextBox();
            this.btnInitial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxRemoteIP
            // 
            this.tbxRemoteIP.Location = new System.Drawing.Point(302, 12);
            this.tbxRemoteIP.Name = "tbxRemoteIP";
            this.tbxRemoteIP.Size = new System.Drawing.Size(100, 20);
            this.tbxRemoteIP.TabIndex = 0;
            // 
            // tbxRemotePort
            // 
            this.tbxRemotePort.Location = new System.Drawing.Point(302, 52);
            this.tbxRemotePort.Name = "tbxRemotePort";
            this.tbxRemotePort.Size = new System.Drawing.Size(100, 20);
            this.tbxRemotePort.TabIndex = 1;
            // 
            // tbxLocalPort
            // 
            this.tbxLocalPort.Location = new System.Drawing.Point(67, 52);
            this.tbxLocalPort.Name = "tbxLocalPort";
            this.tbxLocalPort.Size = new System.Drawing.Size(100, 20);
            this.tbxLocalPort.TabIndex = 2;
            // 
            // tbxClientNick
            // 
            this.tbxClientNick.Location = new System.Drawing.Point(67, 12);
            this.tbxClientNick.Name = "tbxClientNick";
            this.tbxClientNick.Size = new System.Drawing.Size(100, 20);
            this.tbxClientNick.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "RemoteIP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "RemotePort";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ClientNick";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "LocalPort";
            // 
            // tbxChatWindow
            // 
            this.tbxChatWindow.Location = new System.Drawing.Point(13, 105);
            this.tbxChatWindow.Multiline = true;
            this.tbxChatWindow.Name = "tbxChatWindow";
            this.tbxChatWindow.Size = new System.Drawing.Size(389, 237);
            this.tbxChatWindow.TabIndex = 8;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(314, 374);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbxEnterMessage
            // 
            this.tbxEnterMessage.Location = new System.Drawing.Point(13, 374);
            this.tbxEnterMessage.Name = "tbxEnterMessage";
            this.tbxEnterMessage.Size = new System.Drawing.Size(295, 20);
            this.tbxEnterMessage.TabIndex = 10;
            // 
            // btnInitial
            // 
            this.btnInitial.Location = new System.Drawing.Point(176, 76);
            this.btnInitial.Name = "btnInitial";
            this.btnInitial.Size = new System.Drawing.Size(75, 23);
            this.btnInitial.TabIndex = 11;
            this.btnInitial.Text = "Initial";
            this.btnInitial.UseVisualStyleBackColor = true;
            this.btnInitial.Click += new System.EventHandler(this.btnInitial_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 420);
            this.Controls.Add(this.btnInitial);
            this.Controls.Add(this.tbxEnterMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbxChatWindow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxClientNick);
            this.Controls.Add(this.tbxLocalPort);
            this.Controls.Add(this.tbxRemotePort);
            this.Controls.Add(this.tbxRemoteIP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxRemoteIP;
        private System.Windows.Forms.TextBox tbxRemotePort;
        private System.Windows.Forms.TextBox tbxLocalPort;
        private System.Windows.Forms.TextBox tbxClientNick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxChatWindow;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbxEnterMessage;
        private System.Windows.Forms.Button btnInitial;
    }
}

