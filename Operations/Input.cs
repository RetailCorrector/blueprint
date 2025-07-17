using RetailCorrector.Blueprint.Abstractions;
using RetailCorrector.Blueprint.Pinouts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace RetailCorrector.Blueprint.Operations
{
    public class Input : BlockBase
    {
        protected override string Header { get; } = "Строка";

        public string Value { get; set; } = "";

        protected override BlockPinoutBase[] Pinouts { get; }

        public Input(): base(133)
        {
            var @out = new BlockPinoutOut("Вывод", this);
            var _input = new TextBox
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 120
            };
            _input.SetBinding(TextBlock.TextProperty, new Binding(nameof(@out.Value)) { Source = @out });
            Grid.SetColumnSpan(_input, 3);
            var input = new BlockPinoutCustom(_input, this);

            Pinouts = [input, @out];
            Draw();
        }
    }
}
