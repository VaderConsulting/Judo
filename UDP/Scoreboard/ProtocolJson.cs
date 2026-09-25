using System;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Scoreboard
{
    public class ProtocolJSON : Protocol
    {
        #region Fields

        private JsonDocument _JsonDocument;
        private JsonElement _RootElement;

        #endregion

        #region Properties

        public override string StartToken
        {
            get
            {
                // For compatibility - JSON doesn't have start tokens
                return "2";
            }
        }

        public override string ProtocolVersion
        {
            get
            {
                return GetJsonValue("ProtoVer", "0");
            }
        }

        public override string EventID
        {
            get
            {
                return GetJsonValue("IDEvent", "");
            }
        }

        public override string Gender
        {
            get
            {
                // IJF uses "1" for Men, "0" for Women
                string gender = GetJsonValue("Gender", "");
                switch (gender)
                {
                    case "1":
                        return "m";  // Men
                    case "0":
                        return "w";  // Women
                    default:
                        return gender;
                }
            }
        }

        public override string Category
        {
            get
            {
                string category = GetJsonValue("Category", "");
                // Remove the minus sign for compatibility with Protocol216
                return category.Replace("-", "");
            }
        }

        public override string AgeGroup
        {
            get
            {
                string ageGroup = GetJsonValue("AgeGroup", "");
                // Convert to single letter code for compatibility
                switch (ageGroup.ToLower())
                {
                    case "men":
                    case "women":
                        return "s"; // Senior
                    case "junior":
                        return "j";
                    case "cadet":
                        return "c";
                    default:
                        return "s";
                }
            }
        }

        public override string Round
        {
            get
            {
                // IJF round codes
                string round = GetJsonValue("Round", "");
                switch (round.ToUpper())
                {
                    case "R1":
                        return "1";  // Round 1
                    case "R2":
                        return "2";  // Round 2
                    case "QF":
                        return "Q";  // Quarter Final
                    case "SF":
                        return "S";  // Semi Final
                    case "BRZ":
                        return "B"; // Bronze
                    case "FNL":
                        return "F"; // Final
                    case "REP":
                        return "R"; // Repechage
                    default:
                        return round;
                }
            }
        }

        public override string ContestID
        {
            get
            {
                return GetJsonValue("ContestID", "0");
            }
        }

        public override string TimerFlag
        {
            get
            {
                return GetJsonValue("TimerFlag", "0");
            }
        }

        public override string TimerMinute
        {
            get
            {
                return GetJsonValue("TimerMinute", "0");
            }
        }

        public override string TimerSecond
        {
            get
            {
                string seconds = GetJsonValue("TimerSecond", "0");
                // Ensure two-digit format
                if (seconds.Length == 1)
                {
                    return "0" + seconds;
                }

                return seconds;
            }
        }

        public override string NationWhite
        {
            get
            {
                return GetJsonValue("NationWhite", "");
            }
        }

        public override string IDWhite
        {
            get
            {
                return GetJsonValue("IDWhite", "");
            }
        }

        public override string ShortNameWhite
        {
            get
            {
                return GetJsonValue("NameWhiteShort", "");
            }
        }

        public override string WorldRankingListPositionWhite
        {
            get
            {
                return GetJsonValue("WRLWhite", "0");
            }
        }

        public override string LongNameWhite
        {
            get
            {
                return GetJsonValue("NameWhiteLong", "");
            }
        }

        public override string IpponWhite
        {
            get
            {
                return GetJsonValue("IpponWhite", "0");
            }
        }

        public override string WazaAriWhite
        {
            get
            {
                return GetJsonValue("WazaWhite", "0");
            }
        }

        public override string YukoWhite
        {
            get
            {
                return GetJsonValue("YukoWhite", "0");
            }
        }

        public override string ShidoWhite
        {
            get
            {
                string penalty = GetJsonValue("PenaltyWhite", "0");
                string hansoku = GetJsonValue("HansokuMakeWhite", "0");

                // Check for Hansoku make
                if (hansoku == "1")
                {
                    return "H";
                }

                return penalty;
            }
        }

        public override string TimerOsaekomiWhite
        {
            get
            {
                string timer = GetJsonValue("TimerOsaeWhite", null);
                if (string.IsNullOrEmpty(timer) || timer == "null")
                {
                    return "00";
                }

                return timer;
            }
        }

        public override string TeamScoreWhite
        {
            get
            {
                return GetJsonValue("TeamScoreWhite", "0");
            }
        }

        public override string NationBlue
        {
            get
            {
                return GetJsonValue("NationBlue", "");
            }
        }

        public override string IDBlue
        {
            get
            {
                return GetJsonValue("IDBlue", "");
            }
        }

        public override string ShortNameBlue
        {
            get
            {
                return GetJsonValue("NameBlueShort", "");
            }
        }

        public override string WorldRankingListPositionBlue
        {
            get
            {
                return GetJsonValue("WRLBlue", "0");
            }
        }

        public override string LongNameBlue
        {
            get
            {
                return GetJsonValue("NameBlueLong", "");
            }
        }

        public override string IpponBlue
        {
            get
            {
                return GetJsonValue("IpponBlue", "0");
            }
        }

        public override string WazaAriBlue
        {
            get
            {
                return GetJsonValue("WazaBlue", "0");
            }
        }

        public override string YukoBlue
        {
            get
            {
                return GetJsonValue("YukoBlue", "0");
            }
        }

        public override string ShidoBlue
        {
            get
            {
                string penalty = GetJsonValue("PenaltyBlue", "0");
                string hansoku = GetJsonValue("HansokuMakeBlue", "0");

                // Check for Hansoku make
                if (hansoku == "1")
                {
                    return "H";
                }

                return penalty;
            }
        }

        public override string TimerOsaekomiBlue
        {
            get
            {
                string timer = GetJsonValue("TimerOsaeBlue", null);
                if (string.IsNullOrEmpty(timer) || timer == "null")
                {
                    return "00";
                }

                return timer;
            }
        }

        public override string TeamScoreBlue
        {
            get
            {
                return GetJsonValue("TeamScoreBlue", "0");
            }
        }

        public override string GoldenScore
        {
            get
            {
                bool goldenScore = GetJsonValue("GoldenScore", false);
                return goldenScore ? "1" : "0";
            }
        }

        public override string Winner
        {
            get
            {
                string winner = GetJsonValue("Winner", "");
                if (string.IsNullOrEmpty(winner))
                {
                    return "0";
                }

                // Convert to Protocol216 format
                switch (winner.ToUpper())
                {
                    case "WHITE":
                        return "W";
                    case "BLUE":
                        return "B";
                    default:
                        return "0";
                }
            }
        }

        public override string IDReferee
        {
            get
            {
                return GetJsonValue("IDReferee", "");
            }
        }

        public override string IDJudge1
        {
            get
            {
                return GetJsonValue("IDJudge1", "");
            }
        }

        public override string IDJudge2
        {
            get
            {
                return GetJsonValue("IDJudge2", "");
            }
        }

        public override string IDMat
        {
            get
            {
                return GetJsonValue("MatSending", "0");
            }
        }

        public bool IsPreMatch()
        {
            // IJF pre-match state
            return GetJsonValue("DisplayMode", "1") == "1" && string.IsNullOrEmpty(GetJsonValue("IDEvent", null));
        }

        public bool IsActiveMatch()
        {
            // IJF active match state
            return GetJsonValue("DisplayMode", "6") == "6" && !string.IsNullOrEmpty(GetJsonValue("IDEvent", null));
        }

        public bool IsMatchEnded()
        {
            // IJF match ended state
            return !string.IsNullOrEmpty(GetJsonValue("Winner", "")) &&
                   GetJsonValue("Winner", "") != "0";
        }

        public override string DisplayMode
        {
            get
            {
                string mode = GetJsonValue("DisplayMode", "6");

                // Map IJF numeric codes to your existing string values
                switch (mode)
                {
                    case "1":
                        return "1"; // Logo
                    case "2":
                        return "2"; // Contest Info
                    case "3":
                        return "3"; // White Info
                    case "4":
                        return "4"; // Blue Info
                    case "5":
                        return "5"; // Both Info
                    case "6":
                        return "6"; // Scoreboard (active match)
                    case "C":
                        return "C"; // Countdown
                    case "L":
                        return "L"; // Last Call
                    default:
                        return mode;
                }
            }
        }

        public override string OsaekomiTimerFlag
        {
            get
            {
                string flag = GetJsonValue("OsaekomiFlag", "0");

                // Convert to Protocol216 format if necessary
                switch (flag)
                {
                    case "0":
                        return "0";
                    case "1":
                        // Need to determine if it's White or Blue
                        // This might need additional logic based on your requirements
                        return "W";
                    case "2":
                        return "B";
                    default:
                        return flag;
                }
            }
        }

        public override string EndToken
        {
            get
            {
                // For compatibility - JSON doesn't have end tokens
                return "3";
            }
        }

        #endregion

        #region Constructors and Destructor

        public ProtocolJSON(string jsonData)
        {
            try
            {
                _JsonDocument = JsonDocument.Parse(jsonData);
                _RootElement = _JsonDocument.RootElement;
            }
            catch (JsonException ex)
            {
                throw new FormatException("Invalid JSON data", ex);
            }
        }

        public ProtocolJSON(byte[] data)
        {
            try
            {
                string jsonString = System.Text.Encoding.UTF8.GetString(data);
                _JsonDocument = JsonDocument.Parse(jsonString);
                _RootElement = _JsonDocument.RootElement;
            }
            catch (JsonException ex)
            {
                throw new FormatException("Invalid JSON data", ex);
            }
        }

        ~ProtocolJSON()
        {
            _JsonDocument?.Dispose();
        }

        #endregion

        #region Private Methods

        private string GetJsonValue(string propertyName, string defaultValue)
        {
            if (_RootElement.TryGetProperty(propertyName, out JsonElement element))
            {
                if (element.ValueKind == JsonValueKind.Null)
                {
                    return defaultValue;
                }

                switch (element.ValueKind)
                {
                    case JsonValueKind.String:
                        return element.GetString() ?? defaultValue;
                    case JsonValueKind.Number:
                        return element.GetRawText();
                    case JsonValueKind.True:
                        return "1";
                    case JsonValueKind.False:
                        return "0";
                    default:
                        return element.ToString();
                }
            }
            return defaultValue;
        }

        private bool GetJsonValue(string propertyName, bool defaultValue)
        {
            if (_RootElement.TryGetProperty(propertyName, out JsonElement element))
            {
                switch (element.ValueKind)
                {
                    case JsonValueKind.True:
                        return true;
                    case JsonValueKind.False:
                        return false;
                    case JsonValueKind.Number:
                        return element.GetInt32() != 0;
                    case JsonValueKind.String:
                        string value = element.GetString()?.ToLower() ?? "";
                        return value == "true" || value == "1";
                    default:
                        return defaultValue;
                }
            }
            return defaultValue;
        }

        #endregion

        #region Public Methods

        // Helper method to check if this is a scoreboard message (not a server info message)
        public bool IsScoreboardMessage()
        {
            // Check for required fields that indicate this is a scoreboard message
            return _RootElement.TryGetProperty("ProtoVer", out _) &&
                   _RootElement.TryGetProperty("DisplayMode", out _) &&
                   _RootElement.TryGetProperty("ContestID", out _) &&
                   _RootElement.TryGetProperty("MatSending", out _);
        }

        #endregion
    }
}