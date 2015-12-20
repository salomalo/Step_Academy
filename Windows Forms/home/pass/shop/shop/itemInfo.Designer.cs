namespace shop
{
    partial class itemInfo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.lPrice = new System.Windows.Forms.Label();
            this.lTitle = new System.Windows.Forms.Label();
            this.txPrice = new System.Windows.Forms.TextBox();
            this.txTitle = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.lPrice);
            this.panel1.Controls.Add(this.lTitle);
            this.panel1.Controls.Add(this.txPrice);
            this.panel1.Controls.Add(this.txTitle);
            this.panel1.Location = new System.Drawing.Point(10, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 241);
            this.panel1.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(31, 181);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lPrice
            // 
            this.lPrice.AutoSize = true;
            this.lPrice.Location = new System.Drawing.Point(28, 105);
            this.lPrice.Name = "lPrice";
            this.lPrice.Size = new System.Drawing.Size(31, 13);
            this.lPrice.TabIndex = 3;
            this.lPrice.Text = "Price";
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Location = new System.Drawing.Point(25, 19);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(27, 13);
            this.lTitle.TabIndex = 2;
            this.lTitle.Text = "Title";
            // 
            // txPrice
            // 
            this.txPrice.Location = new System.Drawing.Point(55, 119);
            this.txPrice.Name = "txPrice";
            this.txPrice.Size = new System.Drawing.Size(139, 20);
            this.txPrice.TabIndex = 1;
            // 
            // txTitle
            // 
            this.txTitle.Location = new System.Drawing.Point(52, 36);
            this.txTitle.Name = "txTitle";
            this.txTitle.Size = new System.Drawing.Size(142, 20);
            this.txTitle.TabIndex = 0;
            // 
            // itemInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.panel1);
            this.Name = "itemInfo";
            this.Text = "itemInfo";
            this.Load += new System.EventHandler(this.itemInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lPrice;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.TextBox txPrice;
        private System.Windows.Forms.TextBox txTitle;
        private System.Windows.Forms.Button btnOk;
    }
}