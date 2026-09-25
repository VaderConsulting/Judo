using System;
using System.Collections.Generic;

namespace EuroJudo
{
    [Serializable]
    public class WeightCategory : Judo.WeightCategory, IEquatable<WeightCategory>
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

        private int _ClassNumber = 0;
        private Event _Event = null;

        #endregion

        #region Properties

        public int ClassNumber
        {
            get
            {
                return _ClassNumber;
            }

            set
            {
                _ClassNumber = value;
            }
        }

        public Event Event
        {
            get
            {
                return _Event;
            }

            set
            {
                _Event = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public WeightCategory(int ClassNumber, Event Event, string Name, int Minimum, int Maximum)
        {
            _ClassNumber = ClassNumber;
            _Event = Event;
            base.Name = Name;
            base.Minimum = Minimum;
            base.Maximum = Maximum;
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public override string ToString()
        {
            if (_Event != null)
            {
                return $"{_Event.Name} {base.Name}";
            }
            else
            {
                return $"{base.Name}";
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as WeightCategory);
        }

        public bool Equals(WeightCategory other)
        {
            return other != null &&
                   _ClassNumber == other.ClassNumber &&
                   _Event.Name == other.Event.Name;
        }

        public override int GetHashCode()
        {
            int hashCode = -373032237;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + _ClassNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Event>.Default.GetHashCode(_Event);
            return hashCode;
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion



    }
}
