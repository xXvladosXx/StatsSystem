using System;
using UnityEngine;

namespace _Codebase.Runtime.Stats.StatsSystem.CoreStat.CoreModifiers
{
    [Serializable]
    public struct StatModifier
    {
        [field: SerializeField] public StatType Type { get; private set; }
        [field: SerializeField] public float Value { get; private set; }
        
        public StatModifier(StatType type, float value)
        {
            Type = type;
            Value = value;
        }
    }
}