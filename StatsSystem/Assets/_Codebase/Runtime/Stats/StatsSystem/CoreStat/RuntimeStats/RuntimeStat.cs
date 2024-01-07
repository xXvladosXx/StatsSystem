using System;

namespace _Codebase.Runtime.Stats.StatsSystem.CoreStat.RuntimeStats
{//105
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