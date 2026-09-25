using System;

namespace Classes
{
    /// <summary>
    /// Represents a request to move an organizational unit from one parent to another.
    /// The move is implemented as "add under new parent, pending approval from the gaining OrgUnit".
    /// </summary>
    public class OrgMoveRequest : ClassBase
    {
        #region Fields

        private Guid _Id = Guid.Empty;
        private Guid _OrgUnitId = Guid.Empty;
        private OrgUnit _OrgUnit = null;
        private Guid _RequestedParentOrgUnitId = Guid.Empty;
        private OrgUnit _RequestedParentOrgUnit = null;
        private DateTime _RequestedDate = DateTime.UtcNow;
        private Guid _RequestedByPersonId = Guid.Empty;
        private Person _RequestedByPerson = null;
        private Enums.RequestStatus _Status = Enums.RequestStatus.Pending;
        private Guid? _ReviewedByPersonId = null;
        private Person _ReviewedByPerson = null;
        private DateTime? _ReviewedDate = null;
        private string _ReviewNotes = string.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// Unique identifier for the move request.
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
        /// Foreign key to the organizational unit being moved.
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
        /// Navigation property to the organizational unit being moved.
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
        /// Foreign key to the requested new parent organizational unit.
        /// </summary>
        public Guid RequestedParentOrgUnitId
        {
            get
            {
                return _RequestedParentOrgUnitId;
            }
            set
            {
                _RequestedParentOrgUnitId = value;
            }
        }

        /// <summary>
        /// Navigation property to the requested new parent organizational unit.
        /// </summary>
        public OrgUnit RequestedParentOrgUnit
        {
            get
            {
                return _RequestedParentOrgUnit;
            }
            set
            {
                _RequestedParentOrgUnit = value;
            }
        }

        /// <summary>
        /// Date and time when the move request was created.
        /// </summary>
        public DateTime RequestedDate
        {
            get
            {
                return _RequestedDate;
            }
            set
            {
                _RequestedDate = value;
            }
        }

        /// <summary>
        /// Foreign key to the person who requested the move.
        /// </summary>
        public Guid RequestedByPersonId
        {
            get
            {
                return _RequestedByPersonId;
            }
            set
            {
                _RequestedByPersonId = value;
            }
        }

        /// <summary>
        /// Navigation property to the person who requested the move.
        /// </summary>
        public Person RequestedByPerson
        {
            get
            {
                return _RequestedByPerson;
            }
            set
            {
                _RequestedByPerson = value;
            }
        }

        /// <summary>
        /// Status of the move request (Pending, Approved, Rejected, Cancelled).
        /// </summary>
        public Enums.RequestStatus Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }

        /// <summary>
        /// Foreign key to the person who reviewed the move request.
        /// </summary>
        public Guid? ReviewedByPersonId
        {
            get
            {
                return _ReviewedByPersonId;
            }
            set
            {
                _ReviewedByPersonId = value;
            }
        }

        /// <summary>
        /// Navigation property to the person who reviewed the move request.
        /// </summary>
        public Person ReviewedByPerson
        {
            get
            {
                return _ReviewedByPerson;
            }
            set
            {
                _ReviewedByPerson = value;
            }
        }

        /// <summary>
        /// Date and time when the move request was reviewed.
        /// </summary>
        public DateTime? ReviewedDate
        {
            get
            {
                return _ReviewedDate;
            }
            set
            {
                _ReviewedDate = value;
            }
        }

        /// <summary>
        /// Notes from the reviewer regarding the move request.
        /// </summary>
        public string ReviewNotes
        {
            get
            {
                return _ReviewNotes;
            }
            set
            {
                _ReviewNotes = value;
            }
        }

        #endregion

        #region Constructors

        public OrgMoveRequest()
        {
        }

        #endregion
    }
}

