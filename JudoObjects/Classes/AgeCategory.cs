using System;
using System.Collections.ObjectModel;

namespace Classes
{
    public class AgeCategory : ClassBase
    {
        #region Constants

        //public const string KANJITYPENAME = "年齢カテゴリ";
        //public const string JAPANESETYPENAME = "Nenrei kategori";
        //public const string ENGLISHTYPENAME = "Age Category";

        #endregion


        #region Events

        #endregion


        #region DLL Imports

        #endregion

        #region Fields

        private Guid _Identifier = Guid.Empty;
        private short _minimumAge = -1;
        private short _maximumAge = -1;
        private bool _SpecialNeeds = false;
        private Enums.Sex _Sex = Enums.Sex.Unknown;
        private string _Name = string.Empty;
        private ObservableCollection<WeightCategory> _WeightCategories = null;
        private ObservableCollection<Person> _Members = new ObservableCollection<Person>();
        private short _ID = 0;
        private short _WeightLimitID = 0;
        private short _Order = -1;
        private short _GroupID = -1;

        #endregion

        #region Properties

        public Guid Identifier
        {
            get
            {
                return _Identifier = Guid.Empty;
            }
            set
            {
                _Identifier = value;
            }
        }

        public short MinimumAge
        {
            get
            {
                return _minimumAge;
            }
            set
            {
                _minimumAge = value;
            }
        }

        public short MaximumAge
        {
            get
            {
                return _maximumAge;
            }
            set
            {
                _maximumAge = value;
            }
        }

        public bool SpecialNeeds
        {
            get
            {
                return _SpecialNeeds;
            }
            set
            {
                _SpecialNeeds = value;
            }
        }

        public Enums.Sex Sex
        {
            get
            {
                return _Sex;
            }
            set
            {
                _Sex = value;
            }
        }

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

        public ObservableCollection<WeightCategory> WeightCategories
        {
            get
            {
                return _WeightCategories;
            }
            set
            {
                _WeightCategories = value;
            }
        }

        public ObservableCollection<Person> Members
        {
            get
            {
                return _Members;
            }
            set
            {
                _Members = value;
            }
        }

        public short ID
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

        public short WeightLimitID
        {
            get
            {
                return _WeightLimitID;
            }
            set
            {
                _WeightLimitID = value;
            }
        }

        public short Order
        {
            get
            {
                return _Order;
            }
            set
            {
                _Order = value;
            }
        }

        public short GroupID
        {
            get
            {
                return _GroupID;
            }
            set
            {
                _GroupID = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public AgeCategory()
        {
        }

        public AgeCategory(short MinimumAge, short MaximumAge, Enums.Sex Sex, short ID, short WeightLimitID, short Order, short GroupID, bool SpecialNeeds = false, string Name = "")
        {
            //base.KanjiTypeName = KANJITYPENAME;
            //base.JapaneseTypeName = JAPANESETYPENAME;
            //base.EnglishTypeName = ENGLISHTYPENAME;
            //base.ObjectName = Name;

            if (MinimumAge > 0)
            {
                _minimumAge = MinimumAge;
            }

            if (MaximumAge > 0)
            {
                _maximumAge = MaximumAge;
            }

            _Sex = Sex;
            _ID = ID;
            _WeightLimitID = WeightLimitID;
            _SpecialNeeds = SpecialNeeds;

            if (Name.Trim() != string.Empty)
            {
                _Name = Name;
            }

            _Order = Order;
            _GroupID = GroupID;

            _WeightCategories = new ObservableCollection<WeightCategory>();
        }

        #endregion


        #region Private Methods

        #endregion

        #region Public Methods

        public override string ToString()
        {
            if (_SpecialNeeds)
            {
                if (_maximumAge > 0)
                {
                    if (_minimumAge > 0)
                    {
                        return _Name + " " + _minimumAge + " - " + _maximumAge;
                    }
                    else
                    {
                        return _Name + " " + _maximumAge + " and under";
                    }
                }
                else
                {
                    if (_minimumAge > 0)
                    {
                        return _Name + " " + _minimumAge + "+";
                    }
                    else
                    {
                        return _Name + " Open";
                    }
                }
            }
            else
            {
                if (_maximumAge > 0)
                {
                    if (_minimumAge > 0)
                    {
                        return _Name + " " + _minimumAge + " - " + _maximumAge;
                    }
                    else
                    {
                        return _Name + " " + _maximumAge + " and under";
                    }
                }
                else
                {
                    if (_minimumAge > 0)
                    {
                        return _Name + " " + _minimumAge + "+";
                    }
                    else
                    {
                        return _Name + " Open";
                    }
                }
            }

            //if (_Name.Length > 0)
            //{
            //    return _Sex + "  " + _Name + " " + _MinimumAge + " - " + _MaximumAge;
            //}
            //else
            //{
            //    return _Sex + " " + _MinimumAge + " - " + _MaximumAge + " Kg";
            //}
        }

        #endregion



    }
}
