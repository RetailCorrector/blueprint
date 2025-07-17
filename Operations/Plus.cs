using RetailCorrector.Blueprint.Abstractions;
using RetailCorrector.Blueprint.Parts.Rows;

namespace RetailCorrector.Blueprint.Operations
{
    public class Plus : BlockBase
    {
        protected override string Header { get; } = "Плюс";

        internal override BlockRowBase[] Rows { get; }

        public Plus(): base(110)
        {
            var a = new BlockRowIn("A", this);
            var b = new BlockRowIn("B", this);
            Rows = [a, b,
                new BlockRowOut("Сумма", this, () => $"{a.Endpoint?.Value()} + {b.Endpoint?.Value()}"),
            ];
            Draw();
        }
    }
}
