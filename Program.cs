using System;
using System.Collections;
using System.Collections.Generic;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable test = new List<int> { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };

            IEnumerable result = test.Skip(2);
            result.PrintToConsole();

            result = test.Take(4);
            result.PrintToConsole();

            result = test.Distinct();
            result.PrintToConsole();

            Console.ReadKey();
        }
    }
}
