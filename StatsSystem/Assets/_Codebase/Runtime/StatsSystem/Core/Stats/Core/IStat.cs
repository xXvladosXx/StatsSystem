using System.Collections.Generic;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Types;
using _Codebase.Runtime.StatsSystem.Formula.Core;

namespace _Codebase.Runtime.StatsSystem.Core.Stats.Core
{
    public interface IStat
    {
        public IModifierType ModifierType { get; }
        List<StatFormula> Formulas { get; }
        StatType StatType { get; }
    }
}