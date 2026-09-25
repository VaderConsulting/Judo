namespace Classes
{
    public class PhoneNumber
    {


        #region Events

        #endregion


        #region DLL Imports

        #endregion

        #region Fields

        private string _Number = string.Empty;
        private string _AreaCode = string.Empty;
        private string _CountryCode = string.Empty;

        #endregion

        #region Properties

        public string Number
        {
            get
            {
                return _Number;
            }
            set
            {
                _Number = value;
            }
        }

        public string AreaCode
        {
            get
            {
                return _AreaCode;
            }
            set
            {
                _AreaCode = value;
            }
        }

        public string CountryCode
        {
            get
            {
                return _CountryCode;
            }
            set
            {
                _CountryCode = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public PhoneNumber()
        {
        }

        public PhoneNumber(string Number)
        {
            if (!Number.StartsWith("0") && Number.Length == 9)
            {
                _Number = "0" + Number;
            }
            else
            {
                _Number = Number;
            }
        }

        public PhoneNumber(string AreaCode, string Number)
        {
            _AreaCode = AreaCode;

            if (!Number.StartsWith("0") && Number.Length == 9)
            {
                _Number = "0" + Number;
            }
            else
            {
                _Number = Number;
            }
        }

        public PhoneNumber(string CountryCode, string AreaCode, string Number)
        {
            _CountryCode = CountryCode;
            _AreaCode = AreaCode;

            if (!Number.StartsWith("0") && Number.Length == 9)
            {
                _Number = "0" + Number;
            }
            else
            {
                _Number = Number;
            }
        }

        #endregion


        #region Private Methods

        #endregion


    }
}