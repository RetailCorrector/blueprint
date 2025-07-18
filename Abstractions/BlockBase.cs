﻿using RetailCorrector.Blueprint.Parts;
using RetailCorrector.Blueprint.Parts.Rows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace RetailCorrector.Blueprint.Abstractions
{
    public abstract partial class BlockBase : UserControl
    {
        public int X { get; set; }
        public int Y { get; set; }

        internal BlockRowBase[] Rows { get; private set; }

        protected Grid Child { get; }

        public BlockBase(string header, double width, int countRows, Brush? bg = null)
        {
            (Height, Width) = (32 + countRows * 25, width);
            BorderBrush = Brushes.Black;
            Background = Brushes.White;
            BorderThickness = new(1);
            Content = Child = new();
            Configure(Child.ColumnDefinitions);
            AddHeader(header, bg ?? Brushes.Gray);
            AddSplitter();
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

        private void AddHeader(string header, Brush bg)
        {
            Child.RowDefinitions.Add(new() { Height = new(30) });

            var canvas = new BlockHeader(header, bg, this);
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

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            foreach(UIElement el in ((Panel)Parent).Children)
                if(el is BlockBase) Panel.SetZIndex(el, 0);
            Panel.SetZIndex(this, 1);
            base.OnMouseDown(e);
        }
    }
}
