using System.Collections.Generic;

namespace _Codebase.Runtime.Stats.StatsSystem.CoreStat
{
    public interface IStat
    {
        public float BaseValue { get; }
        List<StatFormula> Formulas { get; }
        StatType StatType { get; }
    }
}