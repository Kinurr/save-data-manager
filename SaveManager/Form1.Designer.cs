namespace SaveManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SaveDirectoryList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.DebugLabel = new System.Windows.Forms.Label();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.BackupDirectoryText = new System.Windows.Forms.TextBox();
            this.BackupDirButton = new System.Windows.Forms.Button();
            this.BackupButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SaveDirectoryList
            // 
            this.SaveDirectoryList.FormattingEnabled = true;
            resources.ApplyResources(this.SaveDirectoryList, "SaveDirectoryList");
            this.SaveDirectoryList.Name = "SaveDirectoryList";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // AddButton
            // 
            resources.ApplyResources(this.AddButton, "AddButton");
            this.AddButton.Name = "AddButton";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // DebugLabel
            // 
            resources.ApplyResources(this.DebugLabel, "DebugLabel");
            this.DebugLabel.Name = "DebugLabel";
            // 
            // RemoveButton
            // 
            resources.ApplyResources(this.RemoveButton, "RemoveButton");
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // BackupDirectoryText
            // 
            resources.ApplyResources(this.BackupDirectoryText, "BackupDirectoryText");
            this.BackupDirectoryText.Name = "BackupDirectoryText";
            this.BackupDirectoryText.ReadOnly = true;
            // 
            // BackupDirButton
            // 
            resources.ApplyResources(this.BackupDirButton, "BackupDirButton");
            this.BackupDirButton.Name = "BackupDirButton";
            this.BackupDirButton.UseVisualStyleBackColor = true;
            this.BackupDirButton.Click += new System.EventHandler(this.BackupDirButton_Click);
            // 
            // BackupButton
            // 
            resources.ApplyResources(this.BackupButton, "BackupButton");
            this.BackupButton.Name = "BackupButton";
            this.BackupButton.UseVisualStyleBackColor = true;
            this.BackupButton.Click += new System.EventHandler(this.BackupButton_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.BackupButton);
            this.Controls.Add(this.BackupDirButton);
            this.Controls.Add(this.BackupDirectoryText);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.DebugLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveDirectoryList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox SaveDirectoryList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label DebugLabel;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.TextBox BackupDirectoryText;
        private System.Windows.Forms.Button BackupDirButton;
        private System.Windows.Forms.Button BackupButton;
    }
}

