using System;
using _Codebase.Runtime.StatsSystem.Core.Attributes.Core;
using _Codebase.Runtime.StatsSystem.Core.Stats.Core;

namespace _Codebase.Runtime.StatsSystem.Core.Attributes
{
    public class RuntimeAttribute : IRuntimeValue<IAttribute>
    {
        public IAttribute BaseAttribute { get; }
        
        private float _value;

        public IAttribute Base { get; }

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
            return $"{BaseAttribute.AttributeType} = {BaseAttribute.ModifierType}";
        }
    }
}