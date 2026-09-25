using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Judo
{
    public class Club
    {


        #region Events

        #endregion


        #region DLL Imports

        #endregion

        #region Fields

        private string _Name = string.Empty;
        private Address _StreetAddress = new Address();
        private Address _PostalAddress = new Address();
        private Person _President = null;
        private Person _HeadCoach = null;
        private ObservableCollection<Person> _Members = new ObservableCollection<Person>();
        private Uri _Website = null;
        private Guid _Identifier = Guid.Empty;
        private PhoneNumber _PhoneNumber = null;

        #endregion

        #region Properties

        public Guid Identifier
        {
            get
            {
                return _Identifier = Guid.Empty;
            }
            set
            {
                _Identifier = value;
            }
        }

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

        public ObservableCollection<Person> Members
        {
            get
            {
                return _Members;
            }
            set
            {
                _Members = value;
            }
        }

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

        #endregion

        #region Constructors and Destructor

        public Club(string Name)
        {
            _Name = Name;
        }

        #endregion


        #region Private Methods

        #endregion


    }
}
