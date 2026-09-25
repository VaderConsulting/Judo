using System;

namespace Classes
{
    /// <summary>
    /// Represents a role assignment for a person within a specific organizational unit.
    /// Role assignments are (Role, OrgUnit) pairs that determine permissions and access.
    /// </summary>
    public class RoleAssignment : ClassBase
    {
        #region Fields

        private Guid _Id = Guid.Empty;
        private Guid _PersonId = Guid.Empty;
        private Person _Person = null;
        private Enums.RoleName _RoleName = Enums.RoleName.User;
        private Guid _OrgUnitId = Guid.Empty;
        private OrgUnit _OrgUnit = null;
        private DateTime _AssignedDate = DateTime.UtcNow;
        private Guid? _AssignedByPersonId = null;
        private Person _AssignedByPerson = null;
        private DateTime? _RevokedDate = null;
        private Guid? _RevokedByPersonId = null;
        private Person _RevokedByPerson = null;

        #endregion

        #region Properties

        /// <summary>
        /// Unique identifier for the role assignment.
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
        /// Foreign key to the person who has this role assignment.
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
        /// Navigation property to the person who has this role assignment.
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
        /// Name of the role (Superuser, Admin, User, Guest).
        /// </summary>
        public Enums.RoleName RoleName
        {
            get
            {
                return _RoleName;
            }
            set
            {
                _RoleName = value;
            }
        }

        /// <summary>
        /// Foreign key to the organizational unit where this role applies.
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
        /// Navigation property to the organizational unit where this role applies.
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
        /// Date and time when the role was assigned.
        /// </summary>
        public DateTime AssignedDate
        {
            get
            {
                return _AssignedDate;
            }
            set
            {
                _AssignedDate = value;
            }
        }

        /// <summary>
        /// Foreign key to the person who assigned this role.
        /// </summary>
        public Guid? AssignedByPersonId
        {
            get
            {
                return _AssignedByPersonId;
            }
            set
            {
                _AssignedByPersonId = value;
            }
        }

        /// <summary>
        /// Navigation property to the person who assigned this role.
        /// </summary>
        public Person AssignedByPerson
        {
            get
            {
                return _AssignedByPerson;
            }
            set
            {
                _AssignedByPerson = value;
            }
        }

        /// <summary>
        /// Date and time when the role was revoked (null if still active).
        /// </summary>
        public DateTime? RevokedDate
        {
            get
            {
                return _RevokedDate;
            }
            set
            {
                _RevokedDate = value;
            }
        }

        /// <summary>
        /// Foreign key to the person who revoked this role.
        /// </summary>
        public Guid? RevokedByPersonId
        {
            get
            {
                return _RevokedByPersonId;
            }
            set
            {
                _RevokedByPersonId = value;
            }
        }

        /// <summary>
        /// Navigation property to the person who revoked this role.
        /// </summary>
        public Person RevokedByPerson
        {
            get
            {
                return _RevokedByPerson;
            }
            set
            {
                _RevokedByPerson = value;
            }
        }

        #endregion

        #region Constructors

        public RoleAssignment()
        {
        }

        #endregion
    }
}

