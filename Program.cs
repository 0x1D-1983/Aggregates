using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Aggregates
{
    class Program
    {
        static void Main(string[] args)
        {
            var mylist = new List<int>() { 2, 45, 2, 12, 1, 89, 61 };

            Console.WriteLine($"Length: {Length(mylist)}");

            Console.WriteLine($"Max: {Max(mylist)}");

            Print(Filter(mylist, elem => elem % 2 == 0 ? true : false));

            Print(Map(mylist, elem => elem * elem));
        }

        // Length
        static int Length(IEnumerable<int> list) => list.Aggregate(0, (aggr, _) => aggr + 1);

        // Max
        static int Max(IEnumerable<int> list) => list.Aggregate(0, (aggr, i) => i > aggr ? i : aggr);

        // Filter
        static IEnumerable<int> Filter(IEnumerable<int> list, Func<int, bool> predicate) =>
            list.Aggregate(new List<int>(), (aggr, i) =>
            {
                if (predicate(i))
                {
                    aggr.Add(i);
                }

                return aggr;
            });

        // Map
        static IEnumerable<float> Map(IEnumerable<int> list, Func<int, float> map) =>
            list.Aggregate(new List<float>(), (aggr, i) =>
            {
                aggr.Add(map(i));
                return aggr;
            });

        // print
        static void Print<T>(IEnumerable<T> list)
        {
            foreach(T elem in list)
            {
                Console.Write($"{elem}, ");
            }
            Console.Write("nil");
            Console.WriteLine();
        }
    }
}
