using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTestProject;

namespace UnitTestProject1
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void AddTest()
        {
            //Arrange
            Calculator calculator = new Calculator();
            int a = 6;
            int b = 3;
            int expected = 9;

            //Act
            int result = calculator.Add(a, b);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SubtractTest()
        {
            //Arrange
            Calculator calculator = new Calculator();
            int a = 8;
            int b = 5;
            int expected = 3;

            //Act
            int result = calculator.Subtract(a, b);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            //Arrange
            Calculator calculator = new Calculator();
            int a = 7;
            int b = 4;
            int expected = 28;

            //Act
            int result = calculator.Multiplication(a, b);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DivisionTest()
        {
            //Arrange
            Calculator calculator = new Calculator();
            int a = 42;
            int b = 7;
            int expected = 6;

            //Act
            int result = calculator.Division(a, b);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetSquareRootTest()
        {
            //Arrange
            Calculator calculator = new Calculator();
            int a = 169;
            double expected = 13;

            //Act
            double result = calculator.GetSquareRoot(a);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
