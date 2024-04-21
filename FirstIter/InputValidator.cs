﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstIteration
{
    public class InputValidator
    {
        private string inputRoman;
        public InputValidator(string input) 
        {
            inputRoman = input;
            RomanInputValidator();
        }

        private void RomanInputValidator()
        {
            if (string.IsNullOrEmpty(inputRoman))
                throw new ArgumentException("Input cannot be null or empty.", nameof(inputRoman));

            inputRoman = inputRoman.ToUpper();
            ValidateRomanNumerals();
            ValidateRepetition();
        }

        private void ValidateRomanNumerals()
        {
            for (int i = 0; i < inputRoman.Length; i++)
            {
                if (!RomanNumberMap.Contains(inputRoman[i]))
                    throw new InvalidRomanNumberalException($"Invalid character in Roman numeral: {inputRoman[i]}");

                if (i + 1 < inputRoman.Length && !RomanNumberMap.IsValidPrecedence(inputRoman[i], inputRoman[i + 1]))
                    throw new InvalidRomanNumeralSequenceException($"Invalid numeral sequence: {inputRoman[i]}{inputRoman[i + 1]}");

                if (i + 2 < inputRoman.Length)
                {
                    char current = inputRoman[i];
                    char next = inputRoman[i + 1];
                    char nextNext = inputRoman[i + 2];

                    if (RomanNumberMap.GetValue(current) == RomanNumberMap.GetValue(next) &&
                        RomanNumberMap.GetValue(next) < RomanNumberMap.GetValue(nextNext))
                    {
                        throw new InvalidRomanNumeralSequenceException($"Invalid numeral sequence involving incorrect subtraction: {current}{next}{nextNext}");
                    }
                }
            }
        }


        private void ValidateRepetition()
        {
            char previousChar = '\0';
            int counter = 0;

            foreach (char c in inputRoman)
            {
                if (c == previousChar)
                    counter++;
                else
                {

                    if (counter > 1 && (previousChar == 'V' || previousChar == 'L' || previousChar == 'D'))
                        throw new ExcessiveRepetitionException($"Invalid Roman numeral: {previousChar} cannot be repeated.");

                    if (counter > 3)
                        throw new ExcessiveRepetitionException("Invalid Roman numeral: A character repeats more than three times consecutively.");

                    previousChar = c;
                    counter = 1;
                }

                if (counter > 1 && (previousChar == 'V' || previousChar == 'L' || previousChar == 'D'))
                    throw new ExcessiveRepetitionException($"Invalid Roman numeral: {previousChar} cannot be repeated.");


                if (counter > 3)                
                    throw new ExcessiveRepetitionException("Invalid Roman numeral: A character repeats more than three times consecutively.");                
            }
        }




    }
}