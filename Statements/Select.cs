using RetailCorrector.Blueprint.Abstractions;
using RetailCorrector.Blueprint.Operations;
using RetailCorrector.Blueprint.Parts.Rows;
using System.Text;
using System.Windows.Media;

namespace RetailCorrector.Blueprint.Statements
{
    public class Select: StatementBlockBase
    {
        protected override Brush BackgroundHeader { get; } = Brushes.Green;
        protected override string Header { get; } = "Выборка";

        private readonly BlockRowIn Source;
        private readonly BlockRowIn Where;
        private readonly BlockRowIn Group;
        private readonly BlockRowIn Having;
        private readonly BlockRowIn Columns;
        private readonly BlockRowIn Order;
        private readonly BlockRowIn Limit;

        public Select() : base(175, 8)
        {
            Columns = AddInRow(0, "Столбцы");
            Source = AddInRow(1, "Источник");
            Where = AddInRow(2, "Фильтрация строк");
            Group = AddInRow(3, "Группировка");
            Having = AddInRow(4, "Фильтрация групп");
            Order = AddInRow(5, "Сортировка");
            Limit = AddInRow(6, "Количество строк", typeof(Input));
            AddOutRow(7, "Вывод", ToString);
            Draw();
        }

        public override string ToString()
        {
            if (Columns.Endpoint is null)
                throw new ArgumentException("Отсутствует информация об столбцах");
            var builder = new StringBuilder();
            builder.Append($"SELECT {Columns.Endpoint.Value()}");
            if (Source.Endpoint is not null)
            {
                builder.Append($" FROM {Source.Endpoint.Value()}");
                if (Where.Endpoint is not null)
                    builder.Append($" WHERE {Where.Endpoint.Value()}");
                if (Group.Endpoint is not null)
                {
                    builder.Append($" GROUP BY {Group.Endpoint.Value()}");
                    if (Having.Endpoint is not null)
                        builder.Append($" HAVING {Having.Endpoint.Value()}");
                }
                if (Order.Endpoint is not null)
                    builder.Append($" ORDER BY {Order.Endpoint.Value()}");
                if (Limit.Endpoint is not null)
                    builder.Append($" LIMIT {Limit.Endpoint.Value()}");
            }
            return builder.ToString();
        }
    }
}
