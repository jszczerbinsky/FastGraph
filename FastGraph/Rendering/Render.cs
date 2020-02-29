using System;
using System.Drawing;

namespace FastGraph.Rendering
{
    public static class Render
    {
        private static double CalcScale(int size, int imageSize)
        {
            double s = (double)size;
            double iS = (double)imageSize - 20;

            return iS / s;
        }
        private static void RenderAxes(Graphics g, double xScale, double yScale, Size imageSize, AxesModel axesModel)
        {
            g.DrawLine(new Pen(new SolidBrush(Color.Black)), new Point(20, 0), new Point(20, imageSize.Height - 20));
            g.DrawLine(new Pen(new SolidBrush(Color.Black)), new Point(20, imageSize.Height-20), new Point(imageSize.Width -20, imageSize.Height-20));
        }
        public static Bitmap Image(int xStart, int yStart, int xSize, int ySize, Size imageSize, Graph graph)
        {
            Bitmap bmp = new Bitmap(imageSize.Width, imageSize.Height);

            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(graph.Background, 0, 0, imageSize.Width, imageSize.Height);

            double xScale = CalcScale(xSize, imageSize.Width);
            double yScale = CalcScale(ySize, imageSize.Height);

            RenderAxes(g, xScale, yScale, imageSize, graph.Axes);

            return bmp;
        }
    }
}
