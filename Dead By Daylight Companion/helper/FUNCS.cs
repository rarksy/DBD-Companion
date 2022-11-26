using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dead_By_Daylight_Companion.Config_Editor.helper {
    internal class FUNCS {

        public string Base64Encode(string plainText) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public string Base64Decode(string base64EncodedData) {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public bool IsValidBase64(string input) {
            try {
                Base64Encode(input);
                return true;
            }
            catch {
                return false;
            }
        }
        public void ChangeSetting(string file, string _var, string val) {
            string search_text = _var;
            string old;
            string n = String.Empty;
            StreamReader sr = File.OpenText(file);
            while ((old = sr.ReadLine()) != null) {
                if (old.Contains(search_text)) {
                    n += search_text + val + "\n";
                }

                if (!old.Contains(search_text)) {
                    n += old + Environment.NewLine;
                }
            }
            sr.Close();
            File.WriteAllText(file, n);
        }

        public void DoReadOnly(string filepath, bool var) {
            FileInfo fI = new FileInfo(filepath+@"\GameUserSettings.ini");

            if (var) {
                if (!fI.IsReadOnly) {
                    fI.IsReadOnly = true;
                    fI = new FileInfo(filepath+@"\Engine.ini");
                    fI.IsReadOnly = true;
                }
            }
            else {
                fI.IsReadOnly = false;
                fI = new FileInfo(filepath+@"\Engine.ini");
                if (fI.IsReadOnly)
                    fI.IsReadOnly = false;
            }
        }

        public string iniReadKey(string file, string section, string key) {
            IniFile ini = new IniFile(Config_Editor.sPathToUse + file);
            return ini.ReadString(section, key);
        }

        public bool iniKeyExists(string file, string header, string key) {
            IniFile ini = new IniFile(Config_Editor.sPathToUse + file);
            return ini.KeyExists(key, header);
        }
        public void iniChangeKey(string file, string header, string key, string value) {
            FileInfo info = new FileInfo(Config_Editor.sPathToUse + file);
            IniFile ini = new IniFile(Config_Editor.sPathToUse + file);
            info.IsReadOnly = false;
            ini.Write(key, value, header);
            info.IsReadOnly = true;
        }

        public void iniDeleteSection(string file, string header) {
            FileInfo info = new FileInfo(Config_Editor.sPathToUse + file);
            IniFile ini = new IniFile(Config_Editor.sPathToUse + file);
            info.IsReadOnly = false;
            ini.DeleteSection(header);
            info.IsReadOnly = true;
        }

        public void iniDeleteKey(string file, string header, string key) {
            IniFile ini = new IniFile(Config_Editor.sPathToUse + file);
            FileInfo info = new FileInfo(Config_Editor.sPathToUse + file);
            info.IsReadOnly = false;
            ini.DeleteKey(key, header);
            info.IsReadOnly = true;
        }

        public void iniWriteKey(string file, string header, string key, string value) {
            IniFile ini = new IniFile(Config_Editor.sPathToUse + file);
            FileInfo info = new FileInfo(Config_Editor.sPathToUse + file);

            info.IsReadOnly = false;
            ini.Write(key, value, header);
            info.IsReadOnly = true;
        }

    }
}
