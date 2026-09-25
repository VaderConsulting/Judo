using System;
using System.Collections.Generic;

namespace Classes
{
    /// <summary>
    /// Represents a human being (player, parent, coach, admin, etc.) in the system.
    /// </summary>
    public class Person : ClassBase
    {
        #region Constants

        //public const string KANJITYPENAME = "人";
        //public const string JAPANESETYPENAME = "Hito";
        //public const string ENGLISHTYPENAME = "Person";

        #endregion


        #region Events

        #endregion


        #region DLL Imports

        #endregion

        #region Fields

        private Guid _Id = Guid.Empty;
        private Name _Name = null;
        private Address _Address = new Address();
        private EmailAddress _EmailAddress = new EmailAddress();
        private PhoneNumber _PhoneNumber = null;
        private Enums.Sex _Sex = Classes.Enums.Sex.Unknown;
        private DateTime? _DateOfBirth = null;
        private bool _SpecialNeeds = false;
        private Player _Player = null;
        private ICollection<Person> _Parents = new List<Person>();
        private ICollection<Person> _Siblings = new List<Person>();
        private ICollection<RoleAssignment> _RoleAssignments = new List<RoleAssignment>();
        private ICollection<AttendanceRecord> _AttendanceRecords = new List<AttendanceRecord>();
        private ICollection<PersonMembership> _PersonMemberships = new List<PersonMembership>();
        private ICollection<ResultCorrectionRequest> _ResultCorrectionRequests = new List<ResultCorrectionRequest>();
        private DateTime _CreatedDate = DateTime.UtcNow;
        private DateTime? _ModifiedDate = null;

        #endregion

        #region Properties

        /// <summary>
        /// Unique identifier for the person.
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
        /// Name of the person.
        /// </summary>
        public Name Name
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
        /// Address of the person.
        /// </summary>
        public Address Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }

        /// <summary>
        /// Email address of the person.
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
        /// Phone number of the person.
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
        /// Sex of the person.
        /// </summary>
        public Enums.Sex Sex
        {
            get
            {
                return _Sex;
            }
            set
            {
                _Sex = value;
            }
        }

        /// <summary>
        /// Date of birth of the person (null if not provided).
        /// </summary>
        public DateTime? DateOfBirth
        {
            get
            {
                return _DateOfBirth;
            }
            set
            {
                _DateOfBirth = value;
            }
        }

        /// <summary>
        /// Indicates whether the person has special needs.
        /// </summary>
        public bool SpecialNeeds
        {
            get
            {
                return _SpecialNeeds;
            }
            set
            {
                _SpecialNeeds = value;
            }
        }

        /// <summary>
        /// Navigation property to the player record (1:1 relationship).
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
        /// Collection of parent relationships (many-to-many via join table in EF Core).
        /// </summary>
        public ICollection<Person> Parents
        {
            get
            {
                return _Parents;
            }
            set
            {
                _Parents = value;
            }
        }

        /// <summary>
        /// Collection of sibling relationships (many-to-many via join table in EF Core).
        /// </summary>
        public ICollection<Person> Siblings
        {
            get
            {
                return _Siblings;
            }
            set
            {
                _Siblings = value;
            }
        }

        /// <summary>
        /// Collection of role assignments for this person.
        /// </summary>
        public ICollection<RoleAssignment> RoleAssignments
        {
            get
            {
                return _RoleAssignments;
            }
            set
            {
                _RoleAssignments = value;
            }
        }

        /// <summary>
        /// Collection of attendance records for this person.
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
        /// Collection of memberships for this person.
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

        /// <summary>
        /// Collection of result correction requests made by this person.
        /// </summary>
        public ICollection<ResultCorrectionRequest> ResultCorrectionRequests
        {
            get
            {
                return _ResultCorrectionRequests;
            }
            set
            {
                _ResultCorrectionRequests = value;
            }
        }

        /// <summary>
        /// Date and time when this person record was created.
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
        /// Date and time when this person record was last modified.
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

        #region Constructors and Destructor

        public Person()
        {
        }

        public Person(Name Name, Enums.Sex Sex)
        {
            //base.KanjiTypeName = KANJITYPENAME;
            //base.JapaneseTypeName = JAPANESETYPENAME;
            //base.EnglishTypeName = ENGLISHTYPENAME;
            //base.ObjectName = Name.ToString();

            _Name = Name;
            _Sex = Sex;
        }

        #endregion


        #region Private Methods

        #endregion

        #region Public Methods

        public override string ToString()
        {
            if (_Name != null)
            {
                return _Name.First + " " + _Name.Last;
            }
            return string.Empty;
        }

        #endregion

    }
}
