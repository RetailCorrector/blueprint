using RetailCorrector.Blueprint.Abstractions;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RetailCorrector.Blueprint.Parts
{
    internal class BlockPin : FrameworkElement
    {
        private readonly BlockRowBase _parent;

        public BlockPin(BlockRowBase parent)
        {
            VerticalAlignment = VerticalAlignment.Center;
            HorizontalAlignment = HorizontalAlignment.Center;
            Height = Width = 10;
            _parent = parent;
            AddVisualChild(new Ellipse() { Stroke = Brushes.Black });
        }
    }
}
