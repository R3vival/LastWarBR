using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastWarBR
{
    public class PlayerBase : MonoBehaviour
    {
        #region Declarations
        [SerializeField] protected string playerName;
        [SerializeField] protected short health = 250;

        //Actions
        [SerializeField] public Action<short> LoseHealth;
        [SerializeField] public Action<short> GainHealth;
        #endregion
        #region Functions
        /// <summary>
        /// Heals the player with the given points
        /// the basic points healed ar 50 pts
        /// </summary>
        /// <param name="pointsHealed"></param>
        protected void HealPlayer(short pointsHealed = 50)
        {
            health += pointsHealed;
        }
        /// <summary>
        /// Deals damage to the player with the given points
        /// the basic damage points are 50
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(short damage = 50)
        {
            health -= damage;
        }
        #endregion
    }
}