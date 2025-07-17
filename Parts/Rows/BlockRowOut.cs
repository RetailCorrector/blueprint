using RetailCorrector.Blueprint.Abstractions;
using System.Windows;
using System.Windows.Controls;

namespace RetailCorrector.Blueprint.Parts.Rows
{
    internal class BlockRowOut(string title, BlockBase block) : BlockRowBase(block)
    {
        public string Title { get; } = title;
        public BlockRowIn? Connection { get; } = null;
        public string Value { get; set; } = "";

        public override void Draw(Grid parent)
        {
            parent.RowDefinitions.Add(new() { Height = new(25) });
            var index = parent.RowDefinitions.Count - 1;

            var e = GenerateEllipse();
            Grid.SetRow(e, index);
            Grid.SetColumn(e, 2);
            parent.Children.Add(e);

            var label = GenerateLabel(Title, HorizontalAlignment.Right);
            Grid.SetRow(label, index);
            Grid.SetColumn(label, 1);
            parent.Children.Add(label);
        }
    }
}
