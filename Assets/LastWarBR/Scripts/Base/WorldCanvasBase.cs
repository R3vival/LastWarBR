using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastWarBR
{
    public class WorldCanvasBase :MonoBehaviour
    {
        #region Declarations
        [Header("Base Fields")]
        [SerializeField] protected Camera mainCamera;
        [SerializeField] protected Canvas HUDCanvas;
        #endregion
        #region Unity Functions
        /// <summary>
        /// We initialize this behaviour at Start because it instantiate
        /// before all the gameplay initialize
        /// </summary>
        private void Awake()
        {
            Init();
        }
        /// <summary>
        /// Set the canvas transform position and rotation to perma look at the main Camera
        /// </summary>
        private void LateUpdate()
        {
            this.transform.LookAt(mainCamera.transform);
            transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward);
        }
        #endregion
        #region Functions
        /// <summary>
        /// Initialize the components required for the canvas look at the main camera
        /// </summary>
        protected virtual void Init()
        {
            FindReferences();

            HUDCanvas.worldCamera = mainCamera;
        }
        /// <summary>
        /// Find the references of the items used of The canvas look at main camera
        /// </summary>
        protected virtual void FindReferences()
        {
            if ( mainCamera == null )
            {
                mainCamera = Camera.main;
            }
            if ( HUDCanvas == null )
            {
                HUDCanvas = transform.GetComponent<Canvas>();
            }
        }
        #endregion
    }
}
