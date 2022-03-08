using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastWarBR
{
    public class InventoryController : MonoBehaviour
    {
        #region Declarations
        [SerializeField] private ItemViewController[] itemsCollection;
        private Object[] objects;
        #endregion
        #region Functions
        private void Init(Object[] objects)
        {
            FindReferences();

            this.objects = objects;
            for(int i = 0; i < objects.Length; i++)
            {
                itemsCollection[i].Init(objects[i]);
            }
        }
        private void FindReferences()
        {
            itemsCollection = new ItemViewController[transform.childCount];
            for(int i = 0; i< transform.childCount; i++)
            {
                itemsCollection[i] = transform.GetChild(i).GetComponent<ItemViewController>();
            }
        }
        #endregion
    }
}