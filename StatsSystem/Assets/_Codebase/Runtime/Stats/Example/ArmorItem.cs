using System.Collections.Generic;
using _Codebase.Runtime.Stats.StatsSystem.CoreStat.CoreModifiers;
using UnityEngine;

namespace _Codebase.Runtime.Stats.Example
{
    [CreateAssetMenu(fileName = "ArmorItem", menuName = "Stats/ArmorItem")]
    public class ArmorItem : ScriptableObject
    {
        [field: SerializeField] public List<AttributeModifier> AttributeModifiers { get; private set; }
        [field: SerializeField] public List<StatModifier> StatModifiers { get; private set; }
    }
}