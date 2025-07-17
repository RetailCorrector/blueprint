using RetailCorrector.Blueprint.Abstractions;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace RetailCorrector.Blueprint.Operations
{
    public class DebugBlock : BlockBase
    {
        protected override string Header { get; } = "DEBUG";

        internal override BlockRowBase[] Rows { get; }

        public DebugBlock(): base(100)
        {
            var @in = In("Ввод");
            var btn = new Button
            {
                Content = "Print",
                Width = 80,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            btn.Click += (_, _) =>
            {
                Debug.WriteLine("");
                Debug.WriteLine(@in.Endpoint?.Value() ?? "ВВОД ПУСТ");
                Debug.WriteLine("");
            };
            Grid.SetColumnSpan(btn, 3);

            Rows = [ @in, Custom(btn) ];
            Draw();
        }
    }
}
