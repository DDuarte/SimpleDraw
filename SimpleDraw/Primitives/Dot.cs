using System.Windows;
using System.Windows.Media;

namespace SimpleDraw.Primitives
{
    public class Dot : IObject
    {
        public Dot(Point p)
        {
            P = p;
        }

        public Point P { get; set; }

        public void Draw(DrawingContext dc, IViewMode viewMode)
        {
            viewMode.Draw(this, dc);
        }
    }
}
