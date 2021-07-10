using System;

namespace Lesson_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int iMin = 0;
            int iMax = 1;
            int searchValue = 7;
            Node x = new Node(1);
            x.AddNode(3);
            x.AddNode(5);
            Console.WriteLine($"Max Count Element:{x.GetCount()}"); 
            x.ShowAllValue(); // 1 3 5


            x.RemoveNode(iMin);
            Console.WriteLine($"Max Count Element:{x.GetCount()}"); 
            x.ShowAllValue();  // 3 5

            x.RemoveNode(iMax);
            Console.WriteLine($"Max Count Element:{x.GetCount()}"); 
            x.ShowAllValue(); // 3


            x.AddNode(6);
            x.AddNode(7);
            x.AddNode(9);

            Console.WriteLine($"Max Count Element:{x.GetCount()}");
            x.ShowAllValue(); // 3 6 7 9
            Console.WriteLine(x.FindNode(searchValue).Value);


            Console.ReadKey();
        }
    }

     
}
