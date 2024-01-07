namespace _Codebase.Runtime.Stats.Core.Stats.Core
{
    public interface IRuntimeStat
    {
        IStat BaseStat { get; }
        float Value { get; set; }
    }
}