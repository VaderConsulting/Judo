using System.Collections.ObjectModel;

namespace Classes
{
    public class Division : ClassBase
    {
        #region Constants

        //public const string KANJITYPENAME = "分割";
        //public const string JAPANESETYPENAME = "Bunkatsu";
        //public const string ENGLISHTYPENAME = "Division";

        #endregion


        #region Events

        #endregion


        #region DLL Imports

        #endregion

        #region Fields

        private WeightCategory _WeightDivision = null;
        private AgeCategory _AgeGroup = null;
        private ObservableCollection<Player> _Players = new ObservableCollection<Player>();
        private Mat _Mat = null;

        #endregion

        #region Properties

        public WeightCategory WeightDivision
        {
            get
            {
                return _WeightDivision;
            }
            set
            {
                _WeightDivision = value;
            }
        }

        public AgeCategory AgeGroup
        {
            get
            {
                return _AgeGroup;
            }
            set
            {
                _AgeGroup = value;
            }
        }

        public ObservableCollection<Player> Players
        {
            get
            {
                return _Players;
            }
            set
            {
                _Players = value;
            }
        }

        public Mat Mat
        {
            get
            {
                return _Mat;
            }
            set
            {
                _Mat = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public Division()
        {
            //base.KanjiTypeName = KANJITYPENAME;
            //base.JapaneseTypeName = JAPANESETYPENAME;
            //base.EnglishTypeName = ENGLISHTYPENAME;
            //base.ObjectName = null;
        }

        #endregion


        #region Private Methods

        #endregion


    }
}
