namespace TableToClass
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
            this.ShowAll = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Filter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ShowAll
            // 
            this.ShowAll.Location = new System.Drawing.Point(12, 189);
            this.ShowAll.Name = "ShowAll";
            this.ShowAll.Size = new System.Drawing.Size(154, 41);
            this.ShowAll.TabIndex = 1;
            this.ShowAll.Text = "Show All";
            this.ShowAll.UseVisualStyleBackColor = true;
            this.ShowAll.Click += new System.EventHandler(this.ShowAll_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(342, 153);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Filter
            // 
            this.Filter.Location = new System.Drawing.Point(200, 189);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(154, 41);
            this.Filter.TabIndex = 3;
            this.Filter.Text = "Filter";
            this.Filter.UseVisualStyleBackColor = true;
            this.Filter.Click += new System.EventHandler(this.Filter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 242);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.ShowAll);
            this.Name = "Form1";
            this.Text = "Show Countries";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ShowAll;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button Filter;
    }
}

