using System;
using System.Collections.Generic;

namespace SimpleDraw
{
    public class Document
    {
        public Document()
        {
            Objects = new List<IObject>();
        }

        public void RegisterDocumentView(DocumentView docView)
        {
            _documentViews.Add(docView);
        }

        public void UnregisterDocumentView(DocumentView docView)
        {
            _documentViews.Remove(docView);
        }

        protected void OnChange()
        {
            foreach (var docView in _documentViews)
            {
                docView.NotifyChanges();
            }
        }

        private readonly ISet<DocumentView> _documentViews = new HashSet<DocumentView>();
        public List<IObject> Objects { get; private set; }
    }
}
