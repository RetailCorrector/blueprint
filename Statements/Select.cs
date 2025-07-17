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

        internal override BlockRowBase[] Rows { get; }

        public Select() : base(175)
        {
            Source = new BlockRowIn("Источник", this);
            Where = new BlockRowIn("Фильтрация строк", this);
            Group = new BlockRowIn("Группировка", this);
            Having = new BlockRowIn("Фильтрация групп", this);
            Columns = new BlockRowIn("Столбцы", this);
            Order = new BlockRowIn("Сортировка", this);
            Limit = new BlockRowIn("Количество строк", this, typeof(Input));

            Rows = [
                Source, Where, Group, Having, Columns, Order, Limit,
                new BlockRowOut("Вывод", this, ToString),
            ];
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
            builder.Append(';');
            return builder.ToString();
        }
    }
}
