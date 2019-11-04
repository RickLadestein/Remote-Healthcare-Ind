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
            this.btnEditPatient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxPatientSelect
            // 
            this.cbxPatientSelect.FormattingEnabled = true;
            this.cbxPatientSelect.Location = new System.Drawing.Point(12, 12);
            this.cbxPatientSelect.Name = "cbxPatientSelect";
            this.cbxPatientSelect.Size = new System.Drawing.Size(200, 21);
            this.cbxPatientSelect.TabIndex = 0;
            // 
            // btnSelectPatient
            // 
            this.btnSelectPatient.Location = new System.Drawing.Point(12, 205);
            this.btnSelectPatient.Name = "btnSelectPatient";
            this.btnSelectPatient.Size = new System.Drawing.Size(281, 34);
            this.btnSelectPatient.TabIndex = 1;
            this.btnSelectPatient.Text = "Select Patient";
            this.btnSelectPatient.UseVisualStyleBackColor = true;
            // 
            // btnNewPatient
            // 
            this.btnNewPatient.Location = new System.Drawing.Point(218, 11);
            this.btnNewPatient.Name = "btnNewPatient";
            this.btnNewPatient.Size = new System.Drawing.Size(75, 23);
            this.btnNewPatient.TabIndex = 2;
            this.btnNewPatient.Text = "New...";
            this.btnNewPatient.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnEditPatient);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 160);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnEditPatient
            // 
            this.btnEditPatient.Location = new System.Drawing.Point(200, 131);
            this.btnEditPatient.Name = "btnEditPatient";
            this.btnEditPatient.Size = new System.Drawing.Size(75, 23);
            this.btnEditPatient.TabIndex = 0;
            this.btnEditPatient.Text = "Edit";
            this.btnEditPatient.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gender";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Age";
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
            this.Text = "DocPatientSelect";
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}