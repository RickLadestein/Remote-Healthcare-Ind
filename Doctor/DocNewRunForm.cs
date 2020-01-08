using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Doctor.Network;
using Doctor.Profiles;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Timers;

namespace Doctor
{
    public partial class DocNewRunForm : Form, ConnectionResponseListener
    {
        private Doctor curDoc;
        private Patient curPat;
        private Socket socket;
        private bool ready = false;
        private System.Timers.Timer timer;

        public DocNewRunForm(Doctor doc, Patient pat, Socket soc)
        {
            InitializeComponent();
            lblTestStatus.Visible = false;
            lblClientInfo.Visible = false;
            btnFinish.Visible = false;

            ccLiveChart.LegendLocation = LiveCharts.LegendLocation.Left;

            curDoc = doc;
            curPat = pat;
            this.socket = soc;

            DataRouter.GetInstance().SendMessage(this.socket,
                Datapackages.Message_Message(this.curDoc.id.ToString(), this.curPat.id.ToString(), "FIRST MESSAGE"),
                "user/msg", this, false);

            this.SpeedGuage.To = 200;
            this.HeartGuage.To = 200;
            this.ResistanceGuage.To = 200;

            this.SpeedGuage.FromColor = System.Windows.Media.Color.FromRgb(0, 0, 0b11111111);
            this.HeartGuage.FromColor = System.Windows.Media.Color.FromRgb(0, 0, 0b11111111);
            this.ResistanceGuage.FromColor = System.Windows.Media.Color.FromRgb(0, 0, 0b11111111);

            this.SpeedGuage.ToColor = System.Windows.Media.Color.FromRgb(0b11111111, 0, 0);
            this.HeartGuage.ToColor = System.Windows.Media.Color.FromRgb(0b11111111, 0, 0);
            this.ResistanceGuage.ToColor = System.Windows.Media.Color.FromRgb(0b11111111, 0, 0);


            timer = new System.Timers.Timer(1000);
            DataRouter.GetInstance().setGenericMessageListener(this);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Visible = false;
            lblClientInfo.Show();
            lblTestStatus.Show();

        }

        private void StartTest()
        {
            DataRouter.GetInstance().SendMessage(socket, Datapackages.Message_Message(curDoc.id.ToString(), curPat.id.ToString(), "START"), "user/msg", this, false);
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
            ));
            ready = true;
            SetTestStatus("Running test...");
        }

        private void AddMeasurementToChart(BikeMeasurement m)
        {
            if (ready)
            {
                this.ccLiveChart.Series[0].Values.Add((double)m.Bpm);
                this.ccLiveChart.Series[1].Values.Add((double)m.Rpm);
                this.ccLiveChart.Series[2].Values.Add((double)m.Resistance);

                this.ResistanceGuage.Value = m.Resistance;
                this.HeartGuage.Value = m.Bpm;
                this.SpeedGuage.Value = m.Rpm;
            }
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
            this.Close();
        }

        public void onMessageResponse(string command, dynamic data)
        {
            throw new NotImplementedException();
        }

        public void onMessageResponseError(string command, string info)
        {
            BeginInvoke((Action)(() => MessageBox.Show("Stopping test: " + info)));
            BeginInvoke((Action)(() => this.Close()));
        }

        public void onGenericMessageReceived(string command, dynamic data)
        {
            dynamic message = data.data.data;
            JObject obj = JObject.FromObject(message.measurement);
            BikeMeasurement measurement = obj.ToObject<BikeMeasurement>();
            BeginInvoke((Action)(() => AddMeasurementToChart(measurement)));
        }

        private void DocNewRunForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataRouter.GetInstance().setGenericMessageListener(null);
        }
    }
}
