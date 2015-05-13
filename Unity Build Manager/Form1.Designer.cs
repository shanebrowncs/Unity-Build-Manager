namespace Unity_Build_Manager
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buildBtn = new MetroFramework.Controls.MetroButton();
            this.statusLbl = new MetroFramework.Controls.MetroLabel();
            this.progressSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.addBtn = new MetroFramework.Controls.MetroButton();
            this.editBtn = new MetroFramework.Controls.MetroButton();
            this.upBtn = new MetroFramework.Controls.MetroButton();
            this.removeBtn = new MetroFramework.Controls.MetroButton();
            this.downBtn = new MetroFramework.Controls.MetroButton();
            this.buildList = new System.Windows.Forms.ListBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.buildNameTxt = new MetroFramework.Controls.MetroTextBox();
            this.archiveBuildsCb = new MetroFramework.Controls.MetroToggle();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.SpinnerScaleTimer = new System.Windows.Forms.Timer(this.components);
            this.saveFileBtn = new MetroFramework.Controls.MetroButton();
            this.openFileBtn = new MetroFramework.Controls.MetroButton();
            this.setDefaultBtn = new MetroFramework.Controls.MetroButton();
            this.loadedFileLbl = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.newFileBtn = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // buildBtn
            // 
            this.buildBtn.Location = new System.Drawing.Point(23, 372);
            this.buildBtn.Name = "buildBtn";
            this.buildBtn.Size = new System.Drawing.Size(143, 51);
            this.buildBtn.TabIndex = 1;
            this.buildBtn.Text = "&Build";
            this.buildBtn.UseSelectable = true;
            this.buildBtn.Click += new System.EventHandler(this.buildBtn_Click);
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(65, 426);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(49, 19);
            this.statusLbl.TabIndex = 2;
            this.statusLbl.Text = "Ready!";
            // 
            // progressSpinner
            // 
            this.progressSpinner.Location = new System.Drawing.Point(417, 138);
            this.progressSpinner.Maximum = 100;
            this.progressSpinner.Name = "progressSpinner";
            this.progressSpinner.Size = new System.Drawing.Size(170, 170);
            this.progressSpinner.Speed = 3F;
            this.progressSpinner.TabIndex = 3;
            this.progressSpinner.UseSelectable = true;
            this.progressSpinner.MouseMove += new System.Windows.Forms.MouseEventHandler(this.metroProgressSpinner1_MouseMove);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(687, 63);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(74, 23);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "Add";
            this.addBtn.UseSelectable = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(687, 92);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(75, 23);
            this.editBtn.TabIndex = 5;
            this.editBtn.Text = "Edit";
            this.editBtn.UseSelectable = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // upBtn
            // 
            this.upBtn.Location = new System.Drawing.Point(687, 186);
            this.upBtn.Name = "upBtn";
            this.upBtn.Size = new System.Drawing.Size(75, 23);
            this.upBtn.TabIndex = 6;
            this.upBtn.Text = "Up";
            this.upBtn.UseSelectable = true;
            this.upBtn.Click += new System.EventHandler(this.upBtn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(687, 121);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(74, 23);
            this.removeBtn.TabIndex = 7;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseSelectable = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // downBtn
            // 
            this.downBtn.Location = new System.Drawing.Point(687, 215);
            this.downBtn.Name = "downBtn";
            this.downBtn.Size = new System.Drawing.Size(75, 23);
            this.downBtn.TabIndex = 8;
            this.downBtn.Text = "Down";
            this.downBtn.UseSelectable = true;
            this.downBtn.Click += new System.EventHandler(this.downBtn_Click);
            // 
            // buildList
            // 
            this.buildList.Font = new System.Drawing.Font("Segoe WP", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildList.FormattingEnabled = true;
            this.buildList.ItemHeight = 21;
            this.buildList.Location = new System.Drawing.Point(23, 63);
            this.buildList.Name = "buildList";
            this.buildList.Size = new System.Drawing.Size(658, 298);
            this.buildList.TabIndex = 9;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(172, 372);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(81, 19);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "Build Name:";
            // 
            // buildNameTxt
            // 
            this.buildNameTxt.Lines = new string[0];
            this.buildNameTxt.Location = new System.Drawing.Point(259, 372);
            this.buildNameTxt.MaxLength = 32767;
            this.buildNameTxt.Name = "buildNameTxt";
            this.buildNameTxt.PasswordChar = '\0';
            this.buildNameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.buildNameTxt.SelectedText = "";
            this.buildNameTxt.Size = new System.Drawing.Size(152, 23);
            this.buildNameTxt.TabIndex = 11;
            this.buildNameTxt.UseSelectable = true;
            this.buildNameTxt.TextChanged += new System.EventHandler(this.buildNameTxt_TextChanged);
            // 
            // archiveBuildsCb
            // 
            this.archiveBuildsCb.AutoSize = true;
            this.archiveBuildsCb.Location = new System.Drawing.Point(268, 403);
            this.archiveBuildsCb.Name = "archiveBuildsCb";
            this.archiveBuildsCb.Size = new System.Drawing.Size(80, 17);
            this.archiveBuildsCb.TabIndex = 13;
            this.archiveBuildsCb.Text = "Off";
            this.archiveBuildsCb.UseSelectable = true;
            this.archiveBuildsCb.CheckedChanged += new System.EventHandler(this.archiveBuildsCb_CheckedChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(172, 401);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(93, 19);
            this.metroLabel2.TabIndex = 14;
            this.metroLabel2.Text = "Archive Builds:";
            // 
            // SpinnerScaleTimer
            // 
            this.SpinnerScaleTimer.Interval = 1;
            this.SpinnerScaleTimer.Tick += new System.EventHandler(this.SpinnerScaleTimer_Tick);
            // 
            // saveFileBtn
            // 
            this.saveFileBtn.Location = new System.Drawing.Point(579, 372);
            this.saveFileBtn.Name = "saveFileBtn";
            this.saveFileBtn.Size = new System.Drawing.Size(75, 23);
            this.saveFileBtn.TabIndex = 15;
            this.saveFileBtn.Text = "Save";
            this.saveFileBtn.UseSelectable = true;
            this.saveFileBtn.Click += new System.EventHandler(this.saveFileBtn_Click);
            // 
            // openFileBtn
            // 
            this.openFileBtn.Location = new System.Drawing.Point(498, 372);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(75, 23);
            this.openFileBtn.TabIndex = 16;
            this.openFileBtn.Text = "Open";
            this.openFileBtn.UseSelectable = true;
            this.openFileBtn.Click += new System.EventHandler(this.openFileBtn_Click);
            // 
            // setDefaultBtn
            // 
            this.setDefaultBtn.Location = new System.Drawing.Point(417, 401);
            this.setDefaultBtn.Name = "setDefaultBtn";
            this.setDefaultBtn.Size = new System.Drawing.Size(237, 23);
            this.setDefaultBtn.TabIndex = 17;
            this.setDefaultBtn.Text = "Set Current as Default";
            this.setDefaultBtn.UseSelectable = true;
            this.setDefaultBtn.Click += new System.EventHandler(this.setDefaultBtn_Click);
            // 
            // loadedFileLbl
            // 
            this.loadedFileLbl.AutoSize = true;
            this.loadedFileLbl.Location = new System.Drawing.Point(417, 427);
            this.loadedFileLbl.Name = "loadedFileLbl";
            this.loadedFileLbl.Size = new System.Drawing.Size(21, 19);
            this.loadedFileLbl.TabIndex = 18;
            this.loadedFileLbl.Text = "--";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(23, 426);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(46, 19);
            this.metroLabel3.TabIndex = 19;
            this.metroLabel3.Text = "Status:";
            // 
            // newFileBtn
            // 
            this.newFileBtn.Location = new System.Drawing.Point(417, 372);
            this.newFileBtn.Name = "newFileBtn";
            this.newFileBtn.Size = new System.Drawing.Size(75, 23);
            this.newFileBtn.TabIndex = 20;
            this.newFileBtn.Text = "New";
            this.newFileBtn.UseSelectable = true;
            this.newFileBtn.Click += new System.EventHandler(this.newFileBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 454);
            this.Controls.Add(this.newFileBtn);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.loadedFileLbl);
            this.Controls.Add(this.setDefaultBtn);
            this.Controls.Add(this.openFileBtn);
            this.Controls.Add(this.saveFileBtn);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.archiveBuildsCb);
            this.Controls.Add(this.buildNameTxt);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.buildList);
            this.Controls.Add(this.downBtn);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.upBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.progressSpinner);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.buildBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Unity Build Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton buildBtn;
        private MetroFramework.Controls.MetroLabel statusLbl;
        private MetroFramework.Controls.MetroProgressSpinner progressSpinner;
        private MetroFramework.Controls.MetroButton addBtn;
        private MetroFramework.Controls.MetroButton editBtn;
        private MetroFramework.Controls.MetroButton upBtn;
        private MetroFramework.Controls.MetroButton removeBtn;
        private MetroFramework.Controls.MetroButton downBtn;
        private System.Windows.Forms.ListBox buildList;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox buildNameTxt;
        private MetroFramework.Controls.MetroToggle archiveBuildsCb;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.Timer SpinnerScaleTimer;
        private MetroFramework.Controls.MetroButton saveFileBtn;
        private MetroFramework.Controls.MetroButton openFileBtn;
        private MetroFramework.Controls.MetroButton setDefaultBtn;
        private MetroFramework.Controls.MetroLabel loadedFileLbl;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton newFileBtn;






    }
}

