using System;

namespace _Codebase.Runtime.StatsSystem.Core.Modifiers.Core.Operations
{
    [Serializable]
    public class AdditiveOperation : IOperation<float>
    {
        public float CalculateModifierValue(float baseValue, float currentValue)
        {
            return baseValue;
        }
    }
}