using System.Windows.Media;

namespace SimpleDraw
{
    public interface IObject
    {
        void Draw(DrawingContext dc, IViewMode viewMode);
    }
}
