using RetailCorrector.Blueprint.Parts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RetailCorrector.Blueprint.Abstractions
{
    public abstract class BlockBase : UserControl
    {
        public int X { get; set; }
        public int Y { get; set; }

        protected virtual Brush BackgroundHeader { get; } = Brushes.Gray;
        protected abstract string Header { get; }
        protected abstract BlockRowBase[] Pinouts { get; }

        protected Grid Child { get; }

        public BlockBase(double width)
        {
            (Height, Width) = (32, width);
            BorderBrush = Brushes.Black;
            Background = Brushes.White;
            BorderThickness = new(1);
            Content = Child = new();
            Configure(Child.ColumnDefinitions);
        }

        protected void Draw()
        {
            Height += Pinouts.Length * 25;
            AddHeader();
            AddSplitter();
            foreach (var pinout in Pinouts)
                pinout.Draw(Child);
        }

        private static void Configure(ColumnDefinitionCollection coll)
        {
            coll.Add(new() { Width = new(30) });
            coll.Add(new() { Width = new(1, GridUnitType.Star) });
            coll.Add(new() { Width = new(30) });
        }

        private void AddHeader()
        {
            Child.RowDefinitions.Add(new() { Height = new(30) });

            var canvas = new BlockHeader(Header, BackgroundHeader, this);
            Grid.SetColumnSpan(canvas, 3);
            Child.Children.Add(canvas);
        }

        private void AddSplitter()
        {
            Child.RowDefinitions.Add(new() { Height = new(1) });

            Canvas canvas = new() { Background = Brushes.Black };
            Grid.SetRow(canvas, Child.RowDefinitions.Count - 1);
            Grid.SetColumnSpan(canvas, 3);
            Child.Children.Add(canvas);
        }
    }
}
