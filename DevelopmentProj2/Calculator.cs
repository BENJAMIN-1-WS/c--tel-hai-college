using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentProj2
{
    public class Calculator
    {
        public double Add (double x, double y)
        {
            return x+ y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }


        public double Mul(double x, double y)
        {
            return x * y;
        }


        public double Div(double x, double y)
        {
            // Assumption: Div by 0 needs to return MaxValue
            if (y == 0)
                return Double.MaxValue;

            return x / y;
        }


    }
}
