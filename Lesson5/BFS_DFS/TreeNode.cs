using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_DFS
{ 
    public enum Directions
    {
        Left, Right
    }
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; private set; }
        public TreeNode Right { get; private set; }
        public TreeNode Root { get; private set; }
        public int Deep { get; private set; }

        public TreeNode(int value)
        {
            Value = value;
        }

        public void PrintTree(TreeNode CurrentNode, string space)
        {
            if (CurrentNode != null)
            {
                Console.WriteLine($"{space}{CurrentNode.Value}");
                PrintTree(CurrentNode.Left, space + space);
                PrintTree(CurrentNode.Right, space + space);
            }
        }

        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;
            if (node == null) return false;
            return node.Value == Value;
        }

        public void Insert(int changeThisValue, int insteredValue)
        {
            GetNodeByValue(changeThisValue).Value = insteredValue;
        }

        public void Remove(int value)
        {
            TreeNode tr = GetNodeByValue(value);
            if (tr.Root.Left == tr) tr.Root.Left = null;
            else tr.Root.Right = null;
        }

        public TreeNode GetNodeByValue(int value)
        {
            List<TreeNode> ltn = GetListNode(this);
            foreach (var item in ltn)
            {
                if (item.Value == value) return item;
            }
            return null;
        }

        private List<TreeNode> GetListNode(TreeNode CurrentNode)
        {
            List<TreeNode> allNode = new List<TreeNode>();
            AddToList(CurrentNode, allNode);
            return allNode;
        }

        // формируем список со всеми вершинами
        private void AddToList(TreeNode node, List<TreeNode> ltn)
        {
            if (node != null)
            {
                ltn.Add(node);
                if (node.Left != null) AddToList(node.Left, ltn);
                if (node.Right != null) AddToList(node.Right, ltn);
            }
        }

        public void Add(int value, Directions d)
        {
            TreeNode node = new TreeNode(value);
            node.Root = this;
            node.Deep = node.Root.Deep + 1;
            if (d == Directions.Left)
            {
                Left = node;
            }
            if (d == Directions.Right)
            {
                Right = node;
            }
        }

        // Добавляем ветку к указаному корню
        public void Add(int value, TreeNode root, Directions d)
        {
            root.Add(value, d);
        }

        private void ColorPrint( string text, int value, ConsoleColor cc)
        {
            Console.ForegroundColor = cc;
            Console.WriteLine($"{text} {value}");
            Console.ResetColor();
        }


        // Поиск по очереди
        public TreeNode BFS_Searching(int value)
        {
            TreeNode root;
            Queue<TreeNode> q = new Queue<TreeNode>();

            Console.WriteLine("BFS Поиск");
            Console.WriteLine();
            string qIn = "В очередь помещён элемент";
            string qOut = "Из очереди извлечён элемент";
            ConsoleColor red = ConsoleColor.Red;
            ConsoleColor green = ConsoleColor.Green;

            q.Enqueue(this);
            ColorPrint(qIn, this.Value, green);
            do
            {
                root = q.Dequeue();

                ColorPrint(qOut, root.Value, red);
                if (root.Value == value)
                {
                    Console.WriteLine($"Искомый элемент {root.Value} найден ");
                    return root;
                }
                else
                {
                    if (root.Left != null)
                    {
                        q.Enqueue(root.Left);
                        ColorPrint(qIn, root.Left.Value, green);
                    }
                    if (root.Right != null)
                    {
                        q.Enqueue(root.Right);
                        ColorPrint(qIn, root.Right.Value, green);
                    }
                }
                Console.WriteLine($"В очереди {q.Count} элементов");
            }
            while (q.Count > 0);
            if (q.Count == 0) Console.WriteLine("Элемент не найден");
            return root;
        }




        // Поиск по списку
        public TreeNode DFS_Searching (int value)
        {
            TreeNode root;
            Stack<TreeNode> q = new Stack<TreeNode>();

            Console.WriteLine("DFS Поиск");
            Console.WriteLine();
            string qIn = "В список помещён элемент";
            string qOut = "Из списка извлечён элемент";
            ConsoleColor red = ConsoleColor.Red;
            ConsoleColor green = ConsoleColor.Green;

            q.Push(this);
            ColorPrint(qIn, this.Value, green);
            do
            {
                root = q.Pop();

                ColorPrint(qOut, root.Value, red);
                if (root.Value == value)
                {
                    Console.WriteLine($"Искомый элемент {root.Value} найден ");
                    return root;
                }
                else
                {
                    if (root.Left != null)
                    {
                        q.Push(root.Left);
                        ColorPrint(qIn, root.Left.Value, green);
                    }
                    if (root.Right != null)
                    {
                        q.Push(root.Right);
                        ColorPrint(qIn, root.Right.Value, green);
                    }
                }
                Console.WriteLine($"В списке {q.Count} элементов");
            }
            while (q.Count > 0);
            if (q.Count == 0) Console.WriteLine("Элемент не найден");
            return root;
        }

    }

}
