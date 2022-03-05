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
        #endregion
        #region Unity Functions
        private void Awake()
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