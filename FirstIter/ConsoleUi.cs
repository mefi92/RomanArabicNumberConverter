using FirstIteration.ArabicToRoman;
using FirstIteration.RomanToArabic;
using System;

namespace FirstIteration
{
    public class ConsoleUi
    {
        static void Main(string[] args)
        {
            while (true)
            {
                DisplayInputSelection();
                if (!ConverterSelector())
                    break;
            }
        }

        private static bool ConverterSelector()
        {
            string userInput = AskForConverterChoice();

            switch (userInput.ToUpper())
            {
                case "R":
                    ConvertAndPrint(PrintRomanOutput);
                    return true;
                case "A":
                    ConvertAndPrint(PrintArabicOutput);
                    return true;
                case "Q":
                    return false;
                default:
                    Console.WriteLine("Invalid choice. Please select R, A, or Q.");
                    return true;
            }
        }

        private static void DisplayInputSelection()
        {
            Console.WriteLine("What do you want to convert?");
            Console.WriteLine("Roman -> Arabic (R)");
            Console.WriteLine("Arabic -> Roman (A)");
            Console.WriteLine("Exit (Q)");
        }

        private static void ConvertAndPrint(Action<string> converterType)
        {
            string converterName = GetConverterName(converterType);

            Console.WriteLine($"Enter {converterName} numeral to convert or Q to quit:");
            while (true)
            {
                string userInput = Console.ReadLine().Trim().ToUpper();
                if (userInput == "Q")
                    break;
                converterType(userInput);
            }
        }        

        private static void PrintArabicOutput(string arabicNumeral)
        {
            if (int.TryParse(arabicNumeral, out int arabicInt))
                try
                {
                    string roman = ArabicNumberConverter.ArabicToRoman(arabicInt);
                    Console.WriteLine($"Roman numeral: {roman}");
                    Console.WriteLine($"Integer value: {arabicNumeral}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during conversion: {ex.Message}");
                }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Arabic number.");
            }
        }

        private static void PrintRomanOutput(string romanNumeral)
        {
            try
            {
                int integerValue = new RomanNumberConverter().RomanToIntiger(romanNumeral);
                Console.WriteLine($"Roman numeral: {romanNumeral}");
                Console.WriteLine($"Integer value: {integerValue}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during conversion: {ex.Message}");
            }
        }

        private static string AskForConverterChoice()
        {
            Console.Write("Choose conversion type (R/A/Q): ");
            return Console.ReadLine();
        }

        private static string GetConverterName(Action<string> converterType)
        {
            string converterName;
            if (converterType == PrintRomanOutput)
                converterName = "Roman";
            else
                converterName = "Arabic";
            return converterName;
        }
    }
}
