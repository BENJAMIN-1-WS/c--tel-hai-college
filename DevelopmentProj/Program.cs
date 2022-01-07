using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentProj
{
    class Program
    {
        static void Main(string[] args)
        {
          Person Yossi = new Person("Yossi", "Israeli", 25);
          Console.WriteLine("First name: " + Yossi.FirstName() + " \n" +
                            "Last name: " + Yossi.LastName() + " \n" +
                            "Age: " + Yossi.Age() + " \n");

          Console.WriteLine("_______________{");
          Console.ReadLine();
        }
    }
}
