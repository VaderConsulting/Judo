using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer
{
    public class EuroJudoComparisonResult
    {
        public string ValueString = "";
        public int ValueIndex = -1;
        public string ObjectString = "";
        public double Percentage = 0.0;
        public object Value = null;
        public EuroJudoMappingType MapType = EuroJudoMappingType.Unknown;
        public bool Manual = false;

        public EuroJudoComparisonResult()
        {
        }

        public EuroJudoComparisonResult(string ValueString, int ValueIndex, string ObjectString, double Percentage, EuroJudoMappingType MapType, object Value, bool Manual)
        {
            this.ValueString = ValueString;
            this.ValueIndex = ValueIndex;
            this.ObjectString = ObjectString;
            this.Percentage = Percentage;
            this.Value = Value;
            this.MapType = MapType;
            this.Manual = Manual;
        }
    }
}
