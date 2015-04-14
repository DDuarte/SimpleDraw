using System.Windows;
using SimpleDraw.Primitives;

namespace SimpleDraw.Tools
{
    class DotTool : ITool
    {
        public void Press(DocumentView view, Point p)
        {
        }

        public void Drag(DocumentView view, Point p)
        {
        }

        public void Release(DocumentView view, Point p)
        {
            view.TempoObjects.Add(new Dot(p));
            view.CommitChanges();
        }

        public void Cancel(DocumentView view)
        {
            throw new System.NotImplementedException();
        }

        public string GetText()
        {
            return "Dot Tool";
        }

        public string GetToolTipText()
        {
            return "Dot Tool";
        }

        public string Text { get; set; }

        public string ToolTipText { get; set; }
        
        public bool IsEnabled()
        {
            return true;
        }
    }
}
