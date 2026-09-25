using System;

using static Classes.Enums;

namespace Classes
{
    public class Belt : ClassBase
    {
        #region Constants

        //public const string KANJITYPENAME = "帯";
        //public const string JAPANESETYPENAME = "Obi";
        //public const string ENGLISHTYPENAME = "Belt";

        #endregion


        #region Events

        #endregion


        #region DLL Imports

        #endregion

        #region Fields

        private Guid _Identifier = Guid.Empty;
        private Colours _PrimaryColour = Colours.None;
        private Colours _SecondaryColour = Colours.None;
        private string _ConnectionString = string.Empty;
        private SeniorRanks _Rank = SeniorRanks.RokKyu;
        private int _Value = -1;

        #endregion

        #region Properties

        public Colours PrimaryColour
        {
            get
            {
                return _PrimaryColour; // (Colours)Value;
            }

            set
            {
                _PrimaryColour = value;
            }
        }

        public Colours SecondaryColour
        {
            get
            {
                return _SecondaryColour; // (Colours)Value;
            }

            set
            {
                _SecondaryColour = value;
            }
        }

        public string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                _ConnectionString = value;
            }
        }

        public SeniorRanks Rank
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

        public int Value
        {
            get
            {
                return _Value;
            }

            set
            {
                Value = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public Belt()
        {
            //base.KanjiTypeName = KANJITYPENAME;
            //base.JapaneseTypeName = JAPANESETYPENAME;
            //base.EnglishTypeName = ENGLISHTYPENAME;
            //base.ObjectName = null;
        }

        public Belt(int PrimaryValue) : this()
        {
            _Value = PrimaryValue;
            _Rank = (Enums.SeniorRanks)Enum.ToObject(typeof(Enums.SeniorRanks), _Value);
            _PrimaryColour = (Enums.Colours)Enum.ToObject(typeof(Enums.Colours), _Value);
        }

        public Belt(int PrimaryValue, int SecondaryValue) : this()
        {
            _Value = PrimaryValue + 1;
            _Rank = (Enums.SeniorRanks)Enum.ToObject(typeof(Enums.SeniorRanks), _Value);
            _PrimaryColour = (Enums.Colours)Enum.ToObject(typeof(Enums.Colours), PrimaryValue);
            _SecondaryColour = (Enums.Colours)Enum.ToObject(typeof(Enums.Colours), SecondaryValue);
        }

        public Belt(string PrimaryColour) : this()
        {
            _Value = (int)Enum.Parse(typeof(Colours), PrimaryColour);
        }

        public Belt(string PrimaryColour, string SecondaryColour) : this()
        {
            _Value = (int)Enum.Parse(typeof(Colours), PrimaryColour + SecondaryColour);
        }

        public Belt(string PrimaryColour, Guid BeltIdentifier) : this()
        {
            string ShortName = PrimaryColour.Replace(" ", "").Replace("\xA0", ""); // Remove non-breaking space characters

            _Value = (int)Enum.Parse(typeof(Colours), ShortName);
            _Identifier = BeltIdentifier;
            _Rank = (Enums.SeniorRanks)Enum.ToObject(typeof(Enums.SeniorRanks), _Value);
            _PrimaryColour = (Enums.Colours)Enum.ToObject(typeof(Enums.Colours), _Value);
        }

        public Belt(string PrimaryColour, string SecondaryColour, Guid BeltIdentifier) : this()
        {
            string ShortName = PrimaryColour.Replace(" ", "").Replace("\xA0", "") + SecondaryColour.Replace(" ", "").Replace("\xA0", ""); // Remove non-breaking space characters

            _Value = (int)Enum.Parse(typeof(Colours), ShortName);
            _Identifier = BeltIdentifier;
            _Rank = (Enums.SeniorRanks)Enum.ToObject(typeof(Enums.SeniorRanks), _Value);
            _PrimaryColour = (Enums.Colours)Enum.ToObject(typeof(Enums.Colours), _Value);
            _SecondaryColour = (Enums.Colours)Enum.ToObject(typeof(Enums.Colours), _Value);
        }

        #endregion


        #region Private Methods

        #endregion

        #region Public Methods

        //public void Load()
        //{
        //    if (Math.Abs(_Value) == _Value && _ConnectionString != string.Empty) // This checks if _Value is not negative
        //    {
        //        Load(_Value);
        //    }
        //}

        /// <summary>
        /// Determine the Belt colour from the provided Rank
        /// </summary>
        /// <param name="Value"></param>
        public void Load(Rank Rank)
        {
            string Query = string.Empty;
            string StringResult;
            bool Result;

            //Query = "SELECT Identifier, Colour FROM Belt WHERE Value = " + _Value;
            //_Value = Value;

            //DataSet DataResult;

            //(StringResult, Result, DataResult) = Utilities.Data.GetMySQLData(Query, _ConnectionString, "Belt");

            //string ReturnedValue = (string)Utilities.Data.GetDataRowFromDataset(DataResult, 0, 0).ItemArray[1];
        }

        public override string ToString()
        {
            if (_SecondaryColour == Colours.None)
            {
                return _PrimaryColour.ToString();
            }
            else
            {
                return _PrimaryColour.ToString() + "/" + _SecondaryColour.ToString();
            }
        }

        #endregion

        //public string Name()
        //{
        //    switch ((Grades)_Value)
        //    {
        //        default:
        //        case Grades.RoKyu:
        //            return "White";
        //        case Grades.GoKyu:
        //            return "Yellow";
        //        case Grades.YonKyu:
        //            return "Orange";
        //        case Grades.SanKyu:
        //            return "Green";
        //        case Grades.NiKyu:
        //            return "Blue";
        //        case Grades.IkKyu:
        //            return "Brown";
        //        case Grades.ShoDan:
        //            return "1st Dan";
        //        case Grades.NiDan:
        //            return "2nd Dan";
        //        case Grades.SanDan:
        //            return "3rd Dan";
        //        case Grades.YonDan:
        //            return "4th Dan";
        //        case Grades.GoDan:
        //            return "5th Dan";
        //        case Grades.RokuDan:
        //            return "6th Dan";
        //        case Grades.ShichiDan:
        //            return "7th Dan";
        //        case Grades.HachiDan:
        //            return "8th Dan";
        //        case Grades.KuDan:
        //            return "9th Dan";
        //        case Grades.JuDan:
        //            return "10th Dan";
        //    }
        //}

    }
}
