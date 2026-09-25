using System;

namespace Classes
{
    /// <summary>
    /// Represents an attendance record for a person at a session.
    /// Presence is implied by the existence of this record; absence means no record exists.
    /// </summary>
    public class AttendanceRecord : ClassBase
    {
        #region Fields

        private Guid _Id = Guid.Empty;
        private Guid _SessionId = Guid.Empty;
        private Session _Session = null;
        private Guid _PersonId = Guid.Empty;
        private Person _Person = null;
        private DateTime _CheckInTime = DateTime.UtcNow;

        #endregion

        #region Properties

        /// <summary>
        /// Unique identifier for the attendance record.
        /// </summary>
        public Guid Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        /// <summary>
        /// Foreign key to the session for which attendance is recorded.
        /// </summary>
        public Guid SessionId
        {
            get
            {
                return _SessionId;
            }
            set
            {
                _SessionId = value;
            }
        }

        /// <summary>
        /// Navigation property to the session for which attendance is recorded.
        /// </summary>
        public Session Session
        {
            get
            {
                return _Session;
            }
            set
            {
                _Session = value;
            }
        }

        /// <summary>
        /// Foreign key to the person who attended the session.
        /// </summary>
        public Guid PersonId
        {
            get
            {
                return _PersonId;
            }
            set
            {
                _PersonId = value;
            }
        }

        /// <summary>
        /// Navigation property to the person who attended the session.
        /// </summary>
        public Person Person
        {
            get
            {
                return _Person;
            }
            set
            {
                _Person = value;
            }
        }

        /// <summary>
        /// Date and time when the person checked in to the session.
        /// </summary>
        public DateTime CheckInTime
        {
            get
            {
                return _CheckInTime;
            }
            set
            {
                _CheckInTime = value;
            }
        }

        #endregion

        #region Constructors

        public AttendanceRecord()
        {
        }

        public AttendanceRecord(Guid SessionId, Guid PersonId)
        {
            _SessionId = SessionId;
            _PersonId = PersonId;
            _CheckInTime = DateTime.UtcNow;
        }

        #endregion
    }
}

