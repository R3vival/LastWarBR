using System;
using System.Collections.Generic;
using UnityEngine;

namespace LastWarBR
{
    public class PlaceController :MonoBehaviour
    {
        #region Declarations
        [SerializeField] private DoorController door;
        [SerializeField] private GameObject roof;

        [SerializeField] private bool isOpen;

        [Space] 
        [SerializeField] private Animator animator;

        public Action<bool> UnlockedDoor;
        #endregion
        #region Unity Functions
        private void Awake()
        {
            UnlockedDoor += OpenDoor;
            Init();
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                roof.SetActive(false);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if ( other.tag == "Player" )
            {
                roof.SetActive(true);
            }
        }
        #endregion
        #region Functions
        private void Init()
        {
            FindReferences();

            door.Init(this);
        }
        private void FindReferences()
        {
            if(door == null)
            {
                door = transform.Find("door").GetComponent<DoorController>();
            }
            if(roof == null )
            {
                roof = transform.Find("Roof").gameObject;
            }
            if(animator == null )
            {
                animator = GetComponent<Animator>();
            }
        }

        private void OpenDoor(bool isOpen)
        {
            this.isOpen = isOpen;            
            animator.SetBool("DoorOpened", true);
        }
        public void HideDoor()
        {
            door.gameObject.SetActive(false);
        }
        #endregion
    }
}