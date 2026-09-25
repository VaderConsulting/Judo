using System.Drawing;
using System.IO;
using System.Resources;

namespace Judo
{
    // http://www.nbcolympics.com/news/judo-101-rules-scoring
    //
    // Scoring
    ////////////////////////////////////////////////////////////////////////////
    // Ippon           10      本     - Full point
    // Waza ari         7      技あり  - Half point
    // Yuko             5      有効    - Almost waza ari 
    // Decision         1

    // Penalties
    ////////////////////////////////////////////////////////////////////////////
    // Hansoku make            - Disqualification
    // Shido                   - Penalty (max of 3.  4x = Hansoku make)

    public class Score
    {
        #region Delegates

        public delegate void IpponAddedHandler(object sender);
        public delegate void IpponRemovedHandler(object sender);
        public delegate void WazaAriAddedHandler(object sender);
        public delegate void WazaAriRemovedHandler(object sender);
        public delegate void YukoAddedHandler(object sender);
        public delegate void YukoRemovedHandler(object sender);
        public delegate void HansokuMakeAddedHandler(object sender);
        public delegate void HansokuMakeRemovedHandler(object sender);
        public delegate void ShidoAddedHandler(object sender);
        public delegate void ShidoRemovedHandler(object sender);

        #endregion

        #region Events

        public event IpponAddedHandler IpponAdded;
        public event IpponRemovedHandler IpponRemoved;
        public event WazaAriAddedHandler WazaAriAdded;
        public event WazaAriRemovedHandler WazaAriRemoved;
        public event YukoAddedHandler YukoAdded;
        public event YukoRemovedHandler YukoRemoved;
        public event HansokuMakeAddedHandler HansokuMakeAdded;
        public event HansokuMakeRemovedHandler HansokuMakeRemoved;
        public event ShidoAddedHandler ShidoAdded;
        public event ShidoRemovedHandler ShidoRemoved;

        #endregion

        #region Fields

        private int _Ippon;
        private int _WazaAri;
        private int _Yuko;
        private bool _HansokuMake;
        private int _Shido;
        private Bitmap _PenaltyImage;

        #endregion

        #region Properties

        public int Ippon
        {
            get
            {
                return _Ippon;
            }
            set
            {
                if (value > _Ippon)
                {
                    _Ippon = value;
                    IpponAdded?.Invoke(this);
                }
                else if (value < _Ippon)
                {
                    _Ippon = value;
                    IpponRemoved?.Invoke(this);
                }
                else
                {
                    _Ippon = value;
                }
            }
        }

        public int WazaAri
        {
            get
            {
                return _WazaAri;
            }
            set
            {
                if (value > _WazaAri)
                {
                    _WazaAri = value;
                    WazaAriAdded?.Invoke(this);
                }
                else if (value < _WazaAri)
                {
                    _WazaAri = value;
                    WazaAriRemoved?.Invoke(this);
                }
                else
                {
                    _WazaAri = value;
                }
            }
        }

        public int Yuko
        {
            get
            {
                return _Yuko;
            }
            set
            {
                if (value > _Yuko)
                {
                    _Yuko = value;
                    YukoAdded?.Invoke(this);
                }
                else if (value < _Yuko)
                {
                    _Yuko = value;
                    YukoRemoved?.Invoke(this);
                }
                else
                {
                    _Yuko = value;
                }
            }
        }

        public bool HansokuMake
        {
            get
            {
                return _HansokuMake;
            }
            set
            {
                _HansokuMake = value;
                if (_HansokuMake)
                {
                    HansokuMakeAdded?.Invoke(this);
                }
                else
                {
                    HansokuMakeRemoved?.Invoke(this);
                }
            }
        }

        public int Shido
        {
            get
            {
                return _Shido;
            }
            set
            {
                if (value > _Shido)
                {
                    _Shido = value;
                    ShidoAdded?.Invoke(this);
                }
                else if (value < _Shido)
                {
                    _Shido = value;
                    ShidoRemoved?.Invoke(this);
                }
                else
                {
                    _Shido = value;
                }

                if (_Shido > 2 && !_HansokuMake)
                {
                    HansokuMake = true;
                    // Optionally set _PenaltyImage = GetImageFromResource("Hansokumake");
                }
            }
        }

        public Bitmap PenaltyImage
        {
            get
            {
                return _PenaltyImage;
            }
            set
            {
                _PenaltyImage = value;
            }
        }

        #endregion

        #region Constructors

        public Score()
        {
            // no-op
        }

        public Score(int ippon, int wazaAri, int yuko, int shido, bool hansokuMake)
        {
            _Ippon = ippon;
            _WazaAri = wazaAri;
            _Yuko = yuko;
            _Shido = shido;
            _HansokuMake = hansokuMake;

            // initialize penalty image based on shido/hansoku
            UpdatePenaltyImage();
        }

        #endregion

        #region Private Helpers

        private void UpdatePenaltyImage()
        {
            // simple example—expand as needed
            if (_Shido == 1)
            {
                //_PenaltyImage = GetImageFromResource("1_Shido");
            }
            else if (_Shido == 2)
            {
                //_PenaltyImage = GetImageFromResource("2_Shido");
            }
            else if (_Shido > 2 || _HansokuMake)
            {
                //_PenaltyImage = GetImageFromResource("Hansokumake");
            }
        }

        private Bitmap GetImageFromResource(string resourceName)
        {
            ResourceManager rm = new ResourceManager("Foundation_5", typeof(Score).Assembly);
            byte[] bytes = (byte[])rm.GetObject(resourceName);
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return (Bitmap)Image.FromStream(ms);
            }
        }

        #endregion

        #region Overrides & Operators

        public override bool Equals(object obj)
        {
            if (obj is Score other)
            {
                return _Ippon == other._Ippon
                    && _WazaAri == other._WazaAri
                    && _Yuko == other._Yuko
                    && _Shido == other._Shido
                    && _HansokuMake == other._HansokuMake;
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + _Ippon.GetHashCode();
                hash = hash * 23 + _WazaAri.GetHashCode();
                hash = hash * 23 + _Yuko.GetHashCode();
                hash = hash * 23 + _Shido.GetHashCode();
                hash = hash * 23 + _HansokuMake.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Score x, Score y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x is null || y is null)
            {
                return false;
            }

            return x.Equals(y);
        }

        public static bool operator !=(Score x, Score y)
        {
            return !(x == y);
        }

        public static bool operator >(Score x, Score y)
        {
            if (x.Ippon > y.Ippon)
            {
                return true;
            }

            if (x.Ippon == y.Ippon && x.WazaAri > y.WazaAri)
            {
                return true;
            }

            if (x.Ippon == y.Ippon && x.WazaAri == y.WazaAri && x.Yuko > y.Yuko)
            {
                return true;
            }

            return false;
        }

        public static bool operator <(Score x, Score y)
        {
            if (x.Ippon < y.Ippon)
            {
                return true;
            }

            if (x.Ippon == y.Ippon && x.WazaAri < y.WazaAri)
            {
                return true;
            }

            if (x.Ippon == y.Ippon && x.WazaAri == y.WazaAri && x.Yuko < y.Yuko)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            // include ippon, waza-ari and yuko
            return $"{_Ippon} {_WazaAri} {_Yuko}";
        }

        #endregion
    }
}
