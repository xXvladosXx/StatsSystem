using System;
using System.Collections.Generic;
using _Codebase.Runtime.Stats.Core.Modifiers;
using _Codebase.Runtime.Stats.Core.Modifiers.Types;
using _Codebase.Runtime.Stats.Core.Stats.Core;
using _Codebase.Runtime.Stats.Formula.Core;
using UnityEngine;

namespace _Codebase.Runtime.Stats.Core.Stats
{
    [Serializable]
    public class Stat : IStat
    {
        [field: SerializeField] public StatType StatType { get; private set; }
        [field: SerializeField] public IModifierType ModifierType { get; private set; } = new ConstantType();
        [field: SerializeField] public List<StatFormula> Formulas { get; private set; } = new List<StatFormula>();

        public override string ToString()
        {
            return $"{GetType().Name}: Base value: {ModifierType}";
        }
    }
}