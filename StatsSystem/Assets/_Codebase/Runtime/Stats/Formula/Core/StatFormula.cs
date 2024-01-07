using _Codebase.Runtime.Stats.Core;

namespace _Codebase.Runtime.Stats.Formula.Core
{
    public abstract class StatFormula
    {
        public abstract float Calculate(float value, RuntimeCharacteristics characteristics);
    }
}