using System;
using System.Collections.Generic;
using UnityEngine;

namespace LastWarBR
{
    [Serializable]
    public class CharacterStats
    {
        public string characterName;

        [Range(0,3200)]
        public short maxHealth;
        public short health;
        [Range(0,10)]
        public short moveSpeed;
        [Range(0,10)]
        public short turnSpeed;

        public Object selectedWeapon;
        public Object lastUsedObject;
        public List<Object> inventory;
    }
}