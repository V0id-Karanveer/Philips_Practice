using System;
using TestNinja;
using TestNinja.Fundamentals;
using NUnit.Framework;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange - Create the objects
            var reservation = new Reservation();

            //Act - Call the methods on the object
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            //Assert - verification of the result
            Assert.That(result == true);
        }

        [Test]
        public void CanBeCancelledBy_MadeByUser_ReturnsTrue()
        {
            var reservation = new Reservation();
            var user = new User() { IsAdmin = false };
            reservation.MadeBy = user;

            var res = reservation.CanBeCancelledBy(user);

            Assert.That(res == true);
        }

    }
}
