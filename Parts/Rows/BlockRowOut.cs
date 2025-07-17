using RetailCorrector.Blueprint.Abstractions;
using System.Windows;
using System.Windows.Controls;

namespace RetailCorrector.Blueprint.Parts.Rows
{
    internal class BlockRowOut : BlockRowBase
    {
        public string Title { get; }
        public List<BlockRowIn> Endpoints { get; set; } = [];
        public string Value { get; set; } = "";
        public readonly BlockPin Pin;

        public BlockRowOut(string title, BlockBase block): base(block)
        {
            Title = title;
            Pin =  new(this);
        }

        public override void Draw(Grid parent)
        {
            parent.RowDefinitions.Add(new() { Height = new(25) });
            var index = parent.RowDefinitions.Count - 1;

            Grid.SetRow(Pin, index);
            Grid.SetColumn(Pin, 2);
            parent.Children.Add(Pin);

            var label = GenerateLabel(Title, HorizontalAlignment.Right);
            Grid.SetRow(label, index);
            Grid.SetColumn(label, 1);
            parent.Children.Add(label);
        }
    }
}
