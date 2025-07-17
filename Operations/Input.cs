using RetailCorrector.Blueprint.Abstractions;
using System.Windows;
using System.Windows.Controls;

namespace RetailCorrector.Blueprint.Operations
{
    public class Input : BlockBase
    {
        protected override string Header { get; } = "Строка";

        internal override BlockRowBase[] Rows { get; }

        public Input(): base(133)
        {
            var _input = new TextBox
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 120
            };
            Grid.SetColumnSpan(_input, 3);

            Rows = [
                Custom(_input),
                Out("Вывод", () => _input.Text)
            ];
            Draw();
        }
    }
}
