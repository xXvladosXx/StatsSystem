using System;
using System.Collections.Generic;
using System.Linq;
using _Codebase.Runtime.Stats.StatsSystem.CoreAttribute.MainAttributes;
using _Codebase.Runtime.Stats.StatsSystem.CoreAttribute.RuntimeAttributes;
using _Codebase.Runtime.Stats.StatsSystem.CoreStat.RuntimeStats;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Codebase.Runtime.Stats.StatsSystem.CoreStat
{
    [CreateAssetMenu(fileName = "Stats Config", menuName = "Stats/Stats Config")]
    public class StatsConfig : SerializedScriptableObject
    {
        [field: SerializeField] public List<IStat> Stats { get; private set; } = new List<IStat>();
        [field: SerializeField] public List<IAttribute> Attributes { get; private set; } = new List<IAttribute>();

        private void OnValidate()
        {
            if (Stats.Any(stat => Stats.Any(otherStat => stat != otherStat && stat.StatType == otherStat.StatType)))
            {
                Debug.LogError("The same stat was added twice");
            }
            
            if (Attributes.Any(stat => Attributes.Any(otherStat => stat != otherStat && stat.AttributeType == otherStat.AttributeType)))
            {
                Debug.LogError("The same attribute was added twice");
            }
        }

        [Button]
        public void TestStat()
        {
            var stats = new List<IRuntimeStat>();
            foreach (var stat in Stats)
            {
                stats.Add(new RuntimeStat(stat));
            }

            foreach (var runtimeStat in stats)
            {
                Debug.Log(runtimeStat.BaseStat.ToString() + " " + runtimeStat.Calculate());
            }
        }
        
        [Button]
        public void TestAttribute()
        {
            var attributes = new List<IRuntimeAttribute>();
            foreach (var attribute in Attributes)
            {
                attributes.Add(new RuntimeAttribute(attribute));
            }

        }
    }
}