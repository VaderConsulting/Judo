using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Designer
{
    public partial class frmImport : Form
    {
        public string ImportFilename = "";

        public frmImport(string LastFilename)
        {
            InitializeComponent();

            txtFilename.Text = LastFilename;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            ImportFilename = txtFilename.Text;

            this.DialogResult = DialogResult.OK;
        }
    }
}
