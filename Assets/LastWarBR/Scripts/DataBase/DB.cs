using System;
using UnityEngine;

namespace LastWarBR
{
    [CreateAssetMenu(fileName ="DataBase", menuName ="LastWarBR/CharactersDb")]
    public class DB : ScriptableObject
    {
        [Header("Character Data Base")]
        public CharacterStats Player;

        [Header("Enemys Data Base")]
        public CharacterStats[] Enemys;

        public Object[] Objects;
    }    
}