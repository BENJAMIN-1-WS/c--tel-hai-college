using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevelopmentProj3.UnitTests
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange

            // Create an Admin user
            User adminUser = new User();

            // Create a "regular" user (NOT ADMIN)
            User user2 = new User();

            // Create reservation which was made by user2 and not by the admin user
            Reservation reservationForTheTest = new Reservation();
            reservationForTheTest.MadeBy = user2;

            bool ExpectedResult = true;

            //Act
            bool ActualResult = reservationForTheTest.CanBeCancelledBy(adminUser);

            //Assert
            //Assert.IsTrue(ActualResult, "Admin user should always be able to cancel a reservation");
            Assert.AreEqual(ExpectedResult, ActualResult, "Admin user should always be able to cancel a reservation");

        }


        [TestMethod]
        public void CanBeCancelledBy_UserIsTheOwner_ReturnsTrue()
        {
            //Arrange

            // Create a user who is NOT an admin
            User userForTheTest = new User(false);

            // Set the owner of the reservation to be the NONE-Admin user above
            Reservation reservationForTheTest = new Reservation();
            reservationForTheTest.MadeBy = userForTheTest;

            // Act
            bool ActualResult = reservationForTheTest.CanBeCancelledBy(userForTheTest);

            // Assert
            Assert.IsTrue(ActualResult, "The owner of the reservation should always be able to cancel it");
        }


        [TestMethod]
        public void CanBeCancelledBy_NotAdminNotOwner_ReturnsFalse()
        {
            // Arrange
            Reservation reservationForTheTest = new Reservation();

            // user1 that will be set on the reservation as the owner.
            User user1 = new User();
            reservationForTheTest.MadeBy = user1;

            // user2 is the one that tries to cancel the reservation
            User user2 = new User();

            // Act
            bool ActualResult = reservationForTheTest.CanBeCancelledBy(user2);

            // Assert
            //Assert.IsFalse(ActualResult, "User who is not the owner and not admin- should not be able to cancel the reservation");
            Assert.AreEqual(false, ActualResult, "User who is not the owner and not admin- should not be able to cancel the reservation");

        }


    }
}
