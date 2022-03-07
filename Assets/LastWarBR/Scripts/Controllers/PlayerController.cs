using System;
using System.Collections.Generic;
using UnityEngine;

namespace LastWarBR
{
    public class PlayerController : CharacterBase
    {
        #region Declarations
        [SerializeField] private PlayerView playerView;

        public Action IsMoving;
        #endregion
        #region Unity Functions
        #endregion
        #region Functions
        public void Init()
        {
            characterStats = GameManager.Instance.DataBase.GetPlayer();
            playerView.Init(this);
        }
        #endregion

    }
}