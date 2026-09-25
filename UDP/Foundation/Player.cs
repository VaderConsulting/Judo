using System;
using System.Collections.Generic;
using System.Drawing;

namespace Judo
{
    public class Player
    {


        #region Events

        #endregion


        #region DLL Imports

        #endregion

        #region Fields

        private AgeCategory _AgeCategory = null;                                                      // Calculated
        private Club _Club = null;
        private DateTime _DateOfBirth = DateTime.MinValue;
        private Guid _Identifier = Guid.Empty;
        private Person _Person = null;
        private List<WeightCategory> _EligibleWeightCategories = new List<WeightCategory>();          // Calculated
        private WeightCategory _PrimaryWeightCategory = null;                                         // Calculated
        private Rank _Rank = null;
        private Weight _Weight = null; // new Weight(0);
        private List<string> _SystemComments = new List<string>();
        private bool _ReviewFlag;
        private int _WRLPosition = 0;
        private Bitmap _Image = null;

        #endregion

        #region Properties

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

        public bool ReviewFlag
        {
            get
            {
                return _ReviewFlag;
            }
            set
            {
                _ReviewFlag = value;
            }
        }

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

        public int WRLPosition
        {
            get
            {
                return _WRLPosition;
            }
            set
            {
                _WRLPosition = value;
            }
        }

        public Bitmap Image
        {
            get
            {
                return _Image;
            }
            set
            {
                _Image = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public Player(Person Person) : base()
        {
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
