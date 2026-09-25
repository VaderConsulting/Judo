using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KataManager
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            frmManualScorecard ManualScorecardForm = new frmManualScorecard();

            ManualScorecardForm.Show();
        }

        private void btnElectronic_Click(object sender, EventArgs e)
        {
            frmElectronicScoring ElectronicScorecardForm = new frmElectronicScoring();

            ElectronicScorecardForm.Show();
        }
    }
}
