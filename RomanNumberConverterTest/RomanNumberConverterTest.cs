using FirstIteration;
using FirstIteration.RomanToArabic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FirstIterationTets
{
    [TestClass]
    public class RomanNumberConverterTest
    {
        //private TestContext testContextInstance;
        //public TestContext TestContext
        //{
        //    get { return testContextInstance; }
        //    set { testContextInstance = value; }
        //}


        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\output.csv", "output#csv", DataAccessMethod.Sequential), DeploymentItem("output.csv"), TestMethod]
        //public void AddIntegers_FromDataSourceTest()
        //{
        //    string asd = TestContext.DataRow["ValueOne"].ToString();
        //}

        [TestMethod]
        public void RomanToIntiger_ValidInput_ReturnsNoError()
        {
            string user_input = "MMCCCLXV";
            int expected = 2365;

            int result = new RomanNumberConverter().RomanToIntiger(user_input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RomanToIntiger_LowerCaseInput_ReturnsNoError()
        {
            string user_input = "mmccclxv";
            int expected = 2365;

            int result = new RomanNumberConverter().RomanToIntiger(user_input);

            Assert.AreEqual(expected, result);
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
            int expected = 5;

            int result = new RomanNumberConverter().RomanToIntiger(user_input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RomanToIntiger_WhiteSpacesPlusValidInput_ReturnsNoError()
        {
            string user_input = " V";
            int expected = 5;

            int result = new RomanNumberConverter().RomanToIntiger(user_input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RomanToIntiger_LotsOfWhiteSpacesBeforeAndAfterButValidInput_ReturnsNoError()
        {
            string user_input = "   MMMCMXCIX   ";
            
            int expected = 3999;

            int result = new RomanNumberConverter().RomanToIntiger(user_input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumeralSequenceException))]
        public void RomanToIntiger_BiggestNumberInput_ReturnsInvalidRomanNumeralSequenceException()
        {
            string user_input = "MMMDCDLXLVIV";            

            new RomanNumberConverter().RomanToIntiger(user_input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RomanToIntiger_WhiteSpacesInput_ReturnsArgumentException()
        {
            string user_input = "    ";            

            new RomanNumberConverter().RomanToIntiger(user_input);
        }

        [TestMethod]
        public void RomanToIntiger_NinihundredRomanInput_ReturnsNoError()
        {
            string user_input = "CM";
            int expected = 900;

            int result = new RomanNumberConverter().RomanToIntiger(user_input);

            Assert.AreEqual(expected, result);
        }







    }

}