using System;
using System.Linq;
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
        public Object GetKey()
        {
            Object key = Player.inventory.FirstOrDefault(x => x.Type == ObjectType.Key && x.Uses > 0);
            if(key != null )
            {
                return key;
            }
            return null;
        }
        public void UseObject(Object obj)
        {
            if( obj.Type != ObjectType.Gun )
            {
                obj.Uses--;
            }
        }
    }    
}