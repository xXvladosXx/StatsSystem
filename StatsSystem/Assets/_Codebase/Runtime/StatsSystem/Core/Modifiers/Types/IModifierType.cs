using System.Collections.Generic;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Core;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Core.Operations;

namespace _Codebase.Runtime.StatsSystem.Core.Modifiers.Types
{
    public interface IModifierType
    {
        IOperation<float> Operation { get; }
        float Value { get;}
        float FindBonus(float startValue);
    }
}