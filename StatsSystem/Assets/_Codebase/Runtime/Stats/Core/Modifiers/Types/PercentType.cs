using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Codebase.Runtime.Stats.Core.Modifiers.Types
{
    [Serializable]
    public sealed class PercentType : IModifierType
    {
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