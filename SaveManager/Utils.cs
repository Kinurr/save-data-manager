using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveManager
{
    class Utils
    {
        public string FormatList(ICollection<string> list)
        {
            string formattedList = "";

            foreach (var listItem in list)
            {
                formattedList += listItem + "\n";
            }

            return formattedList;
        }

        public void ClearUserSettings()
        {
            Properties.Settings.Default.LocalBackupDirectory = "";
        }
    }
}
