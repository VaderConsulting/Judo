using System;

namespace Classes
{
    /// <summary>
    /// Represents a player's affiliation history with a club.
    /// Tracks when a player joined and left a club, with at most one active affiliation per player.
    /// </summary>
    public class PlayerClubAffiliation : ClassBase
    {
        #region Fields

        private Guid _Id = Guid.Empty;
        private Guid _PlayerId = Guid.Empty;
        private Player _Player = null;
        private Guid _OrgUnitId = Guid.Empty;
        private OrgUnit _OrgUnit = null;
        private DateTime _StartDate = DateTime.UtcNow;
        private DateTime? _EndDate = null;
        private DateTime _CreatedDate = DateTime.UtcNow;
        private DateTime? _ModifiedDate = null;

        #endregion

        #region Properties

        /// <summary>
        /// Unique identifier for the affiliation record.
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
        /// Foreign key to the player.
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
        /// Navigation property to the player.
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
        /// Foreign key to the organizational unit (club) with which the player is affiliated.
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
        /// Navigation property to the organizational unit (club) with which the player is affiliated.
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
        /// Date when the player joined this club.
        /// </summary>
        public DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
            }
        }

        /// <summary>
        /// Date when the player left this club (null if still active).
        /// </summary>
        public DateTime? EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                _EndDate = value;
            }
        }

        /// <summary>
        /// Date and time when this affiliation record was created.
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
        /// Date and time when this affiliation record was last modified.
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

        public PlayerClubAffiliation()
        {
        }

        #endregion
    }
}

