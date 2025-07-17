using RetailCorrector.Blueprint.Abstractions;

namespace RetailCorrector.Blueprint.Operations
{
    public class Plus : BlockBase
    {
        public Plus() : base("Плюс", 110, 3)
        {
            var a = AddInRow(0, "A");
            var b = AddInRow(1, "B");
            AddOutRow(2, "Сумма", () => $"{a.Endpoint?.Value()} + {b.Endpoint?.Value()}");
            Draw();
        }
    }
}
