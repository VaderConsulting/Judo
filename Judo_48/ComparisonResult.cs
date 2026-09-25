using Judo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Judo
{
    [Serializable]
    public class ComparisonResult : IEquatable<ComparisonResult>
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

        public ComparisonResult(string SourceValue, int ValueIndex, double Percentage, object MapType, object Value, bool Manual, Transform.MethodType TransformMethod, string[] TransformParameters)
        {
            this.SourceValue = SourceValue;
            this.ValueIndex = ValueIndex;
            //this.ObjectString = ObjectString;
            this.Percentage = Percentage;
            this.Value = Value;
            this.MapType = (DataColumnType)MapType;
            this.Manual = Manual;
            this.TransformMethod = TransformMethod;
            this.TransformParameters = TransformParameters;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ComparisonResult);
        }

        public bool Equals(ComparisonResult other)
        {
            return other != null &&
                   SourceValue == other.SourceValue &&
                   ValueIndex == other.ValueIndex &&
                   Percentage == other.Percentage &&
                   EqualityComparer<object>.Default.Equals(Value, other.Value) &&
                   MapType == other.MapType &&
                   Manual == other.Manual &&
                   TransformMethod == other.TransformMethod &&
                   EqualityComparer<string[]>.Default.Equals(TransformParameters, other.TransformParameters);
        }

        public override int GetHashCode()
        {
            int hashCode = -1997728041;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SourceValue);
            hashCode = hashCode * -1521134295 + ValueIndex.GetHashCode();
            hashCode = hashCode * -1521134295 + Percentage.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<object>.Default.GetHashCode(Value);
            hashCode = hashCode * -1521134295 + MapType.GetHashCode();
            hashCode = hashCode * -1521134295 + Manual.GetHashCode();
            hashCode = hashCode * -1521134295 + TransformMethod.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string[]>.Default.GetHashCode(TransformParameters);
            return hashCode;
        }
    }
}
