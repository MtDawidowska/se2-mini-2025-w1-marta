using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YourNamespace
{

    [TestClass]
    public class YourTests
    {
        private YourClass _yourClass = null!;

        [TestInitialize]
        public void Setup()
        {
            _yourClass = new YourClass();
        }

        [TestMethod]
        public void TestCalc_WhenAIsEmpty_ShouldReturnZero()
        {
            // Given
            string a = "";

            // When
            int result = _yourClass.Calc(a);

            // Then
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestCalc_SingleNumber_ReturnsValue()
        {
            // Given
            string a = "123";

            // When
            int result = _yourClass.Calc(a);

            // Then
            Assert.AreEqual(123, result);
        }

        [TestMethod]
        public void TestCalc_TwoNumbers_CommaSeparaed_ReturnSum()
        {
            // Given
            string a = "123, 456";
            int expected = 123 + 456;

            // When
            int result = _yourClass.Calc(a);

            // Then
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestCalc_NewlineSeparaed_ReturnSum()
        {
            // Given
            string a = "123\n456";
            int expected = 123 + 456;

            // When
            int result = _yourClass.Calc(a);

            // Then
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestCalc_ThreeNumbers_EitherWay_ReturnSum()
        {
            // Given
            string a = "123, 456\n789";
            string b = "123\n456\n789";
            string c = "123, 456, 789";
            int expected = 123 + 456 + 789;

            // When
            int result_a = _yourClass.Calc(a);
            int result_b = _yourClass.Calc(b);
            int result_c = _yourClass.Calc(c);


            // Then
            Assert.AreEqual(expected, result_a);
            Assert.AreEqual(expected, result_b);
            Assert.AreEqual(expected, result_c);
        }

        [TestMethod]
        public void TestCalc_NegativeNumbers_ShouldThrowException()
        {
            // Given
            string a = "123, -456, 789";

            // When
            void action() => _yourClass.Calc(a);

            // Then
            Assert.ThrowsException<System.ArgumentException>(action);
        }

        [TestMethod]
        public void TestCalc_NumberGreaterThan1000_ShouldIgnore()
        {
            //Given
            string a = "123, 456, 1001";
            int expected = 123 + 456;

            //When
            int result = _yourClass.Calc(a);

            //Then
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestCalc_SingleCharDeliminer_OnTheFirstLine()
        {
            //Given
            string a = "123#456";
            int expected = 123 + 456;

            //When
            int result = _yourClass.Calc(a);

            //Then
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestCalc_MultiCharDeliminer_OnTheFirstLine()
        {
            //Given
            string a = "123###456";
            int expected = 123 + 456;

            //When
            int result = _yourClass.Calc(a);

            //Then
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestCalc_MultiCharDeliminer_OnTheFirstLineAndNewLine()
        {
            //Given
            string a = "123[###]456[;;]789";
            int expected = 123 + 456 + 789;

            //When
            int result = _yourClass.Calc(a);

            //Then

            Assert.AreEqual(expected, result);
        }
    }
}