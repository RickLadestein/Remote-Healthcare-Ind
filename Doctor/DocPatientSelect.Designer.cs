namespace Doctor
{
    partial class DocPatientSelect
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
            this.cbxPatientSelect = new System.Windows.Forms.ComboBox();
            this.btnSelectPatient = new System.Windows.Forms.Button();
            this.btnNewPatient = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDetailsDate = new System.Windows.Forms.Label();
            this.lblDetailsGender = new System.Windows.Forms.Label();
            this.lblDetailsName = new System.Windows.Forms.Label();
            this.btnEditPatient = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxPatientSelect
            // 
            this.cbxPatientSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPatientSelect.FormattingEnabled = true;
            this.cbxPatientSelect.Items.AddRange(new object[] {
            "asdf1",
            "asdf2",
            "adsf"});
            this.cbxPatientSelect.Location = new System.Drawing.Point(24, 23);
            this.cbxPatientSelect.Margin = new System.Windows.Forms.Padding(6);
            this.cbxPatientSelect.Name = "cbxPatientSelect";
            this.cbxPatientSelect.Size = new System.Drawing.Size(396, 33);
            this.cbxPatientSelect.TabIndex = 0;
            this.cbxPatientSelect.SelectedIndexChanged += new System.EventHandler(this.cbxPatientSelect_SelectedIndexChanged);
            this.cbxPatientSelect.TextChanged += new System.EventHandler(this.CbxPatientSelect_TextChanged);
            // 
            // btnSelectPatient
            // 
            this.btnSelectPatient.Location = new System.Drawing.Point(24, 394);
            this.btnSelectPatient.Margin = new System.Windows.Forms.Padding(6);
            this.btnSelectPatient.Name = "btnSelectPatient";
            this.btnSelectPatient.Size = new System.Drawing.Size(562, 65);
            this.btnSelectPatient.TabIndex = 1;
            this.btnSelectPatient.Text = "Select Patient";
            this.btnSelectPatient.UseVisualStyleBackColor = true;
            this.btnSelectPatient.Click += new System.EventHandler(this.BtnSelectPatient_Click);
            // 
            // btnNewPatient
            // 
            this.btnNewPatient.Location = new System.Drawing.Point(436, 21);
            this.btnNewPatient.Margin = new System.Windows.Forms.Padding(6);
            this.btnNewPatient.Name = "btnNewPatient";
            this.btnNewPatient.Size = new System.Drawing.Size(150, 44);
            this.btnNewPatient.TabIndex = 2;
            this.btnNewPatient.Text = "New...";
            this.btnNewPatient.UseVisualStyleBackColor = true;
            this.btnNewPatient.Click += new System.EventHandler(this.BtnNewPatient_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDetailsDate);
            this.groupBox1.Controls.Add(this.lblDetailsGender);
            this.groupBox1.Controls.Add(this.lblDetailsName);
            this.groupBox1.Controls.Add(this.btnEditPatient);
            this.groupBox1.Location = new System.Drawing.Point(24, 75);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(562, 308);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblDetailsDate
            // 
            this.lblDetailsDate.AutoSize = true;
            this.lblDetailsDate.Location = new System.Drawing.Point(44, 142);
            this.lblDetailsDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDetailsDate.Name = "lblDetailsDate";
            this.lblDetailsDate.Size = new System.Drawing.Size(131, 25);
            this.lblDetailsDate.TabIndex = 3;
            this.lblDetailsDate.Text = "Date of Birth";
            // 
            // lblDetailsGender
            // 
            this.lblDetailsGender.AutoSize = true;
            this.lblDetailsGender.Location = new System.Drawing.Point(44, 90);
            this.lblDetailsGender.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDetailsGender.Name = "lblDetailsGender";
            this.lblDetailsGender.Size = new System.Drawing.Size(83, 25);
            this.lblDetailsGender.TabIndex = 2;
            this.lblDetailsGender.Text = "Gender";
            // 
            // lblDetailsName
            // 
            this.lblDetailsName.AutoSize = true;
            this.lblDetailsName.Location = new System.Drawing.Point(44, 38);
            this.lblDetailsName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDetailsName.Name = "lblDetailsName";
            this.lblDetailsName.Size = new System.Drawing.Size(68, 25);
            this.lblDetailsName.TabIndex = 1;
            this.lblDetailsName.Text = "Name";
            // 
            // btnEditPatient
            // 
            this.btnEditPatient.Location = new System.Drawing.Point(400, 252);
            this.btnEditPatient.Margin = new System.Windows.Forms.Padding(6);
            this.btnEditPatient.Name = "btnEditPatient";
            this.btnEditPatient.Size = new System.Drawing.Size(150, 44);
            this.btnEditPatient.TabIndex = 0;
            this.btnEditPatient.Text = "Edit";
            this.btnEditPatient.UseVisualStyleBackColor = true;
            this.btnEditPatient.Click += new System.EventHandler(this.BtnEditPatient_Click);
            // 
            // DocPatientSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 477);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNewPatient);
            this.Controls.Add(this.btnSelectPatient);
            this.Controls.Add(this.cbxPatientSelect);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "DocPatientSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DocPatientSelect";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DocPatientSelect_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxPatientSelect;
        private System.Windows.Forms.Button btnSelectPatient;
        private System.Windows.Forms.Button btnNewPatient;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEditPatient;
        private System.Windows.Forms.Label lblDetailsDate;
        private System.Windows.Forms.Label lblDetailsGender;
        private System.Windows.Forms.Label lblDetailsName;
    }
}