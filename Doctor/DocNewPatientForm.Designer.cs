namespace Doctor
{
    partial class DocNewPatientForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.inpName = new System.Windows.Forms.TextBox();
            this.inpGender = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.inpBirth = new System.Windows.Forms.DateTimePicker();
            this.btnCreate = new System.Windows.Forms.Button();
            this.inpSurName = new System.Windows.Forms.TextBox();
            this.inpHeight = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.inpWeight = new System.Windows.Forms.TextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // inpName
            // 
            this.inpName.Location = new System.Drawing.Point(89, 12);
            this.inpName.Name = "inpName";
            this.inpName.Size = new System.Drawing.Size(55, 20);
            this.inpName.TabIndex = 5;
            // 
            // inpGender
            // 
            this.inpGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inpGender.FormattingEnabled = true;
            this.inpGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.inpGender.Location = new System.Drawing.Point(89, 38);
            this.inpGender.Name = "inpGender";
            this.inpGender.Size = new System.Drawing.Size(121, 21);
            this.inpGender.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gender";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date of Birth";
            // 
            // inpBirth
            // 
            this.inpBirth.Location = new System.Drawing.Point(89, 65);
            this.inpBirth.Name = "inpBirth";
            this.inpBirth.Size = new System.Drawing.Size(173, 20);
            this.inpBirth.TabIndex = 3;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 175);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(250, 23);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create New Patient";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // inpSurName
            // 
            this.inpSurName.Location = new System.Drawing.Point(160, 12);
            this.inpSurName.Name = "inpSurName";
            this.inpSurName.Size = new System.Drawing.Size(102, 20);
            this.inpSurName.TabIndex = 7;
            // 
            // inpHeight
            // 
            this.inpHeight.Location = new System.Drawing.Point(89, 95);
            this.inpHeight.Name = "inpHeight";
            this.inpHeight.Size = new System.Drawing.Size(55, 20);
            this.inpHeight.TabIndex = 9;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(12, 98);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(38, 13);
            this.lblHeight.TabIndex = 8;
            this.lblHeight.Text = "Height";
            // 
            // inpWeight
            // 
            this.inpWeight.Location = new System.Drawing.Point(89, 124);
            this.inpWeight.Name = "inpWeight";
            this.inpWeight.Size = new System.Drawing.Size(55, 20);
            this.inpWeight.TabIndex = 11;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(12, 127);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(41, 13);
            this.lblWeight.TabIndex = 10;
            this.lblWeight.Text = "Weight";
            // 
            // DocNewPatientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 210);
            this.Controls.Add(this.inpWeight);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.inpHeight);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.inpSurName);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.inpName);
            this.Controls.Add(this.inpGender);
            this.Controls.Add(this.inpBirth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DocNewPatientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DocNewPatientForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inpName;
        private System.Windows.Forms.ComboBox inpGender;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker inpBirth;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox inpSurName;
        private System.Windows.Forms.TextBox inpHeight;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.TextBox inpWeight;
        private System.Windows.Forms.Label lblWeight;
    }
}