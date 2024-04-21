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
            string input = "lll";

            new InputValidator(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumeralSequenceException))]
        public void InputValidator_InvalidTwoOnesBeforeFive_ReturnsInvalidRomanNumberalException()
        {
            string input = "IIV";

            new InputValidator(input);
        }


    }
}
