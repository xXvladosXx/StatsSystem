namespace _Codebase.Runtime.Stats.StatsSystem.CoreStat.RuntimeStats
{
    public interface IRuntimeStat
    {
        IStat BaseStat { get; }
        float Calculate();
    }
}