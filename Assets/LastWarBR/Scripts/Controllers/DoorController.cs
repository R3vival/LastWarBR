using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastWarBR
{
    public class DoorController :MonoBehaviour
    {
        #region Declarations
        PlaceController place;
        #endregion
        #region Unity Functions
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                OpenDoor(true);
            }
        }
        #endregion
        #region Functions
        public void Init(PlaceController place)
        {
            this.place = place;
        }
        private void OpenDoor(bool isOpen)
        {
            place.UnlockedDoor?.Invoke(isOpen);
        }
        #endregion
    }
}
