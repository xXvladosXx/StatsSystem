using _Codebase.Runtime.Stats.StatsSystem.CoreAttribute.MainAttributes;

namespace _Codebase.Runtime.Stats.StatsSystem.CoreStat
{
    public abstract class AttributeFormula
    {
        public abstract float Calculate(IAttribute attribute, StatsConfig statsConfig);
    }
}