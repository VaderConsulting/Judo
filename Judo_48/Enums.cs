using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Judo
{
    [Serializable]
    public enum Grade
    {
        None = -1,
        White = 0,
        WhiteYellow,
        Yellow,
        YellowOrange,
        Orange,
        OrangeGreen,
        Green,
        GreenBlue,
        Blue,
        BlueBrown,
        Brown,
        Black1stDan,
        Black2ndDan,
        Black3rdDan,
        Black4thDan,
        Black5thDan,
        Black6thDan,
        Black7thDan,
        Black8thDan,
        Black9thDan,
        Black10thDan
    }

    [Serializable]
    public enum DataColumnType
    {
        Unknown = -1,
        FirstName,
        Surname,
        DateOfBirth,
        Gender,
        MemberID,
        Club,
        EuroJudo_Event,
        EuroJudo_WeightCategory,
        IJF_WeightCategory,
        EuroJudo_Belt,
        EuroJudo_Function,
        IJF_Function,
        IJF_Photo
    }

    [Serializable]
    public enum Gender
    {
        Unknown = -1,
        Male,
        Female
    }
}
