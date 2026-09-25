using Judo;

using System;
using System.Collections.Generic;
using System.Text;

namespace Receiver
{
    public class UDPDataReceivedEventArgs : EventArgs
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

        private ScoreboardData _ReceivedData = null;

        #endregion

        #region Properties

        public ScoreboardData ReceivedData
        {
            get
            {
                return _ReceivedData;
            }

        }

        #endregion

        #region Constructors and Destructor

        public UDPDataReceivedEventArgs(ScoreboardData ReceivedData)
        {
            _ReceivedData = ReceivedData;
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion
    }
}
