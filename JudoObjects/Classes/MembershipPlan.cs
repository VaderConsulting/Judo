using System;
using System.Collections.Generic;

namespace Classes
{
    /// <summary>
    /// Represents a membership plan offered by an organizational unit (typically a Club).
    /// Defines pricing, session limits, and billing periods.
    /// </summary>
    public class MembershipPlan : ClassBase
    {
        #region Fields

        private Guid _Id = Guid.Empty;
        private Guid _OrgUnitId = Guid.Empty;
        private OrgUnit _OrgUnit = null;
        private string _Name = string.Empty;
        private string _Description = string.Empty;
        private int? _MaxSessionsPerWeek = null;
        private decimal _Price = 0m;
        private string _BillingPeriod = string.Empty;
        private bool _IsActive = true;
        private DateTime _CreatedDate = DateTime.UtcNow;
        private DateTime? _ModifiedDate = null;
        private ICollection<PersonMembership> _PersonMemberships = new List<PersonMembership>();

        #endregion

        #region Properties

        /// <summary>
        /// Unique identifier for the membership plan.
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
        /// Foreign key to the organizational unit that offers this membership plan.
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
        /// Navigation property to the organizational unit that offers this membership plan.
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
        /// Name of the membership plan.
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
        /// Description of the membership plan.
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
        /// Maximum number of sessions allowed per week (null for unlimited).
        /// </summary>
        public int? MaxSessionsPerWeek
        {
            get
            {
                return _MaxSessionsPerWeek;
            }
            set
            {
                _MaxSessionsPerWeek = value;
            }
        }

        /// <summary>
        /// Price of the membership plan.
        /// </summary>
        public decimal Price
        {
            get
            {
                return _Price;
            }
            set
            {
                _Price = value;
            }
        }

        /// <summary>
        /// Billing period for the membership plan (e.g., "Monthly", "Yearly", "Quarterly").
        /// </summary>
        public string BillingPeriod
        {
            get
            {
                return _BillingPeriod;
            }
            set
            {
                _BillingPeriod = value;
            }
        }

        /// <summary>
        /// Indicates whether this membership plan is currently active and available for new memberships.
        /// </summary>
        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
            }
        }

        /// <summary>
        /// Date and time when this membership plan was created.
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
        /// Date and time when this membership plan was last modified.
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

        /// <summary>
        /// Collection of person memberships using this plan.
        /// </summary>
        public ICollection<PersonMembership> PersonMemberships
        {
            get
            {
                return _PersonMemberships;
            }
            set
            {
                _PersonMemberships = value;
            }
        }

        #endregion

        #region Constructors

        public MembershipPlan()
        {
        }

        #endregion
    }
}

