﻿using RetailCorrector.Blueprint.Blocks;

namespace RetailCorrector.Blueprint.Abstractions
{
    public partial class BlockBase
    {
        public readonly static Type[] Statements = [typeof(Select)];
    }
}
