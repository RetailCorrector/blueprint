using RetailCorrector.Blueprint.Abstractions;
using System.Windows;
using System.Windows.Controls;

namespace RetailCorrector.Blueprint.Blocks
{
    internal class Table : BlockBase
    {
        public Table(): base("Таблица", 125, 2)
        {
            var cb = new ComboBox
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 115,
                DisplayMemberPath = "Value",
                SelectedValuePath = "Key",
                SelectedIndex = 0
            };
            cb.Items.Add(new KeyValuePair<string, string>("receipt", "Чеки"));
            cb.Items.Add(new KeyValuePair<string, string>("position", "Позиции"));
            cb.Items.Add(new KeyValuePair<string, string>("code", "Коды позиций"));
            cb.Items.Add(new KeyValuePair<string, string>("industry", "Отрасль"));
            Grid.SetColumnSpan(cb, 3);
            AddCustomRow(0, cb);
            AddOutRow(1, "Id", () => $"\"{(string)cb.SelectedValue}\"");
            Draw();
        }
    }
}
