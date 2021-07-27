using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseStep
{
    public enum Direction
    {
        TopLeft,
        TopRight,
        RightTop,
        RightBottom,
        BottomRight,
        BottomLeft,
        LeftBottom,
        LeftTop
    }

    public class HorseField
    {
        public int[,] Field { get; private set; }
        public int Length { get; private set; }

        public HorseField(int length)
        {
            Field = new int[length, length];
            Length = length - 1;
        }
        public bool CheckMove(Coordinate position)
        {
            if (position.X >= 0 && position.X <= Length && position.Y >= 0 && position.Y <= Length && Field[position.X, position.Y] == 0)
            {
                return true;
            }
            else return false;
        }
        public void Move(Coordinate position)
        {
            Field[position.X, position.Y] = 1;
        }

        public void MoveBack(Coordinate currentPosition)
        {
            Field[currentPosition.X, currentPosition.Y] = 0;
        }

        public bool CheckWin()
        {
            int count = 0;
            foreach (var item in Field)
            {
                if (item == 1) count++;
                else return false;
            }
            if (count == Field.Length) return true;
            return false;
        }

        public void FieldPrint()
        {
            for (int i = 0; i < Field.GetLongLength(0); i++)
            {
                for (int j = 0; j < Field.GetLongLength(0); j++)
                {
                    Console.Write(Field[j, i]);
                }
                Console.WriteLine();
            }
        }
    }
    public class Coordinate
    {
        public Dictionary<Direction,Coordinate> Araund { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
            Araund = new Dictionary<Direction, Coordinate>();
        }

        public override bool Equals(object obj)
        {
            Coordinate c = obj as Coordinate;
            if (c != null)
            {
                return (X == c.X && Y == c.Y);
            }
            else return false;
        }
    }
    public class Horse
    {
        private static int count;
        public bool NoSolutions { get; private set; }
        public bool Solutions { get; private set; }
        public Coordinate StartPosition { get; private set; }
        public Coordinate CurrentPosition { get; private set; }
        public Stack<Coordinate> Steps { get; private set; }
        public Horse(Coordinate startPosition, HorseField hf)
        {
            StartPosition = startPosition;
            CurrentPosition = startPosition;
            hf.Move(CurrentPosition);
            Steps = new Stack<Coordinate>();
            Steps.Push(CurrentPosition);
            NoSolutions = false;
            Solutions = false;
            count = 0;
        }

        private (int x, int y) TakeXY(Direction d)
        {
            switch (d)
            {
                case Direction.TopLeft:
                    return (-1, -2);
                case Direction.TopRight:
                    return (1, -2);
                case Direction.RightTop:
                    return (2, -1);
                case Direction.RightBottom:
                    return (2, 1);
                case Direction.BottomRight:
                    return (1, 2);
                case Direction.BottomLeft:
                    return (-1, 2);
                case Direction.LeftBottom:
                    return (-2, 1);
                case Direction.LeftTop:
                    return (-2, -1);
            }
            return (0,0);
        }

        public void Move(Direction d, HorseField hf)
        {
            count++;
            (int x, int y) nextCoor = TakeXY(d);

            if (d >= Direction.TopLeft && d <= Direction.LeftTop && Steps.Count > 0)
            {
                // Извлекаем из стека последний элемент, чтобы изменять его свойство Araund
                CurrentPosition = Steps.Pop();
                Coordinate next = new Coordinate(CurrentPosition.X + nextCoor.x, CurrentPosition.Y + nextCoor.y);

                // Проверяем ходили ли мы в направлении d с текущих координат и можем ли мы сходить
                if (!CurrentPosition.Araund.ContainsKey(d) && hf.CheckMove(next))
                {
                    CurrentPosition.Araund.Add(d, next);
                    hf.Move(next);
                    //Добавляем в стэк текущую позицию с изменениями т.к. мы её извлекли и добавляем следущую позицию
                    Steps.Push(CurrentPosition);
                    Steps.Push(next);
                    if (hf.CheckWin())
                    {
                        Solutions = true;
                        Console.WriteLine($"Решено за {count} ходов. Начало в точке ({StartPosition.X},{StartPosition.Y})");
                    }
                }
                else
                {
                    //Возвращаем текущую позицию в стэк, т.к. ни каких изменений произведено небыло
                    Steps.Push(CurrentPosition);
                    Move(d + 1, hf);
                }
            }
            else
            {
                //Если стэк пуст, значит алгоритм перебрал все возможные ходы
                //Если нет - делаем шаг назад
                if (Steps.Count > 0)
                {
                    Steps.Pop();
                    hf.MoveBack(CurrentPosition);
                    Move(Direction.TopLeft, hf);
                }
                else
                {
                    NoSolutions = true;
                    Console.WriteLine($"Решений из координт ({StartPosition.X}, {StartPosition.Y}) нет. Сделано {count} шагов");
                }
                
            }
        }
    }
}
