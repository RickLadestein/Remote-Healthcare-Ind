namespace Doctor
{
    partial class DocNewRunForm
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
            this.btnFinish = new System.Windows.Forms.Button();
            this.pgbWarmup = new System.Windows.Forms.ProgressBar();
            this.pgbRunning = new System.Windows.Forms.ProgressBar();
            this.pgbCooldown = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblWarmup = new System.Windows.Forms.Label();
            this.lblRunning = new System.Windows.Forms.Label();
            this.lblCooldown = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(229, 165);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 0;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // pgbWarmup
            // 
            this.pgbWarmup.Location = new System.Drawing.Point(91, 76);
            this.pgbWarmup.Maximum = 1200;
            this.pgbWarmup.Name = "pgbWarmup";
            this.pgbWarmup.Size = new System.Drawing.Size(213, 23);
            this.pgbWarmup.TabIndex = 1;
            // 
            // pgbRunning
            // 
            this.pgbRunning.Location = new System.Drawing.Point(91, 106);
            this.pgbRunning.Maximum = 2400;
            this.pgbRunning.Name = "pgbRunning";
            this.pgbRunning.Size = new System.Drawing.Size(213, 23);
            this.pgbRunning.TabIndex = 2;
            // 
            // pgbCooldown
            // 
            this.pgbCooldown.Location = new System.Drawing.Point(91, 136);
            this.pgbCooldown.Maximum = 600;
            this.pgbCooldown.Name = "pgbCooldown";
            this.pgbCooldown.Size = new System.Drawing.Size(213, 23);
            this.pgbCooldown.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(291, 57);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start Test";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblWarmup
            // 
            this.lblWarmup.AutoSize = true;
            this.lblWarmup.BackColor = System.Drawing.Color.Transparent;
            this.lblWarmup.Location = new System.Drawing.Point(12, 80);
            this.lblWarmup.Name = "lblWarmup";
            this.lblWarmup.Size = new System.Drawing.Size(66, 13);
            this.lblWarmup.TabIndex = 5;
            this.lblWarmup.Text = "Warming Up";
            // 
            // lblRunning
            // 
            this.lblRunning.AutoSize = true;
            this.lblRunning.BackColor = System.Drawing.Color.Transparent;
            this.lblRunning.Location = new System.Drawing.Point(12, 110);
            this.lblRunning.Name = "lblRunning";
            this.lblRunning.Size = new System.Drawing.Size(56, 13);
            this.lblRunning.TabIndex = 6;
            this.lblRunning.Text = "Measuring";
            // 
            // lblCooldown
            // 
            this.lblCooldown.AutoSize = true;
            this.lblCooldown.BackColor = System.Drawing.Color.Transparent;
            this.lblCooldown.Location = new System.Drawing.Point(12, 140);
            this.lblCooldown.Name = "lblCooldown";
            this.lblCooldown.Size = new System.Drawing.Size(73, 13);
            this.lblCooldown.TabIndex = 7;
            this.lblCooldown.Text = "Cooling Down";
            // 
            // DocNewRunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 200);
            this.ControlBox = false;
            this.Controls.Add(this.lblCooldown);
            this.Controls.Add(this.lblRunning);
            this.Controls.Add(this.lblWarmup);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pgbCooldown);
            this.Controls.Add(this.pgbRunning);
            this.Controls.Add(this.pgbWarmup);
            this.Controls.Add(this.btnFinish);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DocNewRunForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DocNewRun";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.ProgressBar pgbWarmup;
        private System.Windows.Forms.ProgressBar pgbRunning;
        private System.Windows.Forms.ProgressBar pgbCooldown;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblWarmup;
        private System.Windows.Forms.Label lblRunning;
        private System.Windows.Forms.Label lblCooldown;
    }
}