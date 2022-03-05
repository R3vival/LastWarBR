using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastWarBR
{
    public class PlayerInfoCanvasController : MonoBehaviour
    {
        #region Declarations
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Canvas HUDCanvas;
        #endregion
        #region Unity Functions
        private void Awake()
        {
            Init();
        }
        private void LateUpdate()
        {
            this.transform.LookAt(mainCamera.transform);
            transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward);
        }
        #endregion
        #region Functions
        private void Init()
        {
            FindReferences();

            HUDCanvas.worldCamera = mainCamera;
        }
        private void FindReferences()
        {
            if(mainCamera == null)
            {
                mainCamera = Camera.main;
            }
            if (HUDCanvas == null)
            {
                HUDCanvas = transform.GetComponent<Canvas>();
            }
        }
        #endregion
    }
}