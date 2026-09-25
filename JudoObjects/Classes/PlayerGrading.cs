using System;

namespace Classes
{
    /// <summary>
    /// Represents a grading record for a player.
    /// Stores the awarded belt/rank, date, context (Club/State/Country), and type of grading.
    /// </summary>
    public class PlayerGrading : ClassBase
    {
        #region Fields

        private Guid _Id = Guid.Empty;
        private Guid _PlayerId = Guid.Empty;
        private Player _Player = null;
        private Rank _AwardedRank = null;
        private DateTime _AwardedDate = DateTime.MinValue;
        private Guid? _AwardedByOrgUnitId = null;
        private OrgUnit _AwardedByOrgUnit = null;
        private Enums.GradingType _GradingType = Enums.GradingType.Normal;
        private string _Notes = string.Empty;
        private Guid? _AwardedByPersonId = null;
        private Person _AwardedByPerson = null;
        private DateTime _CreatedDate = DateTime.UtcNow;

        #endregion

        #region Properties

        /// <summary>
        /// Unique identifier for the grading record.
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
        /// Foreign key to the player who received this grading.
        /// </summary>
        public Guid PlayerId
        {
            get
            {
                return _PlayerId;
            }
            set
            {
                _PlayerId = value;
            }
        }

        /// <summary>
        /// Navigation property to the player who received this grading.
        /// </summary>
        public Player Player
        {
            get
            {
                return _Player;
            }
            set
            {
                _Player = value;
            }
        }

        /// <summary>
        /// The rank/belt that was awarded in this grading.
        /// </summary>
        public Rank AwardedRank
        {
            get
            {
                return _AwardedRank;
            }
            set
            {
                _AwardedRank = value;
            }
        }

        /// <summary>
        /// Date when the grading was awarded.
        /// </summary>
        public DateTime AwardedDate
        {
            get
            {
                return _AwardedDate;
            }
            set
            {
                _AwardedDate = value;
            }
        }

        /// <summary>
        /// Foreign key to the organizational unit (Club/State/Country) that awarded this grading.
        /// </summary>
        public Guid? AwardedByOrgUnitId
        {
            get
            {
                return _AwardedByOrgUnitId;
            }
            set
            {
                _AwardedByOrgUnitId = value;
            }
        }

        /// <summary>
        /// Navigation property to the organizational unit that awarded this grading.
        /// </summary>
        public OrgUnit AwardedByOrgUnit
        {
            get
            {
                return _AwardedByOrgUnit;
            }
            set
            {
                _AwardedByOrgUnit = value;
            }
        }

        /// <summary>
        /// Type of grading (Normal, AgeBasedDemotion, RPL, ExternalRecognition).
        /// </summary>
        public Enums.GradingType GradingType
        {
            get
            {
                return _GradingType;
            }
            set
            {
                _GradingType = value;
            }
        }

        /// <summary>
        /// Additional notes about the grading.
        /// </summary>
        public string Notes
        {
            get
            {
                return _Notes;
            }
            set
            {
                _Notes = value;
            }
        }

        /// <summary>
        /// Foreign key to the person who awarded this grading.
        /// </summary>
        public Guid? AwardedByPersonId
        {
            get
            {
                return _AwardedByPersonId;
            }
            set
            {
                _AwardedByPersonId = value;
            }
        }

        /// <summary>
        /// Navigation property to the person who awarded this grading.
        /// </summary>
        public Person AwardedByPerson
        {
            get
            {
                return _AwardedByPerson;
            }
            set
            {
                _AwardedByPerson = value;
            }
        }

        /// <summary>
        /// Date and time when this grading record was created.
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

        #endregion

        #region Constructors

        public PlayerGrading()
        {
        }

        #endregion
    }
}

