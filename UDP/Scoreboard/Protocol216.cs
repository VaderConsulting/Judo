using System;

using static Utilities.Extensions;

namespace Scoreboard
{
    public class Protocol216 : Protocol
    {
        #region Constants

        private const int ProtocolLength = 216;

        #endregion

        #region Fields

        // Note that start and end can be transposed - the Segment class works it out
        private Segment _StartTokenSegment = new Segment(0);
        private Segment _ProtocolVersionSegment = new Segment(1, 3);
        private Segment _EventIDSegment = new Segment(4, 23);
        private Segment _GenderSegment = new Segment(24);
        private Segment _CategorySegment = new Segment(25, 28);
        private Segment _AgeGroupSegment = new Segment(29);
        private Segment _RoundSegment = new Segment(30);
        private Segment _ContestIDSegment = new Segment(31, 33);
        private Segment _TimerFlagSegment = new Segment(34);
        private Segment _TimerMinuteSegment = new Segment(35);
        private Segment _TimerSecondSegment = new Segment(36, 37);
        private Segment _NationWhiteSegment = new Segment(40, 38);
        private Segment _IDWhiteSegment = new Segment(55, 41);
        private Segment _ShortNameWhiteSegment = new Segment(59, 56);
        private Segment _WorldRankingListPositionWhiteSegment = new Segment(62, 60);
        private Segment _LongNameWhiteSegment = new Segment(92, 63);
        private Segment _IpponWhiteSegment = new Segment(93);
        private Segment _YukoWhiteSegment = new Segment(94);
        private Segment _WazaAriWhiteSegment = new Segment(95);
        private Segment _ShidoWhiteSegment = new Segment(96);
        private Segment _TimerOsaekomiWhiteSegment = new Segment(97, 98);
        private Segment _TeamScoreWhiteSegment = new Segment(99);
        private Segment _NationBlueSegment = new Segment(100, 102);
        private Segment _IDBlueSegment = new Segment(103, 117);
        private Segment _ShortNameBlueSegment = new Segment(118, 121);
        private Segment _WorldRankingListPositionBlueSegment = new Segment(122, 124);
        private Segment _LongNameBlueSegment = new Segment(125, 154);
        private Segment _IpponBlueSegment = new Segment(155);
        private Segment _YukoBlueSegment = new Segment(156);
        private Segment _WazaAriBlueSegment = new Segment(157);
        private Segment _ShidoBlueSegment = new Segment(158);
        private Segment _TimerOsaekomiBlueSegment = new Segment(159, 160);
        private Segment _TeamScoreBlueSegment = new Segment(161);
        private Segment _GoldenScoreSegment = new Segment(162);
        private Segment _WinnerSegment = new Segment(163);
        private Segment _IDRefereeSegment = new Segment(164, 178);
        private Segment _IDJudge1Segment = new Segment(179, 193);
        private Segment _IDJudge2Segment = new Segment(194, 208);
        private Segment _IDMatSegment = new Segment(209);
        private Segment _DisplayModeSegment = new Segment(210);
        private Segment _OsaekomiTimerFlagSegment = new Segment(211);
        private Segment _NotUsedSegment = new Segment(212, 214);
        private Segment _EndTokenSegment = new Segment(215);

        private byte[] _Data = null;

        #endregion

        #region Properties

        public override string StartToken
        {
            get
            {
                byte[] Bytes = new byte[_StartTokenSegment.Length];
                Array.Copy(_Data, _StartTokenSegment.StartPosition, Bytes, 0, _StartTokenSegment.Length);
                return System.Text.Encoding.Default.GetString(Bytes);
            }
        }

        public override string ProtocolVersion
        {
            get
            {
                return _Data.ToString(_ProtocolVersionSegment.StartPosition, _ProtocolVersionSegment.Length);
            }
        }

        public override string EventID
        {
            get
            {
                return _Data.ToString(_EventIDSegment.StartPosition, _EventIDSegment.Length);
            }
        }

