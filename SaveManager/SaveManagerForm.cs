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
using Newtonsoft.Json;

namespace SaveManager
{
    public partial class SaveManagerForm : Form
    {
        private int totalFilesBackedUp, totalMainDirectoriesBackedUp;
        private const string configFile = "config.json";
        private static int saveIDCounter = 0;

        public SaveManagerForm()
        {
            InitializeComponent();
            CreateLocalConfigFile();
        }

        private void CreateLocalConfigFile()
        {
            if (!File.Exists(configFile))
            {
                File.Create(configFile);
            }
        }

        private void BackupButton_Click(object sender, EventArgs e)
        {
            BackupDirectory();
        }

        private void BackupDirectory()
        {
            List<string> titles = new List<string>();

            for (int i = 0; i < SaveDirectoryList.Rows.Count; i++)
            {
                string fullPath = Path.GetFullPath(SaveDirectoryList.Rows[i].Cells[2].Value.ToString()).TrimEnd(Path.DirectorySeparatorChar);
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
                titles.Add(SaveDirectoryList.Rows[i].Cells[0].Value.ToString());
            }

            //TODO: Put this in a function and class of its own called Utils
            string formattedList = "";

            foreach (var title in titles)
            {
                formattedList += "  - " + title + "\n";
            }

            MessageBox.Show("Sucessfully backed up the following games: \n \n" + formattedList, "Backup Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
           // MessageBox.Show("Sucessfully backed up " + totalMainDirectoriesBackedUp + " main directories containing a total of " +
             //   totalFilesBackedUp + " files.", "Backup Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BackupDirButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog backupDirectoryBrowser = new FolderBrowserDialog();

            if (backupDirectoryBrowser.ShowDialog() == DialogResult.OK)
            {
                BackupDirectoryText.Text = backupDirectoryBrowser.SelectedPath;
                var serializedBackupPath = JsonConvert.SerializeObject(backupDirectoryBrowser.SelectedPath, Formatting.Indented);
                File.WriteAllText(configFile, serializedBackupPath);
                SetInfoText("Backup directory set to " + backupDirectoryBrowser.SelectedPath);
            }

            backupDirectoryBrowser.Dispose();
        } 

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddSaveFileForm addSaveFileForm = new AddSaveFileForm(saveIDCounter, SaveDirectoryList);
            addSaveFileForm.ShowDialog();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if(SaveDirectoryList.SelectedRows.Count >= 0)
            {
                foreach (DataGridViewRow row in SaveDirectoryList.SelectedRows)
                {
                    SaveDirectoryList.Rows.Remove(row);
                    SetInfoText("Removed " + row.Cells[2]);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetInfoText("Application started");
            SaveDirectoryList.AllowUserToAddRows = false;
            SaveDirectoryList.Columns.Add("Title", "Title");
            SaveDirectoryList.Columns.Add("Platform", "Platform");
            SaveDirectoryList.Columns.Add("Path", "Path");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SetInfoText(string s)
        {
            DebugLabel.Text = s;
        }
    }
}
