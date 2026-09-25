using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJF
{

    [Serializable]
    public enum Function
    {
        Unknown = -1,
        Competitor,
        Judoka,
        Coach,
        Team_Official,
        Referee,
        Doctor,
        Medic,
        Physiotherapist,
        President,
        Vice_President,
        General_Secretary,
        Delegate,
        Staff,
        VIP,
        VVIP,
        Guest,
        Spectator,
        Head_Of_Organisation,
        Organisation_2,
        Organisation_3,
        Press,
        Press_Photo,
        Press_TV,
        Press_TV_Arena,
        Press_Journalist,
        Head_Of_Security,
        Security,
        Video_Team
    }

    [Serializable]
    public enum Gender
    {
        Unknown = -1,
        m = 0,
        w = 1
    }
}
