using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace SimpleDraw
{
    public class DocumentView : UIElement, IDisposable
    {
        public DocumentView(Document document, IViewMode viewMode)
        {
            _document = document;
            _viewMode = viewMode;

            TempoObjects = new List<IObject>();

            _document.RegisterDocumentView(this);
        }

        public void Dispose()
        {
            _document.UnregisterDocumentView(this);
        }

        public void NotifyChanges()
        {
            
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            _viewMode.Draw(_document, drawingContext);
        }

        public void CommitChanges()
        {
            _document.Objects.AddRange(TempoObjects);
            TempoObjects.Clear();
        }

        public List<IObject> TempoObjects { get; private set; }
        private readonly Document _document;
        private readonly IViewMode _viewMode;
    }
}
