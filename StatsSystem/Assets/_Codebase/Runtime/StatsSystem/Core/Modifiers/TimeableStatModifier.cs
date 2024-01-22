using System;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Types;
using _Codebase.Runtime.StatsSystem.Core.Stats;

namespace _Codebase.Runtime.StatsSystem.Core.Modifiers
{
    [Serializable]
    public class TimeableStatModifier : StatModifier, ITimeable
    {
        public float Duration { get; private set; }

        public TimeableStatModifier(StatType type,
            IModifierType modifierType,
            float duration) : base(type, modifierType)
        {
            Duration = duration;
        }

        public void UpdateDuration(float tickSpeed) => Duration -= tickSpeed;
    }
}