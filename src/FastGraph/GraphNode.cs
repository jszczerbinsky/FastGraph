using System;
using System.Collections.Generic;
using System.Drawing;

namespace FastGraph
{
    public class GraphNode
    {
        public string Name;
        public Color Color = Color.Red;

        public List<Coordinate> Values { get; private set; } = new List<Coordinate>();

        public bool RenderPoints = true;

        public bool RenderLines = true;

        public bool RenderName = true;

        public GraphNode(string name)
        {
            this.Name = name;
        }
        public GraphNode(string name, List<Coordinate> values)
        {
            this.Name = name;
            this.Values = values;
        }
    }
}
