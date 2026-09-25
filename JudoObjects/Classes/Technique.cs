using System;
using System.Drawing;

// https://en.wikipedia.org/wiki/List_of_judo_techniques

namespace Classes
{
    public class Technique : ClassBase
    {
        #region Constants

        //public const string KANJITYPENAME = "技";
        //public const string JAPANESETYPENAME = "Waza";
        //public const string ENGLISHTYPENAME = "Technique";

        #endregion


        #region Events

        #endregion


        #region DLL Imports

        #endregion

        #region Fields

        private string _EnglishName = string.Empty;
        private Guid _Identifier = Guid.Empty;
        private string _Name = string.Empty;
        private string _Category = string.Empty;
        private Image _Image = null;
        private Guid _Parent = Guid.Empty;

        #endregion

        #region Properties

        public string Category
        {
            get
            {
                return _Category;
            }
            set
            {
                _Category = value;
            }
        }

        public string EnglishName
        {
            get
            {
                return _EnglishName;
            }
            set
            {
                _EnglishName = value;
            }
        }

        public Guid Identifier
        {
            get
            {
                return _Identifier;
            }
            set
            {
                _Identifier = value;
            }
        }

        public Image Image
        {
            get
            {
                return _Image;
            }
            set
            {
                _Image = value;
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

        public Guid Parent
        {
            get
            {
                return _Parent;
            }
            set
            {
                _Parent = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public Technique()
        {
        }

        public Technique(string Name)
        {
            //base.KanjiTypeName = KANJITYPENAME;
            //base.JapaneseTypeName = JAPANESETYPENAME;
            //base.EnglishTypeName = ENGLISHTYPENAME;
            //base.ObjectName = Name;

            _Name = Name;
        }

        #endregion


        #region Private Methods

        #endregion


    }
}
