using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroJudo
{
    [Serializable]
    public enum Gender
    {
        Unknown = -1,
        M = 0,
        F = 1
    }

    [Serializable]
    public enum Function
    {
        Unknown = -1,
        Competitor,
        Referee,
        Coach,
        Team_Official,
        Medic,
        Press,
        EJU_VIP,
        Organizer

    }
}
