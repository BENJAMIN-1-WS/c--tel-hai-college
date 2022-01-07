using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCompProj
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime benFligth = new DateTime(2021, 10, 28);
            
            Customer ben = new Customer(true, 1000, 34);

            Flight B747 = new Flight(ben, benFligth, true, 200);

        }
    }
}
