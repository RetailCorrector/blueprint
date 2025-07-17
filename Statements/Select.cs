using RetailCorrector.Blueprint.Abstractions;
using RetailCorrector.Blueprint.Operations;
using RetailCorrector.Blueprint.Pinouts;
using System.Windows.Media;

namespace RetailCorrector.Blueprint.Statements
{
    public class Select: StatementBlockBase
    {
        protected override Brush BackgroundHeader { get; } = Brushes.Green;
        protected override string Header { get; } = "Выборка";

        protected override BlockPinoutBase[] Pinouts { get; }

        public Select() : base(175)
        {
            Pinouts = [
                new BlockPinoutIn("Источник", this),
                new BlockPinoutIn("Фильтрация строк", this),
                new BlockPinoutIn("Группировка", this),
                new BlockPinoutIn("Фильтрация групп", this),
                new BlockPinoutIn("Столбцы", this),
                new BlockPinoutIn("Сортировка", this),
                new BlockPinoutIn("Количество строк", this, typeof(Input)),
                new BlockPinoutOut("Вывод", this),
            ];
            Draw();
        }

        /*public override string ToString()
        {
            if (InputChildren[4] is null)
                throw new ArgumentException("Отсутствует информация об столбцах");
            var builder = new StringBuilder();
            builder.Append($"SELECT {InputChildren[4]}");
            if (InputChildren[0] is not null)
            {
                builder.Append($" FROM {InputChildren[0]}");
                if (InputChildren[1] is not null)
                    builder.Append($" WHERE {InputChildren[1]}");
                if (InputChildren[2] is not null)
                {
                    builder.Append($" GROUP BY {InputChildren[2]}");
                    if (InputChildren[3] is not null)
                        builder.Append($" HAVING {InputChildren[3]}");
                }
                if (InputChildren[5] is not null)
                    builder.Append($" ORDER BY {InputChildren[5]}");
                if (InputChildren[6] is not null)
                    builder.Append($" LIMIT {InputChildren[6]}");
            }
            builder.Append(';');
            return builder.ToString();
        }*/
    }
}
