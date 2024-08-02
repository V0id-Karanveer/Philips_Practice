using System;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private EmployeeController _employeeController;
        private Mock<IEmployeeRepo> _employeeRepo;

        [SetUp]
        public void SetUp()
        {

            _employeeRepo = new Mock<IEmployeeRepo>();
            _employeeController = new EmployeeController(_employeeRepo.Object);
        }

        [Test]
        public void DeleteEmployee_IDGiven_RedirectToAction()
        {
            _employeeRepo.Setup(er => er.DeleteByID(It.IsAny<int>(),It.IsAny<EmployeeContext>()));
            var res = _employeeController.DeleteEmployee(It.IsAny<int>());
            Assert.That(res,Is.TypeOf<RedirectResult>());

        }

    }
}
