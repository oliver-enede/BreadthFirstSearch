using System;
using System.Collections.Generic;

namespace BreadthFirstSearch
{
    class DirectedGraph
    {
        public readonly int MAX_VERTICES = 30;
        int n;
        int e;
        bool[,] adj;
        Vertex[] vertexList;

        /* constants for different states of a vertex */
        private readonly int INITIAL = 0;
        private readonly int WAITING = 1;
        private readonly int VISITED = 2;

        public DirectedGraph()
        {
            adj = new bool[MAX_VERTICES, MAX_VERTICES];
            vertexList = new Vertex[MAX_VERTICES];
        }

        public void BfsTraversal()
        {
            for (int v = 0; v < n; v++)
                vertexList[v].State = INITIAL;

            Console.Write("Enter starting vertex for Breadth First Search: ");
            string s = Console.ReadLine();
            Bfs(GetIndex(s));
        }

        private void Bfs(int v)
        {
            Queue<int> qu = new Queue<int>();
            qu.Enqueue(v);
            vertexList[v].State = WAITING;

            while (qu.Count != 0)
            {
                v = qu.Dequeue();
                Console.Write(vertexList[v].Name + " ");
                vertexList[v].State = VISITED;

                for (int i = 0; i < n; i++)
                {
                    if (IsAdjacent(v, i) && vertexList[i].State == INITIAL)
                    {
                        qu.Enqueue(i);
                        vertexList[i].State = WAITING;
                    }
                }
            }
            Console.WriteLine();
        }

        public void BfsTraversal_All()
        {
            for (int v = 0; v < n; v++)
                vertexList[v].State = INITIAL;

            Console.Write("Enter starting vertex for Breadth First Search: ");
            string s = Console.ReadLine();
            Bfs(GetIndex(s));

            for (int v = 0; v < n; v++)
                if (vertexList[v].State == INITIAL)
                    Bfs(v);
        }

        public void InsertVertex(string name)
        {
            vertexList[n++] = new Vertex(name);
        }

        private int GetIndex(string s)
        {
            for (int i = 0; i < n; i++)
                if (s.Equals(vertexList[i].Name))
                    return i;

            throw new InvalidOperationException("Invalid Vertex");
        }

        private bool IsAdjacent(int u, int v)
        {
            return adj[u, v];
        }

        /* Insert an edge (s1,s2) */
        public void InsertEdge(string s1, string s2)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s2);

            if (u == v)
                throw new InvalidOperationException("Not a valid edge");

            if (adj[u, v] == true)
                Console.Write("Edge already present");
            else
            {
                adj[u, v] = true;
                e++;
            }
        }
    }
}
