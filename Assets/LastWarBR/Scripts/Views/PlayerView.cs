using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LastWarBR
{
    public class PlayerView : MonoBehaviour
    {
        #region Declarations
        #region HUD
        /// <summary>
        /// HUD - Display name at gameplay
        /// </summary>
        [SerializeField] private TMP_Text nameDisplay;
        /// <summary>
        /// HUD - Display HealthPoints at gameplay
        /// </summary>
        [SerializeField] private TMP_Text healthDisplayAmmount;
        /// <summary>
        /// Health bar display at gameplay
        /// </summary>
        [SerializeField] private Slider healthSlider;
        #endregion
        [SerializeField] private Animator animator;
        /// <summary>
        /// Player information
        /// </summary>
        private CharacterBase player;
        #endregion
        #region Unity Funtions
        #endregion
        #region Function
        /// <summary>
        /// Initialize the player view behaviour
        /// Including the player HUD info and finding the references needed for this
        /// </summary>
        /// <param name="newPlayer"></param>
        public void Init(CharacterBase newPlayer)
        {
            player = newPlayer;

            FindReferences();

            nameDisplay.text = player.GetName().ToString();

            healthDisplayAmmount.text = player.GetMaxHealthPoints().ToString();
            healthSlider.maxValue = player.GetMaxHealthPoints();
            healthSlider.value = player.GetMaxHealthPoints();

            player.Shooting -= PlayAnim;
            player.IsMoving -= PlayAnim;
            player.IsNotMoving -= StopAnim;

            player.Shooting += PlayAnim;
            player.IsMoving += PlayAnim;
            player.IsNotMoving += StopAnim;
        }
        /// <summary>
        /// Find all the references needed for the correct functionality of Player view behaviour
        /// </summary>
        private void FindReferences()
        {
            Transform tempCanvas = transform.Find("Canvas").transform;
            if (healthSlider == null)
            {
                healthSlider = tempCanvas.Find("HealthBar").GetComponent<Slider>();
            }

            if (nameDisplay == null)
            {
                nameDisplay = healthSlider.transform.Find("NameLabel").GetComponent<TMP_Text>();
            }
            if (healthDisplayAmmount == null)
            {
                healthDisplayAmmount = healthSlider.transform.Find("HealthLabel").GetComponent<TMP_Text>();
            }
            if(animator == null)
            {
                animator = gameObject.GetComponent<Animator>();
            }
        }
        /// <summary>
        /// Function called to update the HUD name displayed
        /// </summary>
        /// <param name="newName"></param>
        public void UpdateName(string newName)
        {
            nameDisplay.text = newName;
        }
        /// <summary>
        /// Function called to update the HUD health name and Healthbar displayed
        /// </summary>
        /// <param name="health"></param>
        public void UpdateHealth(short health)
        {
            healthDisplayAmmount.text = health.ToString();

            healthSlider.value = health;
        }

        private void PlayAnim(int action)
        {
            animator.SetBool("Moving", true);

            float currentBlend = animator.GetFloat("Blend");

            if(currentBlend != action)
            {
                currentBlend = (currentBlend + action) / 2;
            }
            animator.SetFloat("Blend", currentBlend);
        }
        private void StopAnim()
        {
            animator.SetBool("Moving", false);
        }
        #endregion
    }
}
