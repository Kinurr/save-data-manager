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
using System.Diagnostics;

namespace SaveManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BackupButton_Click(object sender, EventArgs e)
        {
            string fullPath = Path.GetFullPath(SaveDirectoryList.Items[0].ToString()).TrimEnd(Path.DirectorySeparatorChar);
            string folderName = Path.GetFileName(fullPath);

            Debug.WriteLine(folderName);

            string targetPath = Path.Combine(BackupDirectoryText.Text, folderName);

            Directory.CreateDirectory(targetPath);

            Debug.WriteLine(targetPath + " " + Directory.Exists(targetPath));

            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(fullPath, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(fullPath, targetPath));

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(fullPath, "*.*",
                SearchOption.AllDirectories))
            {
                try
                {
                    File.Copy(newPath, newPath.Replace(fullPath, targetPath), true);
                }
                catch(IOException exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

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
