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
            this.HeartGuage = new LiveCharts.WinForms.SolidGauge();
            this.SpeedGuage = new LiveCharts.WinForms.SolidGauge();
            this.ResistanceGuage = new LiveCharts.WinForms.SolidGauge();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.ccLiveChart.Location = new System.Drawing.Point(259, 105);
            this.ccLiveChart.Name = "ccLiveChart";
            this.ccLiveChart.Size = new System.Drawing.Size(498, 435);
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
            // HeartGuage
            // 
            this.HeartGuage.Location = new System.Drawing.Point(13, 118);
            this.HeartGuage.Name = "HeartGuage";
            this.HeartGuage.Size = new System.Drawing.Size(200, 100);
            this.HeartGuage.TabIndex = 11;
            this.HeartGuage.Text = "solidGauge1";
            // 
            // SpeedGuage
            // 
            this.SpeedGuage.Location = new System.Drawing.Point(12, 273);
            this.SpeedGuage.Name = "SpeedGuage";
            this.SpeedGuage.Size = new System.Drawing.Size(200, 100);
            this.SpeedGuage.TabIndex = 12;
            this.SpeedGuage.Text = "solidGauge2";
            // 
            // ResistanceGuage
            // 
            this.ResistanceGuage.Location = new System.Drawing.Point(12, 413);
            this.ResistanceGuage.Name = "ResistanceGuage";
            this.ResistanceGuage.Size = new System.Drawing.Size(200, 100);
            this.ResistanceGuage.TabIndex = 13;
            this.ResistanceGuage.Text = "solidGauge3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Heart Rate (BPM)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Speed (Rpm)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 516);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Resistance (m/s)";
            // 
            // DocNewRunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 556);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ResistanceGuage);
            this.Controls.Add(this.SpeedGuage);
            this.Controls.Add(this.HeartGuage);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DocNewRunForm_FormClosing);
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
        private LiveCharts.WinForms.SolidGauge HeartGuage;
        private LiveCharts.WinForms.SolidGauge SpeedGuage;
        private LiveCharts.WinForms.SolidGauge ResistanceGuage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}