using System;

namespace Lesson_1_2
{
    // Задание с числом фибоначи
    class Task_2
    {
        static void Main(string[] args)
        {
            int test = 6;
            Console.WriteLine($"{test}e число = {FiboCycle(test)}");
            Console.WriteLine($"{test}e число = {FiboRecursion(0, 1, test)}");
            test = 8;
            Console.WriteLine($"{test}e число = {FiboCycle(test)}");
            Console.WriteLine($"{test}e число = {FiboRecursion(0, 1, test)}");
            test = 11;
            Console.WriteLine($"{test}e число = {FiboCycle(test)}");
            Console.WriteLine($"{test}e число = {FiboRecursion(0, 1, test)}");

            Console.ReadLine();
        }

        static int FiboCycle (int fquantity)
        {
            int f1 = 0;
            int f2 = 1;
            int fSumm = 0;
            if (fquantity >1)
            {
                for (int i = 1; i < fquantity-1; i++)
                {
                    fSumm = f1 + f2;
                    f1 = f2;
                    f2 = fSumm;
                }
            }
            return fSumm;
        }

        static int FiboRecursion(int f1, int f2, int fquantity)
        {
            return fquantity == 1 ? f1 : FiboRecursion(f2, f1 + f2, fquantity - 1); 
        }
    }
}
