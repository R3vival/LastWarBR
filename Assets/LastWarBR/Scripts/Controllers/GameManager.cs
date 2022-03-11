using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastWarBR
{
    public class GameManager : GenericSingleton<GameManager>
    {
        #region Declarations
        [SerializeField] private DB dataBase;
        public DB DataBase { get => dataBase; }

        //Actions
        public Action Initialize;
        public Action<GameObject, CharacterType> OnSpawn;
        public Action Interact;
        public Action UseAidKit;
        public Action Respawn;
        #endregion
        #region Unity Functions
        private void Start()
        {
            Init();
        }
        #endregion
        #region Functions
        private void Init()
        {
            FindReferences();

            Initialize?.Invoke();
        }
        private void FindReferences()
        {
            if(dataBase == null)
            {
                Debug.LogError("<color=#ff0000>WARNING - Data Base need to be setted at GameManager</color>");
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #endif
            }
        }
        #endregion
    }
}