using System;
using System.Collections.Generic;
using System.Linq;

namespace ToRomanNumerals
{
    public class ToRomanNumerals
    {
        public string Generate(int decimalNumber)
        {
            string result = "";
            SortedDictionary<int, string> romanDic = new SortedDictionary<int, string>()
            {
                {1000, "M"},
                {900, "CM"},
                {500, "D"},
                {400, "CD"},
                {100, "C"},
                {90, "XC"},
                {50, "L"},
                {40, "XL"},
                {10, "X"},
                {9, "IX"},
                {5, "V"},
                {4, "IV"},
                {1, "I"}
            };

            int current = decimalNumber;

            while (current > 0)
            {
                foreach (var item in romanDic.Reverse())
                {
                    if (current >= item.Key)
                    {
                        current -= item.Key;
                        result += item.Value;
                        break;
                    }
                }
            }
            //int tmpDecimalNumber = decimalNumber;
            //while (tmpDecimalNumber > 0)
            //{
            //    for (int i = romanDic.Values.Count - 1; i >= 0; i--)
            //    {
            //        if (romanDic.Keys.ToList()[i] == Math.Abs(tmpDecimalNumber))
            //        {
            //            result += romanDic.Values.ToList()[i];
            //            tmpDecimalNumber -= romanDic.Keys.ToList()[i];
            //        }
            //        else if (romanDic.Keys.ToList()[i] < Math.Abs(tmpDecimalNumber))
            //        {
            //            if (romanDic.Keys.Count < i)
            //            {
            //                result += romanDic.Values.ToList()[i + 1];
            //                tmpDecimalNumber -= romanDic.Keys.ToList()[i];
            //            }
            //        }

            //    }
            //}
            

            //while (decimalNumber > 0)
            //{
            //    if (decimalNumber > 8 && decimalNumber <= 10)
            //    {
            //        result += "X";
            //        int dn = decimalNumber;
            //        decimalNumber -= 10;

            //        if (10 - dn > 0)
            //        {
            //            result = 'I' + result;
            //            decimalNumber += 1;
            //        }

            //    }
            //    else if (decimalNumber == 5)
            //    {
            //        result = "V";
            //        decimalNumber -= 5;
            //    }
            //    else if (decimalNumber == 4)
            //    {
            //        result = "IV";
            //        decimalNumber -= 4;
            //    }
            //    else if (decimalNumber < 4)
            //    {
            //        result = result + "I" ;
            //        decimalNumber -= 1;
            //    }
            //}

            return result;
        }
    }
}