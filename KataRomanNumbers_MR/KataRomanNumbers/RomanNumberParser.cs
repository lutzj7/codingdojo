using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataRomainNumberParser
{
    public class RomanNumberParser
    {
        public int Parse(string romanNumber)
        {
            int totalVal = 0;
            int previousVal = 0;

            foreach (char c in romanNumber.ToUpper())
            {
                int currentVal = GetDecimalValue(c);

                if (previousVal > 0 && previousVal < currentVal)
                {
                    totalVal += ValidateAndSubstractValues(currentVal, previousVal);
                    previousVal = 0;
                }
                else
                {
                    totalVal += previousVal;
                    previousVal = currentVal;
                }
            }

            totalVal += previousVal;

            return totalVal;
        }

        private int ValidateAndSubstractValues(int currentVal, int previousVal)
        {
            if (currentVal/previousVal > 10)
            {
                throw new ArgumentException();
            }
            
            var result =  currentVal - previousVal;

            if (result == previousVal)
            {
                throw new ArgumentException();
            }

            return result;  
        }

        private int GetDecimalValue(char c)
        {
            switch (c)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
