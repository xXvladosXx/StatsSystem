using System.Collections.Generic;
using _Codebase.Runtime.Stats.StatsSystem.CoreStat;

namespace _Codebase.Runtime.Stats.StatsSystem.CoreAttribute.MainAttributes
{
    public interface IAttribute
    {
        public AttributeType AttributeType { get; }
        public float BaseValue { get; }
        public List<AttributeFormula> Formulas { get; }
    }
}