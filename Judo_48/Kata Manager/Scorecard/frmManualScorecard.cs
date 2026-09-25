using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KataManager
{
    public partial class frmManualScorecard : Form
    {
        public frmManualScorecard()
        {
            InitializeComponent();

            web.EnsureCoreWebView2Async(null);
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            Task<string> task = web.CoreWebView2.ExecuteScriptAsync("window.print();");
        }

        private void cmbKata_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPrint.Enabled = cmbKata.SelectedItem != null;

            if (cmbKata.SelectedItem != null)
            {
                string Filename = "";
                string AppFolder = Path.GetDirectoryName(Application.ExecutablePath);
                string KataName = (string)(cmbKata.SelectedItem);

                switch (KataName)
                {
                    case "Nage No Kata (1 set)":
                        Filename = "Nage1.html";
                        break;
                    case "Nage No Kata (2 sets)":
                        Filename = "Nage2.html";
                        break;
                    case "Nage No Kata (3 sets)":
                        Filename = "Nage3.html";
                        break;
                    case "Nage No Kata":
                        Filename = "Nage.html";
                        break;
                    case "Katame No Kata (1 set)":
                        Filename = "Katame1.html";
                        break;
                    case "Katame No Kata (2 sets)":
                        Filename = "Katame2.html";
                        break;
                    case "Katame No Kata":
                        Filename = "Katame.html";
                        break;
                    case "Kime No Kata":
                        Filename = "Kime.html";
                        break;
                    case "Ju No Kata":
                        Filename = "Ju.html";
                        break;
                    case "Goshin Jutsu":
                        Filename = "Goshin.html";
                        break;
                    case "Koshiki No Kata":
                        Filename = "Koshiki.html";
                        break;
                }

                if (Filename.Length > 0)
                {
                    string FullFilename = Path.Combine(AppFolder, Filename);

                    if (File.Exists(FullFilename))
                    {
                        string AllText = System.IO.File.ReadAllText(FullFilename);

                        AllText = AllText.Replace("##TOURNAMENTNAME##", "&nbsp;");
                        AllText = AllText.Replace("##TOURNAMENTDETAILS##", "&nbsp;");
                        AllText = AllText.Replace("##JUDGENAME##", "&nbsp;");
                        AllText = AllText.Replace("##JUDGEAFFILIATION##", "&nbsp;");
                        AllText = AllText.Replace("##PAIRAFFILIATIONTYPE##", "&nbsp;");
                        AllText = AllText.Replace("##PAIRNAMES##", "&nbsp;");
                        AllText = AllText.Replace("##PAIRAFFILIATION##", "&nbsp;");

                        string OutputPath = Path.Combine(AppFolder, KataName);

                        try
                        {
                            web.NavigateToString(AllText);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Printing error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
