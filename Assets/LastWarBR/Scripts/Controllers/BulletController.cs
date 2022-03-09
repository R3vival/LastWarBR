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

        Vector3 spawnPoint;

        public BulletView View => view;
        #endregion
        #region Unity Functions
        
        private void FixedUpdate()
        {
            if ( view.gameObject.activeSelf )
            {
                float distance = Vector3.Distance(spawnPoint,transform.position);

                transform.Translate(Vector3.forward * weaponUsed.BulletSpeed,Space.Self);
                if ( distance > weaponUsed.Range )
                {
                    Disable();
                }
            }
        }
        #endregion
        #region Functions
        public void Init(CharacterBase bulletOwner)
        {
            FindReferences(bulletOwner);

            this.tag = "Bullet";
            spawnPoint = transform.position;
            Disable();
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
        public void Enable(Transform spawnPoint)
        {
            transform.position = spawnPoint.position;
            transform.rotation = spawnPoint.rotation;

            this.spawnPoint = spawnPoint.position;
            view.gameObject.SetActive(true);
            collider.enabled = true;
        }
        private void Disable()
        {
            view.gameObject.SetActive(false);
            collider.enabled = false;

            transform.position = spawnPoint;
        }
        #endregion        
    }
}