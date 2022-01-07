using NUnit.Framework;
using System;

namespace DevelopmentProj3.UnitTests
{
    [TestFixture]
    class ReservationTests_Nunit
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange

            // Create an Admin user
            User adminUser = new User();
            adminUser.IsAdmin = true;

            // Create a "regular" user (NOT ADMIN)
            User user2 = new User();
            user2.IsAdmin = false;

            // Create reservation which was made by user2 and not by the admin user
            Reservation reservationForTheTest = new Reservation();
            reservationForTheTest.MadeBy = user2;

            bool ExpectedResult = true;

            //Act
            bool ActualResult = reservationForTheTest.CanBeCancelledBy(adminUser);

            //Assert
            //Assert.IsTrue(ActualResult, "Admin user should always be able to cancel a reservation");
            //Assert.AreEqual(ExpectedResult, ActualResult, "Admin user should always be able to cancel a reservation");
            Assert.That(ActualResult, Is.True, "*Admin user should always be able to cancel a reservation*");


        }

        [Test]
        public void CanBeCancelledBy_UserIsTheOwner_ReturnsTrue()
        {
            //Arrange

            // Create a user who is NOT an admin
            User userForTheTest = new User();
            userForTheTest.IsAdmin = false;

            // Set the owner of the reservation to be the NONE-Admin user above
            Reservation reservationForTheTest = new Reservation();
            reservationForTheTest.MadeBy = userForTheTest;

            // Act
            bool ActualResult = reservationForTheTest.CanBeCancelledBy(userForTheTest);

            // Assert
            //Assert.IsTrue(ActualResult, "The owner of the reservation should always be able to cancel it");
            Assert.That(ActualResult == true, "The owner of the reservation should always be able to cancel it");
        }

        [Test]
        public void CanBeCancelledBy_NotAdminNotOwner_ReturnsFalse()
        {
            // Arrange
            Reservation reservationForTheTest = new Reservation();

            // user1 that will be set on the reservation as the owner.
            User user1 = new User();
            user1.IsAdmin = false;
            reservationForTheTest.MadeBy = user1;

            // user2 is the one that tries to cancel the reservation
            User user2 = new User();
            user2.IsAdmin = false;

            // Act
            bool ActualResult = reservationForTheTest.CanBeCancelledBy(user2);

            // Assert
            //Assert.IsFalse(ActualResult, "User who is not the owner and not admin- should not be able to cancel the reservation");
            //Assert.AreEqual(false, ActualResult, "User who is not the owner and not admin- should not be able to cancel the reservation");
            Assert.That(false, Is.EqualTo(ActualResult), "****Error message");


        }
    }
}
