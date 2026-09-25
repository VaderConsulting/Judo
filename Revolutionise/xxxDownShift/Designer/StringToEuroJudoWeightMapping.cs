using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer
{
    public class StringToEuroJudoWeightMapping
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
        private EuroJudoWeightCategory _DestinationCategory = null;

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

        public EuroJudoWeightCategory DestinationCategory
        {
            get
            {
                return _DestinationCategory;
            }
            set
            {
                _DestinationCategory = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public StringToEuroJudoWeightMapping(string SourceValue, int SourceIndex, EuroJudoWeightCategory DestinationCategory)
        {
            _SourceValue = SourceValue;
            _SourceIndex = SourceIndex;
            _DestinationCategory = DestinationCategory;
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return $"'{SourceValue}' = '{DestinationCategory.Event.Name}' ({DestinationCategory.Name})";
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
