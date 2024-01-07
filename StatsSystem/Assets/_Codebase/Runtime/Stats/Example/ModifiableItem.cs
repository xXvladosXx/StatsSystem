using System.Collections.Generic;
using _Codebase.Runtime.Stats.StatsSystem.CoreStat.CoreModifiers;
using UnityEngine;

namespace _Codebase.Runtime.Stats.Example
{
    [CreateAssetMenu(fileName = "Modifiable Item", menuName = "Stats/Modifiable Item")]
    public class ModifiableItem : ScriptableObject
    {
        [field: SerializeField] public List<AttributeModifier> AttributeModifiers { get; private set; }
        [field: SerializeField] public List<StatModifier> StatModifiers { get; private set; }
    }
}