using _Codebase.Runtime.Stats.StatsSystem.CoreAttribute.MainAttributes;
using _Codebase.Runtime.Stats.StatsSystem.CoreStat;

namespace _Codebase.Runtime.Stats.StatsSystem.CoreAttribute.RuntimeAttributes
{
    public interface IRuntimeAttribute
    {
        IAttribute BaseAttribute { get; }
        float Value { get; set; }
    }
}