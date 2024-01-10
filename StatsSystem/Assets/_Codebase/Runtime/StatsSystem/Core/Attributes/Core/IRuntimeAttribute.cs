namespace _Codebase.Runtime.StatsSystem.Core.Attributes.Core
{
    public interface IRuntimeAttribute
    {
        IAttribute BaseAttribute { get; }
        float Value { get; set; }
    }
}