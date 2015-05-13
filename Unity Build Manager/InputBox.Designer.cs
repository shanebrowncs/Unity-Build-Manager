namespace Unity_Build_Manager
{
    partial class InputBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputBox));
            this.buildTargetCb = new MetroFramework.Controls.MetroComboBox();
            this.projectLocTxt = new MetroFramework.Controls.MetroTextBox();
            this.buildLocTxt = new MetroFramework.Controls.MetroTextBox();
            this.projectLocBrowseBtn = new MetroFramework.Controls.MetroButton();
            this.BuildLocBrowseBtn = new MetroFramework.Controls.MetroButton();
            this.okBtn = new MetroFramework.Controls.MetroButton();
            this.cancelBtn = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // buildTargetCb
            // 
            this.buildTargetCb.FormattingEnabled = true;
            this.buildTargetCb.ItemHeight = 23;
            this.buildTargetCb.Items.AddRange(new object[] {
            "Linux x64",
            "Linux x86",
            "Mac OSX x64",
            "Mac OSX x86",
            "Windows x64",
            "Windows x86"});
            this.buildTargetCb.Location = new System.Drawing.Point(132, 118);
            this.buildTargetCb.Name = "buildTargetCb";
            this.buildTargetCb.Size = new System.Drawing.Size(220, 29);
            this.buildTargetCb.TabIndex = 0;
            this.buildTargetCb.UseSelectable = true;
            // 
            // projectLocTxt
            // 
            this.projectLocTxt.Lines = new string[0];
            this.projectLocTxt.Location = new System.Drawing.Point(132, 60);
            this.projectLocTxt.MaxLength = 32767;
            this.projectLocTxt.Name = "projectLocTxt";
            this.projectLocTxt.PasswordChar = '\0';
            this.projectLocTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.projectLocTxt.SelectedText = "";
            this.projectLocTxt.Size = new System.Drawing.Size(188, 23);
            this.projectLocTxt.TabIndex = 1;
            this.projectLocTxt.UseSelectable = true;
            // 
            // buildLocTxt
            // 
            this.buildLocTxt.Lines = new string[0];
            this.buildLocTxt.Location = new System.Drawing.Point(132, 89);
            this.buildLocTxt.MaxLength = 32767;
            this.buildLocTxt.Name = "buildLocTxt";
            this.buildLocTxt.PasswordChar = '\0';
            this.buildLocTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.buildLocTxt.SelectedText = "";
            this.buildLocTxt.Size = new System.Drawing.Size(188, 23);
            this.buildLocTxt.TabIndex = 2;
            this.buildLocTxt.UseSelectable = true;
            // 
            // projectLocBrowseBtn
            // 
            this.projectLocBrowseBtn.Location = new System.Drawing.Point(326, 60);
            this.projectLocBrowseBtn.Name = "projectLocBrowseBtn";
            this.projectLocBrowseBtn.Size = new System.Drawing.Size(26, 23);
            this.projectLocBrowseBtn.TabIndex = 3;
            this.projectLocBrowseBtn.Text = "...";
            this.projectLocBrowseBtn.UseSelectable = true;
            this.projectLocBrowseBtn.Click += new System.EventHandler(this.projectLocBrowseBtn_Click);
            // 
            // BuildLocBrowseBtn
            // 
            this.BuildLocBrowseBtn.Location = new System.Drawing.Point(326, 89);
            this.BuildLocBrowseBtn.Name = "BuildLocBrowseBtn";
            this.BuildLocBrowseBtn.Size = new System.Drawing.Size(26, 23);
            this.BuildLocBrowseBtn.TabIndex = 4;
            this.BuildLocBrowseBtn.Text = "...";
            this.BuildLocBrowseBtn.UseSelectable = true;
            this.BuildLocBrowseBtn.Click += new System.EventHandler(this.BuildLocBrowseBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(23, 153);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 5;
            this.okBtn.Text = "OK";
            this.okBtn.UseSelectable = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(104, 153);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseSelectable = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(20, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(106, 19);
            this.metroLabel1.TabIndex = 7;
            this.metroLabel1.Text = "Project Location:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(32, 89);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(94, 19);
            this.metroLabel2.TabIndex = 8;
            this.metroLabel2.Text = "Build Location:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(43, 118);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(83, 19);
            this.metroLabel3.TabIndex = 9;
            this.metroLabel3.Text = "Build Target:";
            // 
            // InputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 188);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.BuildLocBrowseBtn);
            this.Controls.Add(this.projectLocBrowseBtn);
            this.Controls.Add(this.buildLocTxt);
            this.Controls.Add(this.projectLocTxt);
            this.Controls.Add(this.buildTargetCb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputBox";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Build Settings";
            this.Shown += new System.EventHandler(this.InputBox_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox buildTargetCb;
        private MetroFramework.Controls.MetroTextBox projectLocTxt;
        private MetroFramework.Controls.MetroTextBox buildLocTxt;
        private MetroFramework.Controls.MetroButton projectLocBrowseBtn;
        private MetroFramework.Controls.MetroButton BuildLocBrowseBtn;
        private MetroFramework.Controls.MetroButton okBtn;
        private MetroFramework.Controls.MetroButton cancelBtn;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
    }
}