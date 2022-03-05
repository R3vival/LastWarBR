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
        [Header("Objecets Data Base")]
        public Object[] Objects;

        public CharacterStats GetPlayer()
        {
            return Player;
        }
        public CharacterStats[] GetAllEnemys()
        {
            return Enemys;
        }
        public Object[] GetAllObjects()
        {
            return Objects;
        }
    }    
}