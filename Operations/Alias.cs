using RetailCorrector.Blueprint.Abstractions;
using System.Windows;
using System.Windows.Controls;

namespace RetailCorrector.Blueprint.Operations
{
    public class Alias : BlockBase
    {
        protected override string Header { get; } = "Именование";
        internal override BlockRowBase[] Rows { get; }

        public Alias(): base(150)
        {
            var input = new TextBox
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 130
            };
            Grid.SetColumnSpan(input, 3);

            var @in = In("Исходное");

            Rows = [
                @in, Custom(input),
                Out("Регистрация", () => $"({@in.Endpoint!.Value()}) AS {input.Text}"),
                Out("Название", () => input.Text)
            ];
            Draw();
        }
    }
}
