using System.Collections.Generic;
using _Codebase.Runtime.Stats.StatsSystem.CoreAttribute.MainAttributes;
using _Codebase.Runtime.Stats.StatsSystem.CoreAttribute.RuntimeAttributes;
using _Codebase.Runtime.Stats.StatsSystem.CoreStat.CoreModifiers;
using _Codebase.Runtime.Stats.StatsSystem.CoreStat.RuntimeStats;
using UnityEngine;

namespace _Codebase.Runtime.Stats.StatsSystem.CoreStat
{
    public class StatsContainer
    {
        private readonly StatsConfig _statsConfig;
        
        private readonly List<IRuntimeAttribute> _runtimeAttributes = new List<IRuntimeAttribute>();
        private readonly List<IRuntimeStat> _runtimeStats = new List<IRuntimeStat>();
        
        private readonly List<AttributeModifier> _attributeModifiers = new List<AttributeModifier>();
        private readonly List<StatModifier> _statModifiers = new List<StatModifier>();
        
        private readonly Dictionary<AttributeType, IRuntimeAttribute> _attributeDictionary = new Dictionary<AttributeType, IRuntimeAttribute>();
        private readonly Dictionary<StatType, IRuntimeStat> _statDictionary = new Dictionary<StatType, IRuntimeStat>();

        public StatsContainer(StatsConfig statsConfig)
        {
            _statsConfig = statsConfig;

            foreach (var attribute in _statsConfig.Attributes)
            {
                _attributeDictionary.Add(attribute.AttributeType, new RuntimeAttribute(attribute));
            }
            
            foreach (var stat in _statsConfig.Stats)
            {
                _statDictionary.Add(stat.StatType, new RuntimeStat(stat));
            }

            RecalculateStats();
        }
        
        public void AddAttributeModifier(AttributeModifier attributeModifier)
        {
            _attributeModifiers.Add(attributeModifier);
        }

        public void RemoveAttributeModifier(AttributeModifier attributeModifier)
        {
            _attributeModifiers.Remove(attributeModifier);
        }

        public void AddStatModifier(StatModifier statModifier)
        {
            _statModifiers.Add(statModifier);
        }

        public void RemoveStatModifier(StatModifier statModifier)
        {
            _statModifiers.Remove(statModifier);
        }

        public void RecalculateStats()
        {
            foreach (var attribute in _attributeDictionary)
            {
                attribute.Value.Value = attribute.Value.BaseAttribute.BaseValue;
                foreach (var formula in attribute.Value.BaseAttribute.Formulas)
                {
                    attribute.Value.Value += formula.Calculate(attribute.Value.BaseAttribute, _statsConfig);
                }
            }
            
            foreach (var attributeModifier in _attributeModifiers)
            {
                _attributeDictionary[attributeModifier.Type].Value += attributeModifier.Value;
            }

            foreach (var attribute in _attributeDictionary)
            {
                Debug.Log(attribute.Key.ToString() + " = " + attribute.Value.Value);
            }
        }
    }
}