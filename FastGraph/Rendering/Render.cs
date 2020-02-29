using System;
using System.Drawing;

namespace FastGraph.Rendering
{
    public static class Render
    {
        private static double CalcScale(int size, int imageSize, int margin)
        {
            double s = (double)size;
            double iS = (double)(imageSize - margin);

            return iS / s;
        }
        private static void RenderAxes(Graphics g, double xScale, double yScale, Size imageSize, AxesModel axesModel)
        {
            g.DrawLine(new Pen(new SolidBrush(Color.Black)),
                new Point(
                    axesModel.xMargin,
                    0
                ),
                new Point(
                    axesModel.xMargin,
                    imageSize.Height - axesModel.yMargin
                )
            );
            g.DrawLine(new Pen(new SolidBrush(Color.Black)),
                new Point(
                    axesModel.xMargin,
                    imageSize.Height-axesModel.yMargin
                ),
                new Point(
                    imageSize.Width,
                    imageSize.Height-axesModel.yMargin
                )
            );
        }
        private static void RenderAsymptote(Graphics g, int xStart, int yStart, int xSize, int ySize, double xScale, double yScale, Size imageSize, AxesModel axesModel, Asymptote asymptote)
        {
            Point start = new Point();
            Point end = new Point();

            if(asymptote.Axis == Axis.X)
            {
                start = new Point(axesModel.xMargin+(int)(((double)asymptote.Coordinate - (double)xStart)*xScale), 0);
                end = new Point(axesModel.xMargin + (int)(((double)asymptote.Coordinate - (double)xStart) * xScale), imageSize.Height - axesModel.yMargin);
            }
            else
            {
                start = new Point(axesModel.xMargin, axesModel.yMargin + (int)(((double)asymptote.Coordinate - (double)yStart) * yScale));
                end = new Point(imageSize.Width,axesModel.yMargin + (int)(((double)asymptote.Coordinate - (double)yStart) * yScale));
            }

            if(asymptote.RenderCoordinate)
            {
                string s = asymptote.Axis.ToString() + " = " + asymptote.Coordinate;
                StringFormat sf = new StringFormat();
                if (asymptote.Axis == Axis.X)
                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
                g.DrawString(s, SystemFonts.DefaultFont, new SolidBrush(asymptote.Color), new PointF(start.X+ 10, start.Y+ 10), sf);
            }

            g.DrawLine(new Pen(new SolidBrush(asymptote.Color)), start, end);
        }
        private static void RenderNode(Graphics g, int xStart, int yStart, int xSize, int ySize, double xScale, double yScale, AxesModel axesModel, GraphNode node, Size imageSize)
        {
            for (int i = 0; i < node.Values.Count-1; i++)
            {
                double x = node.Values[i].X;
                double y = node.Values[i].Y;

                double x1 = node.Values[i+1].X;
                double y1 = node.Values[i+1].Y;

                int xmar = axesModel.xMargin;
                int ymar = axesModel.yMargin;

                g.DrawLine(new Pen(new SolidBrush(node.Color)),
                    new Point(
                        xmar + (int)((x - (double)xStart) * xScale),
                        imageSize.Height - ymar - (int)((y - (double)yStart) * yScale)
                    ),
                    new Point(
                        xmar + (int)((x1 - (double)xStart) * xScale),
                        imageSize.Height - ymar - (int)((y1 - (double)yStart) * yScale)
                    )
                );
            }
        }
        public static Bitmap Image(int xStart, int yStart, int xSize, int ySize, Size imageSize, Graph graph)
        {
            Bitmap bmp = new Bitmap(imageSize.Width, imageSize.Height);

            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(graph.Background, 0, 0, imageSize.Width, imageSize.Height);

            double xScale = CalcScale(xSize, imageSize.Width, graph.Axes.xMargin);
            double yScale = CalcScale(ySize, imageSize.Height, graph.Axes.yMargin);

            RenderAxes(g, xScale, yScale, imageSize, graph.Axes);

            foreach(Asymptote a in graph.Asymptotes)
            {
                RenderAsymptote(g, xStart, yStart, xSize, ySize, xScale, yScale, imageSize, graph.Axes, a);
            }
            foreach (GraphNode node in graph.Nodes)
            {
                RenderNode(g, xStart, yStart, xSize, ySize, xScale, yScale, graph.Axes, node, imageSize);
            }

            return bmp;
        }
    }
}
