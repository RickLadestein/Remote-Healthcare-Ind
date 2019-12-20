using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doctor
{
    public partial class DocPatientSelect : Form
    {
        public DocPatientSelect()
        {
            InitializeComponent();
            MessageBox.Show("Something went wrong. Please contact your system administrator!\nError code: ERR_NO_DOCNAME");
        }
        public DocPatientSelect(string docname)
        {
            InitializeComponent();
            btnSelectPatient.Enabled = false;
            btnEditPatient.Enabled = false;
        }

        private void BtnNewPatient_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WIP");
            Form np = new DocNewPatientForm();
            np.ShowDialog();
        }

        private void BtnEditPatient_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WIP");
            Form ep = new DocEditPatientForm("");
            ep.ShowDialog();
            MessageBox.Show("Update Patient!");
            // TODO: Update Patient
        }

        private void CbxPatientSelect_TextChanged(object sender, EventArgs e)
        {
            // Does not trigger correctly, using SelectedIndexChanged(...) instead
        }

        private void BtnSelectPatient_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cbxPatientSelect.SelectedIndex.ToString() + "\n" + cbxPatientSelect.SelectedItem.ToString());

            if (cbxPatientSelect.SelectedIndex >= 0)
            {
                Form dm = new AstrandDoctorGUI(cbxPatientSelect.SelectedItem.ToString());
                dm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a patient");
            }
        }

        private void cbxPatientSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("TODO: Update properties!");
            lblDetailsName.Text = "Name: " + cbxPatientSelect.SelectedItem.ToString();
            lblDetailsGender.Text = "Gender: Implement Server Connection!";
            lblDetailsDate.Text = "Date of Birth: Implement Server Connection!";
            
            btnSelectPatient.Enabled = true;
            btnEditPatient.Enabled = true;
        }
    }
}
