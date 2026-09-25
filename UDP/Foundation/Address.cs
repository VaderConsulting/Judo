using System;
using System.Collections.Generic;
using System.Text;

namespace Judo
{
    public class Address
    {


        #region Events

        #endregion


        #region DLL Imports

        #endregion

        #region Fields

        private Guid _Identifier = Guid.Empty;
        private string _ApartmentNumber = string.Empty;
        private string _BuildingName = string.Empty;
        private string _Country = string.Empty;
        private string _Latitude = string.Empty;
        private string _Locality = string.Empty;
        private string _Longitude = string.Empty;
        private string _PostCode = string.Empty;
        private string _StreetName1 = string.Empty;
        private string _StreetName2 = string.Empty;
        private string _StreetNumber = String.Empty;
        private string _State = string.Empty;

        #endregion

        #region Properties

        public string ApartmentNumber
        {
            get
            {
                return _ApartmentNumber;
            }
            set
            {
                _ApartmentNumber = value;
            }
        }

        public string BuildingName
        {
            get
            {
                return _BuildingName;
            }
            set
            {
                _BuildingName = value;
            }
        }

        public string Country
        {
            get
            {
                return _Country;
            }
            set
            {
                _Country = value;
            }
        }

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

        public string Latitude
        {
            get
            {
                return _Latitude;
            }
            set
            {
                _Latitude = value;
            }
        }

        public string Locality
        {
            get
            {
                return _Locality;
            }
            set
            {
                _Locality = value;
            }
        }

        public string Longitude
        {
            get
            {
                return _Longitude;
            }
            set
            {
                _Longitude = value;
            }
        }

        public string PostCode
        {
            get
            {
                return _PostCode;
            }
            set
            {
                _PostCode = value;
            }
        }

        public string StreetName1
        {
            get
            {
                return _StreetName1;
            }
            set
            {
                _StreetName1 = value;
            }
        }

        public string StreetName2
        {
            get
            {
                return _StreetName2;
            }
            set
            {
                _StreetName2 = value;
            }
        }

        public string StreetNumber
        {
            get
            {
                return _StreetNumber;
            }
            set
            {
                _StreetNumber = value;
            }
        }

        public string State
        {
            get
            {
                return _State;
            }
            set
            {
                _State = value;
            }
        }

        #endregion


        #region Event Handlers

        #endregion


        #region Public Methods

        public string ToString(bool Full = false)
        {
            StringBuilder Result = new StringBuilder();

            if (_StreetName2.Trim() == string.Empty)
            {
                if (_ApartmentNumber.Trim() != string.Empty)
                {
                    Result.Append(_ApartmentNumber.Trim());
                    Result.Append(" ");
                }

                if (_BuildingName.Trim() != string.Empty)
                {
                    Result.AppendLine(_BuildingName.Trim());
                }

                Result.Append(_StreetNumber + " " + _StreetName1 + ", ");
            }
            else
            {
                if (_BuildingName.Trim() != string.Empty)
                {
                    Result.AppendLine(_BuildingName.Trim());
                }

                Result.Append("Corner of " + _StreetName1 + " and " + _StreetName2 + ", ");
            }

            Result.Append(_Locality);

            if (Full)
            {
                Result.Append(" " + _State + " " + _PostCode + ", " + _Country);
            }

            return Result.ToString();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Address))
            {
                return false;
            }

            Address other = obj as Address;

            if (
                    _ApartmentNumber != other.ApartmentNumber ||
                    _BuildingName != other.BuildingName ||
                    _Country != other.Country ||
                    _Locality != other.Locality ||
                    _PostCode != other.PostCode ||
                    _State != other.State ||
                    _StreetName1 != other.StreetName1 ||
                    _StreetName2 != other.StreetName2 ||
                    _StreetNumber != other.StreetNumber
               )
            {
                return false;
            }

            return true;
        }

        public static bool operator ==(Address x, Address y)
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

        public static bool operator !=(Address x, Address y)
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
