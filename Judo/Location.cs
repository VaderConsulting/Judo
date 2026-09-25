using System;
using System.Collections;
using System.Collections.Generic;

namespace Judo
{
    [Serializable]
    public class Location : IEquatable<Location>
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

        public override bool Equals(object obj)
        {
            return Equals(obj as Location);
        }

        public bool Equals(Location other)
        {
            return other != null &&
                   _Country.Name == other.Country.Name &&
                   _SubDivision.Name == other.SubDivision.Name;
        }

        public override int GetHashCode()
        {
            int hashCode = -1470402349;
            hashCode = hashCode * -1521134295 + EqualityComparer<Country>.Default.GetHashCode(_Country);
            hashCode = hashCode * -1521134295 + EqualityComparer<SubDivision>.Default.GetHashCode(_SubDivision);
            return hashCode;
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
