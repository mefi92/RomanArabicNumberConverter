using FirstIteration;

namespace FirstIterationTets
{
    [TestClass]
    public class RomanNumberConverterTest
    {
        [TestMethod]
        public void RomanToIntiger_ValidInput_ReturnsNoError()
        {
            string user_input = "MMCCCLXV";

            int result = new RomanNumberConverter().RomanToIntiger(user_input);

            Assert.AreEqual(2365, result);
        }

        [TestMethod]
        public void RomanToIntiger_LowerCaseInput_ReturnsNoError()
        {
            string user_input = "mmccclxv";

            int result = new RomanNumberConverter().RomanToIntiger(user_input);

            Assert.AreEqual(2365, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumberalException))]
        public void RomanToIntiger_ValidatorCall_NonRomanCharInput_ReturnsInvalidRomanNumberalException()
        {
            string user_input = "a";
            new RomanNumberConverter().RomanToIntiger(user_input);         
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumeralSequenceException))]
        public void RomanToIntiger_InvalidRomanSequenceInput_ReturnsInvalidRomanNumeralSequenceException()
        {
            string user_input = "iiv";

            int result = new RomanNumberConverter().RomanToIntiger(user_input);

            Assert.AreEqual(5, result);
        }






        //[TestMethod]
        //[ExpectedException(typeof(Exception))]
        //public void RomanToIntiger_InvalidRomanNumber_Excpetion()
        //{
        //    string user_input = "iiii";

        //    new RomanNumberConverter().RomanToIntiger(user_input);           
        //}

        //[TestMethod]
        //[ExpectedException(typeof(Exception))]
        //public void RomanToIntiger_InvalidRomanNumber_Excpetiona()
        //{
        //    string user_input = "vv";

        //    new RomanNumberConverter().RomanToIntiger(user_input);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(Exception))]
        //public void RomanToIntiger_InvalidRomanNumber_Excpetionb()
        //{
        //    string user_input = "vx";

        //    new RomanNumberConverter().RomanToIntiger(user_input);
        //}
    }

}