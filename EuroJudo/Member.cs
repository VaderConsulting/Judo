using Judo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroJudo
{
    [Serializable]
    public class Member : Judo.Person, IEquatable<Member>
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

        //private string _MemberNumber = "";
        private Club _Club = null;
        //private string _FirstName = "";
        private string _Suffix = "";
        //private string _LastName = "";
        //private Gender _Genus = Gender.Unknown;
        //private DateTime _DateOfBirth = DateTime.MinValue;
        private Function _Function;
        private Event _Event = null;
        private WeightCategory _WeightCategory = null;
        //private double _Weight = 0.0;
        //private Country _Citizenship = null;
        //private int _Seeding = 0;
        private int _DrawNumber = 0;
        //private Belt _Belt = null;

        #endregion

        #region Properties

        public string MemberNumber
        {
            get
            {
                return base.ID;
            }
            set
            {
                base.ID = value;
            }
        }

        public Club Club
        {
            get
            {
                return _Club;
            }
            set
            {
                _Club = value;
            }
        }

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

        public string Suffix
        {
            get
            {
                return _Suffix;
            }
            set
            {
                _Suffix = value;
            }
        }

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

        public Gender Genus
        {
            get
            {
                switch (base.Gender)
                {
                    default:
                    case Judo.Gender.Unknown:
                        return EuroJudo.Gender.Unknown;
                    case Judo.Gender.Male:
                        return EuroJudo.Gender.M;
                    case Judo.Gender.Female:
                        return EuroJudo.Gender.F;
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
                    case Gender.M:
                        base.Gender = Judo.Gender.Male;
                        break;
                    case Gender.F:
                        base.Gender = Judo.Gender.Female;
                        break;
                }
            }
        }

        [Obsolete("Use Genus property instead", true)]
        public new Gender Gender
        {
            get; set;
        }

        //public DateTime DateOfBirth
        //{
        //    get
        //    {
        //        return _DateOfBirth;
        //    }
        //    set
        //    {
        //        _DateOfBirth = value;
        //    }
        //}

        public Function Function
        {
            get
            {
                return _Function;
            }
            set
            {
                _Function = value;
            }
        }

        public Event Event
        {
            get
            {
                return _Event;
            }
            set
            {
                _Event = value;
            }
        }

        public new EuroJudo.WeightCategory WeightCategory // Hides base.WeightCategory
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

        //public double Weight
        //{
        //    get
        //    {
        //        return _Weight;
        //    }
        //    set
        //    {
        //        _Weight = value;
        //    }
        //}

        //public Country Citizenship
        //{
        //    get
        //    {
        //        return _Citizenship;
        //    }
        //    set
        //    {
        //        _Citizenship = value;
        //    }
        //}

        //public int Seeding
        //{
        //    get
        //    {
        //        return _Seeding;
        //    }
        //    set
        //    {
        //        _Seeding = value;
        //    }
        //}

        public int DrawNumber
        {
            get
            {
                return _DrawNumber;
            }
            set
            {
                _DrawNumber = value;
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Member);
        }

        public bool Equals(Member other)
        {
            return other != null &&
                   _Club == other.Club;
        }

        public override int GetHashCode()
        {
            int hashCode = -1460240370;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Club>.Default.GetHashCode(_Club);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_Suffix);
            hashCode = hashCode * -1521134295 + _Function.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Event>.Default.GetHashCode(_Event);
            hashCode = hashCode * -1521134295 + EqualityComparer<WeightCategory>.Default.GetHashCode(_WeightCategory);
            hashCode = hashCode * -1521134295 + _DrawNumber.GetHashCode();
            return hashCode;
        }

        //public Belt Belt
        //{
        //    get
        //    {
        //        return _Belt;
        //    }
        //    set
        //    {
        //        _Belt = value;
        //    }
        //}

        #endregion

        #region Constructors and Destructor

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public string[] Values()
        {
            string[] Result = { };
            List<string> List = new List<string>();

            // Member nr	Club IdNr	Clubname	Club Short	First Name	Suffix	Last Name	Genus	Date of Birth	Year of Birth	Function	Event Nr	Weight cat.	Weight	Citizenship	Seeding	DrawNr	Kyu

            List.Add(base.ID);
            List.Add(Club.ID.ToString());
            List.Add(Club.Name);
            List.Add(Club.Code);
            List.Add(base.FirstName);
            List.Add(_Suffix);
            List.Add(base.LastName);
            List.Add(Genus.ToString());
            List.Add(base.DateOfBirth.ToString("dd-MM", CultureInfo.InvariantCulture));
            List.Add(base.DateOfBirth.ToString("yyyy", CultureInfo.InvariantCulture));
            List.Add(_Function.ToString());
            List.Add(_Event.Number.ToString());
            List.Add(_WeightCategory.Name);
            List.Add(base.Weight.ToString());
            List.Add(base.Citizenship.ISO3Code);
            List.Add(base.Seeding.ToString());
            List.Add(""); // Draw number
            List.Add(base.Belt.Name);

            Result = List.ToArray<string>();

            return Result;
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
