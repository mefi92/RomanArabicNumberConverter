using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstIteration.RomanToArabic
{
    public class RomanNumberMap
    {
        private static readonly Dictionary<char, int> romanValues = new Dictionary<char, int>() {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };


        public static bool Contains(char numeral)
        {
            return romanValues.ContainsKey(numeral);
        }

        public static int GetValue(char numeral)
        {
            if (romanValues.TryGetValue(numeral, out int value))
                return value;

            throw new InvalidRomanNumberalException($"Invalid Roman numeral character: {numeral}");
        }

        public static bool IsValidPrecedence(char current, char next)
        {
            if (!romanValues.ContainsKey(current) || !romanValues.ContainsKey(next))
                return false;

            int currentValue = romanValues[current];
            int nextValue = romanValues[next];


            if (currentValue < nextValue)
            {
                return current == 'I' && (next == 'V' || next == 'X') ||
                       current == 'X' && (next == 'L' || next == 'C') ||
                       current == 'C' && (next == 'D' || next == 'M');
            }

            return currentValue >= nextValue;
        }
    }
}
