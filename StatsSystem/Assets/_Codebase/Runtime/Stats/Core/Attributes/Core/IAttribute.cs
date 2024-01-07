using System.Collections.Generic;
using _Codebase.Runtime.Stats.Core.Modifiers.Types;
using _Codebase.Runtime.Stats.Formula.Core;

namespace _Codebase.Runtime.Stats.Core.Attributes.Core
{
    public interface IAttribute
    {
        public AttributeType AttributeType { get; }
        public IModifierType ModifierType { get; }
        public List<StatFormula> Formulas { get; }
    }
}