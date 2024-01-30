using System.Collections.Generic;
using _Codebase.Runtime.StatsSystem.Core.Attributes;
using _Codebase.Runtime.StatsSystem.Core.Attributes.Core;
using _Codebase.Runtime.StatsSystem.Core.Stats;
using _Codebase.Runtime.StatsSystem.Core.Stats.Core;

namespace _Codebase.Runtime.StatsSystem.Core
{
    public class RuntimeCharacteristics
    {
        public readonly List<RuntimeStat> RuntimeStats;
        public readonly List<IRuntimeAttribute> RuntimeAttributes;

        public RuntimeCharacteristics(List<RuntimeStat> runtimeStats,
            List<IRuntimeAttribute> runtimeAttributes)
        {
            RuntimeStats = runtimeStats;
            RuntimeAttributes = runtimeAttributes;
        }
    }
}