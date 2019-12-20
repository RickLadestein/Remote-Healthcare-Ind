namespace Doctor
{
    partial class DocEditPatientForm
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
            this.btnApply = new System.Windows.Forms.Button();
            this.inpName = new System.Windows.Forms.TextBox();
            this.inpGender = new System.Windows.Forms.ComboBox();
            this.inpBirth = new System.Windows.Forms.DateTimePicker();
            this.lblBirth = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(273, 195);
            this.btnApply.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(248, 44);
            this.btnApply.TabIndex = 13;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // inpName
            // 
            this.inpName.Location = new System.Drawing.Point(174, 23);
            this.inpName.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.inpName.Name = "inpName";
            this.inpName.Size = new System.Drawing.Size(342, 31);
            this.inpName.TabIndex = 12;
            // 
            // inpGender
            // 
            this.inpGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inpGender.FormattingEnabled = true;
            this.inpGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.inpGender.Location = new System.Drawing.Point(174, 73);
            this.inpGender.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.inpGender.Name = "inpGender";
            this.inpGender.Size = new System.Drawing.Size(238, 33);
            this.inpGender.TabIndex = 11;
            // 
            // inpBirth
            // 
            this.inpBirth.Location = new System.Drawing.Point(174, 125);
            this.inpBirth.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.inpBirth.Name = "inpBirth";
            this.inpBirth.Size = new System.Drawing.Size(342, 31);
            this.inpBirth.TabIndex = 10;
            // 
            // lblBirth
            // 
            this.lblBirth.AutoSize = true;
            this.lblBirth.Location = new System.Drawing.Point(20, 133);
            this.lblBirth.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Size = new System.Drawing.Size(131, 25);
            this.lblBirth.TabIndex = 9;
            this.lblBirth.Text = "Date of Birth";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(20, 79);
            this.lblGender.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(83, 25);
            this.lblGender.TabIndex = 8;
            this.lblGender.Text = "Gender";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 29);
            this.lblName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(68, 25);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(15, 195);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(248, 44);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DocEditPatientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 254);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.inpName);
            this.Controls.Add(this.inpGender);
            this.Controls.Add(this.inpBirth);
            this.Controls.Add(this.lblBirth);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblName);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "DocEditPatientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DocEditPatientForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox inpName;
        private System.Windows.Forms.ComboBox inpGender;
        private System.Windows.Forms.DateTimePicker inpBirth;
        private System.Windows.Forms.Label lblBirth;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnCancel;
    }
}