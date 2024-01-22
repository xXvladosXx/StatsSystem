using System.Collections.Generic;
using _Codebase.Runtime.LevelSystem.Formula;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Codebase.Runtime.LevelSystem
{
    [CreateAssetMenu(menuName = "Level system/Level data", fileName = "Level data")]
    public class LevelData : SerializedScriptableObject
    {
        [field: SerializeField]
        public Dictionary<int, StandardLevelFormula> LevelFormulas { get; private set; } =
            new Dictionary<int, StandardLevelFormula>();

        public int FindAppropriateXp(int level)
        {
            return LevelFormulas[level].GetRequiredXp(level);
        }
    }
}