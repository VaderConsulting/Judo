using System;
using System.Collections.Generic;

namespace Classes
{
    public class Player : ClassBase
    {
        #region Constants

        //public const string KANJITYPENAME = "柔道";
        //public const string JAPANESETYPENAME = "Jūdōka";
        //public const string ENGLISHTYPENAME = "Player";

        #endregion

        #region Events

        #endregion

        #region DLL Imports

        #endregion

        #region Fields

        private Guid _Id = Guid.Empty;
        private Guid _PersonId = Guid.Empty;
        private Person _Person = null;
        private Guid? _HomeOrgUnitId = null;
        private OrgUnit _HomeOrgUnit = null;
        private DateTime _DateOfBirth = DateTime.MinValue;
        private Rank _Rank = null;
        private Weight _Weight = new Weight(0);
        private AgeCategory _AgeCategory = null;
        private List<WeightCategory> _EligibleWeightCategories = new List<WeightCategory>();
        private WeightCategory _PrimaryWeightCategory = null;
        private List<string> _SystemComments = new List<string>();
        private bool _Flag = false;
        private ICollection<PlayerClubAffiliation> _ClubAffiliations = new List<PlayerClubAffiliation>();
        private ICollection<PlayerGrading> _Gradings = new List<PlayerGrading>();
        private DateTime _CreatedDate = DateTime.UtcNow;
        private DateTime? _ModifiedDate = null;

        #endregion

        #region Properties

        /// <summary>
        /// Unique identifier for the player.
        /// </summary>
        public Guid Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        /// <summary>
        /// Foreign key to the person (1:1 relationship).
        /// </summary>
        public Guid PersonId
        {
            get
            {
                return _PersonId;
            }
            set
            {
                _PersonId = value;
            }
        }

        /// <summary>
        /// Navigation property to the person (1:1 relationship).
        /// </summary>
        public Person Person
        {
            get
            {
                return _Person;
            }
            set
            {
                _Person = value;
            }
        }

        /// <summary>
        /// Foreign key to the current home club (organizational unit).
        /// </summary>
        public Guid? HomeOrgUnitId
        {
            get
            {
                return _HomeOrgUnitId;
            }
            set
            {
                _HomeOrgUnitId = value;
            }
        }

        /// <summary>
        /// Navigation property to the current home club (organizational unit).
        /// </summary>
        public OrgUnit HomeOrgUnit
        {
            get
            {
                return _HomeOrgUnit;
            }
            set
            {
                _HomeOrgUnit = value;
            }
        }

        /// <summary>
        /// Date of birth of the player.
        /// </summary>
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

        /// <summary>
        /// Current rank of the player.
        /// </summary>
        public Rank Rank
        {
            get
            {
                return _Rank;
            }
            set
            {
                _Rank = value;
            }
        }

        /// <summary>
        /// Current weight of the player.
        /// </summary>
        public Weight Weight
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

        //public WeightCategory PrimaryWeightCategory
        //{
        //    get
        //    {
        //        return _PrimaryWeightCategory;
        //    }
        //    set
        //    {
        //        _PrimaryWeightCategory = value;
        //    }
        //}

        //public List<WeightCategory> EligibleWeightCategories
        //{
        //    get
        //    {
        //        return _EligibleWeightCategories;
        //    }
        //    set
        //    {
        //        _EligibleWeightCategories = value;
        //    }
        //}

        public int Age
        {
            get
            {
                return DateTime.Now.Year - _DateOfBirth.Year;
            }
        }

        public int AgeThisYear
        {
            get
            {
                DateTime Date = new DateTime(DateTime.Now.Year, 12, 31);

                return AgeAtDate(Date);
            }
        }

        //public WeightCategory AddFivePercentWeightCategory
        //{
        //    get
        //    {
        //        return _AddFivePercentWeightCategory;
        //    }
        //    set
        //    {
        //        _AddFivePercentWeightCategory = value;
        //    }
        //}

        //public WeightCategory RemoveFivePercentWeightCategory
        //{
        //    get
        //    {
        //        return _RemoveFivePercentWeightCategory;
        //    }
        //    set
        //    {
        //        _RemoveFivePercentWeightCategory = value;
        //    }
        //}

