namespace Designer
{
    public class EuroJudoWeightCategory
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

        private int _ClassNumber = 0;
        private EuroJudoEvent _Event = null;
        private string _Name = "";

        #endregion

        #region Properties

        public int ClassNumber
        {
            get
            {
                return _ClassNumber;
            }

            set
            {
                _ClassNumber = value;
            }
        }

        public EuroJudoEvent Event
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

        #endregion

        #region Constructors and Destructor

        public EuroJudoWeightCategory(int ClassNumber, EuroJudoEvent Event, string Name)
        {
            _ClassNumber = ClassNumber;
            _Event = Event;
            _Name = Name;

            if (Event == null)
            {
                int i = 1;
            }
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public override string ToString()
        {
            if (_Event != null)
            {
                return $"{_Event.Name} {_Name}";
            }
            else
            {
                return $"{_Name}";
            }
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion
    }
}
