namespace Designer
{
    public class EuroJudoEvent : EuroJudoObject
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

        private int _Index = 0;
        private int _Number = 0;
        private string _Name = "";
        private Sex _Sex = Sex.Unknown;

        #endregion

        #region Properties

        public int Index
        {
            get
            {
                return _Index;
            }

            set
            {
                _Index = value;
            }
        }

        public int Number
        {
            get
            {
                return _Number;
            }

            set
            {
                _Number = value;
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

        public Sex Sex
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

        #endregion

        #region Constructors and Destructor

        public EuroJudoEvent()
        {

        }

        public EuroJudoEvent(int Index, int Number, string Name, Sex Sex)
        {
            _Index = Index;
            _Number = Number;
            _Name = Name;
            _Sex = Sex;
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return _Name;
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }

    public class EuroJudoObject
    {
    }
}
