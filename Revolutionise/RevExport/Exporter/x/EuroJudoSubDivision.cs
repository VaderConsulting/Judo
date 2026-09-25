using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer
{
    public class EuroJudoSubDivision
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

        private string _Name = "";
        private string _Code = "";
        private EuroJudoCountry _Country = null;

        #endregion

        #region Properties

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

        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                _Code = value;
            }
        }

        public EuroJudoCountry Country
        {
            get
            {
                return _Country;
            }
            set
            {
                _Country = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public EuroJudoSubDivision()
        {
        }

        public EuroJudoSubDivision(string Name, string Code, EuroJudoCountry Country)
        {
            _Name = Name;
            _Code = Code;
            _Country = Country;
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return $"{_Name} ({_Code})";
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
