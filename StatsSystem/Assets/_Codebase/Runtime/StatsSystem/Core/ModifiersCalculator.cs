using System;
using System.Collections.Generic;
using _Codebase.Runtime.StatsSystem.Core.Attributes;
using _Codebase.Runtime.StatsSystem.Core.Attributes.Core;
using _Codebase.Runtime.StatsSystem.Core.Modifiers;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Core;
using _Codebase.Runtime.StatsSystem.Core.Stats.Core;
using UnityEngine;

namespace _Codebase.Runtime.StatsSystem.Core
{
    public class ModifiersCalculator<T1> 
        where T1 : Enum
    {
        private readonly List<IModifier<T1>> _modifiers = new List<IModifier<T1>>();
        public IReadOnlyCollection<IModifier<T1>> Modifiers => _modifiers;
        
        public void AddModifier(IModifier<T1> modifier) => 
            _modifiers.Add(modifier);

        public void RemoveModifier(IModifier<T1> attributeModifier) => 
            _modifiers.Remove(attributeModifier);


        public float MakeOperations(T1 key, float startValue) 
        {
            float bonus = 0;

            foreach (var modifier in _modifiers)
            {
                if(modifier.Type.Equals(key))
                    modifier.Operation(startValue);
            }

            return bonus;
        }
    }
}