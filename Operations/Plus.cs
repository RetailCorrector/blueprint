using RetailCorrector.Blueprint.Abstractions;

namespace RetailCorrector.Blueprint.Operations
{
    public class Plus : BlockBase
    {
        protected override string Header { get; } = "Плюс";

        internal override BlockRowBase[] Rows { get; }

        public Plus(): base(110)
        {
            var a = In("A");
            var b = In("B");
            Rows = [a, b,
                Out("Сумма", () => $"{a.Endpoint?.Value()} + {b.Endpoint?.Value()}"),
            ];
            Draw();
        }
    }
}
