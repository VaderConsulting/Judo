using System;

namespace EuroJudo
{
    [Serializable]
    public class Tournament
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
        private string _Name = "";

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

        public Tournament()
        {

        }

        public Tournament(int Index, string Name)
        {
            _Index = Index;
            _Name = Name;
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
}
