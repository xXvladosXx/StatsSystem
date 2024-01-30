using System;
using System.Collections.Generic;
using _Codebase.Runtime.StatsSystem.Core.Attributes;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Core;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Core.Operations;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Types;
using UnityEngine;

namespace _Codebase.Runtime.StatsSystem.Core.Modifiers
{
    [Serializable]
    public class TimeableModifier<T> : IModifier<T>
    {
        [field: SerializeField] public T Type { get; private set; }
        [field: SerializeField] public IModifierType ModifierType { get; private set; }
        [field: SerializeField] public float Duration { get; private set; }

        public TimeableModifier() { }
        
        public TimeableModifier(T type, 
            IModifierType modifierType,
            float duration)
        {
            Type = type;
            ModifierType = modifierType;
            Duration = duration;
        }

        public IOperation<IModifier<T>> Operation(List<IModifier<T>> modifiers)
        {
            return null;
        }

        public void UpdateDuration(float tickSpeed) => Duration -= tickSpeed;
    }
}