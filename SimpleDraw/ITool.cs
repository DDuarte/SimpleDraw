using System.Windows;

namespace SimpleDraw
{
    public interface ITool
    {
        void Press(DocumentView view, Point p);
        void Drag(DocumentView view, Point p);
        void Release(DocumentView view, Point p);
        void Cancel(DocumentView view);

        string GetText();
        string GetToolTipText();

        bool IsEnabled();
    }
}
