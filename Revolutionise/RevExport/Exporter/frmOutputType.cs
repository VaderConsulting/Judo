using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MappingTool
{
    public partial class frmOutputType : Form
    {
        DataTable _RevolutioniseSourceData;
        List<Judo.Club> _Clubs;
        List<Judo.Belt> _Belts;
        List<Judo.Country> _Countries;
        List<Judo.SubDivision> _SubDivisions;

        public frmOutputType(DataTable RevolutioniseSourceData, List<Judo.Club> Clubs, List<Judo.Belt> EuroJudoBelts, List<Judo.Country> Countries, List<Judo.SubDivision> SubDivisions)
        {
            InitializeComponent();

            _RevolutioniseSourceData = RevolutioniseSourceData;
            _Clubs = Clubs;
            _Belts = EuroJudoBelts;
            _Countries = Countries;
            _SubDivisions = SubDivisions;

        }

        private void btnEuroJudo_Click(object sender, EventArgs e)
        {
            this.Close();

            Properties.Settings.Default.PreviousOutputType = "EuroJudo";
            Properties.Settings.Default.Save();

            frmMapping EuroJudoForm = new frmMapping(frmMapping.MappingMode.Euro_Judo, _RevolutioniseSourceData, _Clubs, _Belts, _Countries, _SubDivisions);

            EuroJudoForm.Show();
        }

        private void btnIJF_Click(object sender, EventArgs e)
        {
            this.Close();

            Properties.Settings.Default.PreviousOutputType = "IJF";
            Properties.Settings.Default.Save();

            frmMapping EuroJudoForm = new frmMapping(frmMapping.MappingMode.IJF, _RevolutioniseSourceData, _Clubs, _Belts, _Countries, _SubDivisions);

            EuroJudoForm.Show();
        }

        private void btnEuroJudoAndIJF_Click(object sender, EventArgs e)
        {
            this.Close();

            Properties.Settings.Default.PreviousOutputType = "EuroJudo and IJF";
            Properties.Settings.Default.Save();

            frmMapping EuroJudoForm = new frmMapping(frmMapping.MappingMode.EuroJudo_And_IJF, _RevolutioniseSourceData, _Clubs, _Belts, _Countries, _SubDivisions);

            EuroJudoForm.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.PreviousOutputType = "Canceled";
            Properties.Settings.Default.Save();

            this.Close();
        }

        private void frmOutputType_Shown(object sender, EventArgs e)
        {
            string LastOutputType = Properties.Settings.Default.PreviousOutputType;

            switch (LastOutputType)
            {
                case "":
                    // None - first run
                    btnCancel.Focus();
                    break;
                case "EuroJudo":
                    btnEuroJudo.Focus();
                    break;
                case "IJF":
                    btnIJF.Focus();
                    break;
                case "EuroJudo and IJF":
                    btnEuroJudoAndIJF.Focus();
                    break;
                case "Canceled":
                    btnCancel.Focus();
                    break;
            }
        }
    }
}
