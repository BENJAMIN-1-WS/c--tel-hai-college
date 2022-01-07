using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W_935590
{
    class W_935590
    {
        public static void q_7_1(LinkedList<LinkedList<int>> lst)
        {
            Queue<int> q = new Queue<int>();
            LinkedList<int> temp;
            while (lst.First() != null)
            {
                Console.WriteLine(lst.First());
            }
        }


        public static int rev(string s)
        {
            string news = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                news += s[i];
            }
            int r = Int32.Parse(news);
            return r;
        }

        public static int q_7_2(Node<Node<int>> lst)
        {
            int big = 0;
            Node<Node<int>> pos1 = lst;
            int arrIntLen = 0, inx = 0;
            string str = "";
            Node<int> pos;
            while (pos1 != null)
            {
                arrIntLen++;
                pos1 = pos1.GetNext();
            }
            int[] numbers_to_result = new int[arrIntLen];


            while (lst != null)
            {
                pos = lst.GetInfo();
                while (pos != null)
                {
                    str += pos.GetInfo();
                    pos = pos.GetNext();
                }
                numbers_to_result[inx++] = rev(str);
                str = "";
                lst = lst.GetNext();
            }
            for (int i = 0; i < numbers_to_result.Length; i++)
            {
                if (big < numbers_to_result[i]) { big = numbers_to_result[i]; }
            }

            return big;
        }
        public static void blog()
        {
            LinkedList<int> n1 = new LinkedList<int>(2, new LinkedList<int>(6));
            LinkedList<int> n2 = new LinkedList<int>(7, new LinkedList<int>(2, new LinkedList<int>(4)));
            LinkedList<int> n3 = new LinkedList<int>(8, new LinkedList<int>(2));
            LinkedList<int> n4 = new LinkedList<int>(1, new LinkedList<int>(6, new LinkedList<int>(9)));
            LinkedList<LinkedList> S = new LinkedList<LinkedList>();

            S.First(n1.AddLast());
            q_7(S);
        }

    }
}
