using _Codebase.Runtime.Stats.Core.Modifiers.Types;
using _Codebase.Runtime.Stats.Core.Stats;

namespace _Codebase.Runtime.Stats.Core.Modifiers.Core
{
    public interface IStatModifier
    {
        StatType Type { get; }
        IModifierType ModifierType { get; }
    }
}