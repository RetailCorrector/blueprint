using RetailCorrector.Blueprint.Abstractions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RetailCorrector.Blueprint.Parts.Rows
{
    internal class BlockRowIn : BlockRowBase
    {
        public string Title { get; }
        private Type[] AllowedBlockTypes { get; }
        public BlockRowOut? Endpoint { get; private set; } = null;
        public readonly BlockPin Pin;
        private Line _connection = new() { Stroke = Brushes.Black };

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

        public void UpdateConnectionLine()
        {
            if (Endpoint is null) return;
            _connection.X1 = Pin.X;
            _connection.Y1 = Pin.Y;
            _connection.X2 = Endpoint.Pin.X;
            _connection.Y2 = Endpoint.Pin.Y;
        }
    }
}
