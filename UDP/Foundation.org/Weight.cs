using System;
using System.Collections.Generic;
using System.Text;

namespace Judo
{
    public class Weight
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

        private float _Kilograms = 0;

        #endregion

        #region Properties

        public float Kilograms
        {
            get
            {
                return _Kilograms;
            }
            set
            {
                _Kilograms = value;
            }
        }

        public float Pounds
        {
            get
            {
                return (float)(_Kilograms * 2.20462262);
            }
            set
            {
                _Kilograms = (float)(value / 0.45359237);
            }
        }

        public float Plus5Percent
        {
            get
            {
                return _Kilograms + Percentage(5, _Kilograms);
            }
        }

        public float Minus5Percent
        {
            get
            {
                return _Kilograms - Percentage(5, _Kilograms);
            }
        }

        #endregion

        #region Constructors and Destructor

        public Weight()
        {
        }

        public Weight(float Kilograms)
        {
            _Kilograms = Kilograms;
        }

        public Weight(double Kilograms)
        {
            _Kilograms = (float)Kilograms;
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        private float Percentage(int Value, float Maximum)
        {
            return (float)(Maximum * (float)Value) / 100;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return _Kilograms + " Kg (~" + Math.Round(Pounds, 0) + " Lb)";
        }

        #endregion

    }
}
