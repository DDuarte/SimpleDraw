using System.Windows;
using System.Windows.Media;

namespace SimpleDraw.Primitives
{
    public class BezierCurve : IObject
    {
        public BezierCurve(Point p1, Point p2, Point p3, Point p4)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            P4 = p4;
        }

        public Point P1 { get; set; }
        public Point P2 { get; set; }
        public Point P3 { get; set; }
        public Point P4 { get; set; }

        public void Draw(DrawingContext dc, IViewMode viewMode)
        {
            viewMode.Draw(this, dc);
        }
    }
}

