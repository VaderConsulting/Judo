using System;

namespace Classes
{
    /// <summary>
    /// Represents a request to correct a match result.
    /// Users can request corrections for their own (or their child's) match results.
    /// Admins at the relevant level can approve/reject, and on approval, update the result snapshot.
    /// </summary>
    public class ResultCorrectionRequest : ClassBase
    {
        #region Fields

        private Guid _Id = Guid.Empty;
        private Guid _MatchId = Guid.Empty;
        private Match _Match = null;
        private Guid _RequestedByPersonId = Guid.Empty;
        private Person _RequestedByPerson = null;
        private string _Reason = string.Empty;
        private string _RequestedChanges = string.Empty;
        private Enums.CorrectionRequestStatus _Status = Enums.CorrectionRequestStatus.Pending;
        private DateTime _RequestedDate = DateTime.UtcNow;
        private Guid? _ReviewedByPersonId = null;
        private Person _ReviewedByPerson = null;
        private DateTime? _ReviewedDate = null;
        private string _ReviewNotes = string.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// Unique identifier for the correction request.
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
        /// Foreign key to the match for which the correction is requested.
        /// </summary>
        public Guid MatchId
        {
            get
            {
                return _MatchId;
            }
            set
            {
                _MatchId = value;
            }
        }

        /// <summary>
        /// Navigation property to the match for which the correction is requested.
        /// </summary>
        public Match Match
        {
            get
            {
                return _Match;
            }
            set
            {
                _Match = value;
            }
        }

        /// <summary>
        /// Foreign key to the person who requested the correction.
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
        /// Navigation property to the person who requested the correction.
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
        /// Reason for the correction request.
        /// </summary>
        public string Reason
        {
            get
            {
                return _Reason;
            }
            set
            {
                _Reason = value;
            }
        }

        /// <summary>
        /// Description of the requested changes to the match result.
        /// </summary>
        public string RequestedChanges
        {
            get
            {
                return _RequestedChanges;
            }
            set
            {
                _RequestedChanges = value;
            }
        }

        /// <summary>
        /// Status of the correction request (Pending, Approved, Rejected).
        /// </summary>
        public Enums.CorrectionRequestStatus Status
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
        /// Date and time when the correction request was created.
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
        /// Foreign key to the person who reviewed the correction request.
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
        /// Navigation property to the person who reviewed the correction request.
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
        /// Date and time when the correction request was reviewed.
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
        /// Notes from the reviewer regarding the correction request.
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

        public ResultCorrectionRequest()
        {
        }

        #endregion
    }
}

