namespace Classes
{
    public class EmailAddress
    {


        #region Events

        #endregion


        #region DLL Imports

        #endregion

        #region Fields

        private string _Mailbox = string.Empty;
        private string _Domain = string.Empty;

        #endregion

        #region Properties

        public string Mailbox
        {
            get
            {
                return _Mailbox;
            }
            set
            {
                _Mailbox = value;
            }
        }

        public string Domain
        {
            get
            {
                return _Domain;
            }
            set
            {
                _Domain = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public EmailAddress()
        {
        }

        #endregion


        #region Private Methods

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return _Mailbox + "@" + _Domain;
        }

        #endregion

    }
}