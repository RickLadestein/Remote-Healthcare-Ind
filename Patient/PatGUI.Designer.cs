namespace Patient
{
    partial class PatGUI
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
            this.DummyButton = new System.Windows.Forms.Button();
            this.sgRpm = new LiveCharts.WinForms.SolidGauge();
            this.sgHeartRate = new LiveCharts.WinForms.SolidGauge();
            this.sgPower = new LiveCharts.WinForms.SolidGauge();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.lblCounter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DummyButton
            // 
            this.DummyButton.Location = new System.Drawing.Point(733, 79);
            this.DummyButton.Margin = new System.Windows.Forms.Padding(2);
            this.DummyButton.Name = "DummyButton";
            this.DummyButton.Size = new System.Drawing.Size(128, 19);
            this.DummyButton.TabIndex = 0;
            this.DummyButton.Text = "Send Data";
            this.DummyButton.UseVisualStyleBackColor = true;
            this.DummyButton.Click += new System.EventHandler(this.DummyButton_Click);
            // 
            // sgRpm
            // 
            this.sgRpm.Location = new System.Drawing.Point(32, 279);
            this.sgRpm.Name = "sgRpm";
            this.sgRpm.Size = new System.Drawing.Size(252, 170);
            this.sgRpm.TabIndex = 1;
            this.sgRpm.Text = "RPM";
            // 
            // sgHeartRate
            // 
            this.sgHeartRate.Location = new System.Drawing.Point(326, 279);
            this.sgHeartRate.Name = "sgHeartRate";
            this.sgHeartRate.Size = new System.Drawing.Size(252, 170);
            this.sgHeartRate.TabIndex = 3;
            this.sgHeartRate.Text = "solidGauge2";
            // 
            // sgPower
            // 
            this.sgPower.Location = new System.Drawing.Point(620, 279);
            this.sgPower.Name = "sgPower";
            this.sgPower.Size = new System.Drawing.Size(252, 170);
            this.sgPower.TabIndex = 3;
            this.sgPower.Text = "solidGauge2";
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.Location = new System.Drawing.Point(385, 153);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(134, 29);
            this.lblInstruction.TabIndex = 4;
            this.lblInstruction.Text = "Instructions";
            this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pgbProgress
            // 
            this.pgbProgress.Location = new System.Drawing.Point(12, 12);
            this.pgbProgress.Maximum = 4200;
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(880, 23);
            this.pgbProgress.TabIndex = 5;
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounter.Location = new System.Drawing.Point(407, 38);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(90, 20);
            this.lblCounter.TabIndex = 6;
            this.lblCounter.Text = "Countdown";
            // 
            // PatGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 461);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.pgbProgress);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.sgPower);
            this.Controls.Add(this.sgHeartRate);
            this.Controls.Add(this.sgRpm);
            this.Controls.Add(this.DummyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "PatGUI";
            this.Text = "Avans-Astrand Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DummyButton;
        private LiveCharts.WinForms.SolidGauge sgRpm;
        private LiveCharts.WinForms.SolidGauge sgHeartRate;
        private LiveCharts.WinForms.SolidGauge sgPower;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.ProgressBar pgbProgress;
        private System.Windows.Forms.Label lblCounter;
    }
}

