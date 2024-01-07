using System;
using _Codebase.Runtime.Stats.Core.Attributes;
using _Codebase.Runtime.Stats.Core.Modifiers.Core;
using _Codebase.Runtime.Stats.Core.Modifiers.Types;
using _Codebase.Runtime.Stats.Core.Stats;
using UnityEngine;

namespace _Codebase.Runtime.Stats.Core.Modifiers
{
    [Serializable]
    public class AttributeModifier : IAttributeModifier
    {
        [field: SerializeField] public AttributeType Type { get; private set; }
        [field: SerializeField] public IModifierType ModifierType { get; private set; }
    }
}