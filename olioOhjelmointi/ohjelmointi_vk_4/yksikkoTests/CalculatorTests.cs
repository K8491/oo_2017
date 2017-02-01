using Microsoft.VisualStudio.TestTools.UnitTesting;
using ohjelmointi.VK5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ohjelmointi.VK5
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void AddTest()
        {
            /// AAA periaate
            /// /// Arrange tietojen alustus
            /// /// Act kutsutaan metodia
            /// Assert, varmistetaann että tulos ok
            // arrange
            Calculator Calc = new Calculator();
            int a = 4;
            int b = 5;
            int expected = 9;
            //act
            int actual = Calc.Add(a, b);
            // assert
            Assert.AreEqual(expected,actual);
            // jatoinen testi add-metofilla
            a = 0;
            b = 1;
            expected = 1;
            actual = Calc.Add(expected,actual);
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            // arrange
            Calculator calc = new Calculator();
            int number1 = 5;
            int number2 = 7;
            int expected = 35;

            // act
            int actual = calc.Multiply(number1, number2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void DivideTest()
        {
            // arrange
            Calculator calc = new Calculator();
            int number1 = 10;
            int number2 = 5;
            int expected = 2;

            // act
            int actual = calc.Divide(number1, number2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SubtractTest()
        {
            // arrange
            Calculator calc = new Calculator();
            int number1 = 5;
            int number2 = 4;
            int expected = 1;

            // act
            int actual = calc.Subtract(number1, number2);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}