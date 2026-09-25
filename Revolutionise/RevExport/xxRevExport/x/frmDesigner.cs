using Classes;
using CsvHelper;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Designer
{
    public partial class frmDesigner : Form
    {
        public frmDesigner()
        {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            string[] SplitCharacters = new string[] { cmbSplitCharacters.Text };
            DataTable table = null;

            table = Utilities.Data.ReadCSV(txtImportFilename.Text, SplitCharacters, chkImportHasHeaders.Checked);

            DataGridView.DataSource = table;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            // csv
            List<Person> records = new List<Person>();
            //{
            //    new Person { Id = 1, Name = "one" },
            //};

            using (StreamWriter writer = new StreamWriter(txtIJFExportFilename.Text))  // .csv
            {
                using (CsvWriter csv = new CsvWriter(writer))
                {
                    csv.WriteRecords(records);
                }
            }

            // Excel
            string newFile = txtEuroJudoExportFilename.Text; // xls

            using (FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write))
            {

                IWorkbook workbook = new HSSFWorkbook();

                ISheet sheet1 = workbook.CreateSheet("Sheet1");

                sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 10));
                int rowIndex = 0;
                IRow row = sheet1.CreateRow(rowIndex);
                row.Height = 30 * 80;
                row.CreateCell(0).SetCellValue("this is content");
                sheet1.AutoSizeColumn(0);
                rowIndex++;

                ISheet sheet2 = workbook.CreateSheet("Sheet2");
                ICellStyle style1 = workbook.CreateCellStyle();
                style1.FillForegroundColor = HSSFColor.Blue.Index2;
                style1.FillPattern = FillPattern.SolidForeground;

                ICellStyle style2 = workbook.CreateCellStyle();
                style2.FillForegroundColor = HSSFColor.Yellow.Index2;
                style2.FillPattern = FillPattern.SolidForeground;

                ICell cell2 = sheet2.CreateRow(0).CreateCell(0);
                cell2.CellStyle = style1;
                cell2.SetCellValue(0);

                cell2 = sheet2.CreateRow(1).CreateCell(0);
                cell2.CellStyle = style2;
                cell2.SetCellValue(1);

                workbook.Write(fs);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbSplitCharacters.SelectedIndex = 0;


        }
    }
}
