using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Classes
{
    public class WeightCategory : ClassBase
    {
        #region Constants

        //public const string KANJITYPENAME = "重量区分";
        //public const string JAPANESETYPENAME = "Jūryō kubun";
        //public const string ENGLISHTYPENAME = "Weight Category";

        #endregion


        #region Events

        #endregion


        #region DLL Imports

        #endregion

        #region Fields

        private float _LowerWeightLimit = -1;
        private float _UpperWeightLimit = -1;
        private short _LowerAgeLimit = -1;
        private short _UpperAgeLimit = -1;
        private bool _SpecialNeeds = false;
        private Enums.Sex _Sex = Enums.Sex.Unknown;
        private string _Name = string.Empty;
        private ObservableCollection<Person> _Members = new ObservableCollection<Person>();
        private short _ID = 0;
        private short _WeightLimitID = 0;
        private List<WeightCategory> _CompatibleCategories = new List<WeightCategory>();
        private AgeCategory _AgeCategory = null;

        #endregion

        #region Properties

        public float LowerWeightLimit
        {
            get
            {
                return _LowerWeightLimit;
            }
            set
            {
                _LowerWeightLimit = value;
            }
        }

        public float UpperWeightLimit
        {
            get
            {
                return _UpperWeightLimit;
            }
            set
            {
                _UpperWeightLimit = value;
            }
        }

        public short LowerAgeLimit
        {
            get
            {
                return _LowerAgeLimit;
            }
            set
            {
                _LowerAgeLimit = value;
            }
        }

        public short UpperAgeLimit
        {
            get
            {
                return _UpperAgeLimit;
            }
            set
            {
                _UpperAgeLimit = value;
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

        public List<WeightCategory> CompatibleCategories
        {
            get
            {
                return _CompatibleCategories;
            }
            set
            {
                _CompatibleCategories = value;
            }
        }

        public AgeCategory AgeCategory
        {
            get
            {
                return _AgeCategory;
            }
            set
            {
                _AgeCategory = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public WeightCategory()
        {
        }

        public WeightCategory(string Name)
        {
            _Name = Name;
        }

        public WeightCategory(float LowerWeightLimit, float UpperWeightLimit, short LowerAgeLimit, short UpperAgeLimit, Enums.Sex Sex, short ID, short WeightLimitID, AgeCategory AgeCat, bool SpecialNeeds = false, string Name = "")
        {
            //base.KanjiTypeName = KANJITYPENAME;
            //base.JapaneseTypeName = JAPANESETYPENAME;
            //base.EnglishTypeName = ENGLISHTYPENAME;

            if (LowerWeightLimit > 0)
            {
                _LowerWeightLimit = LowerWeightLimit;
            }

            if (UpperWeightLimit > 0)
            {
                _UpperWeightLimit = UpperWeightLimit;
            }

            if (LowerAgeLimit > 0)
            {
                _LowerAgeLimit = LowerAgeLimit;
            }
            if (UpperAgeLimit > 0)
            {
                _UpperAgeLimit = UpperAgeLimit;
            }

            _Sex = Sex;
            _ID = ID;
            _WeightLimitID = WeightLimitID;
            _SpecialNeeds = SpecialNeeds;
            _AgeCategory = AgeCat;

            if (Name.Trim() != string.Empty)
            {
                _Name = Name;
            }
        }

        #endregion


        #region Private Methods

        #endregion

        #region Public Methods

        public override string ToString()
        {
            if (_Name.Length > 0)
            {
                return _Name;
            }
            else
            {
                if (_UpperWeightLimit > 0)
                {
                    return _Sex + " " + _LowerWeightLimit + " - " + _UpperWeightLimit + " Kg";
                }
                else
                {
                    return _Sex + " " + _LowerWeightLimit + " Kg +";
                }
            }
        }

        #endregion

    }
}
