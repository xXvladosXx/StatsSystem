using System.Collections.Generic;
using _Codebase.Runtime.Stats.Core.Attributes;
using _Codebase.Runtime.Stats.Core.Attributes.Core;
using _Codebase.Runtime.Stats.Core.Modifiers;
using _Codebase.Runtime.Stats.Core.Modifiers.Core;
using _Codebase.Runtime.Stats.Core.Stats;
using _Codebase.Runtime.Stats.Core.Stats.Core;
using UnityEngine;

namespace _Codebase.Runtime.Stats.Core
{
    public class StatsContainer
    {
        private readonly List<IRuntimeAttribute> _runtimeAttributes = new List<IRuntimeAttribute>();
        private readonly List<IRuntimeStat> _runtimeStats = new List<IRuntimeStat>();
        
        private readonly List<IAttributeModifier> _attributeModifiers = new List<IAttributeModifier>();
        private readonly List<IStatModifier> _statModifiers = new List<IStatModifier>();
        
        private readonly Dictionary<AttributeType, IRuntimeAttribute> _attributeDictionary = new Dictionary<AttributeType, IRuntimeAttribute>();
        private readonly Dictionary<StatType, IRuntimeStat> _statDictionary = new Dictionary<StatType, IRuntimeStat>();
        
        private readonly RuntimeCharacteristics _runtimeCharacteristics;

        public StatsContainer(StatsConfig statsConfig)
        {
            foreach (var attribute in statsConfig.Attributes)
                _attributeDictionary.Add(attribute.AttributeType, new RuntimeAttribute(attribute));
            
            foreach (var stat in statsConfig.Stats)
                _statDictionary.Add(stat.StatType, new RuntimeStat(stat));

            _runtimeCharacteristics = new RuntimeCharacteristics(_runtimeStats, _runtimeAttributes);

            RecalculateStats();
        }
        
        public void AddAttributeModifier(IAttributeModifier attributeModifier) => 
            _attributeModifiers.Add(attributeModifier);

        public void RemoveAttributeModifier(IAttributeModifier attributeModifier) => 
            _attributeModifiers.Remove(attributeModifier);

        public void AddStatModifier(IStatModifier statModifier) => 
            _statModifiers.Add(statModifier);

        public void RemoveStatModifier(IStatModifier statModifier) => 
            _statModifiers.Remove(statModifier);

        public void RecalculateStats()
        {
            _runtimeStats.Clear();
            _runtimeAttributes.Clear();

            RecalculateBaseStats();
            RecalculateStatModifiers();

            RecalculateBaseAttributes();
            RecalculateAttributeModifiers();

            foreach (var runtimeAttribute in _attributeDictionary)
            {
                Debug.Log(runtimeAttribute.Key + " = " + runtimeAttribute.Value.Value + " (" + runtimeAttribute.Value.BaseAttribute.ModifierType.Value + ")");
            }
            
            foreach (var stat in _statDictionary)
            {
                Debug.Log(stat.Key + " = " + stat.Value.Value + " (" + stat.Value.BaseStat.ModifierType.Value + ")");
            }
            
            Debug.Log("==================================== Modifiers");

            foreach (var attributeModifier in _attributeModifiers)
            {
                Debug.Log(attributeModifier.Type + " = " + attributeModifier.ModifierType.Value);
            }
            
            foreach (var statModifier in _statModifiers)
            {
                Debug.Log(statModifier.Type + " = " + statModifier.ModifierType.Value);
            }
            
            Debug.Log("====================================");
        }

        private void RecalculateBaseStats()
        {
            foreach (var stat in _statDictionary)
            {
                _runtimeStats.Add(stat.Value);
                
                stat.Value.Value = stat.Value.BaseStat.ModifierType.Value;
                
                foreach (var formula in stat.Value.BaseStat.Formulas)
                {
                    stat.Value.Value += formula.Calculate(stat.Value.Value, _runtimeCharacteristics);
                }
            }
        }

        private void RecalculateStatModifiers()
        {
            foreach (var statModifier in _statModifiers)
                _statDictionary[statModifier.Type].Value += statModifier.ModifierType.FindBonus(_statDictionary[statModifier.Type].Value);
        }

        private void RecalculateBaseAttributes()
        {
            foreach (var attribute in _attributeDictionary)
            {
                _runtimeAttributes.Add(attribute.Value);
                
                attribute.Value.Value = attribute.Value.BaseAttribute.ModifierType.Value;
                
                foreach (var formula in attribute.Value.BaseAttribute.Formulas)
                {
                    attribute.Value.Value += formula.Calculate(attribute.Value.Value, _runtimeCharacteristics);
                }
            }
        }

        private void RecalculateAttributeModifiers()
        {
            foreach (var attributeModifier in _attributeModifiers)
                _attributeDictionary[attributeModifier.Type].Value += attributeModifier.ModifierType.FindBonus(_attributeDictionary[attributeModifier.Type].Value);
        }
    }
}