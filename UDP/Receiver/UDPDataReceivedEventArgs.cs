using Judo;

using System;
using System.Collections.Generic;
using System.Text;

using Utilities;

namespace Receiver
{
    public class UDPDataReceivedEventArgs : EventArgs
    {
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

        #region Constructors

        public UDPDataReceivedEventArgs(ScoreboardData ReceivedData)
        {
            _ReceivedData = ReceivedData;
        }

        #endregion
    }
}
