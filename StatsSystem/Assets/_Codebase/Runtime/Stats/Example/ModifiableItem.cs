using System.Collections.Generic;
using _Codebase.Runtime.Stats.Core.Attributes;
using _Codebase.Runtime.Stats.Core.Modifiers;
using _Codebase.Runtime.Stats.Core.Modifiers.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Codebase.Runtime.Stats.Example
{
    [CreateAssetMenu(fileName = "Modifiable Item", menuName = "Stats/Modifiable Item")]
    public class ModifiableItem : SerializedScriptableObject
    {
        [field: SerializeField] public List<IAttributeModifier> AttributeModifiers { get; private set; } = new List<IAttributeModifier>();
        [field: SerializeField] public List<IStatModifier> StatModifiers { get; private set; } = new List<IStatModifier>();
    }
}