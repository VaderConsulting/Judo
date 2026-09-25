using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer
{
    public class StringToEuroJudoClubMapping
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
        private EuroJudoClub _DestinationClub = null;

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

        public EuroJudoClub DestinationClub
        {
            get
            {
                return _DestinationClub;
            }
            set
            {
                _DestinationClub = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public StringToEuroJudoClubMapping(string SourceValue, int SourceIndex, EuroJudoClub DestinationClub)
        {
            _SourceValue = SourceValue;
            _SourceIndex = SourceIndex;
            _DestinationClub = DestinationClub;
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return $"'{SourceValue}' = '{_DestinationClub.Name}' ({_DestinationClub.Code})";
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion
    }
}
