using System.Drawing;
using System.Windows.Forms;

namespace Judo
{
    public class Nation
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

        private string _TwoLetterCode = "";
        private string _ThreeLetterCode = "";
        private string _Name = "";
        private string _ID = "";
        private Bitmap _Flag = null;
        private string _AnthemPath = "";

        #endregion

        #region Properties

        public string TwoLetterCode
        {
            get
            {
                return _TwoLetterCode;
            }

            set
            {
                _TwoLetterCode = value;
            }
        }

        public string ThreeLetterCode
        {
            get
            {
                return _ThreeLetterCode;
            }

            set
            {
                _ThreeLetterCode = value;
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

        public string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        public Bitmap Flag
        {
            get
            {
                return _Flag;
            }
            set
            {
                _Flag = value;
            }
        }

        public string AnthemPath
        {
            get
            {
                return _AnthemPath;
            }
            set
            {
                _AnthemPath = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public Nation(string Name, string ThreeLetterCode)
        {
            _Name = Name;
            _ThreeLetterCode = ThreeLetterCode;

            SetFlag();
        }

        public Nation(string ThreeLetterCode)
        {
            _ThreeLetterCode = ThreeLetterCode;

            string ResourceName = _ThreeLetterCode.ToLower() + "_m";
            string AppPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string Filename = $"{AppPath}\\{ResourceName}.jpg";

            //SetFlag();
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        private void SetFlag()
        {
            string ResourceName = _ThreeLetterCode.ToLower() + "_m";
            string AppPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string Filename = $"{AppPath}\\{ResourceName}.jpg";

            try
            {
                Image Flag = Image.FromFile(Filename);

                //if (System.Configuration.ConfigurationManager.AppSettings[ResourceName] != null)
                //{
                //    string x = System.Configuration.ConfigurationManager.AppSettings[ResourceName];
                //    //_Flag = (System.Configuration.ConfigurationManager.AppSettings[ResourceName]);
                //}
                //else
                //{
                //    _Flag = null;
                //}

            }
            catch
            {
                // Flag doesn't exist
            }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }

}
