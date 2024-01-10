using System;
using UnityEngine;

namespace _Codebase.Runtime.StatsSystem.Core.Modifiers.Types
{
    [Serializable]
    public sealed class ConstantType : IModifierType
    {
        [field: SerializeField] public float Value { get; private set; }

        public ConstantType() { }

        public ConstantType(float value)
        {
            Value = value;
        }

        public float FindBonus(float startValue) => Value;
    }
}