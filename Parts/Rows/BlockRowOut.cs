using RetailCorrector.Blueprint.Abstractions;
using System.Windows;
using System.Windows.Controls;

namespace RetailCorrector.Blueprint.Parts.Rows
{
    internal class BlockRowOut : BlockRowBase
    {
        public string Title { get; }
        public List<BlockRowIn> Endpoints { get; set; } = [];
        public Func<string> Value { get; }
        public readonly BlockPin Pin;

        public BlockRowOut(string title, BlockBase block, Func<string> value): base(block)
        {
            Title = title;
            Pin =  new(this);
            Value = value;
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

        public void DisconnectAll()
        {
            while(Endpoints.Count > 0) 
                Endpoints[0].Disconnect();
        }
    }
}
