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
            this.label1 = new System.Windows.Forms.Label();
            this.inpHeight = new System.Windows.Forms.TextBox();
            this.inpWeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inpSurName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(136, 147);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(124, 23);
            this.btnApply.TabIndex = 13;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // inpName
            // 
            this.inpName.Location = new System.Drawing.Point(87, 12);
            this.inpName.Name = "inpName";
            this.inpName.Size = new System.Drawing.Size(61, 20);
            this.inpName.TabIndex = 12;
            // 
            // inpGender
            // 
            this.inpGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inpGender.FormattingEnabled = true;
            this.inpGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.inpGender.Location = new System.Drawing.Point(87, 38);
            this.inpGender.Name = "inpGender";
            this.inpGender.Size = new System.Drawing.Size(121, 21);
            this.inpGender.TabIndex = 11;
            // 
            // inpBirth
            // 
            this.inpBirth.Location = new System.Drawing.Point(87, 65);
            this.inpBirth.Name = "inpBirth";
            this.inpBirth.Size = new System.Drawing.Size(173, 20);
            this.inpBirth.TabIndex = 10;
            this.inpBirth.ValueChanged += new System.EventHandler(this.inpBirth_ValueChanged);
            // 
            // lblBirth
            // 
            this.lblBirth.AutoSize = true;
            this.lblBirth.Location = new System.Drawing.Point(10, 69);
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Size = new System.Drawing.Size(66, 13);
            this.lblBirth.TabIndex = 9;
            this.lblBirth.Text = "Date of Birth";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(10, 41);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(42, 13);
            this.lblGender.TabIndex = 8;
            this.lblGender.Text = "Gender";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(10, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(8, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Height";
            // 
            // inpHeight
            // 
            this.inpHeight.Location = new System.Drawing.Point(87, 91);
            this.inpHeight.Name = "inpHeight";
            this.inpHeight.Size = new System.Drawing.Size(121, 20);
            this.inpHeight.TabIndex = 16;
            this.inpHeight.TextChanged += new System.EventHandler(this.inpHeight_TextChanged);
            // 
            // inpWeight
            // 
            this.inpWeight.Location = new System.Drawing.Point(87, 119);
            this.inpWeight.Name = "inpWeight";
            this.inpWeight.Size = new System.Drawing.Size(121, 20);
            this.inpWeight.TabIndex = 18;
            this.inpWeight.TextChanged += new System.EventHandler(this.inpWeight_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Weight";
            // 
            // inpSurName
            // 
            this.inpSurName.Location = new System.Drawing.Point(163, 12);
            this.inpSurName.Name = "inpSurName";
            this.inpSurName.Size = new System.Drawing.Size(97, 20);
            this.inpSurName.TabIndex = 19;
            // 
            // DocEditPatientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 183);
            this.Controls.Add(this.inpSurName);
            this.Controls.Add(this.inpWeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inpHeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.inpName);
            this.Controls.Add(this.inpGender);
            this.Controls.Add(this.inpBirth);
            this.Controls.Add(this.lblBirth);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblName);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inpHeight;
        private System.Windows.Forms.TextBox inpWeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inpSurName;
    }
}