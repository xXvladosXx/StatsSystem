using System;
using _Codebase.Runtime.Stats.StatsSystem.CoreAttribute.MainAttributes;
using _Codebase.Runtime.Stats.StatsSystem.CoreStat;

namespace _Codebase.Runtime.Stats.StatsSystem.CoreAttribute.RuntimeAttributes
{
    class RuntimeAttribute : IRuntimeAttribute
    {
        public IAttribute BaseAttribute { get; }
        
        private float _value;
        
        public float Value
        {
            get => _value;
            set
            {
                if (Math.Abs(_value - value) < float.Epsilon)
                    return;

                _value = value;
            }
        }
        
        public RuntimeAttribute(IAttribute baseAttribute)
        {
            BaseAttribute = baseAttribute;
        }

        public override string ToString()
        {
            return $"{BaseAttribute.AttributeType} = {BaseAttribute.BaseValue}";
        }
    }
}