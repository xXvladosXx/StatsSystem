using System;
using _Codebase.Runtime.Stats.Core.Attributes.Core;

namespace _Codebase.Runtime.Stats.Core.Attributes
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
            return $"{BaseAttribute.AttributeType} = {BaseAttribute.ModifierType}";
        }
    }
}