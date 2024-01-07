namespace _Codebase.Runtime.Stats.Core.Modifiers.Types
{
    public interface IModifierType
    {
        public float Value { get;}
        public float FindBonus(float startValue);
    }
}