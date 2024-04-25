using FirstIteration.ArabicToRoman;
using FirstIteration.RomanToArabic;
using System;

namespace FirstIteration
{
    public class ConsoleUi
    {
        enum ConversionType
        {
            RomanToArabic,
            ArabicToRoman,
            Quit
        }

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
            ConversionType choice = GetConversationChoice();

            switch (choice)
            {
                case ConversionType.RomanToArabic:
                    ConvertAndPrint(PrintRomanOutput);
                    return true;
                case ConversionType.ArabicToRoman:
                    ConvertAndPrint(PrintArabicOutput);
                    return true;
                case ConversionType.Quit:
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
                    var roman = ArabicNumberConverter.ArabicToRoman(arabicInt);
                    PrintOriginalAndCalculatedNumbers(arabicNumeral, roman);
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
                var arabicInt = new RomanNumberConverter().RomanToIntiger(romanNumeral);
                PrintOriginalAndCalculatedNumbers(arabicInt.ToString(), romanNumeral);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during conversion: {ex.Message}");
            }
        }

        private static ConversionType GetConversationChoice()
        {
            Console.Write("Choose conversion type (R/A/Q): ");
            string input = Console.ReadLine().ToUpper();
            switch (input)
            {
                case "R": return ConversionType.RomanToArabic;
                case "A": return ConversionType.ArabicToRoman;
                case "Q": return ConversionType.Quit;
                default: throw new ArgumentException("Invalid input. Please select R, A, or Q.");
            }
        }

        private static void PrintOriginalAndCalculatedNumbers(string arabicNumeral, string roman)
        {
            Console.WriteLine($"Roman numeral: {roman}");
            Console.WriteLine($"Integer value: {arabicNumeral}");
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
