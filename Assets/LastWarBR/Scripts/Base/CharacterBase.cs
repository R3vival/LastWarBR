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

        public CharacterStats CharacterStats
        {
            get => characterStats;
            set => characterStats = value;
        }
        #endregion
        #region Unity Functions
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

            characterStats.selectedWeapon = characterStats.inventory.FirstOrDefault(x => x.Type == ObjectType.Gun) as Weapon;
            characterStats.lastUsedObject = characterStats.selectedWeapon;
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

            GainHealth?.Invoke(pointsHealed);
        }
        /// <summary>
        /// Deals damage to the player with the given points
        /// the basic damage points are 50
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(short damage = 50)
        {
            characterStats.health -= damage;
            LoseHealth?.Invoke(damage);

            if(characterStats.health <= 0 )
            {
                GameManager.Instance.Respawn?.Invoke();
            }
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
            return characterStats.characterName;
        }
        /// <summary>
        /// Set a name for the Player or enemy
        /// </summary>
        /// <param name="newName"></param>
        public void SetName(string newName)
        {
            characterStats.characterName = newName;
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
        /// <summary>
        /// Get the current selected Object
        /// </summary>
        /// <returns></returns>
        public Object GetSelectedObject()
        {
            return characterStats.lastUsedObject;
        }
        /// <summary>
        /// Get object from inventory
        /// </summary>
        /// <param name="objectPos"></param>
        /// <returns></returns>
        public Object GetObject(int objectPos)
        {
            characterStats.lastUsedObject = characterStats.inventory[objectPos];
            return characterStats.lastUsedObject;
        }
        /// <summary>
        /// Get all inventory
        /// </summary>
        /// <returns></returns>
        public Object[] GetInventory()
        {
            return characterStats.inventory.ToArray();
        }
        /// <summary>
        /// Add an object to the inventory
        /// </summary>
        /// <param name="newObject"></param>
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