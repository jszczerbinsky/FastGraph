using System;
using System.Collections.Generic;
using System.Drawing;

namespace FastGraph
{
    public class GraphNode
    {
        string Name;
        Color Color;

        List<Point> Values;

        public GraphNode(string name, List<Point> values)
        {
            this.Name = name;
            this.Values = values;
        }
    }
}
