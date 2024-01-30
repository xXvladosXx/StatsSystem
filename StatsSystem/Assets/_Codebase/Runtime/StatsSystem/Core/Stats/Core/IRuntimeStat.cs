namespace _Codebase.Runtime.StatsSystem.Core.Stats.Core
{
    public interface IRuntimeValue<T>
    {
        T Base { get; }
        float Value { get; set; }
    }
}