using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace SimpleDraw
{
    public class ObjectGroup : IObject
    {
        public ObjectGroup()
        {
            
        }

        public void Draw(DrawingContext drawingContext, IViewMode viewMode)
        {
            viewMode.Draw(this, drawingContext);
        }

        public List<IObject> GetObjects()
        {
            return _objects;
        }

        private readonly List<IObject> _objects = new List<IObject>();
    }
}
