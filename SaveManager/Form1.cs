using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveManager
{
    public partial class Form1 : Form
    {
        private int fileCount;

        public Form1()
        {
            InitializeComponent();
        }

        private void BackupButton_Click(object sender, EventArgs e)
        {

            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(SourcePath, BackupDirectoryText.Text));

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(SourcePath, BackupDirectoryText.Text), true);

            //if (!System.IO.Directory.Exists(BackupDirectoryText.Text))
            //{
            //    MessageBox.Show("Invalid backup directory!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //if(SaveDirectoryList.Items.Count < 1)
            //{
            //    MessageBox.Show("List is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //if (System.IO.Directory.Exists(SaveDirectoryList.Items[0].ToString()))
            //{
            //    fileCount = 0;

            //    string[] files = System.IO.Directory.GetFiles(SaveDirectoryList.Items[0].ToString());
            //    DebugLabel.Text = files.ToString();

            //    // Copy the files and overwrite destination files if they already exist.
            //    foreach (string s in files)
            //    {
            //        // Use static Path methods to extract only the file name from the path.
            //        var fileName = System.IO.Path.GetFileName(s);
            //        var destFile = System.IO.Path.Combine(BackupDirectoryText.Text, fileName);
            //        DebugLabel.Text = "Copying " + fileName + "...";
            //        fileCount++;
            //        System.IO.File.Copy(s, destFile, true);
            //    }

            //    DebugLabel.Text = fileCount + " files backed up at" + DateTime.Now.TimeOfDay + ".";
            //    MessageBox.Show("Backed up " + fileCount + " files successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("Source path does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void BackupDirButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog backupBrowser = new FolderBrowserDialog();

            if (backupBrowser.ShowDialog() == DialogResult.OK)
            {
                BackupDirectoryText.Text = backupBrowser.SelectedPath;
                DebugLabel.Text = "Backup directory set to " + backupBrowser.SelectedPath;
            }
        } 

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddDirectoryToList();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if(SaveDirectoryList.SelectedIndex >= 0)
            {
                DebugLabel.Text = "Removed " + SaveDirectoryList.Items[SaveDirectoryList.SelectedIndex];
                SaveDirectoryList.Items.RemoveAt(SaveDirectoryList.SelectedIndex);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DebugLabel.Text = "Application Started";
        }

        private void AddDirectoryToList()
        {
            FolderBrowserDialog saveDataBrowser = new FolderBrowserDialog();

            if (saveDataBrowser.ShowDialog() == DialogResult.OK)
            {
                SaveDirectoryList.Items.Add(saveDataBrowser.SelectedPath, true);
                DebugLabel.Text = "Added " + saveDataBrowser.SelectedPath;
            }
        }

        //private void IsDuplicate(Object obj)
        //{
        //    for (int i = 0; i < SaveDirectoryList.Items.Count; i++)
        //    {
        //        Console.WriteLine(SaveDirectoryList.Items[i] == obj);

        //        if (SaveDirectoryList.Items[i] == obj)
        //        {
        //            //messagebox.show("the directory you tried to add is already in the list.", "error - duplicate",
        //            //    messageboxbuttons.ok, messageboxicon.error);
        //            //return true;
        //        }
        //    }

        //    //return false;
        //}
    }
}
