﻿using System;
using _Codebase.Runtime.StatsSystem.Core.Attributes;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Core;
using _Codebase.Runtime.StatsSystem.Core.Modifiers.Types;
using UnityEngine;

namespace _Codebase.Runtime.StatsSystem.Core.Modifiers
{
    [Serializable]
    public class AttributeModifier : IModifier<AttributeType>
    {
        [field: SerializeField] public AttributeType Type { get; private set; }
        [field: SerializeField] public IModifierType ModifierType { get; private set; }

        public AttributeModifier() { }
        
        public AttributeModifier(AttributeType attributeType,
            IModifierType modifierType)
        {
            Type = attributeType;
            ModifierType = modifierType;
        }

        public void UpdateDuration(float deltaTime) { }
    }
}