        public override string Gender
        {
            get
            {
                return _Data.ToString(_GenderSegment.StartPosition, _GenderSegment.Length);
            }
        }

        public override string Category
        {
            get
            {
                return _Data.ToString(_CategorySegment.StartPosition, _CategorySegment.Length);
            }
        }

        public override string AgeGroup
        {
            get
            {
                return _Data.ToString(_AgeGroupSegment.StartPosition, _AgeGroupSegment.Length);
            }
        }

        public override string Round
        {
            get
            {
                return _Data.ToString(_RoundSegment.StartPosition, _RoundSegment.Length);
            }
        }

        public override string ContestID
        {
            get
            {
                return _Data.ToString(_ContestIDSegment.StartPosition, _ContestIDSegment.Length);
            }
        }

        public override string TimerFlag
        {
            get
            {
                return _Data.ToString(_TimerFlagSegment.StartPosition, _TimerFlagSegment.Length);
            }
        }

        public override string TimerMinute
        {
            get
            {
                return _Data.ToString(_TimerMinuteSegment.StartPosition, _TimerMinuteSegment.Length);
            }
        }

        public override string TimerSecond
        {
            get
            {
                return _Data.ToString(_TimerSecondSegment.StartPosition, _TimerSecondSegment.Length);
            }
        }

        public override string NationWhite
        {
            get
            {
                return _Data.ToString(_NationWhiteSegment.StartPosition, _NationWhiteSegment.Length);
            }
        }

        public override string IDWhite
        {
            get
            {
                return _Data.ToString(_IDWhiteSegment.StartPosition, _IDWhiteSegment.Length);
            }
        }

        public override string ShortNameWhite
        {
            get
            {
                return _Data.ToString(_ShortNameWhiteSegment.StartPosition, _ShortNameWhiteSegment.Length);
            }
        }

        public override string WorldRankingListPositionWhite
        {
            get
            {
                return _Data.ToString(_WorldRankingListPositionWhiteSegment.StartPosition, _WorldRankingListPositionWhiteSegment.Length);
            }
        }

        public override string LongNameWhite
        {
            get
            {
                return _Data.ToString(_LongNameWhiteSegment.StartPosition, _LongNameWhiteSegment.Length);
            }
        }

        public override string IpponWhite
        {
            get
            {
                return _Data.ToString(_IpponWhiteSegment.StartPosition, _IpponWhiteSegment.Length);
            }
        }

        public override string WazaAriWhite
        {
            get
            {
                return _Data.ToString(_WazaAriWhiteSegment.StartPosition, _WazaAriWhiteSegment.Length);
            }
        }

        public override string YukoWhite
        {
            get
            {
                return _Data.ToString(_YukoWhiteSegment.StartPosition, _YukoWhiteSegment.Length);
            }
        }

        public override string ShidoWhite
        {
            get
            {
                return _Data.ToString(_ShidoWhiteSegment.StartPosition, _ShidoWhiteSegment.Length);
            }
        }

        public override string TimerOsaekomiWhite
        {
            get
            {
                return _Data.ToString(_TimerOsaekomiWhiteSegment.StartPosition, _TimerOsaekomiWhiteSegment.Length);
            }
        }

        public override string TeamScoreWhite
        {
            get
            {
                return _Data.ToString(_TeamScoreWhiteSegment.StartPosition, _TeamScoreWhiteSegment.Length);
            }
        }

        public override string NationBlue
        {
            get
            {
                return _Data.ToString(_NationBlueSegment.StartPosition, _NationBlueSegment.Length);
            }
        }

        public override string IDBlue
        {
            get
            {
                return _Data.ToString(_IDBlueSegment.StartPosition, _IDBlueSegment.Length);
            }
        }

        public override string ShortNameBlue
        {
            get
            {
                return _Data.ToString(_ShortNameBlueSegment.StartPosition, _ShortNameBlueSegment.Length);
            }
        }

