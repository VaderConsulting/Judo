using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Judo
{
    public class Person
    {
        #region Constants

        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Enums

        #endregion

        #region DLL Imports

        #endregion

        #region Fields

        private Address _Address = new Address();
        //private Lazy<Player> _Player = null;
        private Player _Player = null;
        private EmailAddress _EmailAddress = new EmailAddress();
        private Guid _Identifier = Guid.Empty;
        private Name _Name = null;
        private ObservableCollection<Person> _Parents = null;
        private PhoneNumber _PhoneNumber = null;
        private Enums.Sex _Sex = Enums.Sex.Unknown;
        private Lazy<ObservableCollection<Person>> _Siblings = new Lazy<ObservableCollection<Person>>();
        private bool _SpecialNeeds = false;
        private Nation _Nation = null;

        #endregion

        #region Properties

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

        public ObservableCollection<Person> Parents
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

        public Lazy<ObservableCollection<Person>> Siblings
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

        public Guid Identifier
        {
            get
            {
                return _Identifier;
            }
            set
            {
                _Identifier = value;
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

        //public Lazy<Player> Player
        //{
        //    get
        //    {
        //        return _Player;
        //    }
        //    set
        //    {
        //        _Player = value;
        //    }
        //}

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

        public Nation Nation
        {
            get
            {
                return _Nation;
            }
            set
            {
                _Nation = value;
            }
        }

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

        #endregion

        #region Constructors and Destructor

        public Person()
        {
        }

        public Person(Name Name, Enums.Sex Sex)
        {
            _Name = Name;
            _Sex = Sex;
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return _Name.First + " " + _Name.Last;
        }

        #endregion

    }
}
