using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Dead_By_Daylight_Companion.Config_Editor {
    public partial class Config_Editor : Form {
        public static string sPathToUse = string.Empty;
        static helper.FUNCS func = new helper.FUNCS();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")] public extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")] public extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        public Config_Editor() {
            InitializeComponent();
        }

        private void SelectConfigLocation() {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.ValidateNames = false;
                openFileDialog.CheckFileExists = false;
                openFileDialog.CheckPathExists = false;
                openFileDialog.FileName = "Folder Selection. (Do Not Change This)";

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    filePath = openFileDialog.FileName;
                    filePath = filePath.Remove(filePath.Length - 38);
                    if (!Directory.Exists($@"C:\Users\{Environment.UserName}\Appdata\Local\DBDCE"))
                        Directory.CreateDirectory($@"C:\Users\{Environment.UserName}\Appdata\Local\DBDCE");
                    File.WriteAllText($@"C:\Users\{Environment.UserName}\Appdata\Local\DBDCE\custompath.DBDCE", filePath);
                    sPathToUse = filePath;
                    GamePathTextBox.Text = sPathToUse;
                }
            }
        }

        private void Config_Editor_Load(object sender, EventArgs e) {
            if (Directory.Exists($@"C:\Users\{Environment.UserName}\Appdata\Local\Dead By Daylight Companion\Config Editor")) {
                if (File.Exists($@"C:\Users\{Environment.UserName}\Appdata\Local\Dead By Daylight Companion\Config Editor\custompath.companion")) {
                    string sPath = File.ReadAllText($@"C:\Users\{Environment.UserName}\Appdata\Local\Dead By Daylight Companion\Config Editor\custompath.companion");
                    if (sPath != string.Empty) {
                        sPathToUse = sPath;
                        if (!Directory.Exists(sPathToUse)) {
                            Directory.Delete($@"C:\Users\{Environment.UserName}\Appdata\Local\Dead By Daylight Companion\Config Editor", true);

                            var t = new Thread(() => Application.Run(new Config_Editor()));
                            t.Start();
                            this.Close();
                        }
                        func.DoReadOnly(sPathToUse, false);
                        GamePathTextBox.Text = sPathToUse;
                        UserLabel.Text += Environment.UserName;
                        InfoPanel.Height = 0;
                        TimerInit.Start();
                        return;
                    }
                }
            }
            if (!Directory.Exists($@"C:\Users\{Environment.UserName}\Appdata\Local\DeadByDaylight\Saved\Config\WindowsNoEditor")) {
                DialogResult NoDefaultDir = MessageBox.Show("Default Config Location Not Found, Please Select It Now");
                if (Directory.Exists($@"C:\Users\{Environment.UserName}\Appdata\Local\DBDCE")) {
                    string cPath = File.ReadAllText($@"C:\Users\{Environment.UserName}\Appdata\Local\DBDCE\custompath.DBDCE");
                    if (cPath == String.Empty)
                        SelectConfigLocation();
                    else sPathToUse = cPath;
                }
            }
            else sPathToUse = $@"C:\Users\{Environment.UserName}\Appdata\Local\DeadByDaylight\Saved\Config\WindowsNoEditor";
            if (!Directory.Exists(sPathToUse)) {
                Directory.Delete($@"C:\Users\{Environment.UserName}\Appdata\Local\DBDCE", true);
                Application.Restart();
                Application.Exit();
            }
            func.DoReadOnly(sPathToUse, false);
            GamePathTextBox.Text = sPathToUse;
            UserLabel.Text += Environment.UserName;
            InfoPanel.Height = 0;
            List<string> variables = new List<string> {
                "sgViewDistanceQuality",
                "sgShadowQuality",
                "sgPostProcessQuality",
                "sgTextureQuality",
                "sgEffectsQuality",
                "sgFoliageQuality",
                "sgShadingQuality",
                "sgAnimationQuality"
            };
            
            foreach (ComboBox c in MainPanel.Controls.OfType<ComboBox>()) {
                foreach (string s in variables) {
                    if (c.Name.Contains(s)) {
                        var userini = new helper.IniFile(sPathToUse + @"\GameUserSettings.ini");
                        int value = userini.ReadInt("ScalabilityGroups", s.Insert(2, "."));
                        if (value < 5) c.SelectedIndex = value;
                        else c.SelectedIndex = 4;
                    }
                }
            }
            TimerInit.Start();
        }

        private void Config_Editor_FormClosing(object sender, FormClosingEventArgs e) {
            func.DoReadOnly(sPathToUse, true);
        }

        private void BackToHub_Click(object sender, EventArgs e) {
            var t = new Thread(() => Application.Run(new HubForm()));
            t.Start();
            this.Close();
        }

        private void TitleBarPanel_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void TitleBarPanel_MouseEnter(object sender, EventArgs e) {
            for (int i = 0; i <= 25; i++) {
                InfoPanel.Height += 1;
                if (MiscPanel.Location.Y <= 63) {
                    MiscPanel.Location = new Point(MiscPanel.Location.X, MiscPanel.Location.Y + 1);
                    MainPanel.Location = new Point(MainPanel.Location.X, MainPanel.Location.Y + 1);
                    Misc2Panel.Location = new Point(Misc2Panel.Location.X, Misc2Panel.Location.Y + 1);
                    MiscPanel.Height -= 1;
                    Misc2Panel.Height -= 1;
                }
            }
        }

        private void TitleBarPanel_MouseLeave(object sender, EventArgs e) {
            for (int i = 25; i >= 0; i--) {
                InfoPanel.Height -= 1;
                if (MiscPanel.Location.Y >= 38) {
                    MiscPanel.Location = new Point(MiscPanel.Location.X, MiscPanel.Location.Y - 1);
                    MainPanel.Location = new Point(MainPanel.Location.X, MainPanel.Location.Y - 1);
                    Misc2Panel.Location = new Point(Misc2Panel.Location.X, Misc2Panel.Location.Y - 1);
                    MiscPanel.Height += 1;
                    Misc2Panel.Height += 1;
                }
            }
        }

        private void TitleLabel_MouseDown(object sender, MouseEventArgs e) {
            TitleBarPanel_MouseDown(sender, e);
        }

        private void TitleLabel_MouseEnter(object sender, EventArgs e) {
            TitleBarPanel_MouseEnter(sender, e);
        }
        
        private void ViewDistanceCMB_SelectedIndexChanged(object sender, EventArgs e) {
            var ini = new helper.IniFile(sPathToUse + @"\GameUserSettings.ini");
            ini.Write("sg.ViewDistanceQuality", sgViewDistanceQualityCMB.SelectedIndex.ToString(), "ScalabilityGroups");
        }

        private void AntiAliasingCMB_SelectedIndexChanged(object sender, EventArgs e) {
            var ini = new helper.IniFile(sPathToUse + @"\Engine.ini");
            if (AntiAliasingCMB.SelectedIndex == 0) {
                ini.Write("r.DefaultFeature.AntiAliasing", "0", "/Script/Engine.GarbageCollectionSettings");
            }
            else {
                if (ini.KeyExists("r.DefaultFeature.AntiAliasing", "/Script/Engine.GarbageCollectionSettings"))
                    ini.DeleteKey("r.DefaultFeature.AntiAliasing", "/Script/Engine.GarbageCollectionSettings");
                ini = new helper.IniFile(sPathToUse + @"\GameUserSettings.ini");
                ini.Write("sg.AntiAliasingQuality", AntiAliasingCMB.SelectedIndex.ToString(), "ScalabilityGroups");
            }
        }

        private void FoliageCMB_SelectedIndexChanged(object sender, EventArgs e) {
            var ini = new helper.IniFile(sPathToUse + @"\GameUserSettings.ini");
            ini.Write("sg.FoliageQuality", sgFoliageQualityCMB.SelectedIndex.ToString(), "ScalabilityGroups");
        }

        private void ShadingCMB_SelectedIndexChanged(object sender, EventArgs e) {
            var ini = new helper.IniFile(sPathToUse + @"\GameUserSettings.ini");
            ini.Write("sg.ShadingQuality", sgShadingQualityCMB.SelectedIndex.ToString(), "ScalabilityGroups");
        }

        private void ShadowCMB_SelectedIndexChanged(object sender, EventArgs e) {
            var ini = new helper.IniFile(sPathToUse + @"\GameUserSettings.ini");
            ini.Write("sg.ShadowQuality", sgShadowQualityCMB.SelectedIndex.ToString(), "ScalabilityGroups");
        }

        private void PostProcessingCMB_SelectedIndexChanged(object sender, EventArgs e) {
            var ini = new helper.IniFile(sPathToUse + @"\GameUserSettings.ini");
            ini.Write("sg.PostProcessQuality", sgPostProcessQualityCMB.SelectedIndex.ToString(), "ScalabilityGroups");
        }

        private void AnimationCMB_SelectedIndexChanged(object sender, EventArgs e) {
            var ini = new helper.IniFile(sPathToUse + @"\GameUserSettings.ini");
            ini.Write("sg.AnimationQuality", sgAnimationQualityCMB.SelectedIndex.ToString(), "ScalabilityGroups");
        }

        private void TextureCMB_SelectedIndexChanged(object sender, EventArgs e) {
            var ini = new helper.IniFile(sPathToUse + @"\GameUserSettings.ini");
            ini.Write("sg.TextureQuality", sgTextureQualityCMB.SelectedIndex.ToString(), "ScalabilityGroups");
        }

        private void EffectsCMB_SelectedIndexChanged(object sender, EventArgs e) {
            var ini = new helper.IniFile(sPathToUse + @"\GameUserSettings.ini");
            ini.Write("sg.EffectsQuality", sgEffectsQualityCMB.SelectedIndex.ToString(), "ScalabilityGroups");
        }
        
        private void ResScaleTrackbar_Scroll(object sender, EventArgs e) {
            ResQualityLabel.Text = $"Resolution Quality ({ResScaleTrackbar.Value})";
            var ini = new helper.IniFile(sPathToUse + @"\GameUserSettings.ini");
            ini.Write("sg.ResolutionQuality", ResScaleTrackbar.Value.ToString() + ".000000", "ScalabilityGroups");
        }

        private void UnlockFPSButton_Click(object sender, EventArgs e) {

            Dictionary<string, string> vars = new Dictionary<string, string>() {
                    { "bSmoothFrameRate", "False" },
                    { "MinSmoothedFrameRate", "False" },
                    { "MaxSmoothedFrameRate", "120" }
                };

            bool bDelete = File.ReadAllText(sPathToUse + @"\Engine.ini").Contains("[/script/engine.engine]");

            if (bDelete) {
                func.iniDeleteSection(@"\Engine.ini", "/script/engine.engine");
            } else foreach(var next in vars) {
                    func.iniChangeKey(@"\Engine.ini", "/script/engine.engine", next.Key, next.Value);
                }

            FPSInfoLabel.ForeColor = bDelete ? Color.Red : Color.Green;
            UnlockFPSButton.Text = bDelete ? "Unlock FPS" : "Lock FPS";
            FPSInfoLabel.Text = bDelete ? "FPS Locked" : "FPS Unlocked";

        }

        private void VSyncButton_Click(object sender, EventArgs e) {
            bool bDelete = func.iniReadKey(@"\GameUserSettings.ini", "/Script/DeadByDaylight.DBDGameUserSettings", "bUseVSync") == "False";

            func.iniChangeKey(@"\GameUserSettings.ini", "/Script/DeadByDaylight.DBDGameUserSettings", "bUseVSync", bDelete ? "True" : "False");
            VSyncInfolabel.ForeColor = bDelete ? Color.Red : Color.Green;
            VSyncInfolabel.Text = bDelete ? "VSync Enabled" : "VSync Disabled";
            VSyncButton.Text = bDelete ? "Disable VSync" : "Enable VSync";
        }

        private void MotionBlurButton_Click(object sender, EventArgs e) {
            bool bDelete = func.iniKeyExists(@"\Engine.ini", "/Script/Engine.GarbageCollectionSettings", "r.DefaultFeature.MotionBlur");

            if (bDelete) {
                func.iniDeleteKey(@"\Engine.ini", "/Script/Engine.GarbageCollectionSettings", "r.DefaultFeature.MotionBlur");
            } else {
                func.iniWriteKey(@"\Engine.ini", "/Script/Engine.GarbageCollectionSettings", "r.DefaultFeature.MotionBlur", "0");
            }

            MotionBlurButton.Text = bDelete ? "Disable Motion Blur" : "Enable Motion Blur";
            MotionBlurInfoLabel.Text = bDelete ? "Motion Blur Enabled" : "Motion Blur Disabled";
            MotionBlurInfoLabel.ForeColor = bDelete ? Color.Red : Color.Green;

        }

        private void BloomButton_Click(object sender, EventArgs e) {
            bool bDelete = func.iniKeyExists(@"\Engine.ini", "/Script/Engine.GarbageCollectionSettings", "r.DefaultFeature.Bloom");

            if (bDelete) {
                func.iniDeleteKey(@"\Engine.ini", "/Script/Engine.GarbageCollectionSettings", "r.DefaultFeature.Bloom");
            }
            else {
                func.iniWriteKey(@"\Engine.ini", "/Script/Engine.GarbageCollectionSettings", "r.DefaultFeature.Bloom", "False");
            }

            BloomButton.Text = bDelete ? "Disable Bloom" : "Enable Bloom";
            BloomInfoLabel.Text = bDelete ? "Bloom Enabled" : "Bloom Disabled";
            BloomInfoLabel.ForeColor = bDelete ? Color.Red : Color.Green;

        }

        private void LensFlareButton_Click(object sender, EventArgs e) {
            bool bDelete = func.iniKeyExists(@"\Engine.ini", "/Script/Engine.GarbageCollectionSettings", "r.DefaultFeature.LensFlare");

            if (bDelete) {
                func.iniDeleteKey(@"\Engine.ini", "/Script/Engine.GarbageCollectionSettings", "r.DefaultFeature.LensFlare");
            }
            else {
                func.iniWriteKey(@"\Engine.ini", "/Script/Engine.GarbageCollectionSettings", "r.DefaultFeature.LensFlare", "False");
            }

            LensFlareButton.Text = bDelete ? "Disable Lens Flare" : "Enable Lens Flare";
            LensFlareInfoLabel.Text = bDelete ? "Lens Flare Enabled" : "Lens Flare Disabled";
            LensFlareInfoLabel.ForeColor = bDelete ? Color.Red : Color.Green;
        }

        private void AmbientOcclusionButton_Click(object sender, EventArgs e) {
            bool bDelete = func.iniKeyExists(@"\Engine.ini", "/Script/Engine.GarbageCollectionSettings", "r.DefaultFeature.AmbientOcclusion");

            if (bDelete) {
                func.iniDeleteKey(@"\Engine.ini", "/Script/Engine.GarbageCollectionSettings", "r.DefaultFeature.AmbientOcclusion");
            }
            else {
                func.iniWriteKey(@"\Engine.ini", "/Script/Engine.GarbageCollectionSettings", "r.DefaultFeature.AmbientOcclusion", "False");
            }

            AmbientOcclusionButton.Text = bDelete ? "Disable Ambient Occlusion" : "Enable Ambient Occlusion";
            AmbientOcclusionInfoLabel.Text = bDelete ? "Ambient Occlusion Enabled" : "Ambient Occlusion Disabled";
            AmbientOcclusionInfoLabel.ForeColor = bDelete ? Color.Red : Color.Green;
        }

        private void ExportConfigButton_Click(object sender, EventArgs e) {
            string GUS = File.ReadAllText(sPathToUse + @"\GameUserSettings.ini");
            string E = File.ReadAllText(sPathToUse + @"\Engine.ini");
            Directory.CreateDirectory(sPathToUse + @"\exported");
            File.WriteAllText(sPathToUse + @"\exported\GameUserSettings.ini", GUS);
            File.WriteAllText(sPathToUse + @"\exported\Engine.ini", E);
            MessageBox.Show($@"Exported To {sPathToUse}\exported");
        }

        private void CopyConfigButton_Click(object sender, EventArgs e) {
            byte[] PTBGUS = Encoding.UTF8.GetBytes(File.ReadAllText(sPathToUse + @"\GameUserSettings.ini"));
            byte[] PTBENGINE = Encoding.UTF8.GetBytes(File.ReadAllText(sPathToUse + @"\Engine.ini"));
            string GUSEncoded = Convert.ToBase64String(PTBGUS);
            string EngineEncoded = Convert.ToBase64String(PTBENGINE);

            string JoinedEncode = GUSEncoded + "#" + EngineEncoded;

            File.WriteAllText(sPathToUse + @"\exported\config.txt", JoinedEncode);
            //open the text file
            Process.Start(sPathToUse + @"\exported\config.txt");
        }

        private void InjectConfigButton_Click(object sender, EventArgs e) {
            string clipTXT = Clipboard.GetText(TextDataFormat.Text);

            if (!clipTXT.Contains('#') || !func.IsValidBase64(clipTXT)) {
                MessageBox.Show("Invalid Config");
                return;
            }

            string[] split = clipTXT.Split('#');

            File.WriteAllText(sPathToUse + @"\GameUserSettings.ini", func.Base64Decode(split[0]));
            File.WriteAllText(sPathToUse + @"\Engine.ini", func.Base64Decode(split[1]));
            
            MessageBox.Show("Successfully Injected Config, Restarting...");
            Application.Restart();
            Application.Exit();
        }
        private void TimerInit_Tick(object sender, EventArgs e) {
            var userini = new helper.IniFile(sPathToUse + @"\Engine.ini");

            if (userini.KeyExists("MaxSmoothedFrameRate", "/script/engine.engine")) {
                UnlockFPSButton.Text = "Lock FPS";
                FPSInfoLabel.ForeColor = Color.Green;
                FPSInfoLabel.Text = "FPS Unlocked";
            }
            else {
                FPSInfoLabel.ForeColor = Color.Red;
                FPSInfoLabel.Text = "FPS locked";
            }

            if (userini.KeyExists("r.DefaultFeature.MotionBlur", "/Script/Engine.GarbageCollectionSettings")) {
                if (userini.ReadString("/Script/Engine.GarbageCollectionSettings", "r.DefaultFeature.MotionBlur") == "False") {
                    MotionBlurButton.Text = "Enable Motion Blur";
                    MotionBlurInfoLabel.ForeColor = Color.Green;
                    MotionBlurInfoLabel.Text = "Motion Blur Disabled";
                }
                else {
                    MotionBlurButton.Text = "Disable Motion Blur";
                    MotionBlurInfoLabel.ForeColor = Color.Red;
                    MotionBlurInfoLabel.Text = "Motion Blur Enabled";
                }
            }
            else {
                MotionBlurButton.Text = "Disable Motion Blur";
                MotionBlurInfoLabel.ForeColor = Color.Red;
                MotionBlurInfoLabel.Text = "Motion Blur Enabled";
            }

            if (userini.KeyExists("r.DefaultFeature.Bloom", "/Script/Engine.GarbageCollectionSettings")) {
                if (userini.ReadString("/Script/Engine.GarbageCollectionSettings", "r.DefaultFeature.Bloom") == "False") {
                    BloomButton.Text = "Enable Bloom";
                    BloomInfoLabel.ForeColor = Color.Green;
                    BloomInfoLabel.Text = "Bloom Disabled";
                }
                else {
                    BloomButton.Text = "Disable Bloom";
                    BloomInfoLabel.ForeColor = Color.Red;
                    BloomInfoLabel.Text = "Bloom Enabled";
                }
            }
            else {
                BloomButton.Text = "Disable Bloom";
                BloomInfoLabel.ForeColor = Color.Red;
                BloomInfoLabel.Text = "Bloom Enabled";
            }

            if (userini.KeyExists("r.DefaultFeature.LensFlare", "/Script/Engine.GarbageCollectionSettings")) {
                if (userini.ReadString("/Script/Engine.GarbageCollectionSettings", "r.DefaultFeature.LensFlare") == "False") {
                    LensFlareButton.Text = "Enable Lens Flare";
                    LensFlareInfoLabel.ForeColor = Color.Green;
                    LensFlareInfoLabel.Text = "Lens Flare Disabled";
                }
                else {
                    LensFlareButton.Text = "Disable Lens Flare";
                    LensFlareInfoLabel.ForeColor = Color.Red;
                    LensFlareInfoLabel.Text = "Lens Flare Enabled";
                }
            }
            else {
                LensFlareButton.Text = "Disable Lens Flare";
                LensFlareInfoLabel.ForeColor = Color.Red;
                LensFlareInfoLabel.Text = "Lens Flare Enabled";
            }

            if (userini.KeyExists("r.DefaultFeature.AmbientOcclusion", "/Script/Engine.GarbageCollectionSettings")) {
                if (userini.ReadString("/Script/Engine.GarbageCollectionSettings", "r.DefaultFeature.AmbientOcclusion") == "False") {
                    AmbientOcclusionButton.Text = "Enable Ambient Occlusion";
                    AmbientOcclusionInfoLabel.ForeColor = Color.Green;
                    AmbientOcclusionInfoLabel.Text = "Ambient Occlusion Disabled";
                }
                else {
                    AmbientOcclusionButton.Text = "Disable Ambient Occlusion";
                    AmbientOcclusionInfoLabel.ForeColor = Color.Red;
                    AmbientOcclusionInfoLabel.Text = "Ambient Occlusion Enabled";
                }
            }
            else {
                AmbientOcclusionButton.Text = "Disable Ambient Occlusion";
                AmbientOcclusionInfoLabel.ForeColor = Color.Red;
                AmbientOcclusionInfoLabel.Text = "Ambient Occlusion Enabled";
            }

            userini = new helper.IniFile(sPathToUse + @"\GameUserSettings.ini");

            if (Enumerable.Range(70, 135).Contains(userini.ReadInt("ScalabilityGroups", "sg.ResolutionQuality") / 1000000)) {
                ResScaleTrackbar.Value = userini.ReadInt("ScalabilityGroups", "sg.ResolutionQuality") / 1000000;
            }
            else {
                ResScaleTrackbar.Value = 100;
            }
            ResQualityLabel.Text = $"Resolution Quality ({userini.ReadInt("ScalabilityGroups", "sg.ResolutionQuality") / 1000000})";
            if (userini.ReadString("/Script/DeadByDaylight.DBDGameUserSettings", "bUseVSync") == "False") {
                VSyncButton.Text = "Enable VSync";
                VSyncInfolabel.ForeColor = Color.Green;
                VSyncInfolabel.Text = "VSync Disabled";
            }
            else {
                VSyncInfolabel.ForeColor = Color.Red;
                VSyncInfolabel.Text = "VSync Enabled";
            }
            
            var eini = new helper.IniFile(sPathToUse + @"\Engine.ini");
            if (eini.KeyExists("r.DefaultFeature.AntiAliasing", "/Script/Engine.GarbageCollectionSettings"))
                AntiAliasingCMB.SelectedIndex = 0;
            else
                AntiAliasingCMB.SelectedIndex = userini.ReadInt("ScalabilityGroups", "sg.AntiAliasingQuality");


            TimerInit.Stop();
        }

        private void OpenConfigLocationButton_Click(object sender, EventArgs e) {
            Process.Start("file://" + sPathToUse);
        }

        private void ChangeConfigPathButton_Click(object sender, EventArgs e) {
            SelectConfigLocation();
        }

        private void MinimizeButton_Click(object sender, EventArgs e) {
            for (int i = this.Width; i >= 0; i--) {
                this.Width -= 10;
                this.Height -= 10;
            }
            this.WindowState = FormWindowState.Minimized;
        }

        private void MinimizeButton_MouseEnter(object sender, EventArgs e) {
            MinimizeConfigEditor.ForeColor = Color.Red;
        }

        private void MinimizeButton_MouseLeave(object sender, EventArgs e) {
            MinimizeConfigEditor.ForeColor = Color.Silver;
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }


        private void Config_Editor_Activated(object sender, EventArgs e) {
            this.Width = 1000; 
            this.Height = 620;
        }

        private void OneToOneSensCB_CheckedChanged(object sender, EventArgs e) {
            helper.FUNCS f = new helper.FUNCS();
            switch (OneToOneSensCB.Checked) {
                case true:
                    DialogResult result = MessageBox.Show("Applying 1:1 Sensitivity Is Intended For Killer ONLY\n Survivor Sensitivity Will No Longer Be 1:1 While This Is Enabled", "Confirm", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No) {
                        OneToOneSensCB.Checked = false;
                    }
                    else {
                        f.ChangeSetting(sPathToUse + @"\Input.ini", "AxisMappings=(AxisName=\"LookUp\",Scale=", "-1.550654,Key=MouseY)"); //ini class doesnt support nested ini objects
                    }
                    break;
                case false:
                    f.ChangeSetting(sPathToUse + @"\Input.ini", "AxisMappings=(AxisName=\"LookUp\",Scale=", "-1.000000,Key=MouseY)");
                    break;
            }
            
        }
    }
}
