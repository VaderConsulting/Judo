using EuroJudo;
using Judo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace MappingTool
{
    public partial class frmShowMapping : Form
    {
        #region Constants

        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Enums

        #endregion

        #region DLL Imports

        #endregion

        #region Fields

        private List<ComparisonResult> _ComparisonResults = null;
        private ComparisonResult _SelectedComparisonResult = null;
        public string ComparisonValue = "";
        public int ComparisonValueIndex = -1;
        public Judo.DataColumnType MappingType = DataColumnType.Unknown;

        #endregion

        #region Properties

        public ComparisonResult SelectedComparisonResult
        {
            get
            {
                return _SelectedComparisonResult;
            }
            set
            {
                _SelectedComparisonResult = value;
            }
        }

        //public StringToObjectMapping<EuroJudoEvent> SelectedEventMapping
        //{
        //    get
        //    {
        //        return _SelectedEventMapping;
        //    }
        //    set
        //    {
        //        _SelectedEventMapping = value;
        //    }
        //}

        //public StringToObjectMapping<EuroJudoWeightCategory> SelectedWeightMapping
        //{
        //    get
        //    {
        //        return _SelectedWeightMapping;
        //    }
        //    set
        //    {
        //        _SelectedWeightMapping = value;
        //    }
        //}

        //public StringToObjectMapping<EuroJudoClub> SelectedClubMapping
        //{
        //    get
        //    {
        //        return _SelectedClubMapping;
        //    }
        //    set
        //    {
        //        _SelectedClubMapping = value;
        //    }
        //}

        //public List<StringToObjectMapping<EuroJudoEvent>> EventMapping
        //{
        //    get
        //    {
        //        return _EventMapping;
        //    }
        //    set
        //    {
        //        _EventMapping = value;
        //    }
        //}

        //public List<StringToObjectMapping<EuroJudoWeightCategory>> WeightMapping
        //{
        //    get
        //    {
        //        return _WeightMapping;
        //    }
        //    set
        //    {
        //        _WeightMapping = value;
        //    }
        //}

        //public List<StringToObjectMapping<EuroJudoClub>> ClubMapping
        //{
        //    get
        //    {
        //        return _ClubMapping;
        //    }
        //    set
        //    {
        //        _ClubMapping = value;
        //    }
        //}

        //public EuroJudoMappingType MapType
        //{
        //    get
        //    {
        //        return _MapType;
        //    }
        //    set
        //    {
        //        _MapType = value;
        //    }
        //}

        #endregion

        #region Constructors and Destructor

        public frmShowMapping()
        {
            InitializeComponent();
        }

        public frmShowMapping(List<ComparisonResult> ComparisonResults)
        {
            InitializeComponent();

            if (ComparisonResults != null && ComparisonResults[0].SourceValue != null)
            {
                ComparisonValue = ComparisonResults[0].SourceValue.ToString();
                ComparisonValueIndex = ComparisonResults[0].ValueIndex;
                MappingType = ComparisonResults[0].MapType;

                _ComparisonResults = ComparisonResults;

                lblValue.Text = ComparisonValue;

                foreach (ComparisonResult Result in ComparisonResults)
                {
                    ListViewItem NewItem = new ListViewItem();

                    switch (Result.MapType)
                    {
                        case DataColumnType.EuroJudo_Event:
                            {

                                Event MapObject = (Event)Result.Value;

                                if (MapObject != null)
                                {
                                    NewItem.Text = MapObject.Name;
                                }
                                else
                                {
                                    NewItem.Text = "[NONE]";
                                }

                                if (Result.Manual)
                                {
                                    NewItem.SubItems.Add("Manual (" + Math.Round(Result.Percentage, 0).ToString() + ")");
                                }
                                else
                                {
                                    NewItem.SubItems.Add(Math.Round(Result.Percentage, 0).ToString());
                                }

                                if (Result.Percentage == 100)
                                {
                                    NewItem.BackColor = Color.GreenYellow;
                                }
                                break;
                            }
                        case DataColumnType.EuroJudo_WeightCategory:
                            {
                                EuroJudo.WeightCategory MapObject = (EuroJudo.WeightCategory)Result.Value;

                                if (((EuroJudo.WeightCategory)MapObject).Event == null)
                                {
                                    NewItem.Text = MapObject.Name;
                                }
                                else
                                {
                                    string MapObjectEventName = ((EuroJudo.WeightCategory)MapObject).Event.Name;
                                    string MapObjectName = ((EuroJudo.WeightCategory)MapObject).ToString();

                                    NewItem.Text = MapObject.ToString();
                                }

                                if (Result.Manual)
                                {
                                    NewItem.SubItems.Add("Manual (" + Math.Round(Result.Percentage, 0).ToString() + ")");
                                }
                                else
                                {
                                    NewItem.SubItems.Add(Math.Round(Result.Percentage, 0).ToString());
                                }

                                if (Result.Percentage == 100)
                                {
                                    NewItem.BackColor = Color.GreenYellow;
                                }
                                break;
                            }
                        case DataColumnType.IJF_WeightCategory:
                            {
                                Judo.WeightCategory MapObject = (Judo.WeightCategory)Result.Value;

                                //string MapObjectEventName = ((Judo.WeightCategory)MapObject).Event.Name;
                                string MapObjectName = ((Judo.WeightCategory)MapObject).ToString();

                                NewItem.Text = MapObject.ToString();

                                if (Result.Manual)
                                {
                                    NewItem.SubItems.Add("Manual (" + Math.Round(Result.Percentage, 0).ToString() + ")");
                                }
                                else
                                {
                                    NewItem.SubItems.Add(Math.Round(Result.Percentage, 0).ToString());
                                }

                                if (Result.Percentage == 100)
                                {
                                    NewItem.BackColor = Color.GreenYellow;
                                }
                                break;
                            }
                        case DataColumnType.Club:
                            {
                                Club MapObject = (Club)Result.Value;

                                if (MapObject != null)
                                {
                                    NewItem.Text = MapObject.ToString();
                                }
                                else
                                {
                                    NewItem.Text = "[NONE]";
                                }

                                if (Result.Manual)
                                {
                                    NewItem.SubItems.Add("Manual (" + Math.Round(Result.Percentage, 0).ToString() + ")");
                                }
                                else
                                {
                                    NewItem.SubItems.Add(Math.Round(Result.Percentage, 0).ToString());
                                }

                                if (Result.Percentage == 100)
                                {
                                    NewItem.BackColor = Color.GreenYellow;
                                }
                                break;
                            }
                        case DataColumnType.MemberID:
                            {
                                string MapObject = (string)Result.Value;
                                NewItem.Text = MapObject;

                                if (Result.Manual)
                                {
                                    NewItem.SubItems.Add("Manual (" + Math.Round(Result.Percentage, 0).ToString() + ")");
                                }
                                else
                                {
                                    NewItem.SubItems.Add(Math.Round(Result.Percentage, 0).ToString());
                                }

                                if (Result.Percentage == 100)
                                {
                                    NewItem.BackColor = Color.GreenYellow;
                                }
                                break;
                            }
                        case DataColumnType.DateOfBirth:
                            {
                                DateTime MapObject = (DateTime)Result.Value;
                                NewItem.Text = ((DateTime)MapObject).ToShortDateString();

                                if (Result.Manual)
                                {
                                    NewItem.SubItems.Add("Manual (" + Math.Round(Result.Percentage, 0).ToString() + ")");
                                }
                                else
                                {
                                    NewItem.SubItems.Add(Math.Round(Result.Percentage, 0).ToString());
                                }

                                if (Result.Percentage == 100)
                                {
                                    NewItem.BackColor = Color.GreenYellow;
                                }
                                break;
                            }
                        case DataColumnType.Gender:
                            {
                                Judo.Gender MapObject = (Judo.Gender)Result.Value;
                                NewItem.Text = MapObject.ToString();

                                if (Result.Manual)
                                {
                                    NewItem.SubItems.Add("Manual (" + Math.Round(Result.Percentage, 0).ToString() + ")");
                                }
                                else
                                {
                                    NewItem.SubItems.Add(Math.Round(Result.Percentage, 0).ToString());
                                }

                                if (Result.Percentage == 100)
                                {
                                    NewItem.BackColor = Color.GreenYellow;
                                }
                                break;
                            }
                        case DataColumnType.EuroJudo_Belt:
                            {
                                Belt MapObject = (Belt)Result.Value;
                                NewItem.Text = MapObject.ToString();

                                if (Result.Manual)
                                {
                                    NewItem.SubItems.Add("Manual (" + Math.Round(Result.Percentage, 0).ToString() + ")");
                                }
                                else
                                {
                                    NewItem.SubItems.Add(Math.Round(Result.Percentage, 0).ToString());
                                }

                                if (Result.Percentage == 100)
                                {
                                    NewItem.BackColor = Color.GreenYellow;
                                }
                                break;
                            }
                        case DataColumnType.FirstName:
                            {
                                string MapObject = (string)Result.Value;
                                NewItem.Text = MapObject.ToString();

                                if (Result.Manual)
                                {
                                    NewItem.SubItems.Add("Manual (" + Math.Round(Result.Percentage, 0).ToString() + ")");
                                }
                                else
                                {
                                    NewItem.SubItems.Add(Math.Round(Result.Percentage, 0).ToString());
                                }

                                if (Result.Percentage == 100)
                                {
                                    NewItem.BackColor = Color.GreenYellow;
                                }
                                break;
                            }
                        case DataColumnType.Surname:
                            {
                                string MapObject = (string)Result.Value;
                                NewItem.Text = MapObject.ToString();

                                if (Result.Manual)
                                {
                                    NewItem.SubItems.Add("Manual (" + Math.Round(Result.Percentage, 0).ToString() + ")");
                                }
                                else
                                {
                                    NewItem.SubItems.Add(Math.Round(Result.Percentage, 0).ToString());
                                }

                                if (Result.Percentage == 100)
                                {
                                    NewItem.BackColor = Color.GreenYellow;
                                }
                                break;
                            }
                        case DataColumnType.EuroJudo_Function:
                            {
                                Function MapObject = (Function)Result.Value;
                                NewItem.Text = MapObject.ToString();

                                if (Result.Manual)
                                {
                                    NewItem.SubItems.Add("Manual (" + Math.Round(Result.Percentage, 0).ToString() + ")");
                                }
                                else
                                {
                                    NewItem.SubItems.Add(Math.Round(Result.Percentage, 0).ToString());
                                }

                                if (Result.Percentage == 100)
                                {
                                    NewItem.BackColor = Color.GreenYellow;
                                }
                                break;
                            }
                        case DataColumnType.IJF_Function:
                            {
                                Function MapObject = (Function)Result.Value;
                                NewItem.Text = MapObject.ToString();

                                if (Result.Manual)
                                {
                                    NewItem.SubItems.Add("Manual (" + Math.Round(Result.Percentage, 0).ToString() + ")");
                                }
                                else
                                {
                                    NewItem.SubItems.Add(Math.Round(Result.Percentage, 0).ToString());
                                }

                                if (Result.Percentage == 100)
                                {
                                    NewItem.BackColor = Color.GreenYellow;
                                }
                                break;
                            }
                        case DataColumnType.IJF_Photo:
                            {
                                string MapObject = (string)Result.Value;
                                NewItem.Text = MapObject.ToString();

                                if (Result.Manual)
                                {
                                    NewItem.SubItems.Add("Manual (" + Math.Round(Result.Percentage, 0).ToString() + ")");
                                }
                                else
                                {
                                    NewItem.SubItems.Add(Math.Round(Result.Percentage, 0).ToString());
                                }

                                if (Result.Percentage == 100)
                                {
                                    NewItem.BackColor = Color.GreenYellow;
                                }

                                break;
                            }
                        case DataColumnType.Unknown:
                            break;
                    }

                    NewItem.Tag = Result;
                    lvwMapping.Items.Add(NewItem);
                }
            }
        }

        #endregion

        #region Event Handlers

        private void frmMapping_Load(object sender, EventArgs e)
        {
            int Height = 240;

            if (lvwMapping.Items.Count > 1)
            {
                lblHint.Text = "Select the best match";

                if (lvwMapping.Items.Count >= 5)
                {
                    Height = 320;
                }

                if (lvwMapping.Items.Count >= 10)
                {
                    Height = 480;
                }
            }
            else if (lvwMapping.Items.Count == 0)
            {
                lblHint.Text = "Idle";
            }
            else
            {
                lblHint.Text = "There is only one result";

                lvwMapping.Items[0].Selected = true;
            }

            GetData();

            this.Height = Height;
            this.CenterToScreen();
        }

        private void lvwMapping_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = lvwMapping.SelectedItems.Count == 1;
            //btnRemove.Enabled = lvwMapping.SelectedItems.Count > 0;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (_SelectedComparisonResult == null && lvwMapping.Items.Count == 1)
            {
                _SelectedComparisonResult = (ComparisonResult)lvwMapping.Items[0].Tag;
            }

            this.DialogResult = DialogResult.Yes;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_SelectedComparisonResult == null && lvwMapping.Items.Count == 1)
            {
                _SelectedComparisonResult = (ComparisonResult)lvwMapping.Items[0].Tag;
            }

            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _SelectedComparisonResult = (ComparisonResult)lvwMapping.SelectedItems[0].Tag;

            if (_SelectedComparisonResult == null && lvwMapping.Items.Count == 1)
            {
                _SelectedComparisonResult = (ComparisonResult)lvwMapping.Items[0].Tag;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void lvwMapping_DoubleClick(object sender, EventArgs e)
        {
            _SelectedComparisonResult = (ComparisonResult)lvwMapping.SelectedItems[0].Tag;

            this.DialogResult = DialogResult.OK;
        }

        #endregion

        #region Private Methods

        private void GetData()
        {
            

        }

        #endregion

        #region Public Methods

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}

