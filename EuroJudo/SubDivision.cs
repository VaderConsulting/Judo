using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroJudo
{
    [Serializable]
    public class SubDivision
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
        private Country _Country = null;

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

        public Country Country
        {
            get
            {
                return _Country;
            }
            set
            {
                _Country = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public SubDivision()
        {
        }

        public SubDivision(string Name, string Code, Country Country)
        {
            _Name = Name;
            _Code = Code;
            _Country = Country;

            // If the provided code includes the country code, remove it
            if (_Code.Contains(_Country.ISO2Code))
            {
                _Code = _Code.Substring(_Code.IndexOf("-") + 1);
            }
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return $"{_Name} ({_Code})";
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
