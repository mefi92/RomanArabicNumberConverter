using System.Diagnostics;

namespace FirstIteration
{
    public class RomanNumberConverter
    {
        static void Main(string[] args)
        {
           /* string example1 = "MMCCCLXV"; // 2365
            string example2 = "XLV"; // 45
            int result1 = RomanToIntiger(example1);
            int result2 = RomanToIntiger(example2);
            Console.WriteLine(result1.ToString());
            Console.WriteLine(result2.ToString());*/

            RomanToIntPrinter();
        }

        private static void RomanToIntPrinter()
        {
            string userInput = AskForUserInput();
            PrintOutput(userInput);
        }

        private static void PrintOutput(string romanNumeral) 
        {
            int integerValue = RomanToIntiger(romanNumeral);
            Console.WriteLine("Roman numeral: " + romanNumeral);
            Console.WriteLine("Integer value: " + integerValue);
        }

        private static string AskForUserInput()
        {
            Console.Write("Enter roman number to convert: ");
            return Console.ReadLine();
        }

        private static int RomanToIntiger(string roman)
        {
            Dictionary<char, int> romanMap = new Dictionary<char, int>() {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
            };

            int result = 0;
            int previousValue = 0;

            for (int i = roman.Length - 1; i >= 0; i--)
            {
                int currentValue = romanMap[roman[i]];
                
                if (currentValue < previousValue)
                {
                    result -= currentValue;
                }
                else
                {
                    result += currentValue;
                }

                previousValue = currentValue;
            }
            return result;            
        }
    }

}