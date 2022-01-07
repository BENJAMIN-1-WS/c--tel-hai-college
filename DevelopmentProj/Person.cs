using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentProj
{
    public class Person
    {
        private string first_name;
        private string last_name;
        private int age;

        public Person(string personFirstName, string personLastName)
        {

            //THIS CODE IS JUST FOR THE TEST (For delaying the code in 1 millisecond)
            //System.Threading.Thread.Sleep(1);


            first_name = personFirstName;
            last_name = personLastName;
        }


        public Person(string personFirstName, string personLastName, int personAge)
        {
            first_name = personFirstName;
            last_name = personLastName;
            age = personAge;
        }

        public string FirstName()
        {
            return first_name;
        }
     

        public string LastName()
        {
            return last_name;
        }

        public int Age()
        {
            return age;
        }

    }
}
