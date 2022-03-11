using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace LastWarBR
{
    public class InteractCanvasView : WorldCanvasBase
    {
        #region Declarations
        [SerializeField] private TMP_Text interactTextLabel;
        [Header("Info Shot At Pc Build")]
        [SerializeField] private string pcBuildText;
        [Header("Info Shot At Android Build")]
        [SerializeField] private string androidBuildText;
        #endregion
        #region Unity Functions
        #endregion
        #region Functions      
        /// <summary>
        /// Instantiate the view 
        /// Set the text depends of platform
        /// Disable the Texto to show it when the user is step in front of the object to interact
        /// </summary>
        
        protected override void Init()
        {
            base.Init();
#if PLATFORM_STANDALONE || UNITY_EDITOR
            interactTextLabel.text = pcBuildText;
#endif
#if UNITY_ANDROID
            interactTextLabel.text = androidBuildText;
#endif

            interactTextLabel.gameObject.SetActive(false);
        }
        protected override void FindReferences()
        {
            base.FindReferences();

            interactTextLabel = HUDCanvas.transform.Find("InteractTextLabel").GetComponent<TMP_Text>();
        }
        public void ShowMessage()
        {
            interactTextLabel.gameObject.SetActive(true);
        }
        public void HideMessage()
        {
            interactTextLabel.gameObject.SetActive(false);
        }
        public void DisableInteractView()
        {
            gameObject.SetActive(false);
        }
        #endregion
    }
}
