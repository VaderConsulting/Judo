using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using static Utilities.Extensions;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Print("123456 => " + "123456".Hash());
            Debug.Print("123457 => " + "123457".Hash());
            Debug.Print("12345A => " + "12345A".Hash());
            Debug.Print("12345B => " + "12345B".Hash());
            Debug.Print("12345C => " + "12345C".Hash());
            Debug.Print("12345D => " + "12345D".Hash());
            Debug.Print("1 => " + "1".Hash());
            Debug.Print("12 => " + "12".Hash());
            Debug.Print("123 => " + "123".Hash());
            Debug.Print("1234 => " + "1234".Hash());
            Debug.Print("9999 => " + "9999".Hash());
            Debug.Print("10000 => " + "10000".Hash());
            Debug.Print("11000 => " + "11000".Hash());
            Debug.Print("12000 => " + "12000".Hash());
            Debug.Print("12300 => " + "12300".Hash());
            Debug.Print("12310 => " + "12310".Hash());
            Debug.Print("12320 => " + "12320".Hash());
            Debug.Print("12330 => " + "12330".Hash());
            Debug.Print("12345 => " + "12345".Hash());
            Debug.Print("123456 => " + "123456".Hash());

            Debug.Print("Robinson, David => " + "Robinson, David".Hash());
            Debug.Print("robinson, david => " + "robinson, david".Hash());

            //TestString = "A,B,C,D,E,1,2,3,4,5,A1,A2,A3,A4,A5,1A,2B,3C,4D,5E";

            //Console.WriteLine("No Aplha" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.SimpleMethod.RemoveAlphaChars));
            //Console.WriteLine("No Numeric" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.SimpleMethod.RemoveNumericChars));
            //Console.WriteLine("Lowercase" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.SimpleMethod.Lowercase));
            //Console.WriteLine("Uppercase" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.SimpleMethod.Uppercase));

            //Console.WriteLine("Remove Char" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.RemoveChar, ","));
            //Console.WriteLine("Left of Char" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.LeftOfChar, ","));
            //Console.WriteLine("Right of Char" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.RightOfChar, ","));
            //Console.WriteLine("Switch Left two" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.SwitchLeftTwoValues, ","));
            //Console.WriteLine("Switch Right two" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.SwitchRightTwoValues, ","));
            //Console.WriteLine("Switch Left and Right" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.SwitchLeftAndRightValues, ","));
            //Console.WriteLine("First Value" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.FirstValue,","));
            //Console.WriteLine("Second Value" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.SecondValue, ","));
            //Console.WriteLine("Third Value" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.ThirdValue, ","));
            //Console.WriteLine("Left 2 values" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.LeftTwoValues, ","));
            //Console.WriteLine("Right 2 values" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.RightTwoValues, ","));

            //Console.WriteLine("Remove Left Chars (6)" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.LengthMethod.RemoveLeftChars, 6));
            //Console.WriteLine("Remove Right Chars (6)" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.LengthMethod.RemoveRightChars, 6));
            //Console.WriteLine("------------------------------------");

            //TestString = "1,2,3";

            //Console.WriteLine("No Aplha" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.SimpleMethod.RemoveAlphaChars));
            //Console.WriteLine("No Numeric" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.SimpleMethod.RemoveNumericChars));
            //Console.WriteLine("Lowercase" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.SimpleMethod.Lowercase));
            //Console.WriteLine("Uppercase" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.SimpleMethod.Uppercase));

            //Console.WriteLine("Remove Char" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.RemoveChar, ","));
            //Console.WriteLine("Left of Char" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.LeftOfChar, ","));
            //Console.WriteLine("Right of Char" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.RightOfChar, ","));
            //Console.WriteLine("Switch Left two" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.SwitchLeftTwoValues, ","));
            //Console.WriteLine("Switch Right two" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.SwitchRightTwoValues, ","));
            //Console.WriteLine("Switch Left and Right" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.SwitchLeftAndRightValues, ","));
            //Console.WriteLine("First Value" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.FirstValue, ","));
            //Console.WriteLine("Second Value" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.SecondValue, ","));
            //Console.WriteLine("Third Value" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.ThirdValue, ","));
            //Console.WriteLine("Left 2 values" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.LeftTwoValues, ","));
            //Console.WriteLine("Right 2 values" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.CharacterMethod.RightTwoValues, ","));

            //Console.WriteLine("Remove Left Chars (6)" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.LengthMethod.RemoveLeftChars, 6));
            //Console.WriteLine("Remove Right Chars (6)" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.LengthMethod.RemoveRightChars, 6));

            //Console.WriteLine("------------------------------------");

            //TestString = "ABCDEFGH";

            //Console.WriteLine("Remove Chars (3,2)" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.SubstringMethod.RemoveChars, 3, 2));
            //Console.WriteLine("Extract Chars (3,2)" + ":" + Utilities.Transform.ExecuteMethod(TestString, Transform.SubstringMethod.ExtractChars, 3, 2));

            //Console.ReadKey();
        }
    }
}
