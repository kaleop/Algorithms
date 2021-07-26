using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6_
{

    public class Graph
    {
        public string Name { get; set; }
        public List<(Graph destination,int weight)> Destinations { get; private set; }

        public Graph(string name)
        {
            Name = name;
            Destinations = new List<(Graph destination, int weight)>();
        }

        public override bool Equals(object obj)
        {
            Graph a = obj as Graph;
            if (a == null) return false;
            return a.Name == Name ? true : false;
        }

        public void AddDestination(Graph nameDestination, int weight)
        {
            Destinations.Add((nameDestination, weight));
            nameDestination.Destinations.Add((this,weight));
        }

        public void AddDestination(Graph startNode, Graph nameDestination, int weight)
        {
            startNode.AddDestination(nameDestination, weight);
        }
    }

    public enum CommentFlag
    {
        Yes, No
    }

    public static class GraphHelper
    {
        static private Queue<Graph> workList = new Queue<Graph>();
        static private List<Graph> blackList = new List<Graph>();
        static private Graph node = null;

        // Заполняет очередь не повторяющимися элементами
        private static void AddInWorkList( Queue<Graph> workList, Graph currentGraph, List<Graph> blackList, CommentFlag cf)
        {
            if (cf == CommentFlag.Yes)
            {
                foreach (var item in currentGraph.Destinations)
                {
                    if (!workList.Contains(item.destination) && !blackList.Contains(item.destination))
                    {
                        Console.WriteLine($"{item.destination.Name} добавлен в очередь");
                        workList.Enqueue(item.destination);
                    }
                }
            }
            else
            {
                foreach (var item in currentGraph.Destinations)
                {
                    if (!workList.Contains(item.destination) && !blackList.Contains(item.destination))
                    {
                        workList.Enqueue(item.destination);
                    }
                }
            }
        }

        public static Graph FindNode(Graph startGraphNode, string name)
        {
            AllClear();
            
            workList.Enqueue(startGraphNode);

            while (workList.Count > 0)
            {
                node = workList.Dequeue();
                if (node.Name == name) return node;

                if (!blackList.Contains(node))
                {
                    blackList.Add(node);
                    AddInWorkList(workList, node, blackList, CommentFlag.No);
                }

            }
            return node;
        }

        /// <summary>
        /// Возвращает коллекцию с минимальными маршрутами до каждой вершины из startNode
        /// </summary>
        /// <param name="startNode"> начало пути</param>
        /// <returns></returns>
        public static Dictionary<Graph, int> FindAllMinWeight(Graph startNode, CommentFlag cf)
        {
            AllClear();
            int count = GetCount(startNode);
            Graph[] allNode = new Graph[count];
            int[] allWeight = new int[count];

            Dictionary<Graph, int> minWeightForAll = new Dictionary<Graph, int>();

            workList.Enqueue(startNode);
            minWeightForAll.Add(startNode, 0);

            while (workList.Count > 0)
            {
                node = workList.Dequeue();

                foreach (var item in node.Destinations)
                {
                    // Добавляем элемент в колекцию, если его нет. Длина маршрута = вес + вес предка
                    if (!minWeightForAll.ContainsKey(item.destination))
                    {
                        minWeightForAll.Add(item.destination, minWeightForAll[node]+item.weight);
                        workList.Enqueue(item.destination);
                    }
                    else
                    {
                        // Меняем вес пути к элементу если значение меньше чем в коллекции
                        if (minWeightForAll[node] + item.weight < minWeightForAll[item.destination])
                        {
                            minWeightForAll[item.destination] = minWeightForAll[node] + item.weight;
                            workList.Enqueue(item.destination);
                        }
                    }

                    

                }

            }

            if (cf == CommentFlag.Yes)
            {
                foreach (var item in minWeightForAll)
                {
                    Console.WriteLine($" Из {startNode.Name} можно попасть в {item.Key.Name} минимум за {item.Value}");
                }
            }

            return minWeightForAll;
        }


        // Использование Dictionary было не целесообразно
        public static Dictionary<Graph, int> FindMinPath(Graph startNode, Graph finishNode)
        {
            AllClear();
            Dictionary<Graph, int> minPath = new Dictionary<Graph, int>();
            Dictionary<Graph, int> allMinWeight = FindAllMinWeight(startNode, CommentFlag.Yes);
            
            Graph node = finishNode;

            minPath.Add(finishNode, allMinWeight[finishNode]);


            while (node != startNode)
            {
                foreach (var item in node.Destinations)
                {
                    if ((allMinWeight[node] - item.weight)== allMinWeight[item.destination])
                    {
                        minPath.Add(item.destination, allMinWeight[item.destination]);
                        node = item.destination;
                        break;
                    }
                }
            }

            return minPath;
        }

        private static void AllClear()
        {
            workList.Clear();
            blackList.Clear();
            node = null;
        }

        public static int GetCount(Graph startGraphNode)
        {
            AllClear();
            workList.Enqueue(startGraphNode);

            while (workList.Count > 0)
            {
                node = workList.Dequeue();

                if (!blackList.Contains(node))
                {
                    blackList.Add(node);
                    AddInWorkList(workList, node, blackList, CommentFlag.No);
                }

            }

            return blackList.Count;
        }

        public static void Bypass (Graph startGraphNode)
        {
            AllClear();

            Console.WriteLine($"{startGraphNode.Name} добавлен в очередь");
            workList.Enqueue(startGraphNode);

            while (workList.Count>0)
            {
                node = workList.Dequeue();
                Console.WriteLine($"{node.Name} удалён из очереди");

                if (!blackList.Contains(node))
                {
                    Console.WriteLine($"{node.Name} добавлен в чёрный список");
                    blackList.Add(node);
                    AddInWorkList(workList, node, blackList, CommentFlag.Yes);
                }

            }
        }

    }
}
