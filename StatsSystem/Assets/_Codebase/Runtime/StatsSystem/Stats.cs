using _Codebase.Runtime.StatsSystem.Core;
using _Codebase.Runtime.StatsSystem.Core.Modifiers;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Types;
using _Codebase.Runtime.StatsSystem.Core.Stats;
using _Codebase.Runtime.StatsSystem.Example;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Codebase.Runtime.StatsSystem
{
    public class Stats : MonoBehaviour
    {
        public StatsConfig StatsConfig;
        [FormerlySerializedAs("ArmorItem")] public ModifiableItem modifiableItem;
        
        public StatsContainer StatsContainer { get; private set; }
        
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

        public void ResetStats()
        {
            StatsContainer = new StatsContainer(StatsConfig);
        }
    }
}