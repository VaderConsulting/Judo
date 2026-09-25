using System;

namespace Classes
{
    /// <summary>
    /// Represents branding settings for an organizational unit.
    /// Branding is inherited field-by-field up the org tree (null = inherit from parent).
    /// </summary>
    public class OrgBranding : ClassBase
    {
        #region Fields

        private Guid _Id = Guid.Empty;
        private Guid _OrgUnitId = Guid.Empty;
        private OrgUnit _OrgUnit = null;
        private string _PrimaryColour = null;
        private string _SecondaryColour = null;
        private string _AccentColour = null;
        private string _BackgroundColour = null;
        private string _TextColour = null;
        private string _LogoUrl = null;
        private DateTime _CreatedDate = DateTime.UtcNow;
        private DateTime? _ModifiedDate = null;

        #endregion

        #region Properties

        /// <summary>
        /// Unique identifier for the branding record.
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
        /// Foreign key to the organizational unit that owns this branding.
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
        /// Navigation property to the organizational unit that owns this branding.
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
        /// Primary colour for branding (null = inherit from parent).
        /// </summary>
        public string PrimaryColour
        {
            get
            {
                return _PrimaryColour;
            }
            set
            {
                _PrimaryColour = value;
            }
        }

        /// <summary>
        /// Secondary colour for branding (null = inherit from parent).
        /// </summary>
        public string SecondaryColour
        {
            get
            {
                return _SecondaryColour;
            }
            set
            {
                _SecondaryColour = value;
            }
        }

        /// <summary>
        /// Accent colour for branding (null = inherit from parent).
        /// </summary>
        public string AccentColour
        {
            get
            {
                return _AccentColour;
            }
            set
            {
                _AccentColour = value;
            }
        }

        /// <summary>
        /// Background colour for branding (null = inherit from parent).
        /// </summary>
        public string BackgroundColour
        {
            get
            {
                return _BackgroundColour;
            }
            set
            {
                _BackgroundColour = value;
            }
        }

        /// <summary>
        /// Text colour for branding (null = inherit from parent).
        /// </summary>
        public string TextColour
        {
            get
            {
                return _TextColour;
            }
            set
            {
                _TextColour = value;
            }
        }

        /// <summary>
        /// Logo URL for branding (null = inherit from parent).
        /// </summary>
        public string LogoUrl
        {
            get
            {
                return _LogoUrl;
            }
            set
            {
                _LogoUrl = value;
            }
        }

        /// <summary>
        /// Date and time when this branding record was created.
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
        /// Date and time when this branding record was last modified.
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

        public OrgBranding()
        {
        }

        #endregion
    }
}

