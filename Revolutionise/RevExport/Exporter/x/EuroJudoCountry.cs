namespace Designer
{
    public class EuroJudoCountry
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
        private string _Alpha3Code = "";
        private string _Alpha2Code = "";

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

        public string Alpha3Code
        {
            get
            {
                return _Alpha3Code;
            }
            set
            {
                _Alpha3Code = value;
            }
        }

        public string Alpha2Code
        {
            get
            {
                return _Alpha2Code;
            }
            set
            {
                _Alpha2Code = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public EuroJudoCountry()
        {
        }

        public EuroJudoCountry(string Name, string Alpha2Code, string Alpha3Code)
        {
            _Name = Name;
            _Alpha2Code = Alpha2Code;
            _Alpha3Code = Alpha3Code;
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return $"{_Name} ({_Alpha3Code})";
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
