using RetailCorrector.Blueprint.Abstractions;
using System.Windows;
using System.Windows.Controls;

namespace RetailCorrector.Blueprint.Parts.Rows
{
    internal class BlockRowOut : BlockRowBase
    {
        public string Title { get; }
        public BlockRowIn? Connection { get; } = null;
        public string Value { get; set; } = "";
        private readonly BlockPin pin;

        public BlockRowOut(string title, BlockBase block): base(block)
        {
            Title = title;
            pin =  new(this);
        }

        public override void Draw(Grid parent)
        {
            parent.RowDefinitions.Add(new() { Height = new(25) });
            var index = parent.RowDefinitions.Count - 1;

            Grid.SetRow(pin, index);
            Grid.SetColumn(pin, 2);
            parent.Children.Add(pin);

            var label = GenerateLabel(Title, HorizontalAlignment.Right);
            Grid.SetRow(label, index);
            Grid.SetColumn(label, 1);
            parent.Children.Add(label);
        }
    }
}
