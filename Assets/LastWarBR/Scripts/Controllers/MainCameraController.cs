using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastWarBR
{
    public class MainCameraController :MonoBehaviour
    {
        #region Declarations 
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        #endregion
        #region Unity Functions
        private void Awake()
        {
            GameManager.Instance.OnSpawn -= Init;
            GameManager.Instance.OnSpawn += Init;
        }
        #endregion
        #region Functions
        private void Init(GameObject playerGo,CharacterType type)
        {
            FindReferences();

            if ( type != CharacterType.Player )
            {
                return;
            }

            virtualCamera.Follow = playerGo.transform;
            virtualCamera.LookAt = playerGo.transform;
        }
        private void FindReferences()
        {
            virtualCamera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        }
        #endregion
    }
}