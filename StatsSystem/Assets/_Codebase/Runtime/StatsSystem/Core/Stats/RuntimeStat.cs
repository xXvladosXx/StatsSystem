using System;
using _Codebase.Runtime.StatsSystem.Core.Stats.Core;

namespace _Codebase.Runtime.StatsSystem.Core.Stats
{
    public class RuntimeStat : IRuntimeStat
    {
        public IStat BaseStat { get; }
        
        private float _value;
        
        public float Value
        {
            get => _value;
            set
            {
                if (Math.Abs(_value - value) < float.Epsilon)
                    return;

                _value = value;
            }
        }
        
        public RuntimeStat(IStat baseStat)
        {
            BaseStat = baseStat;
        }
    }
}