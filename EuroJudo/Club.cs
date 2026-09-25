using System;
using System.Collections;

namespace EuroJudo
{
    [Serializable]
    public class Club
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
        private Location _Location = null;
        private int _ID = -1;

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

        public Location Location
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

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public Club()
        {

        }

        public Club(int ID, string Name, string Code, Location Location)
        {
            _ID = ID;
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
                    return $"{_Name} ({_Location.Country.ISO2Code}-{_Location.SubDivision.Code})";
                }
                else
                {
                    return $"{_Name} ({_Location.Country.ISO2Code})";
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
