using RetailCorrector.Blueprint.Abstractions;
using RetailCorrector.Blueprint.Operations;
using RetailCorrector.Blueprint.Parts.Rows;
using System.Windows.Media;

namespace RetailCorrector.Blueprint.Statements
{
    public class Select: StatementBlockBase
    {
        protected override Brush BackgroundHeader { get; } = Brushes.Green;
        protected override string Header { get; } = "Выборка";

        internal override BlockRowBase[] Rows { get; }

        public Select() : base(175)
        {
            Rows = [
                new BlockRowIn("Источник", this),
                new BlockRowIn("Фильтрация строк", this),
                new BlockRowIn("Группировка", this),
                new BlockRowIn("Фильтрация групп", this),
                new BlockRowIn("Столбцы", this),
                new BlockRowIn("Сортировка", this),
                new BlockRowIn("Количество строк", this, typeof(Input)),
                new BlockRowOut("Вывод", this),
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
