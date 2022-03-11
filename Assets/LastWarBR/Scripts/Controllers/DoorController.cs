using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastWarBR
{
    public class DoorController :MonoBehaviour
    {
        #region Declarations
        [SerializeField] private InteractCanvasView interactCanvas;
        PlaceController place;

        [SerializeField] bool isInteracting = false;

        #endregion
        #region Unity Functions
        private void Start()
        {
            GameManager.Instance.Interact -= OpenDoor;
            GameManager.Instance.Interact += OpenDoor;
        }
        /// <summary>
        /// Show the Interact canvas message
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            if ( other.tag == "Player" )
            {
                ShowMessage();
            }
        }
        /// <summary>
        /// Set the isinteracting bool to know which door has to be opened
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerStay(Collider other)
        {
            if ( other.tag == "Player" )
            {
                isInteracting = true;
            }
        }
        /// <summary>
        /// Hide the interactCanvas message
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerExit(Collider other)
        {
            if ( other.tag == "Player" )
            {
                HideMessage();
                isInteracting = false;
            }
        }
        #endregion
        #region Functions
        /// <summary>
        /// Initialize finding the components needed for the correct functionality
        /// </summary>
        /// <param name="place"></param>
        public void Init(PlaceController place)
        {
            this.place = place;
            if ( interactCanvas == null )
            {
                interactCanvas = transform.Find("InteractCanvas").GetComponent<InteractCanvasView>();
            }
        }
        /// <summary>
        /// Called when the user use interaction Btn
        /// call the open door anim 
        /// spend a user key
        /// hide the interaction message
        /// </summary>
        private void OpenDoor()
        {
            if ( !isInteracting )
            {
                return;
            }
            HideMessage();

            Object key = GameManager.Instance.DataBase.GetKey();
            if ( key != null )
            {
                GameManager.Instance.DataBase.UseObject(key);
                place.UnlockedDoor?.Invoke();
            }
        }
        /// <summary>
        /// Show the interaction message
        /// </summary>
        private void ShowMessage()
        {
            interactCanvas.ShowMessage();
        }
        /// <summary>
        /// Hide the interaction message
        /// </summary>
        private void HideMessage()
        {
            interactCanvas.HideMessage();
        }
        #endregion
    }
}
