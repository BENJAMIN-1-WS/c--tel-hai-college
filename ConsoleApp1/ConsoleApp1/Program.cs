using System;

namespace ConsoleApp1
{
    class Program
    {
        public static int Sod(int num)

        {

            if (num < 10)

                return num;

            return ((num % 10) + Sod(num / 10));

        }

        public static int Help(int[] a, int first, int last)

        {

            if (first == last)

            {

                int ma = Sod(a[last]);
                Console.WriteLine(ma);
                return ma;

            }

            int maa = Sod(a[first]);

            int na = Help(a, first + 1, last);

            if (maa > na) 
            {
                Console.WriteLine(maa);
                return maa;
            }
            Console.WriteLine(na);
            return na;

        }
        static void Main(string[] args)
        {
            int[] a = { 346, 245621, 12, 66, 23, 7829, 67, 342 };
            Console.WriteLine(  Help(a,0, 6));
        }
    }
}
