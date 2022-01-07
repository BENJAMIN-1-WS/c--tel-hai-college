using System;
using NUnit.Framework;
using FlightCompProj;


namespace FlightCompProj.UnitTestProj
{
    [TestFixture]
    public class FlightTests_Nunit
    {
        [Test]

        public void Cost_FlightWithCost300_Returns300()
        {
            //Arrange
            Customer Ben = new Customer(true, 33, 434);
            Flight flight = new Flight(Ben, new DateTime(12 / 23 / 23), true, 300);
            int ExpectedResult = 300;
            //Act
            int ActualResult = flight.Cost;
            //Assert
            Assert.That(ExpectedResult, Is.EqualTo(ActualResult), "return is faild- !300");
        }
        [Test]
        public void hasAvailableSeats_FlightWithhasAvailableSeats_ReturnsTrue()
        {
            //Arrange
            Customer Ben = new Customer(true, 33, 434);
            Flight flight = new Flight(Ben, new DateTime(12 / 23 / 23), true, 2000);
            bool ExpectedResult = true;
            //Act
            bool ActualResult = flight.HasAvailableSeats;
            //Assert
            Assert.IsTrue(ExpectedResult == ActualResult);
        }
        [Test]
        public void orderBy_FlightWithOrderBy_ReturnsTrue()
        {
            //Arrange
            Customer Ben = new Customer(true, 33, 434);
            Flight flight = new Flight(Ben, new DateTime(12 / 23 / 23), true, 2000);
            double ExpectedResult = Ben.Age;
            //Act
            double ActualResult = flight.OrderedBy.Age;
            //Assert
            Assert.IsFalse(ExpectedResult != ActualResult);
        }
        [Test]
        public void CanBeCancelledBy_CustomerIsVip_ReturnsTrue()
        {
            //Arrange
            // Create an Vip Customer 
            Customer vipCustomer = new Customer(true, 25, 444);

            // Create a "regular" Customer (NOT Vip)
            Customer user2 = new Customer(false, 30, 433);

            //Create New Flight and regular Customer
            Flight flight = new Flight(user2, new DateTime(12 / 23 / 23), true, 2000);

            bool ExpectedResult = true;

            //Act
            bool ActualResult = flight.CanBeCancelledBy_Customer(vipCustomer);

            //Assert
            Assert.AreEqual(ExpectedResult, ActualResult, "Cutomer user should always be able to cancel Flight");
        }
        [Test]
        public void CanBeCancelledBy_CustomerNotVip_ReturnsFalse()
        {
            //Arrange
            // Create an NOT Vip Customer 
            Customer vipCustomer = new Customer(false, 25, 444);

            // Create a "regular" Customer (NOT Vip)
            Customer user2 = new Customer(false, 30, 433);

            //Create New Flight and regular Customer
            Flight flight = new Flight(user2, new DateTime(12 / 23 / 23), true, 2000);

            bool ExpectedResult = false;

            //Act
            bool ActualResult = flight.CanBeCancelledBy_Customer(vipCustomer);

            //Assert
            Assert.AreEqual(ExpectedResult, ActualResult, "Cutomer user should always be able to cancel Flight");
        }

        public void CanNotBeCancelledBy_func_ReturnFalse(int flightCost, int age, int BudgetForFlight, bool bin, int txt, bool ExpectedResult)
        {
            //   Arrange

            // Open Excel File Excel
    

            // Create an Customer Flight
            Customer CustomerForTest = new Customer(bin, BudgetForFlight, age + txt);
            // Create an Customer Flight for text
            Customer CustomerForTest_2 = new Customer(bin, BudgetForFlight, age + txt);

            // Create an DateTime
            DateTime DateTimeForTest = new DateTime(2021, 10, 28);

            // Initializes a Flight with CustomerForTest_2
            Flight FlightForTest = new Flight(CustomerForTest_2, DateTimeForTest, bin, flightCost);

            //    Act
            // check if CustomerForTest can Cancelled Someone else's flight.
            Assert.IsFalse(FlightForTest.CanBeCancelledBy_Customer(CustomerForTest), "<!> Vip Customer OR Flight.OrderedBy == Customer, Can be Cancelled ");
        }


    }
    
}