        public override string WorldRankingListPositionBlue
        {
            get
            {
                return _Data.ToString(_WorldRankingListPositionBlueSegment.StartPosition, _WorldRankingListPositionBlueSegment.Length);
            }
        }

        public override string LongNameBlue
        {
            get
            {
                return _Data.ToString(_LongNameBlueSegment.StartPosition, _LongNameBlueSegment.Length);
            }
        }

        public override string IpponBlue
        {
            get
            {
                return _Data.ToString(_IpponBlueSegment.StartPosition, _IpponBlueSegment.Length);
            }
        }

        public override string WazaAriBlue
        {
            get
            {
                return _Data.ToString(_WazaAriBlueSegment.StartPosition, _WazaAriBlueSegment.Length);
            }
        }

        public override string YukoBlue
        {
            get
            {
                return _Data.ToString(_YukoBlueSegment.StartPosition, _YukoBlueSegment.Length);
            }
        }

        public override string ShidoBlue
        {
            get
            {
                return _Data.ToString(_ShidoBlueSegment.StartPosition, _ShidoBlueSegment.Length);
            }
        }

        public override string TimerOsaekomiBlue
        {
            get
            {
                return _Data.ToString(_TimerOsaekomiBlueSegment.StartPosition, _TimerOsaekomiBlueSegment.Length);
            }
        }

        public override string TeamScoreBlue
        {
            get
            {
                return _Data.ToString(_TeamScoreBlueSegment.StartPosition, _TeamScoreBlueSegment.Length);
            }
        }

        public override string GoldenScore
        {
            get
            {
                return _Data.ToString(_GoldenScoreSegment.StartPosition, _GoldenScoreSegment.Length);
            }
        }

        public override string Winner
        {
            get
            {
                return _Data.ToString(_WinnerSegment.StartPosition, _WinnerSegment.Length);
            }
        }

        public override string IDReferee
        {
            get
            {
                return _Data.ToString(_IDRefereeSegment.StartPosition, _IDRefereeSegment.Length);
            }
        }

        public override string IDJudge1
        {
            get
            {
                return _Data.ToString(_IDJudge1Segment.StartPosition, _IDJudge1Segment.Length);
            }
        }

        public override string IDJudge2
        {
            get
            {
                return _Data.ToString(_IDJudge2Segment.StartPosition, _IDJudge2Segment.Length);
            }
        }

        public override string IDMat
        {
            get
            {
                return _Data.ToString(_IDMatSegment.StartPosition, _IDMatSegment.Length);
            }
        }

        public override string DisplayMode
        {
            get
            {
                return _Data.ToString(_DisplayModeSegment.StartPosition, _DisplayModeSegment.Length);
            }
        }

        public override string OsaekomiTimerFlag
        {
            get
            {
                return _Data.ToString(_OsaekomiTimerFlagSegment.StartPosition, _OsaekomiTimerFlagSegment.Length);
            }
        }

        public override string EndToken
        {
            get
            {
                return _Data.ToString(_EndTokenSegment.StartPosition, _EndTokenSegment.Length);
            }
        }

        #endregion

        #region Constructors and Destructor

        public Protocol216(byte[] Data)
        {
            if (Data.Length != ProtocolLength)
            {
                throw new TypeLoadException("The data length is incorrect. Exactly " + ProtocolLength.ToString() + " bytes must be specified");
            }

            _Data = Data;
        }

        #endregion

        #region Private Methods

        private string TextFromByte(byte[] InputBytes, int Start, int Length)
        {
            byte[] Bytes = new byte[Length];
            string Result = "";
            Array.Copy(InputBytes, Start, Bytes, 0, Length);

            for (int i = 0; i < Length; i++)
            {
                if (Bytes[i] != 0)
                {
                    Result += ((char)Bytes[i]).ToString();
                }
            }

            return (Result).Trim();
        }

        #endregion
    }
}