using System.Collections;
using _Codebase.Runtime.StatsSystem.Core.Attributes;
using _Codebase.Runtime.StatsSystem.Core.Modifiers;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Types;
using _Codebase.Runtime.StatsSystem.Core.Stats;
using FluentAssertions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace _Codebase.Tests.Stats
{
    public class StatsTests
    {
        private GameObject _exampleStatsPrefab;
        private GameObject _exampleStats;
 
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _exampleStatsPrefab = Resources.Load<GameObject>("Test/ExampleStats");
        }
        
        [SetUp]
        public void BeforeEachTestSetup()
        {
            _exampleStats = Object.Instantiate(_exampleStatsPrefab);
        }
        
        [UnityTest]
        public IEnumerator StatsContainer_WhenConstantStatAdded_ModifyStat()
        {
            yield return null;
            
            var attribute = _exampleStats.GetComponent<Runtime.StatsSystem.Stats>();

            attribute.StatsContainer.GetStat(StatType.Strength).Value.Should().Be(10);
            var statModifier = new StatModifier(StatType.Strength, new ConstantType(10));
            attribute.StatsContainer.AddStatModifier(statModifier);
            attribute.StatsContainer.RecalculateStats();
            attribute.StatsContainer.GetStat(StatType.Strength).Value.Should().Be(20);
        }
        
        [UnityTest]
        public IEnumerator StatsContainer_WhenConstantStatRemoved_ModifyStat()
        {
            yield return null;
            
            var attribute = _exampleStats.GetComponent<Runtime.StatsSystem.Stats>();
            
            var startValue = attribute.StatsContainer.GetStat(StatType.Strength).Value;

            var statModifier = new StatModifier(StatType.Strength, new ConstantType(10));
            
            attribute.StatsContainer.AddStatModifier(statModifier);
            attribute.StatsContainer.RecalculateStats();
            attribute.StatsContainer.GetStat(StatType.Strength).Value.Should().Be(startValue + 10);
            
            attribute.StatsContainer.RemoveStatModifier(statModifier);
            attribute.StatsContainer.RecalculateStats();
            attribute.StatsContainer.GetStat(StatType.Strength).Value.Should().Be(startValue);
        }
        
        [UnityTest]
        public IEnumerator StatsContainer_WhenConstantAttributeAdded_ModifyAttribute()
        {
            yield return null;
            
            var attribute = _exampleStats.GetComponent<Runtime.StatsSystem.Stats>();
            var startValue = attribute.StatsContainer.GetAttribute(AttributeType.Health).Value;
            var statModifier = new AttributeModifier(AttributeType.Health, new ConstantType(10));
            attribute.StatsContainer.AddAttributeModifier(statModifier);
            attribute.StatsContainer.RecalculateStats();
            attribute.StatsContainer.GetAttribute(AttributeType.Health).Value.Should().Be(startValue + 10);
        }
        
        [UnityTest]
        public IEnumerator StatsContainer_WhenConstantAttributeRemoved_ModifyAttribute()
        {
            yield return null;
            
            var attribute = _exampleStats.GetComponent<Runtime.StatsSystem.Stats>();

            var startValue = attribute.StatsContainer.GetAttribute(AttributeType.Health).Value;

            var statModifier = new AttributeModifier(AttributeType.Health, new ConstantType(10));
            attribute.StatsContainer.AddAttributeModifier(statModifier);
            attribute.StatsContainer.RecalculateStats();
            attribute.StatsContainer.GetAttribute(AttributeType.Health).Value.Should().Be(startValue + 10);
            
            attribute.StatsContainer.RemoveAttributeModifier(statModifier);
            attribute.StatsContainer.RecalculateStats();
            attribute.StatsContainer.GetAttribute(AttributeType.Health).Value.Should().Be(startValue);
        }
        
        [UnityTest]
        public IEnumerator StatsContainer_WhenConstantStatAdded_ModifyAttribute()
        {
            yield return null;
            
            var attribute = _exampleStats.GetComponent<Runtime.StatsSystem.Stats>();

            var startValue = attribute.StatsContainer.GetAttribute(AttributeType.Health).Value;

            var statModifier = new StatModifier(StatType.Strength, new ConstantType(10));
            attribute.StatsContainer.AddStatModifier(statModifier);
            attribute.StatsContainer.RecalculateStats();
            attribute.StatsContainer.GetAttribute(AttributeType.Health).Value.Should().Be(startValue + 20);
        }
        
        [UnityTest]
        public IEnumerator StatsContainer_WhenPercentageStatAdded_ModifyStat()
        {
            yield return null;
            
            var attribute = _exampleStats.GetComponent<Runtime.StatsSystem.Stats>();

            var startValue = attribute.StatsContainer.GetStat(StatType.Strength).Value;

            var statModifier = new StatModifier(StatType.Strength, new PercentType(10));
            attribute.StatsContainer.AddStatModifier(statModifier);
            attribute.StatsContainer.RecalculateStats();
            attribute.StatsContainer.GetStat(StatType.Strength).Value.Should().Be(startValue + (startValue * 0.1f));
        }
    }
}