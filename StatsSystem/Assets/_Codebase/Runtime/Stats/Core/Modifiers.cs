using UnityEngine;

namespace _Codebase.Runtime.Stats.Core
{
    public class Modifiers
    {
        public readonly ModifierList Values = new();
        public readonly ModifierList Percentages = new();
        
        public float Calculate(float value)
        {
            value *= 1f + Percentages.Value;
            value += Values.Value;

            return value;
        }
        
        public void Add(ModifierType type, float value)
        {
            switch (type)
            {
                case ModifierType.Value:
                    Values.Add(new Modifier(type, value));
                    break;
                case ModifierType.Percent:
                    Percentages.Add(new Modifier(type, value));
                    break;
                default:
                    Debug.LogError($"Unknown modifier type: {type}");
                    break;
            }
        }
        
        public bool Remove(ModifierType type, float value)
        {
            switch (type)
            {
                case ModifierType.Value:
                    return Values.Remove(value);
                case ModifierType.Percent:
                    return Percentages.Remove(value);
                default:
                    Debug.LogError("Unknown modifier type: " + type);
                    return false;
            }
        }
    }
}