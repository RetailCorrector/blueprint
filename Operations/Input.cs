using RetailCorrector.Blueprint.Abstractions;
using System.Windows;
using System.Windows.Controls;

namespace RetailCorrector.Blueprint.Operations
{
    public class Input : BlockBase
    {
        public Input(): base("Ввод", 133, 2)
        {
            var _input = new TextBox
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 120
            };
            Grid.SetColumnSpan(_input, 3);

            AddCustomRow(0,_input);
            AddOutRow(1,"Вывод", () => _input.Text);
            Draw();
        }
    }
}
