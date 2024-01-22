namespace _Codebase.Runtime.StatsSystem.Core.Modifiers
{
    public interface ITimeable
    {
        float Duration { get; }
        void UpdateDuration(float tickSpeed);
    }
}