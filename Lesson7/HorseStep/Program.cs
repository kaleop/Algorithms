using System;

namespace HorseStep
{
    class Program
    {
        static void Main(string[] args)
        {
            HorseField hf = new HorseField(5);

            // Результаты работы алгоритма при поле 5х5
            // (0,0) 4196 шагов 
            // (1,0) 24,663,850 шагов - решений нет
            // (2,0) 1,071,518 шагов до верного решения
            // (1,1) 491,071 шагов до верного решения
            // (1,2) 13,969,440 шагов - решений нет
            // (2,2) 139,184 шагов до верного решения

            Horse h = new Horse(new Coordinate(2, 0), hf);

            while (h.Solutions == false && h.NoSolutions == false)
            {
                //MoveN(1, h, hf);
                h.Move(Direction.TopLeft, hf);
            }

            Console.ReadKey();
        }

        public static void MoveN(int count, Horse h, HorseField hf)
        {
            for (int i = 0; i < count; i++)
            {
                h.Move(Direction.TopLeft, hf);
                hf.FieldPrint();

                Console.WriteLine();
            }
        }
    }
}
