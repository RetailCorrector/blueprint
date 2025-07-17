using RetailCorrector.Blueprint.Abstractions;

namespace RetailCorrector.Blueprint.Blocks
{
    public class Subquery : BlockBase
    {
        public Subquery(): base("Подзапрос", 120, 2)
        {
            var @in = AddInRow(0, "Запрос", Statements);
            AddOutRow(1, "Результат", () => $"({@in.Endpoint!.Value()})");
            Draw();
        }
    }
}
