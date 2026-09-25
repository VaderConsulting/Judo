using System.Drawing;
using System.IO;
using System.Resources;

namespace Judo
{
    // http://www.nbcolympics.com/news/judo-101-rules-scoring

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


    // Pinning
    // 10-14 seconds - yuko
    // 15-19 seconds - waza ari
    // 20 seconds    - ippon

    /* http://martialarts.stackexchange.com/questions/1307/how-is-the-scoring-determined-in-judo-for-the-olympics

       100  -  0s1     Player 1 has an ippon, and player 2 has a shido. Player 1 wins
       0H   -  100s1   Player 1 has a hansoku make. Player 2 has an ippon (because of player 1's hansoku make) and a shido. Player 2 wins. 
       0s1  -  0s2     Player 1 has a shido. Player 2 has 2 shidos. Golden Score must be used to determine the result. 
    */

    public class Score
    {
        #region Constants

        #endregion

        #region Delegates

        public delegate void IpponAddedHandler(object Sender);
        public delegate void IpponRemovedHandler(object Sender);
        public delegate void WazaAriAddedHandler(object Sender);
        public delegate void WazaAriRemovedHandler(object Sender);
        public delegate void HansokuMakeAddedHandler(object Sender);
        public delegate void HansokuMakeRemovedHandler(object Sender);
        public delegate void ShidoAddedHandler(object Sender);
        public delegate void ShidoRemovedHandler(object Sender);

        #endregion

        #region Events

        public event IpponAddedHandler IpponAdded;
        public event IpponRemovedHandler IpponRemoved;
        public event WazaAriAddedHandler WazaAriAdded;
        public event WazaAriRemovedHandler WazaAriRemoved;
        public event HansokuMakeAddedHandler HansokuMakeAdded;
        public event HansokuMakeRemovedHandler HansokuMakeRemoved;
        public event ShidoAddedHandler ShidoAdded;
        public event ShidoRemovedHandler ShidoRemoved;

        #endregion

        #region Enums

        #endregion

        #region DLL Imports

        #endregion

        #region Fields

        private int _Ippon = 0;
        private int _WazaAri = 0;
        private bool _HansokuMake = false;
        private int _Shido = 0;
        private Bitmap _PenaltyImage = null;

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
                _Ippon = value;
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
                _WazaAri = value;
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
                _Shido = value;
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

        #region Constructors and Destructor

        public Score()
        {
            //_Ippon.CollectionChanged += _Ippon_CollectionChanged;
            //_WazaAri.CollectionChanged += _WazaAri_CollectionChanged;
            //_Yuko.CollectionChanged += _Yuko_CollectionChanged;
            //_HansokuMake.CollectionChanged += _HansokuMake_CollectionChanged;
            //_Shido.CollectionChanged += _Shido_CollectionChanged;
        }

        public Score(int Ippon, int WazaAri, int Shido, bool HansokuMake)
        {
            //_Ippon.CollectionChanged += _Ippon_CollectionChanged;
            //_WazaAri.CollectionChanged += _WazaAri_CollectionChanged;
            //_Yuko.CollectionChanged += _Yuko_CollectionChanged;
            //_HansokuMake.CollectionChanged += _HansokuMake_CollectionChanged;
            //_Shido.CollectionChanged += _Shido_CollectionChanged;

            _Ippon = Ippon;
            _WazaAri = WazaAri;
            _Shido = Shido;
            _HansokuMake = HansokuMake;

            switch (_Shido)
            {
                case 0:
                    _PenaltyImage = null;
                    break;
                case 1:
                    //_PenaltyImage = GetImageFromResource("1_Shido");
                    break;
                case 2:
                    //_PenaltyImage = GetImageFromResource("2_Shido");
                    break;
            }

            if (_Shido > 2 || _HansokuMake)
            {
                _HansokuMake = true;
                //_PenaltyImage = GetImageFromResource("Hansokumake");
            }
        }

        ~Score()
        {
            //_Ippon.CollectionChanged -= _Ippon_CollectionChanged;
            //_WazaAri.CollectionChanged -= _WazaAri_CollectionChanged;
            //_Yuko.CollectionChanged -= _Yuko_CollectionChanged;
            //_HansokuMake.CollectionChanged -= _HansokuMake_CollectionChanged;
            //_Shido.CollectionChanged -= _Shido_CollectionChanged;
        }

        #endregion

        #region Event Handlers

        private void _Ippon_Changed(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RaiseIpponAdded();
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RaiseIpponRemoved();
                    break;
            }
        }

        private void _WazaAri_Changed(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RaiseWazaAriAdded();
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RaiseWazaAriRemoved();
                    break;
            }
        }

        private void _HansokuMake_Changed(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RaiseHansokuMakeAdded();
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RaiseHansokuMakeRemoved();
                    break;
            }
        }

        private void _Shido_Changed(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RaiseShidoAdded();
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RaiseShidoRemoved();
                    break;
            }
        }

        #endregion

        #region Private Methods

        private Bitmap GetImageFromResource(string ResourceName)
        {
            byte[] Bytes;
            byte[] unused = { };

            ResourceManager rm = new ResourceManager("Foundation_5", typeof(Score).Assembly);

            Bytes = (byte[])rm.GetObject(ResourceName);

            MemoryStream ms = new MemoryStream(Bytes);
            return (Bitmap)Image.FromStream(ms);
        }

        #endregion

        #region Public Methods

        public virtual void RaiseIpponAdded()
        {
            IpponAdded?.Invoke(this);
        }

        public virtual void RaiseIpponRemoved()
        {
            IpponRemoved?.Invoke(this);
        }

        public virtual void RaiseWazaAriAdded()
        {
            WazaAriAdded?.Invoke(this);
        }

        public virtual void RaiseWazaAriRemoved()
        {
            WazaAriRemoved?.Invoke(this);
        }

        public virtual void RaiseHansokuMakeAdded()
        {
            HansokuMakeAdded?.Invoke(this);
        }

        public virtual void RaiseHansokuMakeRemoved()
        {
            HansokuMakeRemoved?.Invoke(this);
        }

        public virtual void RaiseShidoAdded()
        {
            ShidoAdded?.Invoke(this);
        }

        public virtual void RaiseShidoRemoved()
        {
            ShidoRemoved?.Invoke(this);
        }

        public override bool Equals(object obj)
        {
            Score other = obj as Score;

            if (other == null)
            {
                return false;
            }

            if (_Ippon != other.Ippon || _WazaAri != other.WazaAri || _Shido != other.Shido || _HansokuMake != other.HansokuMake)
            {
                return false;
            }

            return true;
        }

        public static bool operator ==(Score x, Score y)
        {
            if (x is null)
            {
                if (y is null)
                {
                    return true;
                }

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
            if (x.Ippon > y.Ippon || x.WazaAri > y.WazaAri)
            {
                return true;
            }

            return false;
        }

        public static bool operator <(Score x, Score y)
        {
            if (x.Ippon < y.Ippon || x.WazaAri < y.WazaAri)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            //if (_HansokuMake)
            //{
            //    return _Ippon + " " + _WazaAri + " " + _Shido + " Hansoku make";
            //}
            //else
            //{
            //return _Ippon + " " + _WazaAri + " " + _Shido;
            return _Ippon + " " + _WazaAri;
            //}
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

    }
}
