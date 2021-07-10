using System;

namespace Lesson_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = 999;
            int max = 9999;
            int searchingValue = 5;
            Random r = new Random();
            int arrLength = r.Next(min, max);
            int[] arr = new int[arrLength];

            for (int i = 0; i < arrLength; i++)
            {
                arr[i] = i;
            }

            Console.WriteLine($"число {searchingValue} найдено за {BinarySearch(arr, searchingValue)} шагов в массиве из {arrLength} элементов");

            Console.ReadKey();

            static int BinarySearch (int[] inputArray, int value)
            {
                int min = 0;
                int max = inputArray.Length - 1;
                int center = -1;
                int count = 0;

                do
                {
                    count++;
                    center = (max - min) / 2+min;
                    if (value < inputArray[center])
                    {
                        max = center;
                    }
                    else if (value > inputArray[center])
                    {
                        min = center;
                    }
                    else
                    {
                        center = value;
                    }
                }
                while (center != value);
                return count;
            }
        }


    }
}
