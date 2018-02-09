using System;
using System.Collections.Generic;

namespace practice.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            var boardSize = Int32.Parse(Console.ReadLine());
            for (int i = 1; i < boardSize; i++)
            {
                for (int j = 1; j < boardSize; j++)
                {
                    FindMoves(i, j, boardSize);
                }
                Console.WriteLine();
                Console.ReadLine();
            }
        }

        private static void FindMoves(int positionA, int positionB, int boardSize)
        {
            var visited = new List<int[]>();
            var numVisits = visited.Count;
            var firstPosition = new int[] { 0, 0 };

            visited.Add(firstPosition);
            var currentPositons = new List<int[]> { firstPosition };
            int depth = 0;

            while (visited.Count > numVisits)
            {
                if (currentPositons.Exists(p => p[0] == boardSize - 1 && p[1] == boardSize - 1))
                {
                    Console.Write(depth + " ");
                    break;
                }

                numVisits = visited.Count;
                var nextPositions = new List<int[]>();

                foreach (var position in currentPositons)
                {
                    nextPositions.AddRange(checkPositions(position, positionA, positionB, boardSize));
                }
                depth += 1;

                var uniqueNextPositions = new List<int[]>();
                foreach (var pos in nextPositions)
                {
                    if (!visited.Exists(p => p[0] == pos[0] && p[1] == pos[1]))
                    {
                        uniqueNextPositions.Add(pos);
                        visited.Add(pos);
                    }
                }

                currentPositons = uniqueNextPositions;
            }

            if (numVisits >= visited.Count)
            {
                Console.Write(-1 + " ");
            }
        }

        private static List<int[]> checkPositions(int[] currPosition, int positionA, int positionB, int boardSize)
        {
            var x = currPosition[0];
            var y = currPosition[1];

            var newPositions = new List<int[]>();

            newPositions.Add(checkValid(( x + positionA), (y + positionB), boardSize, newPositions));
            newPositions.Add(checkValid(( x + positionA), (y - positionB ), boardSize, newPositions));
            newPositions.Add(checkValid(( x - positionA), (y - positionB ), boardSize, newPositions));
            newPositions.Add(checkValid(( x - positionA), (y + positionB ), boardSize, newPositions));
            newPositions.Add(checkValid(( x + positionB), (y + positionA ), boardSize, newPositions));
            newPositions.Add(checkValid(( x + positionB), (y - positionA ), boardSize, newPositions));
            newPositions.Add(checkValid(( x - positionB), (y - positionA ), boardSize, newPositions));
            newPositions.Add(checkValid(( x - positionB), (y + positionA ), boardSize, newPositions));

            newPositions.RemoveAll(p => p[0] == 0 && p[1] == 0);
            return newPositions;
        }

        private static int[] checkValid(int v1, int v2, int boardSize, List<int[]> newPositions)
        {
            newPositions.Exists(p => p[0] == v1 && p[1] == v2);
            if (0 <= v1 && v1 <= boardSize - 1 && 0 <= v2 && v2 <= boardSize - 1 && !newPositions.Exists(p => p[0] == v1 && p[1] == v2))
            {
                return new int[] { v1, v2 };
            }

            return new int[2];
        }
    }
}
