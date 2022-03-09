using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LastWarBR
{
    public class ItemViewController :MonoBehaviour
    {
        #region Declarations
        [SerializeField] private Image boundarySprite;
        [SerializeField] private Image itemSprite;
        [SerializeField] private TMP_Text ammountLabel;
        [SerializeField] private Sprite selected_Sprite;
        [SerializeField] private Sprite nonSelected_Sprite;

        private bool selected;
        private Object item;

        public Action<Object> ItemSelected { get; set; }
        #endregion
        #region Fucntions
        public void Init(Object item = null)
        {
            this.item = item;
            FindReferences();

            if ( item != null )
            {
                itemSprite.sprite = item.Image;

                Color tempColor = itemSprite.color;
                tempColor.a = 255f;

                itemSprite.color = tempColor;

                ammountLabel.text = item.Uses.ToString();
            }
            else
            {
                itemSprite.sprite = null;
                Color tempColor = itemSprite.color;
                tempColor.a = 0f;

                itemSprite.color = tempColor;
                ammountLabel.text = "-";
            }
            if ( selected )
            {
                boundarySprite.sprite = selected_Sprite;
            }
            else
            {
                boundarySprite.sprite = nonSelected_Sprite;
            }

            GetComponent<Button>().onClick.AddListener(GetSelected);
        }
        private void FindReferences()
        {
            if ( boundarySprite == null )
            {
                boundarySprite = gameObject.GetComponent<Image>();
            }
            if ( itemSprite == null )
            {
                itemSprite = transform.Find("Item_Sprite").GetComponent<Image>();
            }
            if ( ammountLabel == null )
            {
                ammountLabel = transform.Find("Ammount_Label").GetComponent<TMP_Text>();
            }
        }
        public void GetSelected()
        {
            if ( item == null )
                return;
            selected = true;
            boundarySprite.sprite = selected_Sprite;
            GetComponent<Button>().interactable = false;
            ItemSelected?.Invoke(item);
        }
        public void Deselect()
        {
            if ( item == null )
                return;
            selected = false;
            boundarySprite.sprite = nonSelected_Sprite;
            GetComponent<Button>().interactable = true;
        }
        #endregion
    }
}
