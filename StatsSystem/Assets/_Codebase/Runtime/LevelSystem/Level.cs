using System;
using UnityEngine;

namespace _Codebase.Runtime.LevelSystem
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private LevelData _levelData;

        private int _currentXp;
        private int _maxXp;
        
        private int _currentLevel;
        
        private void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                _currentXp += 5;
                Debug.Log(_currentXp);

                if (_currentXp > _maxXp)
                {
                    _currentLevel++;
                    
                    _maxXp = _levelData.FindAppropriateXp(_currentLevel);
                    _currentXp = 0;
                }
            }
        }
    }
}