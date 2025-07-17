using RetailCorrector.Blueprint.Parts;
using RetailCorrector.Blueprint.Parts.Rows;
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
        internal BlockRowBase[] Rows { get; private set; }

        protected Grid Child { get; }

        public BlockBase(double width, int countRows)
        {
            (Height, Width) = (32 + countRows * 25, width);
            BorderBrush = Brushes.Black;
            Background = Brushes.White;
            AddHeader();
            AddSplitter();
            BorderThickness = new(1);
            Content = Child = new();
            Configure(Child.ColumnDefinitions);
            Rows = new BlockRowBase[countRows];
        }

        protected void Draw()
        {
            foreach (var pinout in Rows)
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

        internal BlockRowIn AddInRow(int index, string text, params Type[] allowed)
        {
            var row = new BlockRowIn(text, this, allowed);
            Rows[index] = row;
            return row;
        }

        internal BlockRowOut AddOutRow(int index, string text, Func<string> valueGenerator)
        {
            var row = new BlockRowOut(text, this, valueGenerator);
            Rows[index] = row;
            return row;
        }

        internal BlockRowCustom AddCustomRow(int index, FrameworkElement element)
        {
            var row = new BlockRowCustom(element, this);
            Rows[index] = row;
            return row;
        }
    }
}
