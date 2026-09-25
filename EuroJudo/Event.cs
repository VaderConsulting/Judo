using System;
using System.Collections.Generic;

namespace EuroJudo
{
    [Serializable]
    public class Event : EuroJudoObject, IEquatable<Event>
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
        private int _Number = 0;
        private string _Name = "";
        private EuroJudo.Gender _Sex = EuroJudo.Gender.Unknown;

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

        public int Number
        {
            get
            {
                return _Number;
            }

            set
            {
                _Number = value;
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

        public EuroJudo.Gender Sex
        {
            get
            {
                return _Sex;
            }
            set
            {
                _Sex = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public Event()
        {

        }

        public Event(int Index, int Number, string Name, EuroJudo.Gender Sex)
        {
            _Index = Index;
            _Number = Number;
            _Name = Name;
            _Sex = Sex;
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
            return Equals(obj as Event);
        }

        public bool Equals(Event other)
        {
            return other != null &&
                   _Index == other._Index &&
                   _Number == other._Number &&
                   _Name == other._Name &&
                   _Sex == other._Sex;
        }

        public override int GetHashCode()
        {
            int hashCode = 1294648956;
            hashCode = hashCode * -1521134295 + _Index.GetHashCode();
            hashCode = hashCode * -1521134295 + _Number.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_Name);
            hashCode = hashCode * -1521134295 + _Sex.GetHashCode();
            return hashCode;
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }

    public class EuroJudoObject
    {
    }
}
