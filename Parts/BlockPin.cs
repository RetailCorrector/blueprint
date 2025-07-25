﻿using RetailCorrector.Blueprint.Abstractions;
using RetailCorrector.Blueprint.Parts.Rows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RetailCorrector.Blueprint.Parts
{
    internal class BlockPin : Canvas
    {
        private static BlockPin? Selected { get; set; } = null;
        private bool IsInput => _parent is BlockRowIn;

        private readonly BlockRowBase _parent;
        private readonly Ellipse _child = new() { Stroke = Brushes.Gray, Fill = Brushes.White };

        public double X
        {
            get
            {
                var xBlock = _parent.Block.RenderTransform.Value.OffsetX;
                return xBlock + (IsInput ? 15 : _parent.Block.Width - 15);
            }
        }
        public double Y
        {
            get
            {
                var y = 45 + _parent.Block.RenderTransform.Value.OffsetY;
                int index = 0;
                var arr = _parent.Block.Rows;
                for (; index < arr.Length; index++)
                    if (arr[index] == _parent)
                        break;
                return y + index * 25;
            }
        }

        public BlockPin(BlockRowBase parent)
        {
            VerticalAlignment = VerticalAlignment.Center;
            HorizontalAlignment = HorizontalAlignment.Center;
            _child.Height = _child.Width = Height = Width = 10;
            _parent = parent;
            Children.Add(_child);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            _child.Stroke = Brushes.Black;
            Selected = this;
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            if (Selected is null) return;
            Selected._child.Stroke = Brushes.Gray;
            if (Selected == this || Selected._parent.GetType() == _parent.GetType() || 
                Selected._parent.Block == _parent.Block)
            {
                Selected = null;
                return;
            }
            var @in = (BlockRowIn)(IsInput ? _parent : Selected._parent);
            var @out = (BlockRowOut)(IsInput ? Selected._parent : _parent);
            @in.TryConnect(@out);
            Selected = null;
        }

        protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
        {
            if (IsInput) ((BlockRowIn)_parent).Disconnect();
            else ((BlockRowOut)_parent).DisconnectAll();
            base.OnMouseRightButtonDown(e);
        }
    }
}
