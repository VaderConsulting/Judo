using Scoreboard;

using System;
using System.Diagnostics;
using System.Text.Json;

using Utilities;

using static Utilities.Enums;
using static Utilities.ScoreboardData;

public class ProtocolFactory : IProtocolFactory
{

    #region Private Methods

    private string DetermineMessageType(JsonElement root)
    {
        if (root.TryGetProperty("Publisher", out JsonElement publisher))
        {
            string publisherValue = publisher.GetString();

            if (publisherValue == "SERVER" && root.TryGetProperty("CompetitionName", out _))
            {
                return "Server Status";
            }

            if (publisherValue == "SCOREBOARD" && root.TryGetProperty("MatId", out _))
            {
                return "Scoreboard Configuration";
            }

            if (publisherValue == "JUDONET")
            {
                return "JudoNet Message";
            }
        }

        return "Unknown";
    }

    private bool IsIJFScoreboardMessage(JsonElement root)
    {
        // IJF scoreboard messages must have these fields
        return root.TryGetProperty("ProtoVer", out _) &&
               root.TryGetProperty("ContestID", out _) &&
               root.TryGetProperty("DisplayMode", out _) &&
               root.TryGetProperty("MatSending", out _);
    }

    private bool IsJsonData(byte[] data)
    {
        return data.Length > 0 && data[0] == '{';
    }

    #endregion

    #region Public Methods

    public IScoreboardProtocol CreateProtocol(byte[] data)
    {
        if (IsJsonData(data))
        {
            string jsonString = System.Text.Encoding.UTF8.GetString(data);
            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                JsonElement root = doc.RootElement;

                // IJF Scoreboard message detection
                if (IsIJFScoreboardMessage(root))
                {
                    return (IScoreboardProtocol)new ProtocolJSON(data);
                }

                // Log but don't throw for non-scoreboard messages
                string messageType = DetermineMessageType(root);
                Debug.WriteLine($"Non-scoreboard message received: {messageType}");
                //throw new InvalidOperationException($"Not a scoreboard data message: {messageType}");
                return null;
            }
        }
        else
        {
            // Legacy 216-byte protocol
            return (IScoreboardProtocol)new Protocol216(data);
        }
    }

    #endregion
}
