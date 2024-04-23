using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FirstIteration.ArabicToRoman
{
    public class ArabicNumberConverter
    {
        public static string ArabicToRoman(int num)
        {
            if (num < 0 || num > 3999)
                throw new ArgumentException();

            var roman = new StringBuilder();

            foreach (var item in ArabicNumberMap.arabicValues)
            {
                while (num >= item.Key) 
                {
                    roman.Append(item.Value);
                    num -= item.Key;
                }
            }

            return roman.ToString();
        }
    }
}
