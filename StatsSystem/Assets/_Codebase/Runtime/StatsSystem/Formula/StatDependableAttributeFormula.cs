using System;
using _Codebase.Runtime.StatsSystem.Core;
using _Codebase.Runtime.StatsSystem.Core.Stats;
using _Codebase.Runtime.StatsSystem.Core.Stats.Core;
using _Codebase.Runtime.StatsSystem.Formula.Core;
using UnityEngine;

namespace _Codebase.Runtime.StatsSystem.Formula
{
    [Serializable]
    public class StatDependableAttributeFormula : StatFormula
    {
        [SerializeField] private float _modifier;
        [SerializeField] private StatType _statType;
        
        public override float Calculate(float value, RuntimeCharacteristics characteristics)
        {
            IRuntimeStat neededStat = null;
            
            foreach (var stat in characteristics.RuntimeStats)
            {
                if (stat.BaseStat.StatType == _statType)
                {
                    neededStat = stat;
                }
            }

            if (neededStat == null)
            {
                Debug.LogError("No stat for attribute was found.");
                return 0;
            }

            var newValue = neededStat.Value * _modifier;
            return newValue;
        }
    }
}
