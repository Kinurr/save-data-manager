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
                SerializeAndSaveToJSON();
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

                saveFile = new SaveFile(saveFileID, folderName, saveDataBrowser.SelectedPath, SaveFile.Platforms.PC);

                gameNameTextBox.Text = saveFile.Game;
                pathTextBox.Text = saveDataBrowser.SelectedPath;
                platformCBox.SelectedItem = saveFile.Platform;
            }

            saveDataBrowser.Dispose();
        }

        private void SerializeAndSaveToJSON()
        {
            string jsonPath = backupPath + "\\savemanifest.json";

            using (StreamWriter sw = new StreamWriter(jsonPath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, saveFiles);
                // {"ExpiryDate":new Date(1230375600000),"Price":0}
            }

            //string serializedSaveFile = serializer.Serialize(backupPath + "\\savemanifest.json", saveFile);
            //File.WriteAllText(backupPath + "\\savemanifest.json", serializedSaveFile);
        }
    }
}
