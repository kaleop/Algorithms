using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
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

        public TreeNode (int value)
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

        public void Insert(int changeThisValue , int insteredValue)
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
        private void AddToList (TreeNode node, List<TreeNode> ltn)
        {
            if (node != null)
            {
                ltn.Add(node);
                if (node.Left != null) AddToList(node.Left, ltn);
                if (node.Right != null) AddToList(node.Right, ltn);
            }
        }

        public void Add (int value, Directions d)
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
        public void Add (int value, TreeNode root, Directions d)
        {
            root.Add(value, d);
        }
    }

}
