using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using SimpleDraw.Primitives;
using Line = SimpleDraw.Primitives.Line;

namespace SimpleDraw.ViewModes
{
    class DefaultMode : IViewMode
    {
        private readonly Brush _brush = new SolidColorBrush(Colors.Black);
        private readonly Pen _pen;

        public DefaultMode()
        {
            _pen = new Pen(_brush, 1.0);
        }

        public override void Draw(Document document, DrawingContext dc)
        {
            foreach (var obj in document.Objects)
            {
                obj.Draw(dc, this);
            }
        }

        public override void Draw(Dot dot, DrawingContext dc)
        {
            dc.DrawEllipse(_brush, _pen, dot.P, 1.0, 1.0);
        }

        public override void Draw(Line line, DrawingContext dc)
        {
            dc.DrawLine(_pen, line.P1, line.P2);
        }

        public override void Draw(BezierCurve curve, DrawingContext dc)
        {
            var c = new PolyBezierSegment(new List<Point> {curve.P1, curve.P2, curve.P3, curve.P4}, false);

            // Set up the Path to insert the segments
            var path = new PathGeometry();

            var pathFigure = new PathFigure
            {
                StartPoint = curve.P1,
                IsClosed = true
            };

            path.Figures.Add(pathFigure);
            pathFigure.Segments.Add(c);

            dc.DrawGeometry(_brush, _pen, path);
        }

        public override void Draw(ObjectGroup group, DrawingContext dc)
        {
            foreach (var obj in group.GetObjects())
            {
                obj.Draw(dc, this);
            }
        }
    }
}
