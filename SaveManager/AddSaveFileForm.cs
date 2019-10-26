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

    public partial class AddSaveFileForm : Form
    {

        private int saveFileID;
        private DataGridView saveDirectoryList;
        private SaveFiles saveFile;


        public AddSaveFileForm(int _saveFileID, DataGridView _saveDirectoryList)
        {
            saveFileID = _saveFileID;
            saveDirectoryList = _saveDirectoryList;

            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddSaveFileForm_Load(object sender, EventArgs e)
        {
            idTextBox.Text = saveFileID.ToString();
            platformCBox.DataSource = Enum.GetValues(typeof(SaveFiles.Platforms));

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
                saveDirectoryList.Rows.Add(saveFile.Game, saveFile.Platform, saveFile.OriginalPath);
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

                saveFile = new SaveFiles(saveFileID, folderName, saveDataBrowser.SelectedPath, SaveFiles.Platforms.PC);

                gameNameTextBox.Text = saveFile.Game;
                pathTextBox.Text = saveDataBrowser.SelectedPath;
                platformCBox.SelectedItem = saveFile.Platform;
            }

            saveDataBrowser.Dispose();
        }
    }
}
