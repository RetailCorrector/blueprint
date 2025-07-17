using RetailCorrector.Blueprint.Abstractions;
using System.Windows;
using System.Windows.Controls;

namespace RetailCorrector.Blueprint.Blocks
{
    public class DebugBlock : BlockBase
    {
        public DebugBlock(): base("Отладка", 100, 2)
        {
            var @in = AddInRow(0, "Ввод");
            var btn = new Button
            {
                Content = "Отобразить",
                Width = 80,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            btn.Click += (_, _) => MessageBox.Show(@in.Endpoint?.Value() ?? "ВВОД ПУСТ");
            Grid.SetColumnSpan(btn, 3);
            AddCustomRow(1, btn);
            Draw();
        }
    }
}
