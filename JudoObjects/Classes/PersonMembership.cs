using System;

namespace Classes
{
    /// <summary>
    /// Represents a person's membership to a membership plan.
    /// Links a Person to a MembershipPlan with start and end dates.
    /// </summary>
    public class PersonMembership : ClassBase
    {
        #region Fields

        private Guid _Id = Guid.Empty;
        private Guid _PersonId = Guid.Empty;
        private Person _Person = null;
        private Guid _MembershipPlanId = Guid.Empty;
        private MembershipPlan _MembershipPlan = null;
        private DateTime _StartDate = DateTime.UtcNow;
        private DateTime? _EndDate = null;
        private DateTime _CreatedDate = DateTime.UtcNow;
        private DateTime? _ModifiedDate = null;

        #endregion

        #region Properties

        /// <summary>
        /// Unique identifier for the person membership.
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
        /// Foreign key to the person who has this membership.
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
        /// Navigation property to the person who has this membership.
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
        /// Foreign key to the membership plan.
        /// </summary>
        public Guid MembershipPlanId
        {
            get
            {
                return _MembershipPlanId;
            }
            set
            {
                _MembershipPlanId = value;
            }
        }

        /// <summary>
        /// Navigation property to the membership plan.
        /// </summary>
        public MembershipPlan MembershipPlan
        {
            get
            {
                return _MembershipPlan;
            }
            set
            {
                _MembershipPlan = value;
            }
        }

        /// <summary>
        /// Date when the membership started.
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
        /// Date when the membership ended (null if still active).
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
        /// Date and time when this membership record was created.
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
        /// Date and time when this membership record was last modified.
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

        public PersonMembership()
        {
        }

        #endregion
    }
}

