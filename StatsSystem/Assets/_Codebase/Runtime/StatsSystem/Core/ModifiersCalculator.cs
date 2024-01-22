using System.Collections.Generic;
using _Codebase.Runtime.StatsSystem.Core.Modifiers;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Core;
using UnityEngine;

namespace _Codebase.Runtime.StatsSystem.Core
{
    public class ModifiersCalculator
    {
        private readonly List<TimeableAttributeModifier> _timeableAttributeModifiers = new List<TimeableAttributeModifier>();
        private readonly List<TimeableStatModifier> _timeableStatModifiers = new List<TimeableStatModifier>();
        
        private readonly List<IAttributeModifier> _attributeModifiers = new List<IAttributeModifier>();
        private readonly List<IStatModifier> _statModifiers = new List<IStatModifier>();

        public IReadOnlyCollection<IAttributeModifier> AttributeModifiers => _attributeModifiers;
        public IReadOnlyCollection<IStatModifier> StatModifiers => _statModifiers;
        
        public void AddAttributeModifier(IAttributeModifier attributeModifier)
        {
            _attributeModifiers.Add(attributeModifier);
            
            if (attributeModifier is TimeableAttributeModifier timeable)
                _timeableAttributeModifiers.Add(timeable);
        }

        public void RemoveAttributeModifier(IAttributeModifier attributeModifier) => 
            _attributeModifiers.Remove(attributeModifier);

        public void AddStatModifier(IStatModifier timeableStatModifier)
        {
            _statModifiers.Add(timeableStatModifier);
            
            if (timeableStatModifier is TimeableStatModifier timeable)
                _timeableStatModifiers.Add(timeable);
        }

        public void RemoveStatModifier(IStatModifier statModifier) => 
            _statModifiers.Remove(statModifier);

        public void Update()
        {
            for (int i = 0; i < _timeableAttributeModifiers.Count; i++)
            {
                _timeableAttributeModifiers[i].UpdateDuration(Time.deltaTime);
                if (_timeableAttributeModifiers[i].Duration <= 0)
                {
                    RemoveAttributeModifier(_timeableAttributeModifiers[i]);
                    _timeableAttributeModifiers.RemoveAt(i);
                }
            }
            
            for (int i = 0; i < _timeableStatModifiers.Count; i++)
            {
                _timeableStatModifiers[i].UpdateDuration(Time.deltaTime);
                if (_timeableStatModifiers[i].Duration <= 0)
                {
                    RemoveStatModifier(_timeableStatModifiers[i]);
                    _timeableStatModifiers.RemoveAt(i);
                }
            }
        }
    }
}