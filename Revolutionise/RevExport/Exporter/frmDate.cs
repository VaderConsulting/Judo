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
    public partial class frmDate : Form
    {
        private string _Input = "";
        public string Output = "";
        public bool Save = false;

        public frmDate(string Input)
        {
            InitializeComponent();

            _Input = Input;
            txtInputValue.Text = _Input;

            if (Input.Trim().Length == 0)
            {
                _Input = DateTime.MinValue.ToShortDateString();
            }

            string ComparisonValue = _Input.Replace(".", "").Replace("/", "").Replace(",", "").Replace("-", "").Replace(" ", "").Trim();

            switch (ComparisonValue.Length)
            {
                case 1:
                case 2:
                case 3:
                case 5:
                    // Have no idea what to do with these values
                    break;
                case 4:
                    mskDate.Text = "01/01/" + ComparisonValue;
                    break;
                case 6:
                    int Year = Convert.ToInt32(ComparisonValue.Substring(4, 2));

                    if (2000 + Year < DateTime.Now.Year)
                    {
                        mskDate.Text = ComparisonValue.Substring(0, 2) + "/" + ComparisonValue.Substring(2, 2) + "/20" + ComparisonValue.Substring(4, 2);
                    }
                    else
                    {
                        mskDate.Text = ComparisonValue.Substring(0, 2) + "/" + ComparisonValue.Substring(2, 2) + "/19" + ComparisonValue.Substring(4, 2);
                    }
                    break;
                case 7:
                    // Have no idea what to do with these values
                    break;
                case 8:
                    mskDate.Text = ComparisonValue.Substring(0, 2) + "/" + ComparisonValue.Substring(2, 2) + "/" + ComparisonValue.Substring(4, 4);
                    mskDate.Focus();
                    mskDate.SelectAll();
                    break;
                default:
                    break;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Output = mskDate.Text;
            Save = chkSave.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            Output = "";
            Save = false;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
