using System;
using _Codebase.Runtime.StatsSystem.Core;
using _Codebase.Runtime.StatsSystem.Formula.Core;
using UnityEngine;

namespace _Codebase.Runtime.StatsSystem.Formula
{
    [Serializable]
    public class LevelFormula : StatFormula
    {
        [SerializeField] private int _level;
        [SerializeField] public float _multiplier;
        
        public override float Calculate(float value, RuntimeCharacteristics characteristics) => _level * _multiplier + value;
    }
}