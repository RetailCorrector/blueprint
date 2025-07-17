using RetailCorrector.Blueprint.Abstractions;
using RetailCorrector.Blueprint.Pinouts;

namespace RetailCorrector.Blueprint.Operations
{
    public class Plus : BlockBase
    {
        protected override string Header { get; } = "Плюс";

        protected override BlockPinoutBase[] Pinouts { get; }

        public Plus(): base(110)
        {
            Pinouts = [
                new BlockPinoutIn("A", this),
                new BlockPinoutIn("B", this),
                new BlockPinoutOut("Сумма", this),
            ];
            Draw();
        }
    }
}
