using _Codebase.Runtime.Stats.Core.Attributes;
using _Codebase.Runtime.Stats.Core.Modifiers.Types;

namespace _Codebase.Runtime.Stats.Core.Modifiers.Core
{
    public interface IAttributeModifier
    {
        AttributeType Type { get; }
        IModifierType ModifierType { get; }
    }
}