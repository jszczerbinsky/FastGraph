using System;
using System.Collections.Generic;
using System.Drawing;

namespace FastGraph
{
    public class GraphNode
    {
        public string Name;
        public Color Color = Color.Red;

        public List<Point> Values { get; private set; }

        public GraphNode(string name, List<Point> values)
        {
            this.Name = name;
            this.Values = values;
        }
    }
}
