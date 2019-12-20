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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.inpBirth = new System.Windows.Forms.DateTimePicker();
            this.inpGender = new System.Windows.Forms.ComboBox();
            this.inpName = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
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
            // inpName
            // 
            this.inpName.Location = new System.Drawing.Point(89, 12);
            this.inpName.Name = "inpName";
            this.inpName.Size = new System.Drawing.Size(173, 20);
            this.inpName.TabIndex = 5;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 101);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(250, 23);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create New Patient";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // DocNewPatientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 136);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker inpBirth;
        private System.Windows.Forms.ComboBox inpGender;
        private System.Windows.Forms.TextBox inpName;
        private System.Windows.Forms.Button btnCreate;
    }
}