using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doctor
{
    public partial class DocEditPatientForm : Form
    {
        public DocEditPatientForm()
        {
            InitializeComponent();
        }
        public DocEditPatientForm(string patName)
        {
            InitializeComponent();

            // Autofill fields from server

            // Store initial values
            // Put a * next to any edited values
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            // Save the changed data in the server
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You have unsaved changes. Are you sure you want to close without saving?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                this.Close();
        }
    }
}
