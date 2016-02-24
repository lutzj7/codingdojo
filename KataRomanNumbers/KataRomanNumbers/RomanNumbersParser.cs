using System;
using System.Collections.Generic;

namespace KataRomanNumbers
{
    public class RomanNumbersParser
    {
        private Dictionary<char,int> romanMap = new Dictionary<char, int>();

        public RomanNumbersParser()
        {
            romanMap['I'] = 1;
            romanMap['V'] = 5;
            romanMap['X'] = 10;
            romanMap['L'] = 50;
            romanMap['C'] = 100;
            romanMap['D'] = 500;
            romanMap['M'] = 1000;
        }
        
        /// <summary>
        /// Parses a roman number
        /// </summary>
        /// <param name="romanNumberString">roman number to be converted</param>
        /// <returns>arabic number</returns>
        public int Parse(string romanNumberString)
        {
            int result = 0;
            int lastIndex = romanNumberString.Length - 1;
            int prev = 0;

            for (int i = lastIndex; i >= 0 ; i--)
            {
                int current = romanMap[romanNumberString[i]];
                                
                if (prev > current)
                {
                    result -= current;
                }
                else if (prev <= current)
                {
                    result += current;
                }

                prev = current;
            }

            return result;
        }
    }
}