using System;

namespace Lesson_1
{
    class Algorithm_1
    {
        static void Main(string[] args)
        {
            Flowchart();
            Flowchart();
            Flowchart();

            Console.ReadLine();

        }

        static void Flowchart ()
        {
            Console.WriteLine();
            int d = 0;
            int i = 2;
            int number;
            Console.Write("Введите целое положительное число : ");
            try
            {
                number = Int32.Parse(Console.ReadLine());
                if (number <= 0)
                {
                    throw new Exception();
                }
                while (i < number)
                {
                    if (number % i == 0)
                    {
                        d++;
                    }
                    i++;
                }
                if (d == 0) Console.WriteLine($"{number} простое");
                else Console.WriteLine($"{number} не простое");
            }
            catch (Exception)
            {
                Console.WriteLine("Число должно быть целым и больше нуля");
            }
        }
    }
}
