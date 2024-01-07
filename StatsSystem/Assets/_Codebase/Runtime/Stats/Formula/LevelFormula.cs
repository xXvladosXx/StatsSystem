using System;
using _Codebase.Runtime.Stats.Core;
using _Codebase.Runtime.Stats.Formula.Core;
using UnityEngine;

namespace _Codebase.Runtime.Stats.Formula
{
    [Serializable]
    public class LevelFormula : StatFormula
    {
        [SerializeField] private int _level;
        [SerializeField] public float _multiplier;
        
        public override float Calculate(float value, RuntimeCharacteristics characteristics) => _level * _multiplier + value;
    }
}