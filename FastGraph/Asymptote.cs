using System;
using System.Drawing;

namespace FastGraph
{
    public class Asymptote
    {
        public Axis Axis { get; private set; }
        public double Coordinate { get; private set; }
        public Color Color = Color.Green;
        public bool RenderCoordinate = true;

        public Asymptote(Axis axis, double coordinate)
        {
            this.Axis = axis;
            this.Coordinate = coordinate;
        }
    }
}
