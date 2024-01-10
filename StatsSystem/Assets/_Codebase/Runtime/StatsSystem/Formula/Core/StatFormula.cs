using _Codebase.Runtime.StatsSystem.Core;

namespace _Codebase.Runtime.StatsSystem.Formula.Core
{
    public abstract class StatFormula
    {
        public abstract float Calculate(float value, RuntimeCharacteristics characteristics);
    }
}