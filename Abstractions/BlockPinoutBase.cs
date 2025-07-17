using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RetailCorrector.Blueprint.Abstractions
{
    public abstract class BlockPinoutBase(BlockBase block)
    {
        public BlockBase Block { get; } = block;

        public abstract void Draw(Grid parent);

        protected static Ellipse GenerateEllipse() => new()
        {
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Height = 10,
            Width = 10,
            Stroke = Brushes.Black,
        };

        protected static TextBlock GenerateLabel(string text, HorizontalAlignment horiz) => new()
        {
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = horiz,
            Margin = new Thickness(2),
            Text = text
        };
    }
}
