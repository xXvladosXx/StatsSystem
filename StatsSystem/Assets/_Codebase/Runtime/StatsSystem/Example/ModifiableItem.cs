using System.Collections.Generic;
using _Codebase.Runtime.StatsSystem.Core.Attributes;
using _Codebase.Runtime.StatsSystem.Core.Attributes.Core;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Core;
using _Codebase.Runtime.StatsSystem.Core.Stats;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Codebase.Runtime.StatsSystem.Example
{
    [CreateAssetMenu(fileName = "Modifiable Item", menuName = "Stats/Modifiable Item")]
    public class ModifiableItem : SerializedScriptableObject
    {
        [field: SerializeField] public List<IModifier<AttributeType>> AttributeModifiers { get; private set; } = new List<IModifier<AttributeType>>();
        [field: SerializeField] public List<IModifier<StatType>> StatModifiers { get; private set; } = new List<IModifier<StatType>>();
    }
}