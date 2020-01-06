using System;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace Doctor
{
    public partial class AstrandDoctorGUI : Form
    {
        Doctor curDoc;
        Patient curPat;

        public AstrandDoctorGUI()
        {
            this.Visible = false;
            InitializeComponent();

            RunLoginProcedure();

            // TODO
            //curDoc = doctor;
            //this.owner = owner;
            ////curPat = patient;

            //lblUsername.Text = "Username: " + curDoc.username;
        }

        private void BtnAppExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AstrandDoctorGUI_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void lbxPrevTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            chartSelectedRun.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Heartrate",
                    Values = new ChartValues<double> {70, 85, 112, 130, 132, 134, 134, 114}
                },
                new LineSeries
                {
                    Title = "RPM",
                    Values = new ChartValues<int> {40, 60, 65, 57, 63, 64, 59, 57}
                }
            };
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            RunLoginProcedure();
            //this.Close();
        }

        private void btnChangePatient_Click(object sender, EventArgs e)
        {
            using (DocPatientSelect showTest = new DocPatientSelect(curDoc))
            {
                showTest.ShowDialog();

                SetPatient(showTest.GetSelectedPatient());
            }
        }

        private void btnGearUp_Click(object sender, EventArgs e)
        {
            // TODO
        } // TODO

        private void btnGearDown_Click(object sender, EventArgs e)
        {
            // TODO
        } // TODO

        private void btnNewRun_Click(object sender, EventArgs e)
        {
            Form runForm = new DocNewRunForm(curDoc, curPat);
            runForm.ShowDialog();

            // TODO: Add new run to the list

            lbxPrevTests.SelectedIndex = 0;
        }

        private void SetPatient(Patient newPat)
        {
            this.curPat = newPat;

            lblPatName.Text = "Name: " + newPat.first_name + " " + newPat.sur_name;
            lblPatGender.Text = "Gender: " + (newPat.gender ? "Male" : "Female");

            int age = DateTime.Today.Year - newPat.birthday.Year;
            if (newPat.birthday.Date > DateTime.Today.AddYears(-age)) age--;
            
            lblPatBirthday.Text = "Birthday: " + newPat.birthday.Date.ToShortDateString() + " (" + age +")";

            MessageBox.Show("Import runs!");

        }

        private void RunLoginProcedure()
        {
            if (this.Visible)
            {
                this.Visible = false;
                // Clear all while invisible

                curPat = null;
                lblPatBirthday.Text = "Birthday: ";
                lblPatGender.Text = "Gender: ";
                lblPatName.Text = "Name: ";
                lbxPrevTests.Items.Clear();
                chartSelectedRun.Series.Clear();

            }
            //Get new data
            Doctor newDoc;

            using (DocLoginForm login = new DocLoginForm())
            {
                login.ShowDialog();

                newDoc = login.GetDoctor();
            }

            this.curDoc = newDoc;
            lblUsername.Text = newDoc.username;
            this.Visible = true;
        }

        private void chartSelectedRun_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
