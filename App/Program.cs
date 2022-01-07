using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Program
    {


        public class Person
        {
            public string Name;

            public Person()
            {
            }

            public Person(string nm)
            {
                Name = nm;
            }

            public virtual void displayFullName()
            {
                Console.WriteLine("Person: {0}", Name);
            }
        }

        class Employee : Person
        {
            //   public ushort hireYear;

            public Employee() : base()
            {
            }

            public Employee(string nm) : base(nm)
            {
            }

            public override void displayFullName()
            {
                Console.WriteLine("Employee: {0}", Name);
            }
        }

        // A new class derived from Person...
        class Contractor : Person
        {
            //   public string company;

            public Contractor() : base()
            {
            }

            public Contractor(string nm) : base(nm)
            {
            }

            public override void displayFullName()
            {
                Console.WriteLine("Contractor: {0}", Name);
            }
        }

        class NameApp
        {
            public static void Main()
            {
                Person[] myCompany = new Person[10];
                int ctr = 0;
                string buffer;

                do
                {
                    do
                    {
                        Console.Write("\nEnter \'c\' for Contractor, \'e\' for Employee then press ENTER: ");
                        buffer = Console.ReadLine();
                    } while (buffer == "");

                    if (buffer[0] == 'c' || buffer[0] == 'C')
                    {
                        Console.Write("\nEnter the contractor\'s name: ");
                        buffer = Console.ReadLine();
                        // do other Contractor stuff...
                        Contractor contr = new Contractor(buffer);
                        myCompany[ctr] = contr as Person;
                    }
                    else
                    if (buffer[0] == 'e' || buffer[0] == 'E')
                    {
                        Console.Write("\nEnter the employee\'s name: ");
                        buffer = Console.ReadLine();
                        // Do other employee stuff...
                        Employee emp = new Employee(buffer);
                        myCompany[ctr] = emp as Person;
                    }
                    else
                    {
                        Person pers = new Person("Not an Employee or Contractor");
                        myCompany[ctr] = pers;
                    }

                    ctr++;

                } while (ctr < 5);

                // Display the results of what was entered....

                Console.WriteLine("\n\n\n===========================");

                for (ctr = 0; ctr < 5; ctr++)
                {
                    if (myCompany[ctr] is Employee)
                    {
                        Console.WriteLine("Employee: {0}", myCompany[ctr].Name);
                    }
                    else
                    if (myCompany[ctr] is Contractor)
                    {
                        Console.WriteLine("Contractor: {0}", myCompany[ctr].Name);
                    }
                    else
                    {
                        Console.WriteLine("Person: {0}", myCompany[ctr].Name);
                    }
                }
                Console.WriteLine("===========================");
            }
        }

    }
}
