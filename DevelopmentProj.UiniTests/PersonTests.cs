using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace DevelopmentProj.UnitTests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Age_personWithAge20_Returns20()
        {
            Person Yossi = new Person("Yossi", "Israeli", 20);

            //Verify that the age is indeed 20
            int ageToBeTested = Yossi.Age();
            Assert.AreEqual(20, ageToBeTested);

        }

        [TestMethod]
        public void Age_personWithAge30_Returns30()
        {
            Person Yossi = new Person("Yossi", "Israeli", 30);

            //Verify that the age is indeed 30
            //Assert.AreEqual(30, Yossi.Age());
            Assert.IsTrue(30 == Yossi.Age(), "I expected the age to be 30");

        }



        [TestMethod]
        public void FirstName_Yossi_ReturnsYossi()
        {
            Person Yossi = new Person("Yossi", "Israeli", 30);

            //Verify that the first name is indeed Yossi
            Assert.AreEqual("Yossi", Yossi.FirstName());

        }


        [TestMethod]
        public void LastName_Israeli_ReturnsYossi()
        {
            Person Yossi = new Person("Yossi", "Israeli", 30);

            //Verify that the first name is indeed Yossi
            Assert.AreEqual("Israeli", Yossi.LastName());

        }


        [TestMethod]
        public void Age_personWithoutAge_Returns0()
        {
            Person Yossi = new Person("Yossi", "Israeli");

            //Verify that the age is 0
            Assert.AreEqual(0, Yossi.Age());
            //Assert.IsTrue(0 == Yossi.Age(), "I expected the age to be 0, because it was not initialized");

        }




        [TestMethod]
        [Timeout(1)]
        public void Age_personWithoutAgeWithTimeoutLimitation_Returns0()
        {

            //Delay the test in 1 millisecond
            //System.Threading.Thread.Sleep(1);
                        
            Person Yossi = new Person("Yossi", "Israeli");

            //Verify that the age is 0
            Assert.AreEqual(0, Yossi.Age());
            //Assert.IsTrue(0 == Yossi.Age(), "I expected the age to be 0, because it was not initialized");

        }



    }
}
