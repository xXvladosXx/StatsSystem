using _Codebase.Runtime.Stats.Core;
using _Codebase.Runtime.Stats.Core.Attributes;
using _Codebase.Runtime.Stats.Core.Modifiers;
using _Codebase.Runtime.Stats.Core.Modifiers.Types;
using _Codebase.Runtime.Stats.Core.Stats;
using _Codebase.Runtime.Stats.Example;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Codebase.Runtime.Stats
{
    public class Stats : MonoBehaviour
    {
        public StatsConfig StatsConfig;
        [FormerlySerializedAs("ArmorItem")] public ModifiableItem modifiableItem;
        
        private StatsContainer StatsContainer { get; set; }
        
        private void Awake()
        {
            StatsContainer = new StatsContainer(StatsConfig);
        }
        
        [Button]
        public void Recalculate()
        {
            StatsContainer.RecalculateStats();
        }
        
        [Button]
        public void AddModifier()
        {
            StatsContainer.AddAttributeModifier(new AttributeModifier());
        }
        
        [Button]
        public void RemoveModifier()
        {
            StatsContainer.RemoveAttributeModifier(new AttributeModifier());
        }
        
        [Button]
        public void AddStatModifier()
        {
            StatsContainer.AddStatModifier(new StatModifier(StatType.Strength, new ConstantType(10)));
        }
        
        [Button]
        public void RemoveStatModifier()
        {
            StatsContainer.RemoveStatModifier(new StatModifier(StatType.Strength, new ConstantType(10)));
        }

        [Button]
        public void AddItem()
        {
            foreach (var attributeModifier in modifiableItem.AttributeModifiers)
            {
                StatsContainer.AddAttributeModifier(attributeModifier);
            }
            
            foreach (var statModifier in modifiableItem.StatModifiers)
            {
                StatsContainer.AddStatModifier(statModifier);
            }
            
            StatsContainer.RecalculateStats();
        }
        
        [Button]
        public void RemoveItem()
        {
            foreach (var attributeModifier in modifiableItem.AttributeModifiers)
            {
                StatsContainer.RemoveAttributeModifier(attributeModifier);
            }
            
            foreach (var statModifier in modifiableItem.StatModifiers)
            {
                StatsContainer.RemoveStatModifier(statModifier);
            }
            
            StatsContainer.RecalculateStats();
        }
    }
}