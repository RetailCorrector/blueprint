using RetailCorrector.Blueprint.Abstractions;
using RetailCorrector.Blueprint.Parts.Rows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace RetailCorrector.Blueprint.Parts
{
    public class BlockHeader : DockPanel
    {
        private Point _positionInBlock;
        private BlockBase _parent;

        public BlockHeader(string text, Brush background, BlockBase parent)
        {
            _parent = parent;
            Background = background;
            var label = new TextBlock
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(2),
                Text = text,
            };
            Children.Add(label);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            _positionInBlock = Mouse.GetPosition(_parent);
            CaptureMouse();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (IsMouseCaptured)
            {
                var container = VisualTreeHelper.GetParent(_parent) as UIElement;
                var mousePosition = e.GetPosition(container);
                _parent.RenderTransform = new TranslateTransform(mousePosition.X - _positionInBlock.X, mousePosition.Y - _positionInBlock.Y);
                UpdateConnections();
            }
        }

        private void UpdateConnections()
        {
            foreach(var row in _parent.Rows)
            {
                switch (row)
                {
                    case BlockRowIn @in:
                        @in.UpdateConnectionLine();
                        break;
                    case BlockRowOut @out:
                        foreach(var @in in @out.Endpoints)
                            @in.UpdateConnectionLine();
                        break;
                    default: break;
                }
            }
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            ReleaseMouseCapture();
        }
    }
}
