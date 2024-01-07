using System;
using System.Collections.Generic;
using _Codebase.Runtime.Stats.StatsSystem.CoreStat;
using UnityEngine;

namespace _Codebase.Runtime.Stats.StatsSystem.CoreAttribute.MainAttributes
{
    [Serializable]
    public class Attribute : IAttribute
    {
        [field: SerializeField] public AttributeType AttributeType { get; private set; }
        [field: SerializeField] public float BaseValue { get; private set; }
        [field: SerializeField] public List<AttributeFormula> Formulas { get; private set; } = new List<AttributeFormula>();
    }
}