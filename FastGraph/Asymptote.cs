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
        public string CustomName = null;

        public Asymptote(string customName, Axis axis, double coordinate)
        {
            this.CustomName = customName;
            this.Axis = axis;
            this.Coordinate = coordinate;
        }
        public Asymptote(Axis axis, double coordinate)
        {
            this.Axis = axis;
            this.Coordinate = coordinate;
        }
    }
}
