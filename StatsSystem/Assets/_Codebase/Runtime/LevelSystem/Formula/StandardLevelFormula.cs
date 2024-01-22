using System;
using UnityEngine;

namespace _Codebase.Runtime.LevelSystem.Formula
{
    [Serializable]
    public class StandardLevelFormula : ILevelFormula
    {
        [SerializeField] private int _experienceModifier;
        
        public int GetRequiredXp(int currentLevel)
        {
            return currentLevel * _experienceModifier;
        }
    }
}