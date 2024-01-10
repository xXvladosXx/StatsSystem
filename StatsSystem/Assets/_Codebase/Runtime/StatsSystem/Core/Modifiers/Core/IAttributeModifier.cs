using _Codebase.Runtime.StatsSystem.Core.Attributes;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Types;

namespace _Codebase.Runtime.StatsSystem.Core.Modifiers.Core
{
    public interface IAttributeModifier
    {
        AttributeType Type { get; }
        IModifierType ModifierType { get; }
    }
}