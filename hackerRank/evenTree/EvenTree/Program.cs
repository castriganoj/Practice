using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenTree
{
    class Program
    {

        static int answer = 0;

        static void Main(string[] args)
        {
            var adjencyList = new Dictionary<int, List<int>>();

            BuildAdjencyList(adjencyList);

            PrintAdjencyList(adjencyList);

            dfs(adjencyList.Keys.First(), adjencyList);

            Console.WriteLine(answer);
            Console.ReadLine();
        }

        private static int dfs(int node, Dictionary<int, List<int>> adjencyList)
        {
            Console.WriteLine("Searching node: " + node);

            int numOfVertex = 0;

            int childNodeCount = 0;
            if (adjencyList.ContainsKey(node))
            {
                childNodeCount = adjencyList[node].Count;
            }

            for (int i = 0; i < childNodeCount; i++)
            {
                int childNode = adjencyList[node][i];

                int num_nodes = dfs(childNode, adjencyList);

                if (num_nodes % 2 == 0)
                {
                    Console.WriteLine("Node number: " + node);
                    answer++;
                    Console.WriteLine("Subtree found at [{0}] with root child node [{1}] and has a total of [{2}] nodes", node, childNode, num_nodes);
                    Console.ReadLine();
                }
                else
                {
                    numOfVertex += num_nodes;
                }
            }
            return numOfVertex + 1;
        }

        private static void PrintAdjencyList(Dictionary<int, List<int>> adjencyList)
        {
            foreach (var pointer in adjencyList)
            {
                Console.Write(pointer.Key + " => ");
                pointer.Value
                    .ForEach(value => Console.Write(value + " "));
                Console.WriteLine();
            }
        }

        private static void BuildAdjencyList(Dictionary<int, List<int>> adjencyList)
        {
            string[] setUpInput = Console.ReadLine().Split();

            int numberOfNodes = Int32.Parse(setUpInput[0]);
            int numberOfEdges = Int32.Parse(setUpInput[1]);

            for (int i = 0; i < numberOfEdges; i++)
            {
                string[] edge = Console.ReadLine().Split();
                int sourceNode = Int32.Parse(edge[1]);
                int destinationNode = Int32.Parse(edge[0]);

                if (!adjencyList.ContainsKey(sourceNode))
                {
                    adjencyList.Add(sourceNode, null);
                    adjencyList[sourceNode] = new List<int> { destinationNode };
                }
                else
                {
                    adjencyList[sourceNode].Add(destinationNode);
                }
            }

            Console.ReadKey();
            Console.WriteLine(" ");
        }
    }
}
