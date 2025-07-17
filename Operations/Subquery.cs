using RetailCorrector.Blueprint.Abstractions;

namespace RetailCorrector.Blueprint.Operations
{
    public class Subquery : BlockBase
    {
        protected override string Header { get; } = "Подзапрос";

        public Subquery(): base(100, 2)
        {
            var @in = AddInRow(0, "Запрос", Statements);
            AddOutRow(1, "Результат", () => $"({@in.Endpoint!.Value()})");
            Draw();
        }
    }
}
