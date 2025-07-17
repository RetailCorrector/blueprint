using RetailCorrector.Blueprint.Abstractions;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RetailCorrector.Blueprint.Parts
{
    internal class BlockPin : FrameworkElement
    {
        private readonly bool _isInput;
        private readonly BlockRowBase _parent;

        public BlockPin(bool input, BlockRowBase parent)
        {
            VerticalAlignment = VerticalAlignment.Center;
            HorizontalAlignment = HorizontalAlignment.Center;
            Height = Width = 10;
            _isInput = input;
            _parent = parent;
            AddVisualChild(new Ellipse() { Stroke = Brushes.Black });
        }
    }
}
