﻿using System.ComponentModel;

namespace _12.EvenNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            while ((n = int.Parse(Console.ReadLine())) % 2 != 0)
            {
                Console.WriteLine("Please write an even number.");
            }

            if (n < 0) n = Math.Abs(n);

            Console.WriteLine("The number is: {0}", n);
        }
    }
}