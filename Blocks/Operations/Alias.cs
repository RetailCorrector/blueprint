﻿using RetailCorrector.Blueprint.Abstractions;
using System.Windows;
using System.Windows.Controls;

namespace RetailCorrector.Blueprint.Blocks
{
    public class Alias : BlockBase
    {
        public Alias(): base("Сокращение", 150, 4)
        {
            var input = new TextBox
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 130
            };
            Grid.SetColumnSpan(input, 3);

            var @in = AddInRow(0,"Исходное");
            AddCustomRow(1, input);
            AddOutRow(2, "Регистрация", () => $"{@in.Endpoint!.Value()} AS \"{input.Text}\"");
            AddOutRow(3, "Название", () => input.Text);

            Draw();
        }
    }
}
