using System.Collections.Generic;
using _Codebase.Runtime.StatsSystem.Core.Attributes.Core;
using _Codebase.Runtime.StatsSystem.Core.Stats.Core;

namespace _Codebase.Runtime.StatsSystem.Core
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