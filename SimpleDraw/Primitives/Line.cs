using System.Windows;
using System.Windows.Media;

namespace SimpleDraw.Primitives
{
    public class Line : IObject
    {
        public Line(Point p1, Point p2)
        {
            P1 = p1;
            P2 = p2;
        }

        public Point P1 { get; set; }
        public Point P2 { get; set; }

        public void Draw(DrawingContext dc, IViewMode viewMode)
        {
            viewMode.Draw(this, dc);
        }
    }
}
