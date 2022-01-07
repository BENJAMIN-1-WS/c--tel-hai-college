using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace DevelopmentProj2.UnitTests
{
    [TestClass]
    public class MathUtilsTests
    {
        [TestMethod]
        public void IsEven_EvenNumber_ReturnsTrue()
        {
            //Arrange
            int numToCheck = 4;
            MathUtils myMathUtils = new MathUtils();

            //Act
            bool ActualResult = myMathUtils.IsEven(numToCheck);

            //Assert
            Assert.IsTrue(ActualResult, numToCheck + " is an even number");
            //Assert.AreEqual(true, ActualResult, numToCheck + " is an even number");

        }


        [TestMethod]
        public void IsEven_OddNumber_ReturnsFalse()
        {
            //Arrange
            int numToCheck = 333;
            MathUtils myMathUtils = new MathUtils();

            //Act
            bool ActualResult = myMathUtils.IsEven(numToCheck);

            //Assert
            Assert.IsFalse(ActualResult, numToCheck + " is an odd number");

        }


        [TestMethod]
        public void IsOdd_EvenNumber_ReturnsFalse()
        {
            //Arrange
            int numToCheck = 4;
            MathUtils myMathUtils = new MathUtils();

            //Act
            bool ActualResult = myMathUtils.IsOdd(numToCheck);

            //Assert
            Assert.IsFalse(ActualResult);

        }


        [TestMethod]
        public void IsOdd_OddNumber_ReturnsTrue()
        {
            //Arrange
            int numToCheck = 333;
            MathUtils myMathUtils = new MathUtils();

            //Act
            bool ActualResult = myMathUtils.IsOdd(numToCheck);

            //Assert
            Assert.IsTrue(ActualResult);

        }


        [TestMethod]
        public void IsPrime_8_returnsFalse()
        {
            //Arrange
            int numToCheck = 8;
            MathUtils myMathUtils = new MathUtils();

            //Act
            bool ActualResult = myMathUtils.IsPrime(numToCheck);

            //Assert
            Assert.IsFalse(ActualResult);

        }


        [TestMethod]
        public void IsPrime_11_returnsTrue()
        {
            //Arrange
            int numToCheck = 11;
            MathUtils myMathUtils = new MathUtils();

            //Act
            bool ActualResult = myMathUtils.IsPrime(numToCheck);

            //Assert
            Assert.IsFalse(!ActualResult);

        }

        [TestMethod]
        public void IsPrime_NegativeNumber_returnsFalse()
        {
            //Arrange
            int numToCheck = -11;
            MathUtils myMathUtils = new MathUtils();

            //Act
            bool ActualResult = myMathUtils.IsPrime(numToCheck);

            //Assert
            Assert.IsFalse(ActualResult, numToCheck + " is a negaive number and therefore is NOT a prime number");

        }


        [TestMethod]
        public void IsPrime_1_returnsFalse()
        {
            //Arrange
            int numToCheck = 1;
            MathUtils myMathUtils = new MathUtils();

            //Act
            bool ActualResult = myMathUtils.IsPrime(numToCheck);

            //Assert
            Assert.IsFalse(ActualResult, numToCheck + " is NOT a prime number");

        }

        [TestMethod]
        public void GetMinValueInIntArr_InputArr_Returns1()
        {
            //Arrange
            int[] arr = { 10, 11, 45, 5646, 3, 7, 1, 298 };
            MathUtils myMathUtils = new MathUtils();
            int expectedResult = 1;

            //Act
            int actualResult = myMathUtils.GetMinValueInIntArr(arr);

            //Assert
            Assert.AreEqual(expectedResult, actualResult, actualResult + " is not the smallest number in the array");
        }

        [TestMethod]
        public void GetMinValueInIntArr_InputArr_Returns2()
        {
            //Arrange
            int[] arr = { 10, 11, 45, 5646, 3, 7, 2, 298 };
            MathUtils myMathUtils = new MathUtils();
            int expectedResult = 2;

            //Act
            int actualResult = myMathUtils.GetMinValueInIntArr(arr);

            //Assert
            Assert.AreEqual(expectedResult, actualResult, actualResult + " is not the smallest number in the array");
        }



        [TestMethod]
        public void GetMinValueInIntArr_ArrWithSimilarNumbers_ReturnsSimilarNumber()
        {
            //Arrange
            int[] arr = { 10, 10, 10, 10, 10 };
            MathUtils myMathUtils = new MathUtils();
            int expectedResult = 10;

            //Act
            int actualResult = myMathUtils.GetMinValueInIntArr(arr);

            //Assert
            Assert.AreEqual(expectedResult, actualResult, actualResult + " is not the smallest number in the array");
        }


        [TestMethod]
        public void GetMinValueInIntArr_ArrWithNegativeNumbers_ReturnsMinus1()
        {
            //Arrange
            int[] arr = { 10, 10, -1, 10, 10 };
            MathUtils myMathUtils = new MathUtils();
            int expectedResult = -1;

            //Act
            int actualResult = myMathUtils.GetMinValueInIntArr(arr);

            //Assert
            Assert.AreEqual(expectedResult, actualResult, actualResult + " is not the smallest number in the array");
        }


        [TestMethod]
        public void GetMinValueInIntArr_EmptyArr_ReturnsMaxValue()
        {
            //Arrange
            int[] arr =  { };
            MathUtils myMathUtils = new MathUtils();
            int expectedResult = Int32.MaxValue;

            //Act
            int actualResult = myMathUtils.GetMinValueInIntArr(arr);
            

            //Assert
            Assert.AreEqual(expectedResult, actualResult, actualResult + " is not the smallest number in the array");
        }


        [TestMethod]
        public void GetMinValueInIntArr_NullArr_ReturnsMaxValue()
        {
            //Arrange
            int[] arr =new int[0];
            MathUtils myMathUtils = new MathUtils();
            int expectedResult = Int32.MaxValue;

            //Act
            int actualResult = myMathUtils.GetMinValueInIntArr(arr);

            //Assert
            Assert.AreEqual(expectedResult, actualResult," is not the smallest number in the array");
        }


        [TestMethod]
        public void GetMinValueInIntArr_ArrayWithSingleMemeber_ReturnsTheSingleMemeber()
        {
            //Arrange
            int[] arr = {3454 };
            MathUtils myMathUtils = new MathUtils();
            int expectedResult = 3454;

            //Act
            int actualResult = myMathUtils.GetMinValueInIntArr(arr);
            

            //Assert
            Assert.AreEqual(expectedResult, actualResult, actualResult + " is not the smallest number in the array");
        }



        [TestMethod]
        public void power_2power3_returns8()
        {
            // Arrange
            double BaseNumber = 2;
            double ExpNumber = 3;
            double ExpectedResult = 8;
            double ActualResult;
            MathUtils myMathUtils = new MathUtils();

            // Act
            ActualResult = myMathUtils.Power(BaseNumber, ExpNumber);

            // Assert
            Assert.AreEqual(ExpectedResult, ActualResult, " Wrong power calculation");
        }


        [TestMethod]
        public void power_2power4_returns16()
        {
            // Arrange
            double BaseNumber = 2;
            double ExpNumber = 4;
            double ExpectedResult = 16;
            double ActualResult;
            MathUtils myMathUtils = new MathUtils();

            // Act
            ActualResult = myMathUtils.Power(BaseNumber, ExpNumber);

            // Assert
            Assert.AreEqual(ExpectedResult, ActualResult, " Wrong power calculation");
        }


        [TestMethod]
        public void power_2power5_returns32()
        {
            // Arrange
            double BaseNumber = 2;
            double ExpNumber = 5;
            double ExpectedResult = 32;
            double ActualResult;
            MathUtils myMathUtils = new MathUtils();

            // Act
            ActualResult = myMathUtils.Power(BaseNumber, ExpNumber);

            // Assert
            Assert.AreEqual(ExpectedResult, ActualResult, " Wrong power calculation");
        }

        [TestMethod]
        [DataRow(10, 2, 100, DisplayName = "power_10power2_returns100")]
        [DataRow(10, 3, 1000, DisplayName = "power_10power3_returns1000")]
        [DataRow(10, 1, 10, DisplayName = "power_10power3_returns99")]
        public void power (double BaseNumber, double ExpNumber, double ExpectedResult)
        {
            // Arrange
            Trace.WriteLine("Base Number= " + BaseNumber + "\nExpNumber=" + ExpNumber + "\nExpectedResult=" + ExpectedResult);
            double ActualResult;
            MathUtils myMathUtils = new MathUtils();

            // Act
            ActualResult = myMathUtils.Power(BaseNumber, ExpNumber);

            // Assert
            Assert.AreEqual(ExpectedResult, ActualResult, " Wrong power calculation");
        }


        [TestMethod]
        [DataRow(10, 2, 100, DisplayName = "power_10power2_returns100")]
        [DataRow(3, 2, 9, DisplayName = "power_3power2_returns8")]
        [DataRow(5, 2, 25, DisplayName = "power_5power2_returns25")]
        [DataRow(100, 2, 10000, DisplayName = "power_100power2_returns10000")]
        public void power_XpowerY_Demo1(double BaseNumber, double ExpNumber, double ExpectedResult)
        {
            // Arrange
            double ActualResult;
            MathUtils myMathUtils = new MathUtils();

            // Act
            Trace.WriteLine("Calculating " + BaseNumber.ToString() + " power " + ExpNumber.ToString());
            ActualResult = myMathUtils.Power(BaseNumber, ExpNumber);

            // Assert
            Trace.WriteLine("ExpectedResult: " + ExpectedResult + 
                            "\nActualResult: " + ActualResult);
            Assert.AreEqual(ExpectedResult, ActualResult, "We've got the wrong Result");
        }




    }
}
