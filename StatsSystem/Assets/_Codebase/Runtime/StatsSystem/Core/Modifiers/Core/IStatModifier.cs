using _Codebase.Runtime.StatsSystem.Core.Modifiers.Types;
using _Codebase.Runtime.StatsSystem.Core.Stats;

namespace _Codebase.Runtime.StatsSystem.Core.Modifiers.Core
{
    public interface IStatModifier
    {
        StatType Type { get; }
        IModifierType ModifierType { get; }
    }
}