using System;
using System.Collections.Generic;

namespace Classes
{
    /// <summary>
    /// Represents a session (training, grading, First Aid course, social event, committee meeting, etc.)
    /// that belongs to an organizational unit, typically a Club.
    /// </summary>
    public class Session : ClassBase
    {
        #region Fields

        private Guid _Id = Guid.Empty;
        private Guid _OrgUnitId = Guid.Empty;
        private OrgUnit _OrgUnit = null;
        private Enums.SessionType _SessionType = Enums.SessionType.Training;
        private string _Name = string.Empty;
        private string _Description = string.Empty;
        private DateTime _ScheduledStart = DateTime.MinValue;
        private DateTime? _ScheduledEnd = null;
        private DateTime? _ActualStart = null;
        private DateTime? _ActualEnd = null;
        private ICollection<AttendanceRecord> _AttendanceRecords = new List<AttendanceRecord>();
        private DateTime _CreatedDate = DateTime.UtcNow;
        private DateTime? _ModifiedDate = null;

        #endregion

        #region Properties

        /// <summary>
        /// Unique identifier for the session.
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
        /// Foreign key to the organizational unit that owns this session (usually a Club).
        /// </summary>
        public Guid OrgUnitId
        {
            get
            {
                return _OrgUnitId;
            }
            set
            {
                _OrgUnitId = value;
            }
        }

        /// <summary>
        /// Navigation property to the organizational unit that owns this session.
        /// </summary>
        public OrgUnit OrgUnit
        {
            get
            {
                return _OrgUnit;
            }
            set
            {
                _OrgUnit = value;
            }
        }

        /// <summary>
        /// Type of session (Training, Grading, FirstAid, Social, Committee, Other).
        /// </summary>
        public Enums.SessionType SessionType
        {
            get
            {
                return _SessionType;
            }
            set
            {
                _SessionType = value;
            }
        }

        /// <summary>
        /// Name of the session.
        /// </summary>
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

        /// <summary>
        /// Description of the session.
        /// </summary>
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        /// <summary>
        /// Scheduled start date and time of the session.
        /// </summary>
        public DateTime ScheduledStart
        {
            get
            {
                return _ScheduledStart;
            }
            set
            {
                _ScheduledStart = value;
            }
        }

        /// <summary>
        /// Scheduled end date and time of the session (null if not specified).
        /// </summary>
        public DateTime? ScheduledEnd
        {
            get
            {
                return _ScheduledEnd;
            }
            set
            {
                _ScheduledEnd = value;
            }
        }

        /// <summary>
        /// Actual start date and time of the session (null if not started).
        /// </summary>
        public DateTime? ActualStart
        {
            get
            {
                return _ActualStart;
            }
            set
            {
                _ActualStart = value;
            }
        }

        /// <summary>
        /// Actual end date and time of the session (null if not ended).
        /// </summary>
        public DateTime? ActualEnd
        {
            get
            {
                return _ActualEnd;
            }
            set
            {
                _ActualEnd = value;
            }
        }

        /// <summary>
        /// Collection of attendance records for this session.
        /// </summary>
        public ICollection<AttendanceRecord> AttendanceRecords
        {
            get
            {
                return _AttendanceRecords;
            }
            set
            {
                _AttendanceRecords = value;
            }
        }

        /// <summary>
        /// Date and time when this session was created.
        /// </summary>
        public DateTime CreatedDate
        {
            get
            {
                return _CreatedDate;
            }
            set
            {
                _CreatedDate = value;
            }
        }

        /// <summary>
        /// Date and time when this session was last modified.
        /// </summary>
        public DateTime? ModifiedDate
        {
            get
            {
                return _ModifiedDate;
            }
            set
            {
                _ModifiedDate = value;
            }
        }

        #endregion

        #region Constructors

        public Session()
        {
        }

        public Session(string Name, Enums.SessionType SessionType, Guid OrgUnitId, DateTime ScheduledStart)
        {
            _Name = Name;
            _SessionType = SessionType;
            _OrgUnitId = OrgUnitId;
            _ScheduledStart = ScheduledStart;
        }

        #endregion
    }
}

