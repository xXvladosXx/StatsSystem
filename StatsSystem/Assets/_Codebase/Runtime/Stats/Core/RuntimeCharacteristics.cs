using System.Collections.Generic;
using _Codebase.Runtime.Stats.Core.Attributes;
using _Codebase.Runtime.Stats.Core.Attributes.Core;
using _Codebase.Runtime.Stats.Core.Stats;
using _Codebase.Runtime.Stats.Core.Stats.Core;

namespace _Codebase.Runtime.Stats.Core
{
    public class RuntimeCharacteristics
    {
        public readonly List<IRuntimeStat> RuntimeStats;
        public readonly List<IRuntimeAttribute> RuntimeAttributes;

        public RuntimeCharacteristics(List<IRuntimeStat> runtimeStats,
            List<IRuntimeAttribute> runtimeAttributes)
        {
            RuntimeStats = runtimeStats;
            RuntimeAttributes = runtimeAttributes;
        }
    }
}