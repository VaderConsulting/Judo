using System;
using System.Collections;
using System.Collections.Generic;

namespace Judo
{
    [Serializable]
    public class Country : IEquatable<Country>
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
        private string _ISO3Code = "";
        private string _ISO2Code = "";
        private string _IOCCode = "";
        private string _AnthemFilename = "";
        private string _FlagFilename = "";

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

        public string ISO3Code
        {
            get
            {
                return _ISO3Code;
            }
            set
            {
                _ISO3Code = value;
            }
        }

        public string ISO2Code
        {
            get
            {
                return _ISO2Code;
            }
            set
            {
                _ISO2Code = value;
            }
        }

        public string IOCCode
        {
            get
            {
                return _IOCCode;
            }
            set
            {
                _IOCCode = value;
            }
        }

        public string AnthemFilename
        {
            get
            {
                return _AnthemFilename;
            }
            set
            {
                _AnthemFilename = value;
            }
        }

        public string FlagFilename
        {
            get
            {
                return _FlagFilename;
            }
            set
            {
                _FlagFilename = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public Country()
        {
        }

        public Country(string Name, string ISO2Code, string ISO3Code)
        {
            _Name = Name;
            _ISO2Code = ISO2Code;
            _ISO3Code = ISO3Code;
        }

        public Country(string Name, string ISO2Code, string ISO3Code, string IOCCode, string FlagFilename, string AnthemFilename)
        {
            _Name = Name;
            _ISO2Code = ISO2Code;
            _ISO3Code = ISO3Code;
            _IOCCode = IOCCode;
            _FlagFilename = FlagFilename;
            _AnthemFilename = AnthemFilename;
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return $"{_Name} ({_ISO3Code})";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Country);
        }

        public bool Equals(Country other)
        {
            return other != null &&
                   _Name == other.Name &&
                   _ISO3Code == other.ISO3Code;
        }

        public override int GetHashCode()
        {
            int hashCode = 1464515473;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_ISO3Code);
            return hashCode;
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion


    }
}
