using RetailCorrector.Blueprint.Abstractions;
using RetailCorrector.Blueprint.Parts.Rows;

namespace RetailCorrector.Blueprint.Operations
{
    public class Plus : BlockBase
    {
        protected override string Header { get; } = "Плюс";

        protected override BlockRowBase[] Pinouts { get; }

        public Plus(): base(110)
        {
            Pinouts = [
                new BlockRowIn("A", this),
                new BlockRowIn("B", this),
                new BlockRowOut("Сумма", this),
            ];
            Draw();
        }
    }
}
