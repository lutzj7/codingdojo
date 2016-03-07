using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataRomainNumberParser
{
    public class RomanNumberGenerator
    {

        private class RomanLetterItem
        {
            public char Letter { get; set; }
            public int DecimalValue { get; set; }
        }

        private static List<RomanLetterItem> _romanLetterValues = new List<RomanLetterItem>()
        {
            new RomanLetterItem() { Letter = 'M', DecimalValue = 1000 },
            new RomanLetterItem() { Letter = 'D', DecimalValue = 500 },
            new RomanLetterItem() { Letter = 'C', DecimalValue = 100 },
            new RomanLetterItem() { Letter = 'L', DecimalValue = 50 },
            new RomanLetterItem() { Letter = 'X', DecimalValue = 10 },
            new RomanLetterItem() { Letter = 'V', DecimalValue = 5 },
            new RomanLetterItem() { Letter = 'I', DecimalValue = 1 },
        };

        public string Generate(int number)
        {
            StringBuilder strBuilder = new StringBuilder();

            int initialValue = number;

            int startAt = 0;
            while (initialValue > 0)
            {
                for (int i = startAt; i < _romanLetterValues.Count; ++i)
                {
                    var item = _romanLetterValues[i];
                    int value = initialValue;

                    if (TryRomanValue(ref initialValue, item, strBuilder))
                    {
                        startAt = i;
                        break;
                    };
                }
            }

            return strBuilder.ToString();
        }

        private bool TryRomanValue(ref int currentValue, RomanLetterItem letterItem, StringBuilder sb)
        {
            int currentValueOrder = GetOrder(currentValue);
            int valueOfOrder = currentValue / currentValueOrder * currentValueOrder;

            int substractedValue = valueOfOrder - letterItem.DecimalValue;

            if (substractedValue >= 0)
            {
                sb.Append(letterItem.Letter);
                currentValue = currentValue - letterItem.DecimalValue;
                return true;
            }
            else
            {
                var differenceValue = _romanLetterValues.FirstOrDefault(p => p.DecimalValue == Math.Abs(substractedValue));

                if (differenceValue != null)
                {
                    int differenceValueOrder = GetOrder(differenceValue.DecimalValue);

                    // 5 - 10 = 5 != VX                                  99 = 90 (100-10) + 9 NICHT 100 - 1 
                    if (differenceValue.DecimalValue != currentValue && currentValueOrder == differenceValueOrder)
                    {
                        sb.Append(differenceValue.Letter);
                        sb.Append(letterItem.Letter);
                        currentValue = currentValue - (letterItem.DecimalValue - differenceValue.DecimalValue);
                        return true;
                    }
                }

                return false;
            }
        }

        private int GetOrder(int currentValue)
        {
            int order = 1000;

            while (order > 0)
            {
                int result = currentValue / order;
                if (result > 0)
                    return order;

                order /= 10;
            }

            return order;
        }
    }
}
