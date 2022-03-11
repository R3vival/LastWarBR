using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LastWarBR
{
    public class InventoryController :MonoBehaviour
    {
        #region Declarations
        [SerializeField] private ItemViewController[] itemsCollection;
        private Object[] objects;
        #endregion
        #region Unity Functions
        private void Awake()
        {
            GameManager.Instance.OnSpawn += Init;

            foreach(ItemViewController item in itemsCollection )
            {
                item.ItemSelected -= SelectObject;
            }
        }
        #endregion
        #region Functions
        private void Init(GameObject player,CharacterType type)
        {
            if ( type == CharacterType.Player )
            {
                FindReferences();

                this.objects = player.GetComponent<PlayerController>().GetInventory();

                for ( int i = 0; i < itemsCollection.Length; i++ )
                {
                    if ( i < objects.Length )
                    {
                        itemsCollection[i].Init(objects[i]);                        
                    }
                    else
                    {
                        itemsCollection[i].Init();
                    }
                }
                if(objects.Length > 0 )
                {
                    itemsCollection[0].GetSelected();
                }
                foreach(ItemViewController item in itemsCollection )
                {
                    item.ItemSelected += SelectObject;
                }
            }

        }
        private void FindReferences()
        {
            itemsCollection = new ItemViewController[transform.childCount];
            for ( int i = 0; i < transform.childCount; i++ )
            {
                itemsCollection[i] = transform.GetChild(i).GetComponent<ItemViewController>();
            }
        }
        private void SelectObject(Object newObject)
        {
            List<Object> tempList = objects.ToList();

            int index = tempList.FindIndex(x => x == GameManager.Instance.DataBase.Player.lastUsedObject);
            itemsCollection[index].Deselect();            

            GameManager.Instance.DataBase.Player.lastUsedObject = newObject;
        }
        #endregion
    }
}