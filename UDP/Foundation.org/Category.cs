using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Judo
{
    public class Category
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

        private WeightCategory _WeightDivision = null;
        private AgeCategory _AgeGroup = null;
        private ObservableCollection<Player> _Players = new ObservableCollection<Player>();
        private Mat _Mat = null;

        #endregion

        #region Properties

        public WeightCategory WeightDivision
        {
            get
            {
                return _WeightDivision;
            }
            set
            {
                _WeightDivision = value;
            }
        }

        public AgeCategory AgeGroup
        {
            get
            {
                return _AgeGroup;
            }
            set
            {
                _AgeGroup = value;
            }
        }

        public ObservableCollection<Player> Players
        {
            get
            {
                return _Players;
            }
            set
            {
                _Players = value;
            }
        }

        public Mat Mat
        {
            get
            {
                return _Mat;
            }
            set
            {
                _Mat = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public Category()
        {
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        #endregion


    }
}
