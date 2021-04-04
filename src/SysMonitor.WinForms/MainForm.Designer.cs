namespace SysMonitor.WinForms
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.GetDataBtn = new System.Windows.Forms.Button();
            this.LangBtn = new System.Windows.Forms.Button();
            this.DataLbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ExportResultLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DescriptionLabel
            // 
            resources.ApplyResources(this.DescriptionLabel, "DescriptionLabel");
            this.DescriptionLabel.Name = "DescriptionLabel";
            // 
            // GetDataBtn
            // 
            resources.ApplyResources(this.GetDataBtn, "GetDataBtn");
            this.GetDataBtn.Name = "GetDataBtn";
            this.GetDataBtn.UseVisualStyleBackColor = true;
            this.GetDataBtn.Click += new System.EventHandler(this.GetDataBtn_Click);
            // 
            // LangBtn
            // 
            resources.ApplyResources(this.LangBtn, "LangBtn");
            this.LangBtn.Name = "LangBtn";
            this.LangBtn.UseVisualStyleBackColor = true;
            this.LangBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // DataLbl
            // 
            resources.ApplyResources(this.DataLbl, "DataLbl");
            this.DataLbl.Name = "DataLbl";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ExportResultLbl
            // 
            resources.ApplyResources(this.ExportResultLbl, "ExportResultLbl");
            this.ExportResultLbl.Name = "ExportResultLbl";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ExportResultLbl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DataLbl);
            this.Controls.Add(this.LangBtn);
            this.Controls.Add(this.GetDataBtn);
            this.Controls.Add(this.DescriptionLabel);
            this.Name = "MainForm";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label ExportResultLbl;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Button GetDataBtn;

        private System.Windows.Forms.Label DescriptionLabel;

        #endregion

        private System.Windows.Forms.Button LangBtn;
        private System.Windows.Forms.Label DataLbl;
    }
}