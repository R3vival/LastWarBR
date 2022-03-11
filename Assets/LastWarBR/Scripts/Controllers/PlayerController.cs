using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LastWarBR
{
    public class PlayerController : CharacterBase
    {
        #region Declarations
        [SerializeField] private CharacterView playerView;

        #endregion
        #region Unity Functions
        private void Start()
        {
            GameManager.Instance.UseAidKit -= Heal;
            GameManager.Instance.UseAidKit += Heal;

            LoseHealth += GetDamage;
        }
        #endregion
        #region Functions
        public void Init()
        {
            base.Init();
            playerView.Init(this);
        }

        private void Heal()
        {
            AidKit aidKit = (AidKit)characterStats.inventory.FirstOrDefault(x => x.Type == ObjectType.AidKit);
            HealPlayer(aidKit.PointsHealed);

            GameManager.Instance.DataBase.UseObject(aidKit);

            playerView.UpdateHealth(aidKit.PointsHealed);
        }
        private void GetDamage(short damage)
        {
            playerView.UpdateHealth(characterStats.health);
        }
        #endregion
    }
}