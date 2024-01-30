using System;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Core.Operations;
using UnityEngine;

namespace _Codebase.Runtime.StatsSystem.Core.Modifiers.Types
{
    [Serializable]
    public sealed class ConstantType : IModifierType
    {
        public IOperation<float> Operation { get; }
        [field: SerializeField] public float Value { get; private set; }

        public ConstantType() { }

        public ConstantType(float value)
        {
            Value = value;
        }

        public float FindBonus(float startValue) => 
            Operation.CalculateModifierValue(Value, startValue);
    }
}