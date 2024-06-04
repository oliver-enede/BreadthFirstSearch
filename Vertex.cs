using System;

namespace BreadthFirstSearch
{
    class Vertex
    {
        public string Name { get; set; }
        public int State { get; set; }

        public Vertex(string name)
        {
            Name = name;
        }
    }
}
