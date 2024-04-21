﻿using System;

namespace FirstIteration
{
    public class ConsoleUi
    {
        static void Main(string[] args)
        {
            RomanToIntPrinter();
        }

        private static void RomanToIntPrinter()
        {
            bool isExiting = false;
            string userInput;

            while (!isExiting)
            {
                userInput = AskForUserInput();
                if (string.IsNullOrEmpty(userInput) || userInput.Trim().ToUpper() == "Q")
                    isExiting = true;
                else
                    PrintOutput(userInput.Trim());
            }
        }

        private static void PrintOutput(string romanNumeral)
        {
            try
            {
                int integerValue = new RomanNumberConverter().RomanToIntiger(romanNumeral);
                Console.WriteLine($"Roman numeral: {romanNumeral}");
                Console.WriteLine($"Integer value: {integerValue}");
            }
            catch (InvalidRomanNumberalException ex)
            {
                Console.WriteLine("Invalid input: " + ex.Message);
            }
            catch (InvalidRomanNumeralSequenceException ex)
            {
                Console.WriteLine("Invalid sequence: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during conversion: " + ex.Message);
            }
        }

        private static string AskForUserInput()
        {
            Console.Write("Enter Roman numeral to convert or Q to quit: ");
            return Console.ReadLine();
        }
    }
}