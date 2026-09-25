namespace Designer
{
    public class StringToEuroJudoEventMapping
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

        private string _SourceValue = "";
        private int _SourceIndex = -1;
        private EuroJudoEvent _DestinationEvent = null;

        #endregion

        #region Properties

        public string SourceValue
        {
            get
            {
                return _SourceValue;
            }
            set
            {
                _SourceValue = value;
            }
        }

        public int SourceIndex
        {
            get
            {
                return _SourceIndex;
            }
            set
            {
                _SourceIndex = value;
            }
        }

        public EuroJudoEvent DestinationEvent
        {
            get
            {
                return _DestinationEvent;
            }
            set
            {
                _DestinationEvent = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public StringToEuroJudoEventMapping(string SourceValue, int SourceIndex, EuroJudoEvent DestinationEvent)
        {
            _SourceValue = SourceValue;
            _SourceIndex = SourceIndex;
            _DestinationEvent = DestinationEvent;
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return $"'{SourceValue}' = '{DestinationEvent.Name}' ({DestinationEvent.Number})";
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
