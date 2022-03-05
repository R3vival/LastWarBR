using System;
using System.Linq;
using UnityEngine;

namespace LastWarBR
{
    /// <summary>
    /// This is used to all characters 
    ///     Players
    ///     Enemys
    /// </summary>
    [Serializable]
    public class CharacterBase :MonoBehaviour
    {
        #region Declarations
        [Header("Basic Components")]
        [SerializeField] protected CharacterStats characterStats;

        [Header("Physics Components")]
        [SerializeField] protected Rigidbody rigidBody;

        //Actions
        [SerializeField] public Action<short> LoseHealth;
        [SerializeField] public Action<short> GainHealth;

        #endregion
        
        #region Functions
        protected void Init()
        {            
            if(rigidBody ==null)
            {
                if ( gameObject.GetComponent<Rigidbody>() != null )
                {
                    rigidBody = gameObject.GetComponent<Rigidbody>();
                }
                else
                {
                    rigidBody = gameObject.AddComponent<Rigidbody>();
                }
            }
        }
        /// <summary>
        /// Heals the player with the given points
        /// the basic points healed ar 50 pts
        /// </summary>
        /// <param name="pointsHealed"></param>
        protected void HealPlayer(short pointsHealed = 50)
        {
            characterStats.health += pointsHealed;
        }
        /// <summary>
        /// Deals damage to the player with the given points
        /// the basic damage points are 50
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(short damage = 50)
        {
            characterStats.health -= damage;
        }
        /// <summary>
        /// Reset the player to a Given Position
        /// </summary>
        /// <param name="spawnPoint"></param>
        public void Respawn(Transform spawnPoint)
        {
            transform.position = spawnPoint.position;
        }
        public string GetName()
        {
            return characterStats.playerName;
        }
        public void SetName(string newName)
        {
            characterStats.playerName = newName;
        }
        public short GetHealthPoints()
        {
            return characterStats.health;
        }
        public void SetHealthPoints(short newHealth) 
        {
            characterStats.health = newHealth;
        }
        public Object GetObject(int objectPos)
        {
            characterStats.SelectedObject = characterStats.inventory[objectPos];
            return characterStats.SelectedObject;
        }
        public void AddObject(Object newObject)
        {
            if (characterStats.inventory.Contains(newObject) )
            {
                characterStats.inventory.Find(x => x.name == newObject.name).Uses++;
                return;
            }
            characterStats.inventory.Add(newObject);
            
        }
        #endregion
    }
}