using System.Diagnostics;

namespace FirstIteration.RomanToArabic
{
    public class RomanNumberConverter
    {
        public int RomanToIntiger(string roman)
        {
            roman = roman.ToUpper().Trim();

            new InputValidator(roman);

            int result = 0;
            int previousValue = 0;

            for (int i = roman.Length - 1; i >= 0; i--)
            {
                int currentValue = RomanNumberMap.GetValue(roman[i]);

                if (currentValue < previousValue)
                    result -= currentValue;
                else
                    result += currentValue;

                previousValue = currentValue;
            }
            return result;
        }
    }
}