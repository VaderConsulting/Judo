using System;
using System.Collections.Generic;

namespace Judo
{
    [Serializable]
    public class WeightCategory : IEquatable<WeightCategory>
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
        private int _Minimum = 0;
        private int _Maximum = 0;

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

        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                _Minimum = value;
            }
        }

        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                _Maximum = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public WeightCategory()
        {
        }

        public WeightCategory(string Name, int Minimum, int Maximum)
        {
            _Name = Name;
            _Minimum = Minimum;
            _Maximum = Maximum;
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return $"{_Name}";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as WeightCategory);
        }

        public bool Equals(WeightCategory other)
        {
            return other != null &&
                   _Name == other.Name &&
                   _Minimum == other.Minimum &&
                   _Maximum == other.Maximum;
        }

        public override int GetHashCode()
        {
            int hashCode = 10685751;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_Name);
            hashCode = hashCode * -1521134295 + _Minimum.GetHashCode();
            hashCode = hashCode * -1521134295 + _Maximum.GetHashCode();
            return hashCode;
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
