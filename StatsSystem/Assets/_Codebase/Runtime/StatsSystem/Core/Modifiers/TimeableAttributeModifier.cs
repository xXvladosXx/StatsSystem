using System;
using _Codebase.Runtime.StatsSystem.Core.Attributes;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Types;

namespace _Codebase.Runtime.StatsSystem.Core.Modifiers
{
    [Serializable]
    public class TimeableAttributeModifier : AttributeModifier, ITimeable
    {
        public float Duration { get; private set; }

        public TimeableAttributeModifier(AttributeType attributeType,
            IModifierType modifierType,
            float duration) : base(attributeType, modifierType)
        {
            Duration = duration;
        }

        public void UpdateDuration(float tickSpeed) => Duration -= tickSpeed;
    }
}