using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using SimpleDraw;
using SimpleDraw.Primitives;
using SimpleDraw.Tools;
using SimpleDraw.ViewModes;
using Xceed.Wpf.AvalonDock.Layout;
using Line = System.Windows.Shapes.Line;

namespace SimpleDraw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Document _document = new Document();
        private readonly DocumentView _docView;
        private ITool _selectedTool;

        public MainWindow()
        {
            InitializeComponent();

            _docView = new DocumentView(_document, new DefaultMode());
            _document.Objects.Add(new Primitives.Line(new Point(100, 250), new Point(200, 100)));
            // DrawCanvas.Children.Add(_docView);
        }

        private void DrawCanvas_MouseDown(object sender, MouseButtonEventArgs e, Canvas canvas, ref Point point)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                point = e.GetPosition(canvas);

            if (_selectedTool != null)
                _selectedTool.Press(_docView, point);
        }

        private void DrawCanvas_MouseMove(object sender, MouseEventArgs e, Canvas canvas, ref Point point)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var position = e.GetPosition(canvas);
            
                var line = new Line
                {
                    Stroke = SystemColors.WindowFrameBrush,
                    X1 = point.X,
                    Y1 = point.Y,
                    X2 = position.X,
                    Y2 = position.Y
                };

                point = position;
            
                canvas.Children.Add(line);
            }
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NewViewButton_Click(object sender, RoutedEventArgs e)
        {
            var childrenCount = LayoutDocumentPane.ChildrenCount;

            var layoutDocument = new LayoutDocument { Title = "View" + (childrenCount + 1) };

            var canvas = new Canvas { Background = new SolidColorBrush(Colors.White) { Opacity = 0 } };

            var point = new Point();

            canvas.MouseDown += (o, args) => DrawCanvas_MouseDown(o, args, canvas, ref point);
            canvas.MouseMove += (o, args) => DrawCanvas_MouseMove(o, args, canvas, ref point);

            layoutDocument.Content = _docView;

            LayoutDocumentPane.Children.Add(layoutDocument);
        }

        private void MenuItemToolDot_OnClick(object sender, RoutedEventArgs e)
        {
            _selectedTool = new DotTool();
        }

        private void MenuItemToolLine_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
