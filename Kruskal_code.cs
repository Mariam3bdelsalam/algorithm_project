using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class Program
    {
        static List<Edge> edges = new List<Edge>()
        {
            new Edge('A', 'B', 7),
            new Edge('A', 'D', 5),
            new Edge('B', 'C', 8),
            new Edge('B', 'D', 9),
            new Edge('B', 'E', 7),
            new Edge('C', 'E', 5),
            new Edge('D', 'E', 15),
            new Edge('D', 'F', 6),
            new Edge('E', 'F', 8),
            new Edge('E', 'G', 9),
            new Edge('F', 'G', 11)
        };

        static List<Edge> mst = new List<Edge>();
        static Dictionary<char, int> vertexMap = new Dictionary<char, int>();
        static char[] reverseMap;

        static void Main(string[] args)
        {
            MapVertices();

            Console.WriteLine("Edges before sorting (u, v, w):");
            foreach (var edge in edges)
            {
                Console.WriteLine($"{edge.U} - {edge.V} : {edge.Weight}");
            }

            // Perform Kruskal's algorithm
            Kruskal();

            Console.WriteLine("\nEdges in the MST (u, v, w):");
            foreach (var edge in mst)
            {
                Console.WriteLine($"{edge.U} - {edge.V} : {edge.Weight}");
            }
        }

        static void MapVertices()
        {
            HashSet<char> vertices = new HashSet<char>();
            foreach (var edge in edges)
            {
                vertices.Add(edge.U);
                vertices.Add(edge.V);
            }

            int index = 0;
            reverseMap = new char[vertices.Count];
            foreach (char vertex in vertices)
            {
                vertexMap[vertex] = index;
                reverseMap[index] = vertex;
                index++;
            }
        }

        static void Kruskal()
        {
            // Sort edges by weight
            edges.Sort((a, b) => a.Weight.CompareTo(b.Weight));

            int[] parent = new int[vertexMap.Count];
            for (int i = 0; i < parent.Length; i++) parent[i] = i;

            foreach (var edge in edges)
            {
                int u = vertexMap[edge.U];
                int v = vertexMap[edge.V];

                if (Find(parent, u) != Find(parent, v))
                {
                    mst.Add(edge);
                    Union(parent, u, v);
                }
            }
        }

        static int Find(int[] parent, int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent, parent[x]);
            }
            return parent[x];
        }

        static void Union(int[] parent, int x, int y)
        {
            int rootX = Find(parent, x);
            int rootY = Find(parent, y);
            if (rootX != rootY)
            {
                parent[rootY] = rootX;
            }
        }
    }

    class Edge
    {
        public char U { get; set; }
        public char V { get; set; }
        public int Weight { get; set; }

        public Edge(char u, char v, int weight)
        {
            U = u;
            V = v;
            Weight = weight;
        }
    }
}