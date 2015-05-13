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

namespace Unity_Build_Manager
{
    public partial class InputBox : MetroForm
    {
        public Form1.BuildTarget target;
        public string projectPath;
        public string buildPath;
        public InputBox(Form1.BuildTarget origTarget = Form1.BuildTarget.None, string origProjectPath = null, string origBuildPath = null)
        {
            InitializeComponent();

            target = origTarget;
            projectPath = origProjectPath;
            buildPath = origBuildPath;
        }

        private void InputBox_Shown(object sender, EventArgs e)
        {
            buildTargetCb.SelectedIndex = 0;

            if(target != Form1.BuildTarget.None)
            {
                switch(target)
                {
                    case Form1.BuildTarget.Linux_x64:
                        buildTargetCb.SelectedIndex = 0;
                        break;
                    case Form1.BuildTarget.Linux_x86:
                        buildTargetCb.SelectedIndex = 1;
                        break;
                    case Form1.BuildTarget.Mac_OSX_x64:
                        buildTargetCb.SelectedIndex = 2;
                        break;
                    case Form1.BuildTarget.Mac_OSX_x86:
                        buildTargetCb.SelectedIndex = 3;
                        break;
                    case Form1.BuildTarget.Windows_x64:
                        buildTargetCb.SelectedIndex = 4;
                        break;
                    case Form1.BuildTarget.Windows_x86:
                        buildTargetCb.SelectedIndex = 5;
                        break;
                }

                projectLocTxt.Text = projectPath;
                buildLocTxt.Text = buildPath;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            string errorList = "";

            if (projectLocTxt.Text.Trim().Length < 1)
                errorList += "- Project Path Empty\n";
            else if (!Directory.Exists(projectLocTxt.Text))
                errorList += "- Project Path Doesn't Exist\n";

            if (buildLocTxt.Text.Trim().Length < 1)
                errorList += "- Build Path Empty\n";
            else if (!Directory.Exists(Path.GetDirectoryName(buildLocTxt.Text)))
                errorList += "- Build Path Doesn't Exist\n";

            if(errorList.Length > 1)
            {
                MetroMessageBox.Show(this, errorList, "You Recieved The Following Errors");
            }
            else
            {
                target = getTargetFromIndex(buildTargetCb.SelectedIndex);
                projectPath = projectLocTxt.Text;
                buildPath = buildLocTxt.Text;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void projectLocBrowseBtn_Click(object sender, EventArgs e)
        {
            FolderSelectDialog fsd = new FolderSelectDialog();
            fsd.Title = "Select Unity Project Directory";
            if(fsd.ShowDialog())
            {
                projectLocTxt.Text = fsd.FileName;
            }
        }

        private void BuildLocBrowseBtn_Click(object sender, EventArgs e)
        {
            FolderSelectDialog fsd = new FolderSelectDialog();
            fsd.Title = "Select Project Build Directory";
            if (fsd.ShowDialog())
            {
                buildLocTxt.Text = fsd.FileName;
            }
        }

        private Form1.BuildTarget getTargetFromIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return Form1.BuildTarget.Linux_x64;
                case 1:
                    return Form1.BuildTarget.Linux_x86;
                case 2:
                    return Form1.BuildTarget.Mac_OSX_x64;
                case 3:
                    return Form1.BuildTarget.Mac_OSX_x86;
                case 4:
                    return Form1.BuildTarget.Windows_x64;
                case 5:
                    return Form1.BuildTarget.Windows_x86;
                default:
                    return Form1.BuildTarget.None;
            }
        }
    }
}
