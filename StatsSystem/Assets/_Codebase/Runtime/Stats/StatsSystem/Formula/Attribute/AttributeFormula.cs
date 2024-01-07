using _Codebase.Runtime.Stats.StatsSystem.CoreAttribute.MainAttributes;
using _Codebase.Runtime.Stats.StatsSystem.CoreAttribute.RuntimeAttributes;

namespace _Codebase.Runtime.Stats.StatsSystem.CoreStat
{
    public abstract class AttributeFormula
    {
        public abstract float Calculate(IRuntimeAttribute attribute, RuntimeCharacteristics statsConfig);
    }
}