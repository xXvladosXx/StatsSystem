using System;
using _Codebase.Runtime.Stats.StatsSystem.CoreAttribute.MainAttributes;
using _Codebase.Runtime.Stats.StatsSystem.CoreAttribute.RuntimeAttributes;
using _Codebase.Runtime.Stats.StatsSystem.CoreStat.RuntimeStats;
using UnityEngine;

namespace _Codebase.Runtime.Stats.StatsSystem.CoreStat
{
    [Serializable]
    public class StatDependableAttributeFormula : AttributeFormula
    {
        [SerializeField] public float Modifier;
        public StatType StatType;
        
        public override float Calculate(IRuntimeAttribute attribute, RuntimeCharacteristics statsConfig)
        {
            IRuntimeStat neededStat = null;
            
            foreach (var stat in statsConfig.RuntimeStats)
            {
                if (stat.BaseStat.StatType == StatType)
                {
                    neededStat = stat;
                }
            }

            if (neededStat == null)
            {
                Debug.LogError("No stat for attribute was found.");
                return 0;
            }

            var value = neededStat.Value * Modifier;
            return value;
        }
    }
}
