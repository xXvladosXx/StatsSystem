namespace _Codebase.Runtime.StatsSystem.Core.Modifiers.Core.Operations
{
    public interface IOperation<out T>
    {
        T CalculateModifierValue(float baseValue, float currentValue);
    }
}