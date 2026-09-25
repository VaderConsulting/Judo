using Judo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace EuroJudo
{
    [Serializable]
    public class ComparisonResult
    {
        public string SourceValue = "";
        public int ValueIndex = -1;
        //public string ObjectString = "";
        public double Percentage = 0.0;
        public object Value = null;
        public DataColumnType MapType = DataColumnType.Unknown;
        public bool Manual = false;
        public Transform.MethodType TransformMethod = Transform.MethodType.None;
        public string[] TransformParameters = { };

        public ComparisonResult()
        {
        }

        //public ComparisonResult(string ValueString, int ValueIndex, string ObjectString, double Percentage, Column MapType, object Value, bool Manual, Transform.MethodType TransformMethod, string[] TransformParameters)
        //{
        //    this.ValueString = ValueString;
        //    this.ValueIndex = ValueIndex;
        //    this.ObjectString = ObjectString;
        //    this.Percentage = Percentage;
        //    this.Value = Value;
        //    this.MapType = MapType;
        //    this.Manual = Manual;
        //    this.TransformMethod = TransformMethod;
        //    this.TransformParameters = TransformParameters;
        //}

        public ComparisonResult(string SourceValue, int ValueIndex, double Percentage, DataColumnType MapType, object Value, bool Manual, Transform.MethodType TransformMethod, string[] TransformParameters)
        {
            this.SourceValue = SourceValue;
            this.ValueIndex = ValueIndex;
            //this.ObjectString = ObjectString;
            this.Percentage = Percentage;
            this.Value = Value;
            this.MapType = MapType;
            this.Manual = Manual;
            this.TransformMethod = TransformMethod;
            this.TransformParameters = TransformParameters;
        }
    }
}
