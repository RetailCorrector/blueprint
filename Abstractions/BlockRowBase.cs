using System.Windows;
using System.Windows.Controls;

namespace RetailCorrector.Blueprint.Abstractions
{
    public abstract class BlockRowBase(BlockBase block)
    {
        public BlockBase Block { get; } = block;

        public abstract void Draw(Grid parent);

        protected static TextBlock GenerateLabel(string text, HorizontalAlignment horiz) => new()
        {
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = horiz,
            Margin = new Thickness(2),
            Text = text
        };
    }
}
