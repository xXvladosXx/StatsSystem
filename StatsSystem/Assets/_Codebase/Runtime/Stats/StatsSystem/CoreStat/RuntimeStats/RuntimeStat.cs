namespace _Codebase.Runtime.Stats.StatsSystem.CoreStat.RuntimeStats
{//105
    public class RuntimeStat : IRuntimeStat
    {
        public IStat BaseStat { get; }
        
        public RuntimeStat(IStat baseStat)
        {
            BaseStat = baseStat;
        }

        public float Calculate()
        {
            float result = 0;
            
            foreach (var statFormula in BaseStat.StatFormulas)
            {
                result += statFormula.Calculate(this, null);
            }

            return result;
        }
    }
}