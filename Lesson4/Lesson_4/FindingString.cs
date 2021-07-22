using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lesson_4
{
    class FindingString
    {
        static void Main(string[] args)
        {
            int stringLength = 10;
            int arrayLength = 100000;
            Random r = new Random();
            Stopwatch sw = new Stopwatch();


            string[] currentArray = GetRandomStringArray(stringLength, arrayLength);
            HashSet<int> hsInt = GetHashSetInt(currentArray);
            HashSet<string> hsString = GetHashSetString(currentArray);


            //строка которую будем искать
            string findingString = currentArray[r.Next(0, arrayLength - 1)];


            Console.WriteLine("Поиск в массиве строк");
            sw.Start();
            if ( FindingInArray(currentArray,findingString) == true)
            {
                sw.Stop();
                Console.WriteLine($"Строка {findingString} найдена за {sw.ElapsedTicks} тактов");
            }
            sw.Stop();
            sw.Reset();

            Console.WriteLine();


            Console.WriteLine("Поиск в HashSet<Int>");
            sw.Start();
            if (FindingInHashSetInt(hsInt,findingString) == true)
            {
                sw.Stop();
                Console.WriteLine($"Строка {findingString} найдена за {sw.ElapsedTicks} тактов");
            }
            sw.Stop();
            sw.Reset();

            Console.WriteLine();


            Console.WriteLine("Поиск в HashSet<string>");
            sw.Start();
            if (FindingInHashSetString(hsString, findingString) == true)
            {
                sw.Stop();
                Console.WriteLine($"Строка {findingString} найдена за {sw.ElapsedTicks} тактов");
            }
            sw.Stop();
            sw.Reset();


        }

        public static string[] GetRandomStringArray(int stringLength, int arrayLength)
        {
            StringBuilder sb = new StringBuilder();
            Random r = new Random();
            string[] result= new string[arrayLength];
            for (int j = 0; j < arrayLength; j++)
            {
                sb.Clear();
                for (int i = 0; i < stringLength; i++)
                {
                    sb.Append(Convert.ToChar(r.Next(0, 255)));
                }
                result[j] = sb.ToString();
            }
            return result;            
        }

        public static HashSet<int> GetHashSetInt(string[] s)
        {
            HashSet<int> hs = new HashSet<int>();
            foreach (string item in s)
            {
                hs.Add(item.GetHashCode());
            }
            return hs;
        }

        public static HashSet<string> GetHashSetString(string[] s)
        {
            HashSet<string> hs = new HashSet<string>();
            foreach (string item in s)
            {
                hs.Add(item);
            }
            return hs;
        }

        public static bool FindingInArray (string [] currentArray, string s)
        {
            int arrayLength = currentArray.Length;
            for (int i = 0; i < arrayLength; i++)
            {
                if (currentArray[i] == s)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool FindingInHashSetString(HashSet<string> hs, string s)
        {
            foreach (string item in hs)
            {
                if (item == s)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool FindingInHashSetInt (HashSet<int> hs, string s)
        {
            foreach (int item in hs)
            {
                if (item == s.GetHashCode())
                {
                    return true;
                }
            }
            return false;
        }


    }
}
