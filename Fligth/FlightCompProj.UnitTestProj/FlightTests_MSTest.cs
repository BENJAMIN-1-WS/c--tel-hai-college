using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlightCompProj;
using System.Diagnostics;
using System.Data.Odbc;

namespace FlightCompProj.UnitTestProj
{
    [TestClass]
    public class FlightTests_MSTest {


        private TestContext context;
        public TestContext TestContext
        {
                get { return context; }
                set { context = value; }
        }

        [TestMethod]
        [DataSource("System.Data.Odbc",
            @"Driver={Microsoft Excel Driver (*.xls)};dbq=C:\Users\User\source\repos\DATA\Data.xls;defaultdir=C:\Users\User\source\repos\DATA;driverid=790;fil=excel 8.0;filedsn=C:\Users\User\source\repos\DATA\Data.dsn;maxbuffersize=2048;maxscanrows=8;pagetimeout=5;readonly=1;safetransactions=0;threads=3;uid=admin;usercommitsync=Yes"
            , "Sheet1$"
            ,DataAccessMethod.Sequential)]
        public void TestAddInteger_DataDrivenTestFromExcel_ReturnTrue()
        {
            // Arrange 
            int CurrentCapacity = Convert.ToInt32(context.DataRow["FlightCurrentCapacity"].ToString());

            int MaxCapacity = Convert.ToInt32(context.DataRow["FlightMaxCapacity"].ToString()); //FlightCurrentCapacity_; FlightMaxCapacity_

            bool Result = Convert.ToBoolean(context.DataRow["ExpetedResult"].ToString());
            DateTime date = new DateTime(2021, 10, 28);
            Customer customer = new Customer(true, 1000, 34);
            Flight flight = new Flight(customer, date, true, 200, CurrentCapacity, MaxCapacity);
            // Act
            bool ActualResult = flight.IfFlightFull();

            // Assert

             Assert.AreEqual(ActualResult, Result, "  ");
        }


        [TestMethod]
        [DataRow(true, 33, 434, true, 300, 300, DisplayName = "FlightWithCost300_Returns300")]
        [DataRow(true, 33, 434, true, 230, 230, DisplayName = "FlightWithCost230_Returns230")]
        [DataRow(true, 33, 434, true, 600, 600, DisplayName = "FlightWithCost600_Returns600")]
        public void Cost_FlightWithCostX_ReturnsX(bool isVip, int age, int BudgetForFlight, bool HasAvailableSeats, int cost, int ExpectedResult)
        {
            //Arrange
            Customer customer = new Customer(isVip, age, BudgetForFlight);
            Flight flight = new Flight(customer, new DateTime(12 / 23 / 23), HasAvailableSeats, cost);

            //Act
            int ActualResult = flight.Cost;
            //Assert
            Assert.AreEqual(ExpectedResult, ActualResult, "return is faild- !300");
        }
        [TestMethod]
        [DataRow(true, 33, 434, true, 300, true)]
        [DataRow(true, 33, 434, true, 230, true)]
        [DataRow(true, 33, 434, true, 600, true)]
        public void hasAvailableSeats_FlightWithhasAvailableSeats_ReturnsTrue(bool isVip, int age, int BudgetForFlight, bool HasAvailableSeats, int cost, bool ExpectedResult)
        {
            //Arrange
            
            Customer customer = new Customer(isVip, age, BudgetForFlight);
            Flight flight = new Flight(customer, new DateTime(12 / 23 / 23), HasAvailableSeats, cost);
            //Act
            bool ActualResult = flight.HasAvailableSeats;
            //Assert
            Assert.IsTrue(ExpectedResult == ActualResult);
        }
        [TestMethod]
        [DataRow(true, 34, 434, true, 450, 34)]
        [DataRow(true, 33, 434, true, 300, 33)]
        [DataRow(true, 23, 434, true, 260, 23)]
        public void orderBy_FlightWithOrderBy_ReturnsTrue(bool isVip, int age, int BudgetForFlight, bool HasAvailableSeats, int cost, int ExpectedResult)
        {
            //Arrange
            Customer customer = new Customer(isVip, age, BudgetForFlight);
            Flight flight = new Flight(customer, new DateTime(12 / 23 / 23), HasAvailableSeats, cost);
            //Act
            double ActualResult = flight.OrderedBy.Age;
            //Assert
            Assert.IsFalse(ExpectedResult == ActualResult);
        }
        [TestMethod]
        [DataRow(true, false, true)]
        public void CanBeCancelledBy_CustomerIsVip_ReturnsTrue(bool vipu1, bool vipu2, bool ExpectedResult)
        {
            //Arrange
            // Create an Vip Customer 
            Customer vipCustomer = new Customer(vipu1, 30, 444);

            // Create a "regular" Customer (NOT Vip)
            Customer user2 = new Customer(vipu2, 40, 443);

            //Create New Flight and regular Customer
            Flight FlightForTheTest = new Flight(user2, new DateTime(12 / 23 / 23), true, 200);


            //Act
            bool ActualResult = FlightForTheTest.CanBeCancelledBy_Customer(vipCustomer);

            //Assert
            Assert.AreEqual(ExpectedResult, ActualResult, "Cutomer user should always be able to cancel Flight");
        }
        [TestMethod]
        [DataRow(false, false)]
        public void CanBeCancelledBy_CustomerNotVip_ReturnsFalse(bool isvip, bool ExpectedResult)
        {
            //Arrange
            // Create an NOT Vip Customer 
            Customer vipCustomer = new Customer(isvip, 25, 444);

            // Create a "regular" Customer (NOT Vip)
            Customer user2 = new Customer(isvip, 30, 433);

            //Create New Flight and regular Customer
            Flight FlightForTheTest = new Flight(user2, new DateTime(12 / 23 / 23), true, 200);


            //Act
            bool ActualResult = FlightForTheTest.CanBeCancelledBy_Customer(vipCustomer);

            //Assert
            Assert.AreEqual(ExpectedResult, ActualResult, "Cutomer user should always be able to cancel Flight");
        }



    }
}
