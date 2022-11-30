using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Permissions;

namespace FastGraph
{
    public class Asymptote
    {
        public Axis Axis { get; private set; }
        public double aFactor;
        public double bFactor;
        public Color Color = Color.Green;
        public DashStyle DashStyle = DashStyle.Dot;

        public Asymptote(Axis axis, double aFactor, double bFactor)
        {
            this.Axis = axis;
            this.aFactor = aFactor;
            this.bFactor = bFactor;
        }

        public double Function(double x)
        {
            return aFactor * x + bFactor; 
        }

    }
}
