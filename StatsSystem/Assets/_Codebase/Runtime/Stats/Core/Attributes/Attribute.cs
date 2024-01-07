using System;
using System.Collections.Generic;
using _Codebase.Runtime.Stats.Core.Attributes.Core;
using _Codebase.Runtime.Stats.Core.Modifiers;
using _Codebase.Runtime.Stats.Core.Modifiers.Types;
using _Codebase.Runtime.Stats.Core.Stats;
using _Codebase.Runtime.Stats.Formula.Core;
using UnityEngine;

namespace _Codebase.Runtime.Stats.Core.Attributes
{
    [Serializable]
    public class Attribute : IAttribute
    {
        [field: SerializeField] public AttributeType AttributeType { get; private set; }
        [field: SerializeField] public IModifierType ModifierType { get; private set; } = new ConstantType();
        [field: SerializeField] public List<StatFormula> Formulas { get; private set; } = new List<StatFormula>();
    }
}