using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LastWarBR
{
    public class ItemViewController : MonoBehaviour
    {
        #region Declarations
        [SerializeField] private Image boundarySprite;
        [SerializeField] private Image itemSprite;
        [SerializeField] private TMP_Text ammountLabel;
        [SerializeField] private Sprite selected_Sprite;
        [SerializeField] private Sprite nonSelected_Sprite;

        private bool selected;
        private Object item;
        #endregion
        #region Fucntions
        public void Init(Object item = null)
        {
            this.item = item;
            FindReferences();

            if(item != null)
            {
                itemSprite.sprite = item.Image;
                ammountLabel.text = item.Uses.ToString();
            }
            if (selected)
            {
                boundarySprite.sprite = selected_Sprite;
            }
            else
            {
                boundarySprite.sprite = nonSelected_Sprite;
            }
        }
        private void FindReferences()
        {
            if(boundarySprite == null)
            {
                boundarySprite = gameObject.GetComponent<Image>();
            }
            if(itemSprite == null)
            {
                itemSprite = transform.Find("Item_Sprite").GetComponent<Image>();
            }
            if(ammountLabel == null)
            {
                ammountLabel = transform.Find("Ammount_Label").GetComponent<TMP_Text>();
            }
        }
        #endregion
    }
}
