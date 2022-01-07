using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {
        public static void q_7(Node<Node<int>> lst)
        {
            Queue<int> q = new Queue<int>();
            Node<int> temp;
            while (lst.getNext() != null)
            {
                Console.WriteLine(lst.getNext());
            }
        }
        public static void blog()
        {

            Node<int> n1 = new Node<int>(2, new Node<int>(6));
            Node<int> n2 = new Node<int>(7, new Node<int>(2, new Node<int>(4)));
            Node<int> n3 = new Node<int>(8, new Node<int>(2));
            Node<int> n4 = new Node<int>(1, new Node<int>(6, new Node<int>(9)));
            Node<Node> S = new Node<Node>();

            S.setNext(n1);
            q_7(S);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
