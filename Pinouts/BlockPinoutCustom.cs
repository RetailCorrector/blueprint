using RetailCorrector.Blueprint.Abstractions;
using System.Windows;
using System.Windows.Controls;

namespace RetailCorrector.Blueprint.Pinouts
{
    public class BlockPinoutCustom(FrameworkElement element, BlockBase block) : BlockPinoutBase(block)
    {
        public override void Draw(Grid parent)
        {
            parent.RowDefinitions.Add(new() { Height = new(25) });
            var index = parent.RowDefinitions.Count - 1;
            Grid.SetRow(element, index);
            parent.Children.Add(element);
        }
    }
}
