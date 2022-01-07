using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentProj2
{
    public class MathUtils
    {
        // This function returns true if the number is even
        // Otherwise- it returns false
        public bool IsEven(int a)
        {
            return (a % 2 == 0);            
        }

        // This function returns true if the number is odd
        // Otherwise- it returns false
        public bool IsOdd(int a)
        {
            return (a % 2 != 0);            
        }

        // The following method returns true if the number is a prime number
        //The following code will be improve!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //The following code will be improve!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //The following code will be improve!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public bool IsPrimeOriginal(int a)
        {
            int i;
            bool result = true;
            //fIX BUG 235- 
            //if (a > 0)
            if (a > 1)
            {
                for (i = 2; i < a; i++)
                    if (a % i == 0)
                    {
                        result = false;
                        break;
                    }
            }
            // Fix bug #234
            else
            {
                result = false;
            }

            return result;
        }

        // The following method returns true if the number is a prime number
        public bool IsPrime(int a)
        {
            int i;
            double sqrt = Math.Sqrt(a);
            if (a < 2) return false;

            for (i = 2; i <= sqrt; i++)
                if (a % i == 0) return false;

            return true; //If the code reach this line then the input number is a prime number

        }

        //The following method contains bug, and needs to be improve
        public int GetMinValueInIntArr(int[] array)
        {
            int MinValue;

            if (array.Length == 0) 
                return Int32.MaxValue; // Ensure that the input is not null

            int index;
            int arrLen;
            arrLen = array.Length;
            if (arrLen == 0)
                return Int32.MaxValue; // Assumption: When the array is empty- the code will return Int32.MaxValue
            else
                  MinValue = array[0];          

            for (index = 1; index < arrLen; index++)
               if (array[index] < MinValue)
                    MinValue = array[index];

            return MinValue;
        }

        public double Power (double x, double y)
        {
            return Math.Pow(x, y);
        }

    }
}
