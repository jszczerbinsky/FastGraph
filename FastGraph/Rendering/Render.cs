using System;
using System.Drawing;

namespace FastGraph.Rendering
{
    public static class Render
    {
        private static double CalcScale(int size, int imageSize, int startMargin, int endMargin)
        {
            double s = size;
            double iS = imageSize - startMargin - endMargin;

            return iS / s;
        }
        private static void RenderAxes(Graphics g, Size imageSize, Graph graph)
        {
            g.DrawLine(graph.Style.AxisPen,
                new Point(
                    graph.Style.LeftMargin,
                    graph.Style.TopMargin
                ),
                new Point(
                    graph.Style.LeftMargin,
                    imageSize.Height - graph.Style.BottomMargin
                )
            );
            g.DrawLine(graph.Style.AxisPen,
                new Point(
                    graph.Style.LeftMargin,
                    imageSize.Height-graph.Style.BottomMargin
                ),
                new Point(
                    imageSize.Width - graph.Style.RightMargin,
                    imageSize.Height-graph.Style.BottomMargin
                )
            );

            StringFormat sfx = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Far
            };
            StringFormat sfy = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.DirectionVertical,
                Alignment = StringAlignment.Center
            };
            g.DrawString(graph.xAxisName, graph.Style.AxisNameFont, graph.Style.AxisNameBrush, new PointF(graph.Style.LeftMargin + (imageSize.Width - graph.Style.LeftMargin - graph.Style.RightMargin)/2, imageSize.Height - 20), sfx);
            g.DrawString(graph.yAxisName, graph.Style.AxisNameFont, graph.Style.AxisNameBrush, new PointF(20, graph.Style.TopMargin + (imageSize.Height - graph.Style.TopMargin - graph.Style.BottomMargin)/2), sfy);
        }
        private static void RenderAsymptote(Graphics g, int xStart, int yStart, int ySize, double xScale, double yScale, Size imageSize, Graph graph, Asymptote asymptote)
        {
            Point start = new Point();
            Point end = new Point();

            if(asymptote.Axis == Axis.X)
            {
                start = new Point(graph.Style.LeftMargin+(int)((asymptote.Coordinate - xStart)*xScale), graph.Style.TopMargin);
                end = new Point(graph.Style.LeftMargin + (int)((asymptote.Coordinate - xStart) * xScale), imageSize.Height - graph.Style.BottomMargin);
            }
            else
            {
                start = new Point(graph.Style.LeftMargin, (int)((ySize-asymptote.Coordinate+yStart)*yScale) + graph.Style.TopMargin);
                end = new Point(imageSize.Width - graph.Style.RightMargin, (int)((ySize - asymptote.Coordinate + yStart)*yScale) + graph.Style.TopMargin);
            }

            if(asymptote.RenderCoordinate)
            {
                string s = asymptote.Axis.ToString() + " = " + asymptote.Coordinate;
                if (asymptote.CustomName != null)
                    s = asymptote.CustomName;
                StringFormat sf = new StringFormat();
                if (asymptote.Axis == Axis.X)
                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
                g.DrawString(s, graph.Style.AsymptoteFont, new SolidBrush(asymptote.Color), new PointF(start.X+ 10, start.Y+ 10), sf);
            }

            g.DrawLine(new Pen(new SolidBrush(asymptote.Color)), start, end);
        }
        private static void RenderNode(Graphics g, int xStart, int yStart, double xScale, double yScale, Graph graph, GraphNode node, Size imageSize)
        {
            Point p2 = new Point();

            for (int i = 0; i < node.Values.Count-1; i++)
            {
                double x = node.Values[i].X;
                double y = node.Values[i].Y;

                double x1 = node.Values[i+1].X;
                double y1 = node.Values[i+1].Y;

                int xmar = graph.Style.LeftMargin;
                int ymar = graph.Style.BottomMargin;

                Point p1 = new Point(
                        xmar + (int)((x - xStart) * xScale),
                        imageSize.Height - ymar - (int)((y - yStart) * yScale)
                    );

                p2 = new Point(
                        xmar + (int)((x1 - xStart) * xScale),
                        imageSize.Height - ymar - (int)((y1 - yStart) * yScale)
                    );

                if (node.RenderPoints)
                {
                    if (i == 0)
                        g.FillEllipse(new SolidBrush(node.Color), p1.X - 4, p1.Y - 4, 8, 8);
                    g.FillEllipse(new SolidBrush(node.Color), p2.X - 4, p2.Y - 4, 8, 8);
                }

                g.DrawLine(new Pen(new SolidBrush(node.Color),2 ),
                    p1,
                    p2
                );
            }

            p2.X += 10;
            StringFormat sf = new StringFormat
            {
                LineAlignment = StringAlignment.Center
            };
            g.DrawString(node.Name, graph.Style.NodeNameFont, new SolidBrush(node.Color), p2, sf);

        }
        private static void RenderValuePointers(Graphics g, int xStart, int yStart, int xSize, int ySize, double xScale, double yScale,Size imageSize, Graph graph)
        {
            StringFormat sfx = new StringFormat
            {
                Alignment = StringAlignment.Center
            };

            StringFormat sfy = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Far
            };

            for (float x = xStart; x <= xSize; x+= graph.xPointersSpace)
            {
                Point start = new Point((int)((x - xStart) * xScale + graph.Style.LeftMargin), imageSize.Height - graph.Style.BottomMargin - 10);
                Point end = new Point((int)((x - xStart) * xScale + graph.Style.LeftMargin), imageSize.Height - graph.Style.BottomMargin + 10);

                if (graph.ShowGrid)
                    start.Y = graph.Style.TopMargin;

                g.DrawString(x.ToString(), graph.Style.ValuePointersFont, graph.Style.ValuePointersTextBrush, new PointF(
                    (float)((x-xStart) * xScale + graph.Style.LeftMargin),
                    imageSize.Height - graph.Style.BottomMargin + 20
                ), sfx);

                g.DrawLine(graph.Style.ValuePointersPen,
                    start,
                    end
                );
            }
            for (float y = yStart; y<=yStart+ySize - graph.yPointersSpace; y += graph.yPointersSpace)
            {
                Point start = new Point(graph.Style.LeftMargin -10, (int)((ySize - y + yStart) * yScale + graph.Style.TopMargin));
                Point end = new Point(graph.Style.LeftMargin + 10, (int)((ySize - y + yStart) * yScale) + graph.Style.TopMargin);

                if (graph.ShowGrid)
                    end.X = imageSize.Width - graph.Style.RightMargin;

                g.DrawString(y.ToString(), graph.Style.ValuePointersFont, graph.Style.ValuePointersTextBrush, new PointF(
                  graph.Style.LeftMargin - 20,
                  (float)((ySize - y + yStart) * yScale + graph.Style.TopMargin)
                  ), sfy); 
                  
                  g.DrawLine(graph.Style.ValuePointersPen,
                    start,
                    end
                    );
            }
        }
        public static Bitmap Image(int xStart, int yStart, int xSize, int ySize, Size imageSize, Graph graph)
        {
            Bitmap bmp = new Bitmap(imageSize.Width, imageSize.Height);

            Graphics g = Graphics.FromImage(bmp);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.FillRectangle(graph.Style.Background, 0, 0, imageSize.Width, imageSize.Height);

            double xScale = CalcScale(xSize, imageSize.Width, graph.Style.LeftMargin, graph.Style.RightMargin);
            double yScale = CalcScale(ySize, imageSize.Height, graph.Style.TopMargin, graph.Style.BottomMargin);

            RenderValuePointers(g, xStart, yStart, xSize, ySize, xScale, yScale, imageSize, graph);
            RenderAxes(g, imageSize, graph);

            foreach (Asymptote a in graph.Asymptotes)
            {
                RenderAsymptote(g, xStart, yStart, ySize, xScale, yScale, imageSize, graph, a);
            }
            foreach (GraphNode node in graph.Nodes)
            {
                RenderNode(g, xStart, yStart, xScale, yScale, graph, node, imageSize);
            }

            return bmp;
        }
    }
}
