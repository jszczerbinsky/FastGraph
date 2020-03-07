using System;
using System.Drawing;

namespace FastGraph
{
    public class GraphStyle
    {
        public static GraphStyle Classic
        {
            get
            {
                GraphStyle gs = new GraphStyle();
                gs.Background = new SolidBrush(Color.White);
                gs.ValuePointersPen = new Pen(new SolidBrush(Color.FromArgb(20, 0, 0, 0)),2);
                return gs;
            }
        }
        public static GraphStyle Bright 
        { 
            get 
            {
                GraphStyle gs = new GraphStyle();
                gs.ValuePointersPen = new Pen(new SolidBrush(Color.FromArgb(100, 191, 172, 109)), 2);
                gs.ValuePointersTextBrush = new SolidBrush(Color.FromArgb(119, 108, 69));
                gs.AxisPen = new Pen(new SolidBrush(Color.FromArgb(191, 172, 109)), 2);
                return gs; 
            }
        }
        public static GraphStyle Dark
        {
            get
            {
                GraphStyle gs = new GraphStyle();
                gs.Background = new SolidBrush(Color.FromArgb(61, 78, 91));
                gs.AxisPen = new Pen(new SolidBrush(Color.FromArgb(51, 116, 165)), 2);
                gs.ValuePointersTextBrush = new SolidBrush(Color.FromArgb(62, 138, 196));
                gs.ValuePointersPen = new Pen(new SolidBrush(Color.FromArgb(20, 255, 255, 255)),2);
                gs.AxisNameBrush = new SolidBrush(Color.FromArgb(51, 116, 165));
                return gs;
            }
        }

        public int LeftMargin = 100;
        public int BottomMargin = 70;
        public int TopMargin = 40;
        public int RightMargin = 40;

        public int xValuePointerOutLength = 10;
        public int xValuePointerInLength = 10;
        public int yValuePointerOutLength = 10;
        public int yValuePointerInLength = 10;

        public int xValuePointerMargin = 20;
        public int yValuePointerMargin = 20;

        public bool ShowXAxisName = true;
        public bool ShowYAxisName = true;

        public bool DisplayXValuePointers = true;
        public bool DisplayYValuePointers = true;

        public bool DisplayXValuePointersLines = true;
        public bool DisplayYValuePointersLines = true;

        public Pen AxisPen = new Pen(new SolidBrush(Color.Black), 2);
        public Pen ValuePointersPen = new Pen(new SolidBrush(Color.Black), 2);

        public Font NodeNameFont = new Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold);
        public Font AxisNameFont = new Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold);
        public Font AsymptoteFont = new Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold);
        public Font ValuePointersFont = SystemFonts.DefaultFont;

        public Brush Background = new SolidBrush(Color.Wheat);
        public Brush ValuePointersTextBrush = new SolidBrush(Color.Black);
        public Brush AxisNameBrush = new SolidBrush(Color.Black);

    }
}
