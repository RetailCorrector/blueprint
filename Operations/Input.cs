using RetailCorrector.Blueprint.Abstractions;
using RetailCorrector.Blueprint.Parts.Rows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace RetailCorrector.Blueprint.Operations
{
    public class Input : BlockBase
    {
        protected override string Header { get; } = "Строка";

        public string Value { get; set; } = "";

        protected override BlockRowBase[] Pinouts { get; }

        public Input(): base(133)
        {
            var @out = new BlockRowOut("Вывод", this);
            var _input = new TextBox
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 120
            };
            _input.SetBinding(TextBlock.TextProperty, new Binding(nameof(@out.Value)) { Source = @out });
            Grid.SetColumnSpan(_input, 3);
            var input = new BlockRowCustom(_input, this);

            Pinouts = [input, @out];
            Draw();
        }
    }
}
