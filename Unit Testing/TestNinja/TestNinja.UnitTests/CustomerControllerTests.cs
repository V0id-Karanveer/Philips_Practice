using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private CustomerController CC;
        [SetUp]
        public void setup()
        {
            CC = new CustomerController();
        }

        [Test]
        public void GetCustomer_ID0_ReturnNotFound()
        {
            var res = CC.GetCustomer(0);

            Assert.That(res , Is.TypeOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IDNot0_ReturnOK()
        {
            var res = CC.GetCustomer(1);
            Assert.That(res, Is.TypeOf<Ok>());
        }
    }
}
