using System;
using System.Collections;

namespace EuroJudo
{
    [Serializable]
    public class Location
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

        private Country _Country = null;
        private SubDivision _SubDivision = null;

        #endregion

        #region Properties

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

        public SubDivision SubDivision
        {
            get
            {
                return _SubDivision;
            }
            set
            {
                _SubDivision = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public Location()
        {

        }

        public Location(Country Country, SubDivision SubDivision)
        {
            _Country = Country;
            _SubDivision = SubDivision;
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return $"{SubDivision.Code}";
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
