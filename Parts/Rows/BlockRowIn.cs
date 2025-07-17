using RetailCorrector.Blueprint.Abstractions;
using System.Windows;
using System.Windows.Controls;

namespace RetailCorrector.Blueprint.Parts.Rows
{
    internal class BlockRowIn(string title, BlockBase block, params Type[] allowed) : BlockRowBase(block)
    {
        public string Title { get; } = title;
        private Type[] AllowedBlockTypes { get; } = allowed;
        public BlockRowOut? Connection { get; } = null;

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
