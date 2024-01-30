using System;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Core.Operations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Codebase.Runtime.StatsSystem.Core.Modifiers.Types
{
    [Serializable]
    public sealed class PercentType : IModifierType
    {
        public IOperation<float> Operation { get; }

        [field: SerializeField, LabelText("Value (%)")]
        public float Value { get; private set; }

        public PercentType() { }

        public PercentType(float value)
        {
            Value = value;
        }

        public float FindBonus(float startValue) => 
            startValue * (Value / 100f);
    }
}