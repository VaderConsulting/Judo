using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using static Classes.Enums;

namespace Classes
{
    public class Rank : ClassBase
    {
        #region Constants

        //public const string KANJITYPENAME = "位";
        //public const string JAPANESETYPENAME = "grād";
        //public const string ENGLISHTYPENAME = "Rank";

        #endregion


        #region Events

        #endregion


        #region DLL Imports

        #endregion

        #region Fields

        private int _Value = 0;
        private Belt _Belt = new Belt("None");
        private ObservableCollection<Technique> _Techniques = new ObservableCollection<Technique>();

        #endregion

        #region Properties

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

        public int Value
        {
            get
            {
                return _Value;
            }

            set
            {
                _Value = value;
            }
        }

        public string Name
        {
            get
            {
                return Enum.GetName(typeof(SeniorRanks), _Value);
            }

            set
            {
                _Value = (int)Enum.Parse(typeof(SeniorRanks), value);
            }
        }

        #endregion

        #region Constructors and Destructor

        public Rank()
        {
            //base.KanjiTypeName = KANJITYPENAME;
            //base.JapaneseTypeName = JAPANESETYPENAME;
            //base.EnglishTypeName = ENGLISHTYPENAME;
            //base.ObjectName = null;
        }

        public Rank(string Colour)
        {
            _Value = (int)(Colours)Enum.Parse(typeof(Colours), Colour);
        }

        public Rank(string PrimaryColour, string SecondaryColour)
        {
            _Value = (int)(Colours)Enum.Parse(typeof(Colours), PrimaryColour + SecondaryColour);
        }

        public Rank(Enums.SeniorRanks Rank)
        {
            _Value = (int)Rank;
        }

        public Rank(Colours PrimaryColour)
        {
            _Value = (int)PrimaryColour;

            _Belt = new Belt(_Value);
        }

        public Rank(Colours PrimaryColour, Colours SecondaryColour)
        {
            //string ColourName = PrimaryColour.ToString() + SecondaryColour.ToString();
            int Value1 = (int)(Colours)Enum.Parse(typeof(Colours), PrimaryColour.ToString()); // (int)PrimaryColour;
            int Value2 = (int)(Colours)Enum.Parse(typeof(Colours), SecondaryColour.ToString()); // (int)PrimaryColour;

            _Value = Value1 + 1;

            _Belt = new Belt(Value1, Value2);
        }

        #endregion


        #region Private Methods

        private List<Technique> RequiredTechniques()
        {
            List<Technique> Result = new List<Technique>();

            switch ((Colours)Enum.Parse(typeof(Colours), Name))
            {
                case Colours.White:
                    // No techniques required
                    break;
                case Colours.Yellow:
                    break;
                case Colours.Orange:
                    break;
                case Colours.Green:
                    break;
                case Colours.Blue:
                    break;
                case Colours.Brown:
                    break;
                case Colours.Black1stDan:
                    break;
            }

            return Result;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return _Value.ToString();
        }

        #endregion

    }
}
