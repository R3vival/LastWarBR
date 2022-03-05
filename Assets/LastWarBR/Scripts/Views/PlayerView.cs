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
        [SerializeField] private TMP_Text nameDisplay;
        [SerializeField] private TMP_Text healthDisplayAmmount;
        [SerializeField] private Slider healthSlider;

        private CharacterBase player;
        #endregion
        #region Unity Funtions
        #endregion
        #region Function
        public void Init(CharacterBase newPlayer)
        {
            player = newPlayer;

            FindReferences();

            nameDisplay.text = player.GetName().ToString();

            healthDisplayAmmount.text = player.GetHealthPoints().ToString();
            healthSlider.maxValue = player.GetHealthPoints();
            healthSlider.value = player.GetHealthPoints();
        }
        private void FindReferences()
        {
            
        }
        public void UpdateName(string newName)
        {
            nameDisplay.text = newName;
        }
        public void UpdateHealth(short health)
        {
            healthDisplayAmmount.text = health.ToString();


        }
        #endregion
    }
}
