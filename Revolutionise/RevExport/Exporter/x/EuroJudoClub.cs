namespace Designer
{
    public partial class EuroJudoClub
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

        private string _Name = "";
        private string _Code = "";
        private EuroJudoLocation _Location = null;

        #endregion

        #region Properties

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                _Code = value;
            }
        }

        public EuroJudoLocation Location
        {
            get
            {
                return _Location;
            }
            set
            {
                _Location = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public EuroJudoClub()
        {

        }

        public EuroJudoClub(string Name, string Code, EuroJudoLocation Location)
        {
            _Name = Name;
            _Code = Code;
            _Location = Location;
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public override string ToString()
        {
            if (_Location != null)
            {
                if (_Location.SubDivision != null)
                {
                    return $"{_Name} ({_Location.SubDivision.Code})";
                }
                else
                {
                    return $"{_Name} ({_Location.Country.Alpha2Code})";
                }
            }
            else if (_Code.Trim().Length != 0)
            {
                return $"{_Name} ({_Code})";
            }
            else
            {
                return $"{_Name}";
            }
        }

        #endregion



    }
}
