using System.Collections.Generic;
using _Codebase.Runtime.StatsSystem.Core.Attributes;
using _Codebase.Runtime.StatsSystem.Core.Attributes.Core;
using _Codebase.Runtime.StatsSystem.Core.Modifiers;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Core;
using _Codebase.Runtime.StatsSystem.Core.Stats;
using _Codebase.Runtime.StatsSystem.Core.Stats.Core;
using UnityEngine;

namespace _Codebase.Runtime.StatsSystem.Core
{
    public class StatsContainer
    {
        private readonly List<IRuntimeAttribute> _runtimeAttributes = new List<IRuntimeAttribute>();
        private readonly List<IRuntimeStat> _runtimeStats = new List<IRuntimeStat>();
        
        private readonly Dictionary<AttributeType, IRuntimeAttribute> _attributeDictionary = new Dictionary<AttributeType, IRuntimeAttribute>();
        private readonly Dictionary<StatType, IRuntimeStat> _statDictionary = new Dictionary<StatType, IRuntimeStat>();

        private readonly RuntimeCharacteristics _runtimeCharacteristics;
        
        private readonly ModifiersCalculator _modifiersCalculator;

        public StatsContainer(StatsConfig statsConfig)
        {
            foreach (var attribute in statsConfig.Attributes)
                _attributeDictionary.Add(attribute.AttributeType, new RuntimeAttribute(attribute));
            
            foreach (var stat in statsConfig.Stats)
                _statDictionary.Add(stat.StatType, new RuntimeStat(stat));

            _runtimeCharacteristics = new RuntimeCharacteristics(_runtimeStats, _runtimeAttributes);
            _modifiersCalculator = new ModifiersCalculator();

            RecalculateStats();
        }

        public IRuntimeStat GetStat(StatType statType) =>
            _statDictionary[statType];
        public IRuntimeAttribute GetAttribute(AttributeType attributeType) => 
            _attributeDictionary[attributeType];

        public void AddAttributeModifier(IAttributeModifier attributeModifier) => 
            _modifiersCalculator.AddAttributeModifier(attributeModifier);

        public void RemoveAttributeModifier(IAttributeModifier attributeModifier) => 
            _modifiersCalculator.RemoveAttributeModifier(attributeModifier);

        public void AddStatModifier(IStatModifier statModifier) => 
            _modifiersCalculator.AddStatModifier(statModifier);

        public void RemoveStatModifier(IStatModifier statModifier) => 
            _modifiersCalculator.RemoveStatModifier(statModifier);
        
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

            foreach (var attributeModifier in _modifiersCalculator.AttributeModifiers)
            {
                Debug.Log(attributeModifier.Type + " = " + attributeModifier.ModifierType.Value);
            }
            
            foreach (var statModifier in _modifiersCalculator.StatModifiers)
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
            foreach (var statModifier in _modifiersCalculator.StatModifiers)
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
            foreach (var attributeModifier in _modifiersCalculator.AttributeModifiers)
                _attributeDictionary[attributeModifier.Type].Value += attributeModifier.ModifierType.FindBonus(_attributeDictionary[attributeModifier.Type].Value);
        }

        public void Update()
        {
            _modifiersCalculator.Update();
        }
    }
}