namespace ArandaSoftware.SysMonitor
{
    partial class MainForm
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
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.GetDataBtn = new System.Windows.Forms.Button();
            this.LangBtn = new System.Windows.Forms.Button();
            this.DataLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Location = new System.Drawing.Point(12, 9);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(560, 56);
            this.DescriptionLabel.TabIndex = 1;
            this.DescriptionLabel.Text = "This application allows you to capture the relevant information of the current co" +
    "mputer (operating system, machine name, IP address, hard disk, RAM and processor" +
    ")";
            // 
            // GetDataBtn
            // 
            this.GetDataBtn.Location = new System.Drawing.Point(12, 52);
            this.GetDataBtn.Name = "GetDataBtn";
            this.GetDataBtn.Size = new System.Drawing.Size(94, 23);
            this.GetDataBtn.TabIndex = 0;
            this.GetDataBtn.Text = "Get data";
            this.GetDataBtn.UseVisualStyleBackColor = true;
            this.GetDataBtn.Click += new System.EventHandler(this.GetDataBtn_Click);
            // 
            // LangBtn
            // 
            this.LangBtn.Location = new System.Drawing.Point(506, 426);
            this.LangBtn.Name = "LangBtn";
            this.LangBtn.Size = new System.Drawing.Size(66, 23);
            this.LangBtn.TabIndex = 2;
            this.LangBtn.Text = "EN";
            this.LangBtn.UseVisualStyleBackColor = true;
            this.LangBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // DataLbl
            // 
            this.DataLbl.Location = new System.Drawing.Point(12, 87);
            this.DataLbl.Name = "DataLbl";
            this.DataLbl.Size = new System.Drawing.Size(560, 323);
            this.DataLbl.TabIndex = 0;
            this.DataLbl.Text = "...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.DataLbl);
            this.Controls.Add(this.LangBtn);
            this.Controls.Add(this.GetDataBtn);
            this.Controls.Add(this.DescriptionLabel);
            this.Name = "MainForm";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button GetDataBtn;

        private System.Windows.Forms.Label DescriptionLabel;

        #endregion

        private System.Windows.Forms.Button LangBtn;
        private System.Windows.Forms.Label DataLbl;
    }
}