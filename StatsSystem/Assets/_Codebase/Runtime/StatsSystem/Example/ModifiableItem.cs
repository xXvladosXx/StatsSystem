using System.Collections.Generic;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Codebase.Runtime.StatsSystem.Example
{
    [CreateAssetMenu(fileName = "Modifiable Item", menuName = "Stats/Modifiable Item")]
    public class ModifiableItem : SerializedScriptableObject
    {
        [field: SerializeField] public List<IAttributeModifier> AttributeModifiers { get; private set; } = new List<IAttributeModifier>();
        [field: SerializeField] public List<IStatModifier> StatModifiers { get; private set; } = new List<IStatModifier>();
    }
}