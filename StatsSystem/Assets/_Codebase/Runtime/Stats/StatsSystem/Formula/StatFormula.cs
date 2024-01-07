using _Codebase.Runtime.Stats.StatsSystem.CoreStat.RuntimeStats;
using UnityEngine;

namespace _Codebase.Runtime.Stats.StatsSystem.CoreStat
{
    public abstract class StatFormula
    {
        public abstract float Calculate(IRuntimeStat stat, StatsConfig traits);
    }
}