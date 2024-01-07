using System.Collections.Generic;
using _Codebase.Runtime.Stats.Core.Modifiers.Types;
using _Codebase.Runtime.Stats.Formula.Core;

namespace _Codebase.Runtime.Stats.Core.Stats.Core
{
    public interface IStat
    {
        public IModifierType ModifierType { get; }
        List<StatFormula> Formulas { get; }
        StatType StatType { get; }
    }
}