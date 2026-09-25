using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer
{
    public enum Sex
    {
        Unknown = -1,
        Male = 0,
        M = 0,
        Female = 1,
        F = 1,
        Other = 2
    }

    public enum EuroJudoMappingType
    {
        Unknown,
        Event,
        WeightCategory,
        Club
    }
}
