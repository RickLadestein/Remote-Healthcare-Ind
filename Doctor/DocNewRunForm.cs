﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace Doctor
{
    public partial class DocNewRunForm : Form
    {
        Doctor curDoc;
        Patient curPat;
        System.Timers.Timer progTimer;

        public DocNewRunForm(Doctor doc, Patient pat)
        {
            InitializeComponent();
            lblTestStatus.Visible = false;
            lblClientInfo.Visible = false;
            btnFinish.Visible = false;

            ccLiveChart.LegendLocation = LiveCharts.LegendLocation.Left;

            curDoc = doc;
            curPat = pat;

            progTimer = new System.Timers.Timer(100);
            progTimer.AutoReset = true;
            progTimer.Elapsed += new ElapsedEventHandler(OnTimerTick);

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Visible = false;
            lblClientInfo.Show();
            lblTestStatus.Show();

            MessageBox.Show("Start test!");

            new Thread(new ThreadStart(StartTest)).Start();
        }

        private void StartTest()
        {
            this.BeginInvoke((Action)(() =>
                ccLiveChart.Series = new LiveCharts.SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Heartrate",
                        Values = new ChartValues<double>{ }
                    },
                    new LineSeries
                    {
                        Title = "RPM",
                        Values = new ChartValues<double>{ }
                    },
                    new LineSeries
                    {
                        Title = "Power",
                        Values = new ChartValues<double>{ }
                    }
                }
            )) ;

            SetTestStatus("Running test...");
            progTimer.Start();
        }
        private void OnTimerTick(object sender, ElapsedEventArgs e)
        {
            if (!IncrementTimer())
            {
                progTimer.Stop();
                SetTestStatus("Test completed.");
                this.BeginInvoke((Action)(() => btnFinish.Visible = true));
            }
        }

        private bool IncrementTimer() 
        {
            if (pgbRunning.Value < pgbRunning.Maximum)
                this.BeginInvoke((Action)(() => pgbRunning.Increment(1)));
            else
                return false;

            if(pgbRunning.Value % 10 == 0 )
            {
                ccLiveChart.Series[0].Values.Add((double)(pgbRunning.Value + 25));
                ccLiveChart.Series[1].Values.Add((double)(pgbRunning.Value + 55));
                ccLiveChart.Series[2].Values.Add((double)(pgbRunning.Value + 95));
            }

            return true;

        }

        private void SetTestStatus(string status)
        {
            this.BeginInvoke((Action)(() => lblTestStatus.Text = status));
            this.BeginInvoke((Action)(() => lblTestStatus.Location = new System.Drawing.Point( (this.Size.Width - lblTestStatus.Size.Width) / 2 , lblTestStatus.Location.Y)));
        }
        private void SetClientInfo(string info)
        {
            this.BeginInvoke((Action)(() => lblClientInfo.Text = info));
            this.BeginInvoke((Action)(() => lblClientInfo.Location = new System.Drawing.Point((this.Size.Width - lblClientInfo.Size.Width) / 2, lblClientInfo.Location.Y)));
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            progTimer.Stop();
            this.Close();
        }
    }
}