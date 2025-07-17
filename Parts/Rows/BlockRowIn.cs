using RetailCorrector.Blueprint.Abstractions;
using System.Windows;
using System.Windows.Controls;

namespace RetailCorrector.Blueprint.Parts.Rows
{
    internal class BlockRowIn : BlockRowBase
    {
        public string Title { get; }
        private Type[] AllowedBlockTypes { get; }
        public BlockRowOut? Connection { get; } = null;
        public readonly BlockPin Pin;

        public BlockRowIn(string title, BlockBase block, params Type[] allowed): base(block)
        {
            Title = title;
            AllowedBlockTypes = allowed;
            Pin = new(this);
        }

        public override void Draw(Grid parent)
        {
            parent.RowDefinitions.Add(new() { Height = new(25) });
            var index = parent.RowDefinitions.Count - 1;

            Grid.SetRow(Pin, index);
            parent.Children.Add(Pin);

            var label = GenerateLabel(Title, HorizontalAlignment.Left);
            Grid.SetRow(label, index);
            Grid.SetColumn(label, 1);
            parent.Children.Add(label);
        }
    }
}
