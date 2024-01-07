using System;
using _Codebase.Runtime.Stats.Core.Modifiers.Core;
using _Codebase.Runtime.Stats.Core.Modifiers.Types;
using _Codebase.Runtime.Stats.Core.Stats;
using UnityEngine;

namespace _Codebase.Runtime.Stats.Core.Modifiers
{
    [Serializable]
    public class StatModifier : IStatModifier
    {
        [field: SerializeField] public StatType Type { get; private set; }
        [field: SerializeField] public IModifierType ModifierType { get; private set; }
        
        public StatModifier(StatType type, IModifierType modifierType)
        {
            Type = type;
            ModifierType = modifierType;
        }
    }
}