        //public List<WeightCategory> AddFivePercentEligibleWeightCategories
        //{
        //    get
        //    {
        //        return _AddFivePercentEligibleWeightCategories;
        //    }
        //    set
        //    {
        //        _AddFivePercentEligibleWeightCategories = value;
        //    }
        //}

        //public List<WeightCategory> RemoveFivePercentEligibleWeightCategories
        //{
        //    get
        //    {
        //        return _RemoveFivePercentEligibleWeightCategories;
        //    }
        //    set
        //    {
        //        _RemoveFivePercentEligibleWeightCategories = value;
        //    }
        //}

        //public AgeCategory AgeCategory
        //{
        //    get
        //    {
        //        return _AgeCategory;
        //    }
        //    set
        //    {
        //        _AgeCategory = value;
        //    }
        //}

        //public List<string> SystemComments
        //{
        //    get
        //    {
        //        return _SystemComments;
        //    }
        //    set
        //    {
        //        _SystemComments = value;
        //    }
        //}

        /// <summary>
        /// Age category (calculated property, typically not stored).
        /// </summary>
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

        /// <summary>
        /// Eligible weight categories (calculated property, typically not stored).
        /// </summary>
        public List<WeightCategory> EligibleWeightCategories
        {
            get
            {
                return _EligibleWeightCategories;
            }
            set
            {
                _EligibleWeightCategories = value;
            }
        }

        /// <summary>
        /// Primary weight category (calculated property, typically not stored).
        /// </summary>
        public WeightCategory PrimaryWeightCategory
        {
            get
            {
                return _PrimaryWeightCategory;
            }
            set
            {
                _PrimaryWeightCategory = value;
            }
        }

        /// <summary>
        /// System comments for the player.
        /// </summary>
        public List<string> SystemComments
        {
            get
            {
                return _SystemComments;
            }
            set
            {
                _SystemComments = value;
            }
        }

        /// <summary>
        /// Flag indicating whether the player record requires attention.
        /// </summary>
        public bool Flag
        {
            get
            {
                return _Flag;
            }
            set
            {
                _Flag = value;
            }
        }

        /// <summary>
        /// Collection of club affiliation history for this player.
        /// </summary>
        public ICollection<PlayerClubAffiliation> ClubAffiliations
        {
            get
            {
                return _ClubAffiliations;
            }
            set
            {
                _ClubAffiliations = value;
            }
        }

        /// <summary>
        /// Collection of grading history for this player.
        /// </summary>
        public ICollection<PlayerGrading> Gradings
        {
            get
            {
                return _Gradings;
            }
            set
            {
                _Gradings = value;
            }
        }

        /// <summary>
        /// Date and time when this player record was created.
        /// </summary>
        public DateTime CreatedDate
        {
            get
            {
                return _CreatedDate;
            }
            set
            {
                _CreatedDate = value;
            }
        }

        /// <summary>
        /// Date and time when this player record was last modified.
        /// </summary>
        public DateTime? ModifiedDate
        {
            get
            {
                return _ModifiedDate;
            }
            set
            {
                _ModifiedDate = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public Player()
        {
        }

        public Player(Person Person) : base()
        {
            //base.KanjiTypeName = KANJITYPENAME;
            //base.JapaneseTypeName = JAPANESETYPENAME;
            //base.EnglishTypeName = ENGLISHTYPENAME;
            //base.ObjectName = null;

            _Person = Person;
        }

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public int AgeAtDate(DateTime Date)
        {
            int age = Date.Year - DateOfBirth.Year;

            if (Date < DateOfBirth.AddYears(age))
            {
                age--;
            }

            if (age < 0)
            {
                age = 0;
            }

            return age;
        }

        //private void Load(string ConnectionString)
        //{
        //    string Query = "SELECT Club";

        //    Utilities.Data.GetDataRowFromDataset(Utilities.Data.Execute(Query, ConnectionString), 0, 0);

        //}

        private void Save(string ConnectionString)
        {
        }

        #endregion

    }
}
