using FirstIteration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstIterationTest
{
    [TestClass]
    public class InputValidatorTest
    {
        [TestMethod]
        public void InputValidator_ValidInput_ReturnsNoException()
        {
            string input = "MMCCCLXV";

            new InputValidator(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcessiveRepetitionException))]
        public void InputValidator_InvalidRepetition_ReturnsExcessiveRepetitionException()
        {
            string input = "MMMMCCCLXV";

            new InputValidator(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcessiveRepetitionException))]
        public void InputValidator_InvalidRomanNumbers_ReturnsInvalidRomanNumberalException()
        {
            string input = "LLL";

            new InputValidator(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumeralSequenceException))]
        public void InputValidator_InvalidTwoOnesBeforeFive_ReturnsInvalidRomanNumberalException()
        {
            string input = "IIV";

            new InputValidator(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcessiveRepetitionException))]
        public void InputValidator_InvalidFourOnes_ReturnsExcessiveRepetitionException()
        {
            string input = "IIII";

            new InputValidator(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcessiveRepetitionException))]
        public void InputValidator_InvalidTwoFives_ReturnsExcessiveRepetitionException()
        {
            string input = "VV";

            new InputValidator(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumeralSequenceException))]
        public void InputValidator_InvalidFiveBeforeTen_ReturnsInvalidRomanNumeralSequenceException()
        {
            string input = "VX";

            new InputValidator(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumeralSequenceException))]
        public void InputValidator_InvalidFiftyBeforeHundred_ReturnsInvalidRomanNumeralSequenceException()
        {
            string input = "LC";

            new InputValidator(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumeralSequenceException))]
        public void InputValidator_InvalidFiveOneFive_ReturnsInvalidRomanNumeralSequenceException()
        {
            string input = "VIV";

            new InputValidator(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumeralSequenceException))]
        public void InputValidator_InvalidFiftyTenFifty_ReturnsInvalidRomanNumeralSequenceException()
        {
            string input = "LXL";

            new InputValidator(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputValidator_EmptyStringInput_ReturnsArgumentException()
        {
            string input = "";

            new InputValidator(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumeralSequenceException))]
        public void InputValidator_InvalidOneFiveOne_ReturnsInvalidRomanNumeralSequenceException()
        {
            string input = "IVI";

            new InputValidator(input);
        }
    }
}
