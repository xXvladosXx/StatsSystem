using System.Collections.Generic;
using _Codebase.Runtime.StatsSystem.Core.Attributes.Core;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Core.Operations;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Types;
using _Codebase.Runtime.StatsSystem.Core.Stats.Core;

namespace _Codebase.Runtime.StatsSystem.Core.Modifiers.Core
{
    public interface IModifier<T>
    {
        T Type { get; }
        IModifierType ModifierType { get; }
        void UpdateDuration(float deltaTime);
    }
}