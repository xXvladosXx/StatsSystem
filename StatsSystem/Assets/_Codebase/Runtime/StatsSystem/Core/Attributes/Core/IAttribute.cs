using System.Collections.Generic;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Types;
using _Codebase.Runtime.StatsSystem.Formula.Core;

namespace _Codebase.Runtime.StatsSystem.Core.Attributes.Core
{
    public interface IAttribute
    {
        public AttributeType AttributeType { get; }
        public IModifierType ModifierType { get; }
        public List<StatFormula> Formulas { get; }
    }
}