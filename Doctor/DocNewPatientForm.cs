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
    public partial class DocNewPatientForm : Form
    {
        public DocNewPatientForm()
        {
            InitializeComponent();

            // Check for unfilled fields (inc. date)
            // Check for values that seem off (short name, very young/old age)
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WIP");
        }
    }
}
