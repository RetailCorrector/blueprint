using RetailCorrector.Blueprint.Abstractions;
using System.Windows;
using System.Windows.Controls;

namespace RetailCorrector.Blueprint.Parts.Pinouts
{
    internal class BlockPinoutIn(string title, BlockBase block, params Type[] allowed) : BlockPinoutBase(block)
    {
        public string Title { get; } = title;
        private Type[] AllowedBlockTypes { get; } = allowed;
        public BlockPinoutOut? Connection { get; } = null;

        public override void Draw(Grid parent)
        {
            parent.RowDefinitions.Add(new() { Height = new(25) });
            var index = parent.RowDefinitions.Count - 1;

            var e = GenerateEllipse();
            Grid.SetRow(e, index);
            parent.Children.Add(e);

            var label = GenerateLabel(Title, HorizontalAlignment.Left);
            Grid.SetRow(label, index);
            Grid.SetColumn(label, 1);
            parent.Children.Add(label);
        }
    }
}
