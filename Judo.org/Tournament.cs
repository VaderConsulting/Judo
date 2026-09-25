using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Judo
{
    [Serializable]
    public class Tournament : IEquatable<Tournament>
    {
        #region Constants

        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Enums

        public enum SoftwareSystemType
        {
            Unknown = -1,
            EuroJudo,
            IJF,
            Other
        }

        #endregion

        #region DLL Imports

        #endregion

        #region Fields

        private int _Index = 0;
        private string _Name = "";
        private string _ID = "";
        private SoftwareSystemType _Type = SoftwareSystemType.Unknown;

        #endregion

        #region Properties

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

        public SoftwareSystemType SystemType
        {
            get
            {
                return _Type;
            }

            set
            {
                _Type = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public Tournament()
        {

        }

        /// <summary>
        /// Create an IJF Tournament
        /// </summary>
        /// <param name="Name">The name of the tournament</param>
        public Tournament(string ID, string Name) // IJF tournaments have an ID
        {
            _ID = ID;
            _Name = Name;
            _Type = SoftwareSystemType.IJF;
        }
        
        /// <summary>
        /// Create a EuroJudo Tournament
        /// </summary>
        /// <param name="Index">The Index used to reference this tournament</param>
        /// <param name="Name">The name of the tournament</param>
        public Tournament(int Index, string Name) // EuroJudo tournaments have an Index
        {
            _Index = Index;
            _Name = Name;
            _Type = SoftwareSystemType.EuroJudo;
        }

        /// <summary>
        /// Create a custom software type Tournament
        /// </summary>
        /// <param name="Name">The name of the tournament</param>
        public Tournament(string Name, SoftwareSystemType SoftwareType)
        {
            _Name = Name;
            _Type = SoftwareType;
        }

        /// <summary>
        /// Create a generic Tournament
        /// </summary>
        /// <param name="Name">The name of the tournament</param>
        public Tournament(string Name)
        {
            _Name = Name;
            _Type = SoftwareSystemType.Other;
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

        public override bool Equals(object obj)
        {
            return Equals(obj as Tournament);
        }

        public bool Equals(Tournament other)
        {
            return other != null &&
                   _Index == other.Index &&
                   _Name == other.Name &&
                   _ID == other.ID;
        }

        public override int GetHashCode()
        {
            int hashCode = -1439730056;
            hashCode = hashCode * -1521134295 + _Index.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_ID);
            hashCode = hashCode * -1521134295 + _Type.GetHashCode();
            return hashCode;
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
