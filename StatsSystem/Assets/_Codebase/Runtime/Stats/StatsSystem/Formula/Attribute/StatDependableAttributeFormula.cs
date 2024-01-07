using System;
using _Codebase.Runtime.Stats.StatsSystem.CoreAttribute.MainAttributes;
using UnityEngine;

namespace _Codebase.Runtime.Stats.StatsSystem.CoreStat
{
    [Serializable]
    public class StatDependableAttributeFormula : AttributeFormula
    {
        public float Modifier;
        public StatType StatType;
        
        public override float Calculate(IAttribute attribute, StatsConfig statsConfig)
        {
            IStat neededStat = null;
            
            foreach (var stat in statsConfig.Stats)
            {
                if (stat.StatType == StatType)
                {
                    neededStat = stat;
                }
            }

            if (neededStat == null)
            {
                Debug.LogError("No stat for attribute was found.");
                return 0;
            }

            var value = neededStat.BaseValue * Modifier;
            return value;
        }
    }
}
