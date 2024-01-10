namespace _Codebase.Runtime.StatsSystem.Core.Modifiers.Types
{
    public interface IModifierType
    {
        public float Value { get;}
        public float FindBonus(float startValue);
    }
}