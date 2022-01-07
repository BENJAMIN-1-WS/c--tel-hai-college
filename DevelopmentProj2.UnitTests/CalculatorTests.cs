using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevelopmentProj2.UnitTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Add_12Add3_Returns15()
        {
            // Arrange
            int x = 12;
            int y = 3;
            double ExpectedResult = 15;
            //Calculator CalculatorForTheTest = new Calculator();
            Calculator CalculatorForTheTest = new Calculator();

            //Act
            double ActualResult = CalculatorForTheTest.Add(x, y);

            //Assert
            Assert.AreEqual(ExpectedResult, ActualResult, "Add Activity return the wrong calculation");

        }


        [TestMethod]
        public void Add_12Add4_Returns16()
        {
            // Arrange
            int x = 12;
            int y = 4;
            double ExpectedResult = 16;
            Calculator CalculatorForTheTest = new Calculator();
            //var CalculatorForTheTest = new Calculator();

            //Act
            double ActualResult = CalculatorForTheTest.Add(x, y);

            //Assert
            Assert.AreEqual(ExpectedResult, ActualResult, "Add Activity return the wrong result");

        }

        [TestMethod]
        public void Sub_12Sub3_Returns9()
        {
            // Arrange
            int x = 12;
            int y = 3;
            double ExpectedResult = 9;
            //Calculator CalculatorForTheTest = new Calculator();
            var CalculatorForTheTest = new Calculator();

            //Act
            double ActualResult = CalculatorForTheTest.Sub(x, y);

            //Assert
            Assert.AreEqual(ExpectedResult, ActualResult, "Sub Activity return the wrong result");

        }


        [TestMethod]
        public void Mul_12Mul3_Returns36()
        {
            // Arrange
            int x = 12;
            int y = 3;
            double ExpectedResult = 36;
            //Calculator CalculatorForTheTest = new Calculator();
            var CalculatorForTheTest = new Calculator();

            //Act
            double ActualResult = CalculatorForTheTest.Mul(x, y);

            //Assert
            Assert.AreEqual(ExpectedResult, ActualResult, "Mul Activity return the wrong result");

        }


        [TestMethod]
        public void Div_12Div3_Returns4()
        {
            // Arrange
            int x = 12;
            int y = 3;
            double ExpectedResult = 4;
            //Calculator CalculatorForTheTest = new Calculator();
            var CalculatorForTheTest = new Calculator();

            //Act
            double ActualResult = CalculatorForTheTest.Div(x, y);

            //Assert
            Assert.AreEqual(ExpectedResult, ActualResult, "Div Activity return the wrong result");

        }

        [TestMethod]
        public void Div_12Div0_ReturnsMaxValue()
        {
            // Arrange
            int x = 12;
            int y = 3;
            double ExpectedResult = 4;
            //Calculator CalculatorForTheTest = new Calculator();
            var CalculatorForTheTest = new Calculator();

            //Act
            double ActualResult = CalculatorForTheTest.Div(x, y);

            //Assert
            Assert.AreEqual(ExpectedResult, ActualResult, "Div Activity return the wrong result");

        }

    }
}
