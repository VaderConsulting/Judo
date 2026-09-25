using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Judo
{
    [Serializable]
    public class Person : IEquatable<Person>
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

        private string _ID = "";
        private string _FirstName = "";
        private string _LastName = "";
        private Gender _Gender = Gender.Unknown;
        private DateTime _DateOfBirth = DateTime.MinValue;
        private WeightCategory _WeightCategory = null;
        private double _Weight = 0.0;
        private Country _Citizenship = null;
        private int _Seeding = 0;
        private Belt _Belt = null;

        #endregion

        #region Properties

        public string ID
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

        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }

        public Gender Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return _DateOfBirth;
            }
            set
            {
                _DateOfBirth = value;
            }
        }

        public WeightCategory WeightCategory
        {
            get
            {
                return _WeightCategory;
            }
            set
            {
                _WeightCategory = value;
            }
        }

        public double Weight
        {
            get
            {
                return _Weight;
            }
            set
            {
                _Weight = value;
            }
        }

        public Country Citizenship
        {
            get
            {
                return _Citizenship;
            }
            set
            {
                _Citizenship = value;
            }
        }

        public int Seeding
        {
            get
            {
                return _Seeding;
            }
            set
            {
                _Seeding = value;
            }
        }

        public Belt Belt
        {
            get
            {
                return _Belt;
            }
            set
            {
                _Belt = value;
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Person);
        }

        public bool Equals(Person other)
        {
            return other != null &&
                   _FirstName == other.FirstName &&
                   _LastName == other.LastName &&
                   _Gender == other.Gender &&
                   _DateOfBirth == other.DateOfBirth;
        }

        public override int GetHashCode()
        {
            int hashCode = 1892348686;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_ID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_LastName);
            hashCode = hashCode * -1521134295 + _Gender.GetHashCode();
            hashCode = hashCode * -1521134295 + _DateOfBirth.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<WeightCategory>.Default.GetHashCode(_WeightCategory);
            hashCode = hashCode * -1521134295 + _Weight.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Country>.Default.GetHashCode(_Citizenship);
            hashCode = hashCode * -1521134295 + _Seeding.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Belt>.Default.GetHashCode(_Belt);
            return hashCode;
        }

        #endregion

        #region Constructors and Destructor

        #endregion

        #region Event Handlers

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
