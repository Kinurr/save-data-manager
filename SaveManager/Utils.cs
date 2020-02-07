using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
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
    static class Utils
    {
        static public string FormatList(ICollection<string> list)
        {
            string formattedList = "";

            foreach (var listItem in list)
            {
                formattedList += listItem + "\n";
            }

            return formattedList;
        }

        static public void ClearUserSettings()
        {
            Properties.Settings.Default.LocalBackupDirectory = "";
        }

        static public void SerializeAndSaveToJSON(string jsonPath, object serializeable)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(jsonPath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, serializeable);
            }
        }
    }
}
