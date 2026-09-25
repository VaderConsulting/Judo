using System;
using System.Collections.Generic;
using System.Text;

namespace Receiver
{
    public class UDPSegment
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

        private int _StartPosition = 0;
        private int _EndPosition = 0;

        #endregion

        #region Properties

        public int StartPosition
        {
            get
            {
                return _StartPosition;
            }

            set
            {
                _StartPosition = value;
            }
        }

        public int EndPosition
        {
            get
            {
                return _EndPosition;
            }

            set
            {
                _EndPosition = value;
            }
        }

        public int Length
        {
            get
            {
                return (_EndPosition + 1) - StartPosition;
            }
        }

        #endregion

        #region Constructors and Destructor

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public UDPSegment(int Position)
        {
            _StartPosition = Position;
            _EndPosition = Position;
        }

        public UDPSegment(int Position1, int Position2)
        {
            if (Position2 >= Position1)
            {
                _StartPosition = Position1;
                _EndPosition = Position2;
            }
            else
            {
                _StartPosition = Position2;
                _EndPosition = Position1;
            }
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion
    }
}
