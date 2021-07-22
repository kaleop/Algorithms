using System;

namespace BinaryTree
{
    class BinaryTree
    {
        static void Main(string[] args)
        {
            TreeNode tr = new TreeNode(1);

            tr.Add(11,Directions.Left);
            tr.Left.Add(111, Directions.Left);
            tr.Left.Left.Add(1111, Directions.Left);
            tr.Left.Add(112, Directions.Right);
            tr.Add(12, Directions.Right);
            tr.Right.Add(121, Directions.Left);
            tr.Right.Add(122, Directions.Right);
            tr.Right.Right.Add(1221, Directions.Left);



            //1
            //  11
            //    111
            //        1111
            //    112
            //  12
            //    121
            //    122
            //        1221
            tr.PrintTree(tr, " ");



            TreeNode a = tr.GetNodeByValue(111);

            Console.WriteLine();

            // меняем значение 1221 на 3333
            tr.Insert(1221, 3333);

            //добавляеме левую ноду к ноде 121
            tr.Add(1212, tr.GetNodeByValue(121), Directions.Left);

            //удаляем корень со значением 11 и как следствие всю ветку 11
            tr.Remove(11);

            //1
            //  12
            //    121
            //        1212
            //    122
            //        3333
            tr.PrintTree(tr, " ");



            Console.ReadKey();
        }
    }
}
