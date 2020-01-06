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
    public partial class DocNewRunForm : Form
    {
        Doctor curDoc;
        Patient curPat;

        public DocNewRunForm(Doctor doc, Patient pat)
        {
            InitializeComponent();

            curDoc = doc;
            curPat = pat;
                
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Visible = false;
            
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
