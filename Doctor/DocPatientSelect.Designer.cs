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
            this.cbxPatientSelect.Location = new System.Drawing.Point(12, 12);
            this.cbxPatientSelect.Name = "cbxPatientSelect";
            this.cbxPatientSelect.Size = new System.Drawing.Size(200, 21);
            this.cbxPatientSelect.TabIndex = 0;
            this.cbxPatientSelect.SelectedIndexChanged += new System.EventHandler(this.cbxPatientSelect_SelectedIndexChanged);
            this.cbxPatientSelect.TextChanged += new System.EventHandler(this.CbxPatientSelect_TextChanged);
            // 
            // btnSelectPatient
            // 
            this.btnSelectPatient.Location = new System.Drawing.Point(12, 205);
            this.btnSelectPatient.Name = "btnSelectPatient";
            this.btnSelectPatient.Size = new System.Drawing.Size(281, 34);
            this.btnSelectPatient.TabIndex = 1;
            this.btnSelectPatient.Text = "Select Patient";
            this.btnSelectPatient.UseVisualStyleBackColor = true;
            this.btnSelectPatient.Click += new System.EventHandler(this.BtnSelectPatient_Click);
            // 
            // btnNewPatient
            // 
            this.btnNewPatient.Location = new System.Drawing.Point(218, 11);
            this.btnNewPatient.Name = "btnNewPatient";
            this.btnNewPatient.Size = new System.Drawing.Size(75, 23);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 160);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblDetailsDate
            // 
            this.lblDetailsDate.AutoSize = true;
            this.lblDetailsDate.Location = new System.Drawing.Point(22, 74);
            this.lblDetailsDate.Name = "lblDetailsDate";
            this.lblDetailsDate.Size = new System.Drawing.Size(66, 13);
            this.lblDetailsDate.TabIndex = 3;
            this.lblDetailsDate.Text = "Date of Birth";
            // 
            // lblDetailsGender
            // 
            this.lblDetailsGender.AutoSize = true;
            this.lblDetailsGender.Location = new System.Drawing.Point(22, 47);
            this.lblDetailsGender.Name = "lblDetailsGender";
            this.lblDetailsGender.Size = new System.Drawing.Size(42, 13);
            this.lblDetailsGender.TabIndex = 2;
            this.lblDetailsGender.Text = "Gender";
            // 
            // lblDetailsName
            // 
            this.lblDetailsName.AutoSize = true;
            this.lblDetailsName.Location = new System.Drawing.Point(22, 20);
            this.lblDetailsName.Name = "lblDetailsName";
            this.lblDetailsName.Size = new System.Drawing.Size(35, 13);
            this.lblDetailsName.TabIndex = 1;
            this.lblDetailsName.Text = "Name";
            // 
            // btnEditPatient
            // 
            this.btnEditPatient.Location = new System.Drawing.Point(200, 131);
            this.btnEditPatient.Name = "btnEditPatient";
            this.btnEditPatient.Size = new System.Drawing.Size(75, 23);
            this.btnEditPatient.TabIndex = 0;
            this.btnEditPatient.Text = "Edit";
            this.btnEditPatient.UseVisualStyleBackColor = true;
            this.btnEditPatient.Click += new System.EventHandler(this.BtnEditPatient_Click);
            // 
            // DocPatientSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 248);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNewPatient);
            this.Controls.Add(this.btnSelectPatient);
            this.Controls.Add(this.cbxPatientSelect);
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