namespace FileComparer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbFile2 = new System.Windows.Forms.RichTextBox();
            this.tbFile1 = new System.Windows.Forms.RichTextBox();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnOpenFile2 = new System.Windows.Forms.Button();
            this.btnOpenFile1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbFile2);
            this.panel1.Controls.Add(this.tbFile1);
            this.panel1.Controls.Add(this.btnCompare);
            this.panel1.Controls.Add(this.btnOpenFile2);
            this.panel1.Controls.Add(this.btnOpenFile1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 493);
            this.panel1.TabIndex = 0;
            // 
            // tbFile2
            // 
            this.tbFile2.Location = new System.Drawing.Point(344, 12);
            this.tbFile2.Name = "tbFile2";
            this.tbFile2.Size = new System.Drawing.Size(318, 469);
            this.tbFile2.TabIndex = 6;
            this.tbFile2.Text = "";
            // 
            // tbFile1
            // 
            this.tbFile1.Location = new System.Drawing.Point(3, 12);
            this.tbFile1.Name = "tbFile1";
            this.tbFile1.Size = new System.Drawing.Size(318, 469);
            this.tbFile1.TabIndex = 5;
            this.tbFile1.Text = "";
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(734, 132);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 4;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnOpenFile2
            // 
            this.btnOpenFile2.Location = new System.Drawing.Point(734, 82);
            this.btnOpenFile2.Name = "btnOpenFile2";
            this.btnOpenFile2.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile2.TabIndex = 3;
            this.btnOpenFile2.Text = "Open file 2";
            this.btnOpenFile2.UseVisualStyleBackColor = true;
            this.btnOpenFile2.Click += new System.EventHandler(this.btnOpenFile2_Click);
            // 
            // btnOpenFile1
            // 
            this.btnOpenFile1.Location = new System.Drawing.Point(734, 30);
            this.btnOpenFile1.Name = "btnOpenFile1";
            this.btnOpenFile1.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile1.TabIndex = 2;
            this.btnOpenFile1.Text = "Open file1";
            this.btnOpenFile1.UseVisualStyleBackColor = true;
            this.btnOpenFile1.Click += new System.EventHandler(this.btnOpenFile1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 493);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnOpenFile2;
        private System.Windows.Forms.Button btnOpenFile1;
        private System.Windows.Forms.RichTextBox tbFile2;
        private System.Windows.Forms.RichTextBox tbFile1;
    }
}

