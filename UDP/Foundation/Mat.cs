using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Judo
{
    public class Mat
    {


        #region Events

        #endregion


        #region DLL Imports

        #endregion

        #region Fields

        private ObservableCollection<Person> _Referees = new ObservableCollection<Person>();
        private ObservableCollection<Person> _Officials = new ObservableCollection<Person>();
        private ObservableCollection<WeightCategory> _WeightCategories = new ObservableCollection<WeightCategory>();
        private int _Number = 0;
        //private string _Name = "";

        #endregion

        #region Properties

        public ObservableCollection<Person> Referees
        {
            get
            {
                return _Referees;
            }
            set
            {
                _Referees = value;
            }
        }

        public ObservableCollection<Person> Officials
        {
            get
            {
                return _Officials;
            }
            set
            {
                _Officials = value;
            }
        }

        public ObservableCollection<WeightCategory> WeightCategories
        {
            get
            {
                return _WeightCategories;
            }
            set
            {
                _WeightCategories = value;
            }
        }

        public int Number
        {
            get
            {
                return _Number;
            }
            set
            {
                _Number = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public Mat()
        {
        }

        public Mat(string Name)
        {
        }

        #endregion


        #region Private Methods

        #endregion

        #region Public Methods

        public override bool Equals(object obj)
        {
            if (!(obj is Mat))
            {
                return false;
            }

            Mat other = obj as Mat;

            if (_Number != other.Number)
            {
                return false;
            }

            return true;
        }

        public static bool operator ==(Mat x, Mat y)
        {
            if (Object.ReferenceEquals(x, null))
            {
                if (Object.ReferenceEquals(y, null))
                {
                    return true;
                }

                return false;
            }

            return x.Equals(y);
        }

        public static bool operator !=(Mat x, Mat y)
        {
            return !(x == y);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

    }
}
