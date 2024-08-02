using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class MathTests
    {
        private Fundamentals.Math math;

        [SetUp]
        public void SetUp()
        {
            math = new Fundamentals.Math();
        }

        [Test]
        public void Add_Main_ReturnsSum()
        {
            var res = math.Add(1, 2);

            Assert.That(res == 3);
        }

        [Test]
        [TestCase(1,2,2)]
        [TestCase(2,1,2)]
        [TestCase(1,1,1)]
        public void Max_ReturnGreater(int a, int b , int ans)
        {
            var res = math.Max(a,b);
            Assert.That(res==ans);
        }

        [Test]
        public void GetOddNumbers_InpGreaterThen0_ReturnOdd()
        {
            var res = math.GetOddNumbers(5);

            Assert.That(res , Is.EquivalentTo(new int[] {1,3,5}));
        }
        
    }
}
