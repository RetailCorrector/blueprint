using RetailCorrector.Blueprint.Abstractions;
using System.Windows;
using System.Windows.Controls;

namespace RetailCorrector.Blueprint.Parts.Rows
{
    public class BlockRowCustom(FrameworkElement element, BlockBase block) : BlockRowBase(block)
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
