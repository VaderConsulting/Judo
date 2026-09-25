using Judo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJF
{
    [Serializable]
    public class Person : Judo.Person, IEquatable<Person>
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

        //private string _ID = "";
        //private string _FirstName = "";
        //private string _LastName = "";
        //private Gender _Gender = Gender.Unknown;
        //private DateTime _DateOfBirth = DateTime.MinValue;
        //private WeightCategory _WeightCategory = null;
        //private double _Weight = 0.0;
        //private Country _Citizenship = null;
        //private int _Seeding = 0;
        //private Belt _Belt = null;

        #endregion

        #region Properties

        //public string ID
        //{
        //    get
        //    {
        //        return _ID;
        //    }
        //    set
        //    {
        //        _ID = value;
        //    }
        //}

        //public string FirstName
        //{
        //    get
        //    {
        //        return _FirstName;
        //    }
        //    set
        //    {
        //        _FirstName = value;
        //    }
        //}

        //public string LastName
        //{
        //    get
        //    {
        //        return _LastName;
        //    }
        //    set
        //    {
        //        _LastName = value;
        //    }
        //}

        public new Gender Gender
        {
            get
            {
                switch (base.Gender)
                {
                    default:
                    case Judo.Gender.Unknown:
                        return IJF.Gender.Unknown;
                    case Judo.Gender.Male:
                        return IJF.Gender.m;
                    case Judo.Gender.Female:
                        return IJF.Gender.w;
                }
            }
            set
            {
                switch (value)
                {
                    default:
                    case Gender.Unknown:
                        base.Gender = Judo.Gender.Unknown;
                        break;
                    case Gender.m:
                        base.Gender = Judo.Gender.Male;
                        break;
                    case Gender.w:
                        base.Gender = Judo.Gender.Female;
                        break;
                }
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Person);
        }

        public bool Equals(Person other)
        {
            return other != null &&
                   Gender == other.Gender;
        }

        public override int GetHashCode()
        {
            return 1644821664 + Gender.GetHashCode();
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
