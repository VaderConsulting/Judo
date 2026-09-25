using Judo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
using static Utilities.Extensions;

namespace MappingTool
{
    public partial class frmDataInfo : Form
    {
        private List<DataRow> _Rows = null;

        private List<string> _Columns = null;

        public List<string> Columns
        {
            get
            {
                return _Columns;
            }

            set
            {
                _Columns = value;
            }
        }

        public List<DataRow> Rows
        {
            get
            {
                return _Rows;
            }

            set
            {
                _Rows = value;
                int Counter = 0;
                int ColumnResizeType = -1; // Auto-width to values

                lvwPeople.BeginUpdate();

                lvwPeople.Clear();

                if (_Columns != null && _Columns.Count > 0)
                {
                    foreach (string Value in _Columns)
                    {
                        lvwPeople.Columns.Add(Value);
                    }
                }
                else
                {
                    foreach (string Value in _Rows[0].ItemArray)
                    {
                        Counter++;
                        lvwPeople.Columns.Add("Column " + Counter);
                    }
                }

                if (_Rows != null && _Rows.Count > 0)
                {
                    foreach (DataRow Row in _Rows)
                    {
                        ListViewItem NewItem = new ListViewItem();

                        int ColumnIndex = 0;
                        foreach (string Value in Row.ItemArray)
                        {
                            if (ColumnIndex == 0)
                            {
                                NewItem.Text = Value;
                            }
                            else
                            {
                                NewItem.SubItems.Add(Value);
                            }

                            ColumnIndex++;
                        }

                        lvwPeople.Items.Add(NewItem);
                    }
                }
                else
                {
                    ColumnResizeType = -2; // Auto-width to column names
                }

                for (int ColumnIndex = 0; ColumnIndex < lvwPeople.Columns.Count; ColumnIndex++)
                {
                    lvwPeople.Columns[ColumnIndex].Width = ColumnResizeType; 
                }

                lvwPeople.EndUpdate();
            }
        }

        public frmDataInfo()
        {
            InitializeComponent();
        }

        private void frmDataInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
