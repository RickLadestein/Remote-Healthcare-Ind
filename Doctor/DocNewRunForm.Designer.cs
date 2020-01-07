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
            this.pgbRunning = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblTestStatus = new System.Windows.Forms.Label();
            this.ccLiveChart = new LiveCharts.WinForms.CartesianChart();
            this.lblClientInfo = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pgbRunning
            // 
            this.pgbRunning.Location = new System.Drawing.Point(13, 86);
            this.pgbRunning.Maximum = 4200;
            this.pgbRunning.Name = "pgbRunning";
            this.pgbRunning.Size = new System.Drawing.Size(744, 13);
            this.pgbRunning.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(299, 68);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start Test";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblTestStatus
            // 
            this.lblTestStatus.AutoSize = true;
            this.lblTestStatus.Location = new System.Drawing.Point(340, 28);
            this.lblTestStatus.Name = "lblTestStatus";
            this.lblTestStatus.Size = new System.Drawing.Size(90, 13);
            this.lblTestStatus.TabIndex = 8;
            this.lblTestStatus.Text = "Test Status Label";
            // 
            // ccLiveChart
            // 
            this.ccLiveChart.Location = new System.Drawing.Point(13, 100);
            this.ccLiveChart.Name = "ccLiveChart";
            this.ccLiveChart.Size = new System.Drawing.Size(744, 440);
            this.ccLiveChart.TabIndex = 9;
            this.ccLiveChart.Text = "Live Chart";
            // 
            // lblClientInfo
            // 
            this.lblClientInfo.AutoSize = true;
            this.lblClientInfo.Location = new System.Drawing.Point(344, 53);
            this.lblClientInfo.Name = "lblClientInfo";
            this.lblClientInfo.Size = new System.Drawing.Size(83, 13);
            this.lblClientInfo.TabIndex = 10;
            this.lblClientInfo.Text = "Client Info Label";
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(459, 12);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(299, 68);
            this.btnFinish.TabIndex = 4;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // DocNewRunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 556);
            this.ControlBox = false;
            this.Controls.Add(this.lblClientInfo);
            this.Controls.Add(this.ccLiveChart);
            this.Controls.Add(this.lblTestStatus);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pgbRunning);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DocNewRunForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Run";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar pgbRunning;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblTestStatus;
        private LiveCharts.WinForms.CartesianChart ccLiveChart;
        private System.Windows.Forms.Label lblClientInfo;
        private System.Windows.Forms.Button btnFinish;
    }
}