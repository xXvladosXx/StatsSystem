using System;
using _Codebase.Runtime.Stats.StatsSystem.CoreStat.RuntimeStats;
using UnityEngine;

namespace _Codebase.Runtime.Stats.StatsSystem.CoreStat
{
    [Serializable]
    public class LevelFormula : StatFormula
    {
        public int Level;
        public float Multiplier;
        
        public override float Calculate(IRuntimeStat stat, StatsConfig traits)
        {
            return (Level * Multiplier) + stat.BaseStat.BaseValue;
        }
    }
}