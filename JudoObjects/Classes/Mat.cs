using System.Collections.ObjectModel;

namespace Classes
{
    public class Mat : ClassBase
    {
        #region Constants

        //public const string KANJITYPENAME = "畳";
        //public const string JAPANESETYPENAME = "tatami";
        //public const string ENGLISHTYPENAME = "Mat";

        #endregion


        #region Events

        #endregion


        #region DLL Imports

        #endregion

        #region Fields

        private ObservableCollection<Person> _Referees = new ObservableCollection<Person>();
        private ObservableCollection<Person> _Officials = new ObservableCollection<Person>();
        private ObservableCollection<WeightCategory> _WeightCategories = new ObservableCollection<WeightCategory>();
        //private string _Name = "";

        #endregion

        #region Properties

        public ObservableCollection<Person> Referees
        {
            get
            {
                return _Referees;
            }
            set
            {
                _Referees = value;
            }
        }

        public ObservableCollection<Person> Officials
        {
            get
            {
                return _Officials;
            }
            set
            {
                _Officials = value;
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

        //public string Name
        //{
        //    get
        //    {
        //        return _Name;
        //    }
        //    set
        //    {
        //        _Name = value;
        //    }
        //}

        #endregion

        #region Constructors and Destructor

        public Mat()
        {
            //base.KanjiTypeName = KANJITYPENAME;
            //base.JapaneseTypeName = JAPANESETYPENAME;
            //base.EnglishTypeName = ENGLISHTYPENAME;
            //base.ObjectName = null;
        }

        public Mat(string Name)
        {
            //base.KanjiTypeName = KANJITYPENAME;
            //base.JapaneseTypeName = JAPANESETYPENAME;
            //base.EnglishTypeName = ENGLISHTYPENAME;
            //base.ObjectName = Name;
        }

        #endregion


        #region Private Methods

        #endregion




    }
}
