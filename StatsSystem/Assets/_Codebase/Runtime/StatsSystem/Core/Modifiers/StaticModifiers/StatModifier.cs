using System;
using System.Collections.Generic;
using _Codebase.Runtime.StatsSystem.Core.Attributes.Core;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Core;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Core.Operations;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Types;
using _Codebase.Runtime.StatsSystem.Core.Stats;
using _Codebase.Runtime.StatsSystem.Core.Stats.Core;
using UnityEngine;

namespace _Codebase.Runtime.StatsSystem.Core.Modifiers
{
    [Serializable]
    public class StatModifier : IModifier<StatType>
    {
        [field: SerializeField] public StatType Type { get; private set; }
        [field: SerializeField] public IModifierType ModifierType { get; private set; }

        public StatModifier() { }
        
        public StatModifier(StatType type, IModifierType modifierType)
        {
            Type = type;
            ModifierType = modifierType;
        }

        public IOperation<IModifier<StatType>> Operation(List<IModifier<StatType>> modifiers)
        {
            return null;
        }

        public void UpdateDuration(float deltaTime) { }
        public void Operation<T2>(T2 startValue) where T2 : IRuntimeValue<IStat>, IRuntimeValue<IAttribute>
        {
            
        }
    }
}