using System;

namespace BFS_DFS
{
    class Program
    {
        static void Main(string[] args)
        {
            Directions left = Directions.Left;
            Directions right = Directions.Right;

            TreeNode tr = new TreeNode(0);
            tr.Add(1, tr.GetNodeByValue(0),left);
            tr.Add(11,tr.GetNodeByValue(1), left);
            tr.Add(12, tr.GetNodeByValue(1), right);
            tr.Add(111, tr.GetNodeByValue(11), left);
            tr.Add(112, tr.GetNodeByValue(11), right);
            tr.Add(2, tr.GetNodeByValue(0), right);
            tr.Add(21, tr.GetNodeByValue(2), left);
            tr.Add(22, tr.GetNodeByValue(2), right);

            tr.PrintTree(tr, " ");

            Console.WriteLine();

            tr.BFS_Searching(2122);

            Console.WriteLine();

            tr.DFS_Searching(21);

            Console.ReadKey();

        }
    }
}
