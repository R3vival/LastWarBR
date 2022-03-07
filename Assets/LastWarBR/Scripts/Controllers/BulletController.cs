using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastWarBR
{
    public class BulletController : MonoBehaviour
    {
        #region Declarations
        [SerializeField] private BulletView view;
        [SerializeField] private CharacterBase owner;
        [SerializeField] private Weapon weaponUsed;
        [SerializeField] private BoxCollider collider;
        #endregion
        #region Functions
        private void Init(CharacterBase bulletOwner)
        {
            FindReferences(bulletOwner);
            this.tag = "Bullet";
            collider.enabled = true;
        }
        private void FindReferences(CharacterBase bulletOwner)
        {
            if(view == null)
            {
                gameObject.transform.Find("View").GetComponent<BulletView>();
            }
            owner = bulletOwner;
            weaponUsed = (Weapon)bulletOwner.GetSelectedObject();
        }
        private void Disable()
        {
            view.gameObject.SetActive(false);
            collider.enabled = false;
        }
        #endregion
    }
}