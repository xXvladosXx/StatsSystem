using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Codebase.Runtime.Stats.StatsSystem.CoreStat
{
    [Serializable]
    public class Stat : IStat
    {
        [field: SerializeField] public StatType StatType { get; private set; }
        [field: SerializeField] public float BaseValue { get; private set; }
        [field: SerializeField] public List<StatFormula> StatFormulas { get; private set; } = new List<StatFormula>();

        public override string ToString()
        {
            return $"{GetType().Name}: Base value: {BaseValue}";
        }
    }
}