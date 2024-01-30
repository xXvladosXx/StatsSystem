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
        private readonly List<RuntimeAttribute> _runtimeAttributes = new List<RuntimeAttribute>();
        private readonly List<RuntimeStat> _runtimeStats = new List<RuntimeStat>();
        
        private readonly Dictionary<AttributeType, RuntimeAttribute> _attributeDictionary = new Dictionary<AttributeType, RuntimeAttribute>();
        private readonly Dictionary<StatType, RuntimeStat> _statDictionary = new Dictionary<StatType, RuntimeStat>();

        private readonly RuntimeCharacteristics _runtimeCharacteristics;

        private readonly ModifiersCalculator<StatType> _statModifiersCalculator;
        private readonly ModifiersCalculator<AttributeType> _attributeModifiersCalculator;

        public StatsContainer(StatsConfig statsConfig)
        {
            foreach (var attribute in statsConfig.Attributes)
                _attributeDictionary.Add(attribute.AttributeType, new RuntimeAttribute(attribute));
            
            foreach (var stat in statsConfig.Stats)
                _statDictionary.Add(stat.StatType, new RuntimeStat(stat));

            _runtimeCharacteristics = new RuntimeCharacteristics(_runtimeStats, _runtimeAttributes);
            
            _statModifiersCalculator = new ModifiersCalculator<StatType, RuntimeStat, IStat>();
            _attributeModifiersCalculator = new ModifiersCalculator<AttributeType, RuntimeAttribute, IAttribute>();

            RecalculateStats();
        }

        public RuntimeStat GetStat(StatType statType) =>
            _statDictionary[statType];

        public RuntimeAttribute GetAttribute(AttributeType attributeType) => 
            _attributeDictionary[attributeType];

        public void AddAttributeModifier(IModifier<AttributeType> attributeModifier) 
        {
            _attributeModifiersCalculator.AddModifier(attributeModifier);
        }

        public void RemoveAttributeModifier(IModifier<AttributeType> attributeModifier)
        {
            _attributeModifiersCalculator.RemoveModifier(attributeModifier);
        }

        public void AddStatModifier(IModifier<StatType> statModifier)
        {
            _statModifiersCalculator.AddModifier(statModifier);
        }
        
        public void RemoveStatModifier(IModifier<StatType> statModifier)
        {
            _statModifiersCalculator.RemoveModifier(statModifier);
        }

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

            foreach (var attributeModifier in _attributeModifiersCalculator.Modifiers)
            {
                Debug.Log(attributeModifier.Type + " = " + attributeModifier.ModifierType.Value);
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
            foreach (var runtimeStat in _statDictionary)
                _statModifiersCalculator.MakeOperations(runtimeStat.Key, runtimeStat.Value);
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
            foreach (var runtimeAttribute in _attributeDictionary) 
                runtimeAttribute.Value.Value += _attributeModifiersCalculator.MakeOperations(runtimeAttribute.Key, runtimeAttribute.Value.Value);
        }

        // public void Update()

        // {

        //     _modifiersCalculator.Update();

        // }
    }
}