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
        private int totalFilesBackedUp, totalMainDirectoriesBackedUp;

        public Form1()
        {
            InitializeComponent();
        }

        private void BackupButton_Click(object sender, EventArgs e)
        {
            BackupDirectory();
        }

        private void BackupDirectory()
        {

            for (int i = 0; i < SaveDirectoryList.Items.Count; i++)
            {
                string fullPath = Path.GetFullPath(SaveDirectoryList.Items[i].ToString()).TrimEnd(Path.DirectorySeparatorChar);
                string folderName = Path.GetFileName(fullPath);

                string targetPath = Path.Combine(BackupDirectoryText.Text, folderName);

                Directory.CreateDirectory(targetPath);

                Debug.WriteLine(targetPath + " " + Directory.Exists(targetPath));

                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(fullPath, "*",
                    SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace(fullPath, targetPath));
                    SetInfoText("Created directory " + folderName);
                }

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(fullPath, "*.*",
                    SearchOption.AllDirectories))
                {
                    try
                    {
                        File.Copy(newPath, newPath.Replace(fullPath, targetPath), true);
                        totalFilesBackedUp++;
                        SetInfoText("Copied file " + fullPath);
                    }
                    catch (IOException exception)
                    {
                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                totalMainDirectoriesBackedUp++;
            }

            MessageBox.Show("Sucessfully backed up " + totalMainDirectoriesBackedUp + " main directories containing a total of " +
                totalFilesBackedUp + " files.", "Backup Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BackupDirButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog backupBrowser = new FolderBrowserDialog();

            if (backupBrowser.ShowDialog() == DialogResult.OK)
            {
                BackupDirectoryText.Text = backupBrowser.SelectedPath;
                SetInfoText("Backup directory set to " + backupBrowser.SelectedPath);
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
                SetInfoText("Removed " + SaveDirectoryList.Items[SaveDirectoryList.SelectedIndex]);
                SaveDirectoryList.Items.RemoveAt(SaveDirectoryList.SelectedIndex);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetInfoText("Application started");
        }

        private void AddDirectoryToList()
        {
            FolderBrowserDialog saveDataBrowser = new FolderBrowserDialog();

            if (saveDataBrowser.ShowDialog() == DialogResult.OK)
            {
                SaveDirectoryList.Items.Add(saveDataBrowser.SelectedPath, true);
                SetInfoText("Added " + saveDataBrowser.SelectedPath);
            }
        }
        private void SetInfoText(string s)
        {
            DebugLabel.Text = s;
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
