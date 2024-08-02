using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator D;
        [SetUp]
        public void SetUp()
        {
            D = new DemeritPointsCalculator();
        }

        [Test]
        public void DemeritPointsCalculator_NegSpeed_ThrowEx()
        {
            
            Assert.That(()=> D.CalculateDemeritPoints(-5),Throws.Exception);
        }

        [Test]
        public void DemeritPointsCalculator_More300_ThrowEx()
        {

            Assert.That(() => D.CalculateDemeritPoints(301), Throws.Exception);
        }

        [Test]
        [TestCase(65)]
        [TestCase(30)]
        [TestCase(0)]
        public void DemeritPointsCalculator_BelowSpeed_0(int speed)
        {
            var res = D.CalculateDemeritPoints(speed);
            Assert.That(res==0);
        }

        [Test]
        [TestCase(70 , 1)]
        [TestCase(78, 2)]
        [TestCase(68, 0)]
        public void DemeritPointsCalculator_AboveLimit_Expected1(int speed, int ExpectedRes)
        {
            var res = D.CalculateDemeritPoints(speed);
            Assert.That(res == ExpectedRes);
        }
        
    }
}
