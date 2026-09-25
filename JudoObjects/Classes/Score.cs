using System.Collections.ObjectModel;

namespace Classes
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
       1s1  -  0s2     Player 1 a yuko and a shido, and player 2 has 2 shidos. Player 1 wins. 
       2    -  10s3    Player 1 has 2 yukos. Player 2 has a wazari and 3 shidos. Player 2 wins. 
       0H   -  100s1   Player 1 has a hansoku make. Player 2 has an ippon (because of player 1's hansoku make) and a shido. Player 2 wins. 
       0s1  -  0s2     Player 1 has a shido. Player 2 has 2 shidos. Player 1 wins. 
    */

    public class Score
    {

        #region Delegates

        public delegate void IpponAddedHandler(object Sender);
        public delegate void IpponRemovedHandler(object Sender);
        public delegate void WazaAriAddedHandler(object Sender);
        public delegate void WazaAriRemovedHandler(object Sender);
        public delegate void YukoAddedHandler(object Sender);
        public delegate void YukoRemovedHandler(object Sender);
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
        public event YukoAddedHandler YukoAdded;
        public event YukoRemovedHandler YukoRemoved;
        public event HansokuMakeAddedHandler HansokuMakeAdded;
        public event HansokuMakeRemovedHandler HansokuMakeRemoved;
        public event ShidoAddedHandler ShidoAdded;
        public event ShidoRemovedHandler ShidoRemoved;

        #endregion


        #region DLL Imports

        #endregion

        #region Fields

        private ObservableCollection<int> _Ippon = new ObservableCollection<int>();
        private ObservableCollection<int> _WazaAri = new ObservableCollection<int>();
        private ObservableCollection<int> _Yuko = new ObservableCollection<int>();
        private ObservableCollection<int> _HansokuMake = new ObservableCollection<int>();
        private ObservableCollection<int> _Shido = new ObservableCollection<int>();

        #endregion

        #region Properties

        public ObservableCollection<int> Ippon
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

        public ObservableCollection<int> WazaAri
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

        public ObservableCollection<int> Yuko
        {
            get
            {
                return _Yuko;
            }
            set
            {
                _Yuko = value;
            }
        }

        public ObservableCollection<int> HansokuMake
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

        public ObservableCollection<int> Shido
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

        #endregion

        #region Constructors and Destructor

        public Score()
        {
            _Ippon.CollectionChanged += _Ippon_CollectionChanged;
            _WazaAri.CollectionChanged += _WazaAri_CollectionChanged;
            _Yuko.CollectionChanged += _Yuko_CollectionChanged;
            _HansokuMake.CollectionChanged += _HansokuMake_CollectionChanged;
            _Shido.CollectionChanged += _Shido_CollectionChanged;
        }

        #endregion

        #region Event Handlers

        private void _Ippon_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
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

        private void _WazaAri_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
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

        private void _Yuko_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RaiseYukoAdded();
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RaiseYukoRemoved();
                    break;
            }
        }

        private void _HansokuMake_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
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

        private void _Shido_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
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


        #region Public Methods

        public virtual void RaiseIpponAdded()
        {
            IpponAddedHandler Raiser = IpponAdded;

            if (Raiser != null)
            {
                Raiser(this);
            }
        }

        public virtual void RaiseIpponRemoved()
        {
            IpponRemovedHandler Raiser = IpponRemoved;

            if (Raiser != null)
            {
                Raiser(this);
            }
        }

        public virtual void RaiseWazaAriAdded()
        {
            WazaAriAddedHandler Raiser = WazaAriAdded;

            if (Raiser != null)
            {
                Raiser(this);
            }
        }

        public virtual void RaiseWazaAriRemoved()
        {
            WazaAriRemovedHandler Raiser = WazaAriRemoved;

            if (Raiser != null)
            {
                Raiser(this);
            }
        }

        public virtual void RaiseYukoAdded()
        {
            YukoAddedHandler Raiser = YukoAdded;

            if (Raiser != null)
            {
                Raiser(this);
            }
        }

        public virtual void RaiseYukoRemoved()
        {
            YukoRemovedHandler Raiser = YukoRemoved;

            if (Raiser != null)
            {
                Raiser(this);
            }
        }

        public virtual void RaiseHansokuMakeAdded()
        {
            HansokuMakeAddedHandler Raiser = HansokuMakeAdded;

            if (Raiser != null)
            {
                Raiser(this);
            }
        }

        public virtual void RaiseHansokuMakeRemoved()
        {
            HansokuMakeRemovedHandler Raiser = HansokuMakeRemoved;

            if (Raiser != null)
            {
                Raiser(this);
            }
        }

        public virtual void RaiseShidoAdded()
        {
            ShidoAddedHandler Raiser = ShidoAdded;

            if (Raiser != null)
            {
                Raiser(this);
            }
        }

        public virtual void RaiseShidoRemoved()
        {
            ShidoRemovedHandler Raiser = ShidoRemoved;

            if (Raiser != null)
            {
                Raiser(this);
            }
        }

        #endregion
    }
}
