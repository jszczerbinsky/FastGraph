using System.Collections.Generic;
using System.Drawing;

namespace FastGraph
{
    public class Graph
    {
        internal List<GraphNode> Nodes = new List<GraphNode>();
        internal List<Asymptote> Asymptotes = new List<Asymptote>();
        public Brush Background;

        public int xMargin = 40;
        public int yMargin = 40;

        public double xPointersSpace = 10;
        public double yPointersSpace = 10;

        public bool ShowGrid = true;

        public Graph()
        {
            Background = new SolidBrush(Color.White);
        }
        public void AddNode(GraphNode node)
        {
            Nodes.Add(node);
        }
        public void AddAsymptote(Asymptote a)
        {
            Asymptotes.Add(a);
        }
        public Bitmap Render(int xStart, int yStart, int xSize, int ySize, Size imageSize)
        {
            return Rendering.Render.Image(xStart, yStart, xSize, ySize, imageSize, this);
        }
    }
}
