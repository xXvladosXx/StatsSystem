namespace _Codebase.Runtime.Stats.Core.Attributes.Core
{
    public interface IRuntimeAttribute
    {
        IAttribute BaseAttribute { get; }
        float Value { get; set; }
    }
}