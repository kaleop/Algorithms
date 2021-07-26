using System;
using System.Collections.Generic;

namespace Lesson_6_
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph v1 = new Graph("V1");
            Graph v2 = new Graph("V2");
            Graph v3 = new Graph("V3");
            Graph v4 = new Graph("V4");
            Graph v5 = new Graph("V5");
            Graph v6 = new Graph("V6");
            Graph v7 = new Graph("V7");
            Graph v8 = new Graph("V8");

            v1.AddDestination(v2, 32);
            v1.AddDestination(v3, 95);
            v1.AddDestination(v4, 75);
            v1.AddDestination(v5, 57);

            v2.AddDestination(v3, 5);
            v2.AddDestination(v5, 23);
            v2.AddDestination(v8, 16);

            v3.AddDestination(v4, 18);
            v3.AddDestination(v6, 6);

            v4.AddDestination(v5, 24);
            v4.AddDestination(v6, 9);

            v5.AddDestination(v6, 11);
            v5.AddDestination(v7, 20);
            v5.AddDestination(v8, 94);

            v6.AddDestination(v7, 7);

            v7.AddDestination(v8, 81);

            Graph start;
            Graph finish;


            start = v1;
            finish = v7;
            Dictionary<Graph, int> b = GraphHelper.FindMinPath(start, finish);
            
            Console.WriteLine();

            Console.WriteLine($"Начало маршрута {start.Name}");
            foreach (var item in b)
            {
                Console.WriteLine($"{item.Key.Name} _ {item.Value}");
            }



            Console.ReadKey();
        }
    }
}
