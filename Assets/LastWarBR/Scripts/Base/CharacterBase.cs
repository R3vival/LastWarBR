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
        public Action<short> LoseHealth;
        public Action<short> GainHealth;
        public Action<int> IsMoving;
        public Action<int> Shooting;

        public Action IsNotMoving;

        #endregion
        #region Unity Functions
        private void OnCollisionEnter(Collision collision)
        {
            BulletController bullet = collision.gameObject.GetComponent<BulletController>();
            if(collision.gameObject.tag == "Bullet")
            {
                //TODO die
            }
        }
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
        
        #region Get PlayerStat Functions
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
        /// <summary>
        /// Return the Player or Enemy Name
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return characterStats.playerName;
        }
        /// <summary>
        /// Set a name for the Player or enemy
        /// </summary>
        /// <param name="newName"></param>
        public void SetName(string newName)
        {
            characterStats.playerName = newName;
        }
        /// <summary>
        /// Get the max health of the player or enemy
        /// </summary>
        /// <returns></returns>
        public short GetMaxHealthPoints()
        {
            return characterStats.maxHealth;
        }
        /// <summary>
        /// Get the current health of the player or enemy
        /// </summary>
        /// <returns></returns>
        public short GetHealthPoints()
        {
            return characterStats.health;
        }
        /// <summary>
        /// Set the current Health of the player or enemy
        /// </summary>
        /// <param name="newHealth"></param>
        public void SetHealthPoints(short newHealth) 
        {
            characterStats.health = newHealth;
        }
        public Object GetSelectedObject()
        {
            return characterStats.SelectedObject;
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

        
        #endregion
    }
}