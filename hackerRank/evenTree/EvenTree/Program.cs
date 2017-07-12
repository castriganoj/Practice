using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenTree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] setUpInput = Console.ReadLine().Split();

            int numberOfNodes = Int32.Parse(setUpInput[0]);
            int numberOfEdges = Int32.Parse(setUpInput[1]);


            var adjencyList = new Dictionary<int, List<int>>();

            //set up pointers of adjency list
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
            //Instead of printing out like we did below,
            //we just need to check and see if the number
            //of references for each pointer is even.
            //If it is not, print 
            Console.ReadKey();
            Console.WriteLine(" ");
            foreach (var pointer in adjencyList)
            {
                Console.Write(pointer.Key + " => ");
                pointer.Value
                    .ForEach(value => Console.Write(value + " "));
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
