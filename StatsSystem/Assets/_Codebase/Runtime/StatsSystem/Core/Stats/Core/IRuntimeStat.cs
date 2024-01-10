namespace _Codebase.Runtime.StatsSystem.Core.Stats.Core
{
    public interface IRuntimeStat
    {
        IStat BaseStat { get; }
        float Value { get; set; }
    }
}