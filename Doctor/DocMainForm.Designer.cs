namespace Doctor
{
    partial class AstrandDoctorGUI
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChangePatient = new System.Windows.Forms.Button();
            this.lblPatBirthday = new System.Windows.Forms.Label();
            this.lblPatGender = new System.Windows.Forms.Label();
            this.lblPatName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGearDown = new System.Windows.Forms.Button();
            this.btnGearUp = new System.Windows.Forms.Button();
            this.lblValGear = new System.Windows.Forms.Label();
            this.lblValHeartbeat = new System.Windows.Forms.Label();
            this.lblValRpm = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAppExit = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbxPrevTests = new System.Windows.Forms.ListBox();
            this.chartSelectedRun = new LiveCharts.WinForms.CartesianChart();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewRun = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChangePatient);
            this.groupBox1.Controls.Add(this.lblPatBirthday);
            this.groupBox1.Controls.Add(this.lblPatGender);
            this.groupBox1.Controls.Add(this.lblPatName);
            this.groupBox1.Location = new System.Drawing.Point(12, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Patient";
            // 
            // btnChangePatient
            // 
            this.btnChangePatient.Location = new System.Drawing.Point(10, 141);
            this.btnChangePatient.Name = "btnChangePatient";
            this.btnChangePatient.Size = new System.Drawing.Size(184, 23);
            this.btnChangePatient.TabIndex = 3;
            this.btnChangePatient.Text = "Change Patient";
            this.btnChangePatient.UseVisualStyleBackColor = true;
            this.btnChangePatient.Click += new System.EventHandler(this.btnChangePatient_Click);
            // 
            // lblPatBirthday
            // 
            this.lblPatBirthday.AutoSize = true;
            this.lblPatBirthday.Location = new System.Drawing.Point(7, 66);
            this.lblPatBirthday.Name = "lblPatBirthday";
            this.lblPatBirthday.Size = new System.Drawing.Size(141, 13);
            this.lblPatBirthday.TabIndex = 2;
            this.lblPatBirthday.Text = "Date of Birth: xx/xx/xxxx (xx)";
            // 
            // lblPatGender
            // 
            this.lblPatGender.AutoSize = true;
            this.lblPatGender.Location = new System.Drawing.Point(7, 43);
            this.lblPatGender.Name = "lblPatGender";
            this.lblPatGender.Size = new System.Drawing.Size(53, 13);
            this.lblPatGender.TabIndex = 1;
            this.lblPatGender.Text = "Gender: x";
            // 
            // lblPatName
            // 
            this.lblPatName.AutoSize = true;
            this.lblPatName.Location = new System.Drawing.Point(7, 20);
            this.lblPatName.Name = "lblPatName";
            this.lblPatName.Size = new System.Drawing.Size(74, 13);
            this.lblPatName.TabIndex = 0;
            this.lblPatName.Text = "Name: xxx xxx";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btnGearDown);
            this.groupBox2.Controls.Add(this.btnGearUp);
            this.groupBox2.Controls.Add(this.lblValGear);
            this.groupBox2.Controls.Add(this.lblValHeartbeat);
            this.groupBox2.Controls.Add(this.lblValRpm);
            this.groupBox2.Location = new System.Drawing.Point(12, 286);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 162);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Live Values";
            // 
            // btnGearDown
            // 
            this.btnGearDown.Location = new System.Drawing.Point(117, 63);
            this.btnGearDown.Name = "btnGearDown";
            this.btnGearDown.Size = new System.Drawing.Size(23, 23);
            this.btnGearDown.TabIndex = 4;
            this.btnGearDown.Text = "🔽";
            this.btnGearDown.UseVisualStyleBackColor = true;
            this.btnGearDown.Click += new System.EventHandler(this.btnGearDown_Click);
            // 
            // btnGearUp
            // 
            this.btnGearUp.Location = new System.Drawing.Point(88, 63);
            this.btnGearUp.Name = "btnGearUp";
            this.btnGearUp.Size = new System.Drawing.Size(23, 23);
            this.btnGearUp.TabIndex = 3;
            this.btnGearUp.Text = "🔼";
            this.btnGearUp.UseVisualStyleBackColor = true;
            this.btnGearUp.Click += new System.EventHandler(this.btnGearUp_Click);
            // 
            // lblValGear
            // 
            this.lblValGear.AutoSize = true;
            this.lblValGear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValGear.Location = new System.Drawing.Point(6, 66);
            this.lblValGear.Name = "lblValGear";
            this.lblValGear.Size = new System.Drawing.Size(30, 13);
            this.lblValGear.TabIndex = 2;
            this.lblValGear.Text = "Gear";
            // 
            // lblValHeartbeat
            // 
            this.lblValHeartbeat.AutoSize = true;
            this.lblValHeartbeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValHeartbeat.Location = new System.Drawing.Point(6, 43);
            this.lblValHeartbeat.Name = "lblValHeartbeat";
            this.lblValHeartbeat.Size = new System.Drawing.Size(54, 13);
            this.lblValHeartbeat.TabIndex = 1;
            this.lblValHeartbeat.Text = "Heartbeat";
            // 
            // lblValRpm
            // 
            this.lblValRpm.AutoSize = true;
            this.lblValRpm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValRpm.Location = new System.Drawing.Point(7, 20);
            this.lblValRpm.Name = "lblValRpm";
            this.lblValRpm.Size = new System.Drawing.Size(31, 13);
            this.lblValRpm.TabIndex = 0;
            this.lblValRpm.Text = "RPM";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAppExit);
            this.groupBox3.Controls.Add(this.btnLogout);
            this.groupBox3.Controls.Add(this.lblUsername);
            this.groupBox3.Location = new System.Drawing.Point(13, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 96);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "User";
            // 
            // btnAppExit
            // 
            this.btnAppExit.Location = new System.Drawing.Point(106, 62);
            this.btnAppExit.Name = "btnAppExit";
            this.btnAppExit.Size = new System.Drawing.Size(88, 23);
            this.btnAppExit.TabIndex = 3;
            this.btnAppExit.Text = "Exit";
            this.btnAppExit.UseVisualStyleBackColor = true;
            this.btnAppExit.Click += new System.EventHandler(this.BtnAppExit_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(7, 62);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(88, 23);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(7, 20);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(61, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username: ";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.lbxPrevTests);
            this.groupBox4.Location = new System.Drawing.Point(218, 8);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(186, 440);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Previous Tests";
            // 
            // lbxPrevTests
            // 
            this.lbxPrevTests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxPrevTests.FormattingEnabled = true;
            this.lbxPrevTests.Items.AddRange(new object[] {
            "Array",
            "Of",
            "Previous",
            "Runs",
            "By",
            "Current",
            "Patient"});
            this.lbxPrevTests.Location = new System.Drawing.Point(5, 14);
            this.lbxPrevTests.Name = "lbxPrevTests";
            this.lbxPrevTests.Size = new System.Drawing.Size(176, 420);
            this.lbxPrevTests.TabIndex = 0;
            this.lbxPrevTests.SelectedIndexChanged += new System.EventHandler(this.lbxPrevTests_SelectedIndexChanged);
            // 
            // chartSelectedRun
            // 
            this.chartSelectedRun.Location = new System.Drawing.Point(409, 12);
            this.chartSelectedRun.Name = "chartSelectedRun";
            this.chartSelectedRun.Size = new System.Drawing.Size(483, 284);
            this.chartSelectedRun.TabIndex = 4;
            this.chartSelectedRun.Text = "cartesianChart1";
            this.chartSelectedRun.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.chartSelectedRun_ChildChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Location = new System.Drawing.Point(410, 303);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(294, 145);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Selected Run";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Average Resistance: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Average Heartrate: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "VO2max: ";
            // 
            // btnNewRun
            // 
            this.btnNewRun.Location = new System.Drawing.Point(710, 306);
            this.btnNewRun.Name = "btnNewRun";
            this.btnNewRun.Size = new System.Drawing.Size(182, 138);
            this.btnNewRun.TabIndex = 6;
            this.btnNewRun.Text = "Start New Run";
            this.btnNewRun.UseVisualStyleBackColor = true;
            this.btnNewRun.Click += new System.EventHandler(this.btnNewRun_Click);
            // 
            // AstrandDoctorGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 456);
            this.ControlBox = false;
            this.Controls.Add(this.btnNewRun);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.chartSelectedRun);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AstrandDoctorGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avans-Ästrand Doctor";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AstrandDoctorGUI_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPatBirthday;
        private System.Windows.Forms.Label lblPatGender;
        private System.Windows.Forms.Label lblPatName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblValGear;
        private System.Windows.Forms.Label lblValHeartbeat;
        private System.Windows.Forms.Label lblValRpm;
        private System.Windows.Forms.Button btnChangePatient;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAppExit;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnGearDown;
        private System.Windows.Forms.Button btnGearUp;
        private System.Windows.Forms.ListBox lbxPrevTests;
        private LiveCharts.WinForms.CartesianChart chartSelectedRun;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewRun;
    }
}

