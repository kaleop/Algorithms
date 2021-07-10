using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2_1
{

    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PreviousNode { get; set; }

        public Node(int value)
        {
            Value = value;
        }


        public void AddNode(int value)
        {
            Node lastNode = LastNode(this);
            lastNode.NextNode = new Node(value);
            lastNode.NextNode.PreviousNode = lastNode;
        }

        public void AddNodeAfter(Node node, int index)
        {
            try
            {
                Node startNode = FindNodeByIndex(index);
                node.NextNode = startNode.NextNode;
                node.PreviousNode = startNode;
                startNode.NextNode = node;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RemoveNode(int index)
        {
            int maxIndex = GetCount() - 1;
            try
            {
                Node a = FindNodeByIndex(index);
                if (index - 1 < 0)
                {
                    a.Value = a.NextNode.Value;
                    a.NextNode = a.NextNode.NextNode;

                }
                else if (index >= maxIndex && index > 0)
                {
                    FindNodeByIndex(index - 1).NextNode = null; 
                }
                else
                {
                    a.NextNode.PreviousNode = a.PreviousNode;
                    a.PreviousNode.NextNode = a.NextNode;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void RemoveNode(Node node)
        {
            int c = GetCurrentIndex(node);
            RemoveNode(c);
        }

        public int GetCurrentIndex(Node node)
        {
            int count = 0;
            Node start = this;
            while (start.Value != node.Value)
            {
                start = start.NextNode;
                count++;
            }
            return count;
        }

        public Node FindNode (int searchValue)
        {
            Node node = this;
            while( searchValue != node.Value)
            {
                node = node.NextNode;
                if (node == null) return null;
            }
            
            return node;
        }
        private Node FindNodeByIndex(int index)
        {
            Node start = this;
            int startIndex = 0;
            if (index < 0) throw new ArgumentOutOfRangeException("Значение индекса не может быть отрицательным");

            while (startIndex != index)
            {
                start = start.NextNode;
                startIndex++;
            }
            return start;
        }



        private Node LastNode(Node startNode)
        {
            return startNode.NextNode == null ? startNode : LastNode(startNode.NextNode);
        }
        public Node GetLastNode()
        {
            return LastNode(this);
        }


        public int GetCount()
        {
            int i = 1;
            Node start = this;
            while (start.NextNode != null)
            {
                i++;
                start = start.NextNode;
            }
            return i;
        }

        public void ShowAllValue()
        {
            Node x = this;
            while (x != null)
            {
                Console.WriteLine(x.Value);
                x = x.NextNode;
            }
            Console.WriteLine();
        }

    }
}
