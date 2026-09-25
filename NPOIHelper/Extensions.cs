using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;

namespace NPOIHelper
{
    public static class Extensions
    {
        public static void SetCellValue(this ISheet Sheet, int Column, int Row, string Value)
        {
            IRow NewRow = Sheet.AddRow(Row);

            if (Value == null)
            {
                Value = "";
            }

            try
            {
                NewRow.GetCell(Column, MissingCellPolicy.CREATE_NULL_AS_BLANK).SetCellValue(Value);
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
            }
        }

        public static void SetCellValue(this ISheet Sheet, int Column, int Row, int Value)
        {
            IRow NewRow = Sheet.AddRow(Row);

            try
            {
                NewRow.GetCell(Column, MissingCellPolicy.CREATE_NULL_AS_BLANK).SetCellValue(Value);
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
            }
        }

        public static void SetCellValue(this ISheet Sheet, int Column, int Row, double Value)
        {
            IRow NewRow = Sheet.AddRow(Row);

            try
            {
                NewRow.GetCell(Column, MissingCellPolicy.CREATE_NULL_AS_BLANK).SetCellValue(Value);
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
            }
        }

        public static void SetCellValue(this ISheet Sheet, int Column, int Row, bool Value)
        {
            IRow NewRow = Sheet.AddRow(Row);

            try
            {
                NewRow.GetCell(Column, MissingCellPolicy.CREATE_NULL_AS_BLANK).SetCellValue(Value);
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
            }
        }

        public static void SetCellValue(this ISheet Sheet, int Column, int Row, DateTime Value)
        {
            IRow NewRow = Sheet.AddRow(Row);

            try
            {
                NewRow.GetCell(Column, MissingCellPolicy.CREATE_NULL_AS_BLANK).SetCellValue(Value);
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
            }
        }

        public static IRow AddRow(this ISheet Sheet, int Row)
        {
            IRow Result = null;

            Result = Sheet.GetRow(Row);

            if (Result == null)
            {
                try
                {
                    Result = Sheet.CreateRow(Row);
                }
                catch (Exception e)
                {
                    Debug.Print(e.ToString());
                }
            }

            return Result;
        }

        //public static IRow CreateRow(ISheet Sheet, int Row)
        //{
        //    IRow Result = null;

        //    Result = Sheet.GetRow(Row);

        //    if (Result == null)
        //    {
        //        Result = Sheet.CreateRow(Row);
        //    }

        //    return Result;
        //}
    }
}
