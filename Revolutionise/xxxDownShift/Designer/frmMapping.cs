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

namespace Designer
{
    public partial class frmMapping : Form
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

        public frmMapping()
        {
            InitializeComponent();
        }

        public frmMapping(List<ComparisonResult> ComparisonResults)
        {
            InitializeComponent();

            ComparisonValue = ComparisonResults[0].ValueString;
            ComparisonValueIndex = ComparisonResults[0].ValueIndex;

            _ComparisonResults = ComparisonResults;

            lblValue.Text = ComparisonValue;

            foreach (ComparisonResult Result in ComparisonResults)
            {
                ListViewItem NewItem = new ListViewItem();

                switch (Result.MapType)
                {
                    case EuroJudoMappingType.Event:
                        {

                            EuroJudoEvent MapObject = (EuroJudoEvent)Result.Value;
                            NewItem.Text = MapObject.Name;

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
                    case EuroJudoMappingType.WeightCategory:
                        {
                            EuroJudoWeightCategory MapObject = (EuroJudoWeightCategory)Result.Value;

                            if (((EuroJudoWeightCategory)MapObject).Event == null)
                            {
                                NewItem.Text = MapObject.Name;
                            }
                            else
                            {
                                string MapObjectEventName = ((EuroJudoWeightCategory)MapObject).Event.Name;
                                string MapObjectName = ((EuroJudoWeightCategory)MapObject).ToString();

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
                    case EuroJudoMappingType.Club:
                        {
                            EuroJudoClub MapObject = (EuroJudoClub)Result.Value;
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
                }
                
                NewItem.Tag = Result;
                lvwMapping.Items.Add(NewItem);
            }
        }

        //public frmMapping(List<StringToEuroJudoEventMapping> EventMapping)
        //{
        //    InitializeComponent();

        //    _EventMapping = EventMapping;

        //    _MapType = EuroJudoMappingType.Event;

        //    foreach (StringToEuroJudoEventMapping Map in EventMapping)
        //    {
        //        ListViewItem NewItem = new ListViewItem();
        //        NewItem.Text = Map.DestinationEvent.Name;
        //        //NewItem.SubItems.Add(Map.DestinationE
        //        NewItem.Tag = Map;
        //        lvwMapping.Items.Add(NewItem);
        //    }
        //}

        //public frmMapping(List<StringToEuroJudoWeightMapping> WeightMapping)
        //{
        //    InitializeComponent();

        //    _WeightMapping = WeightMapping;

        //    _MapType = EuroJudoMappingType.WeightCategory;

        //    foreach (StringToEuroJudoWeightMapping Map in WeightMapping)
        //    {
        //        ListViewItem NewItem = new ListViewItem();
        //        NewItem.Text = Map.DestinationCategory.Name;
        //        NewItem.Tag = Map;
        //        lvwMapping.Items.Add(NewItem);
        //    }
        //}

        //public frmMapping(List<StringToEuroJudoClubMapping> ClubMapping)
        //{
        //    InitializeComponent();

        //    _ClubMapping = ClubMapping;

        //    _MapType = EuroJudoMappingType.Club;

        //    foreach (StringToEuroJudoClubMapping Map in ClubMapping)
        //    {
        //        ListViewItem NewItem = new ListViewItem();
        //        NewItem.Text = Map.DestinationClub.Name;
        //        NewItem.Tag = Map;
        //        lvwMapping.Items.Add(NewItem);
        //    }
        //}

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
            }

            this.Height = Height;
            this.CenterToScreen();
        }

        private void lvwMapping_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = lvwMapping.SelectedItems.Count == 1;
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _SelectedComparisonResult = (ComparisonResult)lvwMapping.SelectedItems[0].Tag;

            this.DialogResult = DialogResult.OK;
        }

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}

