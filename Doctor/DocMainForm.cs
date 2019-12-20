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
    public partial class AstrandDoctorGUI : Form
    {
        public AstrandDoctorGUI()
        {
            InitializeComponent();
            MessageBox.Show("Something went wrong. Please contact your system administrator!\nError code: ERR_NO_DOCNAME");
        }
        public AstrandDoctorGUI(string patName)
        {
            InitializeComponent();
            // TODO
        }

        private void BtnAppExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
