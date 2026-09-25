using System;
using System.Collections.Generic;

namespace Classes
{
    /// <summary>
    /// Represents an organizational unit in the Judo hierarchy (Global, Country, State, Region, Club, Squad, Class).
    /// </summary>
    public class OrgUnit : ClassBase
    {
        #region Fields

        private Guid _Id = Guid.Empty;
        private Enums.OrgType _OrgType = Enums.OrgType.Club;
        private string _Name = string.Empty;
        private Guid? _ParentOrgUnitId = null;
        private OrgUnit _ParentOrgUnit = null;
        private ICollection<OrgUnit> _ChildOrgUnits = new List<OrgUnit>();
        private Address _StreetAddress = new Address();
        private Address _PostalAddress = new Address();
        private PhoneNumber _PhoneNumber = null;
        private EmailAddress _EmailAddress = new EmailAddress();
        private Uri _Website = null;
        private Person _President = null;
        private Guid? _PresidentId = null;
        private Person _HeadCoach = null;
        private Guid? _HeadCoachId = null;
        private DateTime _CreatedDate = DateTime.UtcNow;
        private DateTime? _ModifiedDate = null;

        #endregion

        #region Properties

        /// <summary>
        /// Unique identifier for the organizational unit.
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
        /// Type of organizational unit (Global, Country, State, Region, Club, Squad, Class).
        /// </summary>
        public Enums.OrgType OrgType
        {
            get
            {
                return _OrgType;
            }
            set
            {
                _OrgType = value;
            }
        }

        /// <summary>
        /// Name of the organizational unit.
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
        /// Foreign key to the parent organizational unit (null for top-level units).
        /// </summary>
        public Guid? ParentOrgUnitId
        {
            get
            {
                return _ParentOrgUnitId;
            }
            set
            {
                _ParentOrgUnitId = value;
            }
        }

        /// <summary>
        /// Navigation property to the parent organizational unit.
        /// </summary>
        public OrgUnit ParentOrgUnit
        {
            get
            {
                return _ParentOrgUnit;
            }
            set
            {
                _ParentOrgUnit = value;
            }
        }

        /// <summary>
        /// Collection of child organizational units.
        /// </summary>
        public ICollection<OrgUnit> ChildOrgUnits
        {
            get
            {
                return _ChildOrgUnits;
            }
            set
            {
                _ChildOrgUnits = value;
            }
        }

        /// <summary>
        /// Street address of the organizational unit.
        /// </summary>
        public Address StreetAddress
        {
            get
            {
                return _StreetAddress;
            }
            set
            {
                _StreetAddress = value;
            }
        }

        /// <summary>
        /// Postal address of the organizational unit.
        /// </summary>
        public Address PostalAddress
        {
            get
            {
                return _PostalAddress;
            }
            set
            {
                _PostalAddress = value;
            }
        }

        /// <summary>
        /// Phone number of the organizational unit.
        /// </summary>
        public PhoneNumber PhoneNumber
        {
            get
            {
                return _PhoneNumber;
            }
            set
            {
                _PhoneNumber = value;
            }
        }

        /// <summary>
        /// Email address of the organizational unit.
        /// </summary>
        public EmailAddress EmailAddress
        {
            get
            {
                return _EmailAddress;
            }
            set
            {
                _EmailAddress = value;
            }
        }

        /// <summary>
        /// Website URL of the organizational unit.
        /// </summary>
        public Uri Website
        {
            get
            {
                return _Website;
            }
            set
            {
                _Website = value;
            }
        }

        /// <summary>
        /// Foreign key to the person who is the president of this organizational unit.
        /// </summary>
        public Guid? PresidentId
        {
            get
            {
                return _PresidentId;
            }
            set
            {
                _PresidentId = value;
            }
        }

        /// <summary>
        /// Navigation property to the person who is the president of this organizational unit.
        /// </summary>
        public Person President
        {
            get
            {
                return _President;
            }
            set
            {
                _President = value;
            }
        }

        /// <summary>
        /// Foreign key to the person who is the head coach of this organizational unit.
        /// </summary>
        public Guid? HeadCoachId
        {
            get
            {
                return _HeadCoachId;
            }
            set
            {
                _HeadCoachId = value;
            }
        }

        /// <summary>
        /// Navigation property to the person who is the head coach of this organizational unit.
        /// </summary>
        public Person HeadCoach
        {
            get
            {
                return _HeadCoach;
            }
            set
            {
                _HeadCoach = value;
            }
        }

        /// <summary>
        /// Date and time when this organizational unit was created.
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
        /// Date and time when this organizational unit was last modified.
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

        public OrgUnit()
        {
        }

        public OrgUnit(string Name, Enums.OrgType OrgType)
        {
            _Name = Name;
            _OrgType = OrgType;
        }

        #endregion
    }
}

