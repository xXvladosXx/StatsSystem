using System;
using _Codebase.Runtime.Stats.StatsSystem.CoreAttribute.MainAttributes;
using UnityEngine;

namespace _Codebase.Runtime.Stats.StatsSystem.CoreStat.CoreModifiers
{
    [Serializable]
    public struct AttributeModifier
    {
        [field: SerializeField] public AttributeType Type { get; private set; }
        [field: SerializeField] public float Value { get; private set; }
        
        public AttributeModifier(AttributeType type, float value)
        {
            Type = type;
            Value = value;
        }
    }
}