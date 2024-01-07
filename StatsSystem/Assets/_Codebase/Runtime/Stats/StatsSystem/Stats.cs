using _Codebase.Runtime.Stats.Example;
using _Codebase.Runtime.Stats.StatsSystem.CoreAttribute.MainAttributes;
using _Codebase.Runtime.Stats.StatsSystem.CoreStat.CoreModifiers;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Codebase.Runtime.Stats.StatsSystem.CoreStat
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
            StatsContainer.AddAttributeModifier(new AttributeModifier(AttributeType.Health, 10));
        }
        
        [Button]
        public void RemoveModifier()
        {
            StatsContainer.RemoveAttributeModifier(new AttributeModifier(AttributeType.Health, 10));
        }
        
        [Button]
        public void AddStatModifier()
        {
            StatsContainer.AddStatModifier(new StatModifier(StatType.Strength, 10));
        }
        
        [Button]
        public void RemoveStatModifier()
        {
            StatsContainer.RemoveStatModifier(new StatModifier(StatType.Strength, 10));
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