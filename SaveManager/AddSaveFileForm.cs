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
using Newtonsoft.Json;

namespace SaveManager
{

    public partial class AddSaveFileForm : Form
    {

        private int saveFileID;
        private List<SaveFile> saveFiles;
        private SaveFile saveFile;
        private string backupPath;
        JsonSerializer serializer;


        public AddSaveFileForm(int _saveFileID, List<SaveFile> _saveFiles, string _backupPath)
        {
            saveFileID = _saveFileID;
            saveFiles = _saveFiles;
            backupPath = _backupPath;
            serializer = new JsonSerializer();

            saveFile = new SaveFile(saveFileID, "", "", SaveFile.Platforms.PC);


            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddSaveFileForm_Load(object sender, EventArgs e)
        {
            idTextBox.Text = saveFileID.ToString();
            platformCBox.DataSource = Enum.GetValues(typeof(SaveFile.Platforms));

            CenterToParent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            AddDirectoryToList();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if(saveFile != null)
            {
                saveFiles.Add(saveFile);
                Utils.SerializeAndSaveToJSON(backupPath + "\\savemanifest.json", saveFiles);
                this.Close();
            }
            else
            {
                MessageBox.Show("No save file selected. Please select a save file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddDirectoryToList()
        {
            FolderBrowserDialog saveDataBrowser = new FolderBrowserDialog();

            if (saveDataBrowser.ShowDialog() == DialogResult.OK)
            {
                string fullPath = Path.GetFullPath(saveDataBrowser.SelectedPath).TrimEnd(Path.DirectorySeparatorChar);
                string folderName = Path.GetFileName(fullPath);

                saveFile.Title = folderName;
                saveFile.OriginalPath = fullPath;
                gameNameTextBox.Text = folderName;
                pathTextBox.Text = saveDataBrowser.SelectedPath;
                saveFile.Platform = (SaveFile.Platforms)platformCBox.SelectedItem;
            }

            saveDataBrowser.Dispose();
        }

        private void platformCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveFile.Platform = (SaveFile.Platforms)platformCBox.SelectedItem;
        }
    }
}
