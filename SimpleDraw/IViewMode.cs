using System.Windows.Controls;
using System.Windows.Media;
using SimpleDraw.Primitives;

namespace SimpleDraw
{
    public abstract class IViewMode
    {
        public abstract void Draw(Document document, DrawingContext dc);

        public abstract void Draw(Dot point, DrawingContext dc);

        public abstract void Draw(Line line, DrawingContext dc);

        public abstract void Draw(BezierCurve curve, DrawingContext dc);

        public abstract void Draw(ObjectGroup group, DrawingContext dc);

        public void Draw(IObject obj, DrawingContext dc)
        {
            obj.Draw(dc, this);
        }
    }
}
