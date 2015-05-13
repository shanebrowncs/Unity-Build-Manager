using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Ionic.Zip;

namespace Unity_Build_Manager
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool spinnerIsScaled = false;
        bool pendingChanges = false;
        bool controlsInitialized = false;
        string saveFilePath;
        string unityExec;
        BackgroundWorker builder;

        // Currently supported build platforms
        public enum BuildTarget
        {
            None,
            Windows_x64,
            Windows_x86,
            Linux_x64,
            Linux_x86,
            Mac_OSX_x64,
            Mac_OSX_x86
        }

        #region MISC EVENT HANDLERS
        private void Form1_Shown(object sender, EventArgs e)
        {
            RegistryEditor regEdit = new RegistryEditor();

            string filePath = (string)regEdit.ReadFromRegistry("defaultFile", "Software\\UnityBuildManager", false, "");

            if (filePath != "")
            {
                loadUBMFile(filePath);
            }

            string unityPath = (string)regEdit.ReadFromRegistry("Location x64", "Software\\Unity Technologies\\Installer\\Unity", false, "");

            if(unityPath == "")
            {
                string unityOurRegPath = (string)regEdit.ReadFromRegistry("unityPath", "Software\\UnityBuildManager", false, "");
                if(unityOurRegPath == "")
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "Unity Editor Executable | *.exe";
                    ofd.Title = "Select Unity Editor Executable";

                    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        unityExec = ofd.FileName;
                        regEdit.WriteToRegistry("unityPath", "Software\\UnityBuildManager", unityExec);
                    }
                }
                else
                {
                    unityExec = unityOurRegPath;
                }
            }
            else
            {
                unityExec = unityPath + "\\Editor\\Unity.exe";
                if(File.Exists(unityExec))
                {
                    regEdit.WriteToRegistry("unityPath", "Software\\UnityBuildManager", unityExec);
                }
            }

            Process process = new Process();
            ProcessStartInfo info = new ProcessStartInfo("Unity.exe", "Args");
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pendingChanges)
            {
                if (promptSaveChanges() == System.Windows.Forms.DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
        private void buildNameTxt_TextChanged(object sender, EventArgs e)
        {
            if(buildNameTxt.Text.Contains(' '))
            {
                buildNameTxt.Text = buildNameTxt.Text.Replace(" ", "_");
                buildNameTxt.Select(buildNameTxt.Text.Length, 0);
                this.Refresh();   
            }

            if(controlsInitialized)
            {
                pendingChanges = true;
                this.Text = "Unity Build Manager*";
                this.Refresh();
            }
            
        }

        private void archiveBuildsCb_CheckedChanged(object sender, EventArgs e)
        {
            if(controlsInitialized)
            {
                pendingChanges = true;
                this.Text = "Unity Build Manager*";
                this.Refresh();
            }  
        }
        #endregion

        #region SPINNER
        private void SpinnerScaleTimer_Tick(object sender, EventArgs e)
        {
            if(!spinnerIsScaled)
            {
                if (progressSpinner.Width < 407)
                {
                    progressSpinner.Height += 2;
                    progressSpinner.Width += 2;
                }
                else
                {
                    spinnerIsScaled = true;
                    SpinnerScaleTimer.Stop();
                }
            }
            else
            {
                if (progressSpinner.Width > 170)
                {
                    progressSpinner.Height += -2;
                    progressSpinner.Width += -2;
                }
                else
                {
                    spinnerIsScaled = false;
                    SpinnerScaleTimer.Stop();
                }
            }
            
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void metroProgressSpinner1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        #region LIST CONTROL BUTTONS
        private void addBtn_Click(object sender, EventArgs e)
        {
            InputBox inbox = new InputBox();
            if (inbox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                buildList.Items.Add(inbox.target.ToString() + " | " + inbox.projectPath + " | " + inbox.buildPath);
                pendingChanges = true;
                this.Text = "Unity Build Manager*";
            }

            this.Refresh();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            int index = buildList.SelectedIndex;

            if (index == -1)
                return;

            string[] parseList = parseBuildItem(buildList.Items[index].ToString());

            InputBox input = new InputBox(buildTargetFromString(parseList[0]), parseList[1], parseList[2]);
            if(input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                buildList.Items.RemoveAt(index);
                buildList.Items.Insert(index, input.target + " | " + input.projectPath + " | " + input.buildPath);

                this.Text = "Unity Build Manager*";
                pendingChanges = true;
                this.Refresh();
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            int index = buildList.SelectedIndex;

            if (index == -1)
                return;

            buildList.Items.RemoveAt(index);

            pendingChanges = true;
            this.Text = "Unity Build Manager*";
        }

        private void upBtn_Click(object sender, EventArgs e)
        {
            int index = buildList.SelectedIndex;

            if (index == -1)
                return;

            string item = buildList.SelectedItem.ToString();

            if(index > 0)
            {
                buildList.Items.RemoveAt(index);
                buildList.Items.Insert(index - 1, item);
                buildList.SelectedIndex = index - 1;
            }
            
        }

        private void downBtn_Click(object sender, EventArgs e)
        {
            int index = buildList.SelectedIndex;

            if (index == -1)
                return;

            string item = buildList.SelectedItem.ToString();

            if (index < buildList.Items.Count - 1)
            {
                buildList.Items.RemoveAt(index);
                buildList.Items.Insert(index + 1, item);
                buildList.SelectedIndex = index + 1;
            }
        }
        #endregion

        #region FILE BUTTONS
        private void openFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Unity Build Management File | *.ubm";
            ofd.Title = "Select Unity Build Manager File.";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (pendingChanges && promptSaveChanges() == System.Windows.Forms.DialogResult.Cancel)
                    return;

                loadUBMFile(ofd.FileName);
            }
        }
        private void saveFileBtn_Click(object sender, EventArgs e)
        {
            statusLbl.Text = "Saving UBM..";
            this.Refresh();

            XMLSaver saver = new XMLSaver();
            if(loadedFileLbl.Text == "--")
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Unity Build Management File | *.ubm";
                sfd.Title = "Select Unity Build Manager File Save Location.";

                if(sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string[] items = new string[buildList.Items.Count];
                    for (int i = 0; i < buildList.Items.Count; i++ )
                        items[i] = buildList.Items[i].ToString();

                    saver.saveToXML(loadedFileLbl.Text, items, archiveBuildsCb.Checked, buildNameTxt.Text);
                    this.Text = "Unity Build Manager";
                    loadedFileLbl.Text = sfd.FileName;
                    pendingChanges = false;
                }

                statusLbl.Text = "Ready!";
            }
            else
            {
                string[] items = new string[buildList.Items.Count];
                for (int i = 0; i < buildList.Items.Count; i++ )
                    items[i] = buildList.Items[i].ToString();

                saver.saveToXML(loadedFileLbl.Text, items, archiveBuildsCb.Checked, buildNameTxt.Text);
                statusLbl.Text = "Ready!";
                pendingChanges = false;
                this.Text = "Unity Build Manager";
            }

            this.Refresh();
        }

        private void newFileBtn_Click(object sender, EventArgs e)
        {
            if (pendingChanges && promptSaveChanges() == System.Windows.Forms.DialogResult.Cancel)
                return;

            buildList.Items.Clear();
            this.Text = "Unity Build Manager";
            loadedFileLbl.Text = "--";
            pendingChanges = false;
            this.Refresh();
        }

        private void setDefaultBtn_Click(object sender, EventArgs e)
        {
            if(pendingChanges)
            {
                promptSaveChanges();
            }

            RegistryEditor regedit = new RegistryEditor();
            if(loadedFileLbl.Text != "--")
                regedit.WriteToRegistry("defaultFile", "Software\\UnityBuildManager", loadedFileLbl.Text);
            else
                regedit.WriteToRegistry("defaultFile", "Software\\UnityBuildManager", string.Empty);
        }

        private void buildBtn_Click(object sender, EventArgs e)
        {
            string errors = checkBuildErrors();
            if(errors.Length > 1)
            {
                MetroMessageBox.Show(this, errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if(pendingChanges && promptSaveChanges() == System.Windows.Forms.DialogResult.Cancel)
                return;

            SpinnerScaleTimer.Start();
            builder = new BackgroundWorker();
            builder.DoWork += builder_DoWork;
            builder.RunWorkerCompleted += builder_RunWorkerCompleted;
            builder.ProgressChanged += builder_ProgressChanged;
            builder.WorkerReportsProgress = true;

            SpinnerScaleTimer.Start();

            builder.RunWorkerAsync();
        }

        void builder_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if((int)e.UserState == 0)
            {
                string[] item = parseBuildItem(buildList.Items[e.ProgressPercentage].ToString());
                statusLbl.Text = "Building " + item[0] + "...";
            }
            else if((int)e.UserState == 1)
            {
                string[] item = parseBuildItem(buildList.Items[e.ProgressPercentage].ToString());
                statusLbl.Text = "Archiving " + item[0] + "...";
            }
            
        }

        void builder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SpinnerScaleTimer.Start();
            statusLbl.Text = "Ready!";
        }

        void builder_DoWork(object sender, DoWorkEventArgs e)
        {
            for(int i = 0; i < buildList.Items.Count; i++)
            {
                builder.ReportProgress(i, 0);
                buildItem(buildList.Items[i].ToString());
            }

            if (archiveBuildsCb.Checked)
                archiveBuilds();
        }

        private void buildItem(string item)
        {
            string[] itemInfo = parseBuildItem(item);
            string buildType;
            string buildLoc;

            if (!Directory.Exists(itemInfo[2] + "\\" + buildNameTxt.Text + "_" + itemInfo[0]))
                Directory.CreateDirectory(itemInfo[2] + "\\" + buildNameTxt.Text + "_" + itemInfo[0]);

            string origBuildDir = itemInfo[2];
            itemInfo[2] = itemInfo[2] + "\\" + buildNameTxt.Text + "_" + itemInfo[0];

            switch(buildTargetFromString(itemInfo[0]))
            {
                case BuildTarget.Linux_x64:
                    buildType = "-buildLinux64Player";
                    buildLoc = itemInfo[2] + "\\" + buildNameTxt.Text + "_x64";
                    break;
                case BuildTarget.Linux_x86:
                    buildType = "-buildLinux86Player";
                    buildLoc = itemInfo[2] + "\\" + buildNameTxt.Text + "_x86";
                    break;
                case BuildTarget.Mac_OSX_x64:
                    buildType = "-buildOSX64Player";
                    buildLoc = itemInfo[2] + "\\" + buildNameTxt.Text + "_x64.app";
                    break;
                case BuildTarget.Mac_OSX_x86:
                    buildType = "-buildOSXPlayer";
                    buildLoc = itemInfo[2] + "\\" + buildNameTxt.Text + "_x86.app";
                    break;
                case BuildTarget.Windows_x64:
                    buildType = "-buildWindows64Player";
                    buildLoc = itemInfo[2] + "\\" + buildNameTxt.Text + "_x64.exe";
                    break;
                case BuildTarget.Windows_x86:
                    buildType = "-buildWindowsPlayer";
                    buildLoc = itemInfo[2] + "\\" + buildNameTxt.Text + "_x86.exe";
                    break;
                default:
                    buildType = "-buildWindows64Player";
                    buildLoc = itemInfo[2] + "\\" + buildNameTxt.Text + "_x86.exe";
                    break;
            }

            string arguements = "-projectPath " + itemInfo[1] + " " + buildType + " " + buildLoc + " -quit -batchmode";
            ProcessStartInfo startInfo = new ProcessStartInfo(unityExec, arguements);
            Process buildProcess = Process.Start(startInfo);
            Console.WriteLine("Process Started: " + unityExec + " " + arguements);

            while(!buildProcess.HasExited)
            {
                Application.DoEvents();
            }
            Console.WriteLine("Finished");
        }

        private void archiveBuilds()
        {
            for(int i = 0; i < buildList.Items.Count; i++)
            {
                
                string[] curItem = parseBuildItem(buildList.Items[i].ToString());

                builder.ReportProgress(i, 1);

                string buildLoc = curItem[2] + "\\" + buildNameTxt.Text + "_" + curItem[0];

                using(ZipFile zip = new ZipFile())
                {
                    zip.AddDirectory(buildLoc);
                    zip.Save(curItem[2] + "\\" + buildNameTxt.Text + "_" + curItem[0] + ".zip");
                }
            }
        }

        private string checkBuildErrors()
        {
            string errorList = "";
            if (buildList.Items.Count < 1)
            {
                errorList += "- You have no builds in the build que.";
            }

            if (!Regex.IsMatch(buildNameTxt.Text, @"^[\w\-. ]+$"))
            {
                errorList += "- Build Name Contains Invalid Characters. Please Only Use File Name Appropriate Characters.";
            }

            return errorList;
        }
        #endregion

        #region UTILITY FUNCTIONS
        private BuildTarget buildTargetFromString(string buildTarget)
        {
            switch (buildTarget)
            {
                case "Linux_x64":
                    return BuildTarget.Linux_x64;
                case "Linux_x86":
                    return BuildTarget.Linux_x86;
                case "Mac_OSX_x64":
                    return BuildTarget.Mac_OSX_x64;
                case "Mac_OSX_x86":
                    return BuildTarget.Mac_OSX_x86;
                case "Windows_x64":
                    return BuildTarget.Windows_x64;
                case "Windows_x86":
                    return BuildTarget.Windows_x86;
                default:
                    return BuildTarget.None;
            }
        }
        private void loadUBMFile(string filePath)
        {
            controlsInitialized = false;
            statusLbl.Text = "Loading UBM..";
            this.Text = "Unity Build Manager";
            this.Refresh();
            XMLSaver saver = new XMLSaver();
            string[] list = saver.loadFromXML(filePath);

            if (list[0] == "true")
                archiveBuildsCb.Checked = true;
            else
                archiveBuildsCb.Checked = false;

            buildNameTxt.Text = list[1];

            buildList.Items.Clear();
            for (int i = 2; i < list.Length; i++)
            {
                buildList.Items.Add(list[i]);
            }

            statusLbl.Text = "Ready!";
            loadedFileLbl.Text = filePath;
            this.Refresh();
            controlsInitialized = true;
        }

        private DialogResult promptSaveChanges()
        {
            DialogResult result = MetroMessageBox.Show(this, "You have made changes to this file since your last save, would you like to save?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                string saveLoc;
                if (loadedFileLbl.Text != "--")
                {
                    saveLoc = loadedFileLbl.Text;
                }
                else
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Unity Build Management File | *.ubm";

                    DialogResult sfdResult = sfd.ShowDialog();
                    if (sfdResult == System.Windows.Forms.DialogResult.OK)
                    {
                        saveLoc = sfd.FileName;
                    }
                    else
                    {
                        return DialogResult.Cancel;
                    }
                }

                statusLbl.Text = "Saving UBM..";
                XMLSaver xmlSaver = new XMLSaver();
                string[] listToSave = new string[buildList.Items.Count];
                for (int i = 0; i < buildList.Items.Count; i++)
                {
                    listToSave[i] = buildList.Items[i].ToString();
                }

                xmlSaver.saveToXML(saveLoc, listToSave, archiveBuildsCb.Checked, buildNameTxt.Text);
                loadedFileLbl.Text = saveLoc;
                pendingChanges = false;
                this.Text = "Unity Build Manager";
                statusLbl.Text = "Ready!";
                this.Refresh();

                
            }

            return result;
        }

        private string[] parseBuildItem(string buildItem)
        {
                string[] curItem = buildItem.Replace(" ", string.Empty).Split('|');
                for (int i = 0; i < curItem.Length; i++)
                    curItem[i].Trim();

                return curItem;
        }
        #endregion 
    }
}
