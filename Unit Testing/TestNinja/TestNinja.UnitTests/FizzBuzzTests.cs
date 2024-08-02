using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {

        [Test]
        public void GetOutput_Div15_ReturnFizzBuzz()
        {
            var res = FizzBuzz.GetOutput(30);
            Assert.That(res == "FizzBuzz");
        }

        [Test]
        public void GetOutput_Div3_ReturnFizz()
        {
            var res = FizzBuzz.GetOutput(6);
            Assert.That(res == "Fizz");
        }

        [Test]
        public void GetOutput_Div15_ReturnBuzz()
        {
            var res = FizzBuzz.GetOutput(10);
            Assert.That(res == "Buzz");
        }

        [Test]
        public void GetOutput_NoDivByAny_ReturnNull()
        {
            var res = FizzBuzz.GetOutput(2);
            Assert.That(res == "2");
        }

        

    }
}
