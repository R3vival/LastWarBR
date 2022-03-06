using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastWarBR
{
    public class SpawnController : MonoBehaviour
    {
        #region Declarations
        [SerializeField] private GameObject playerPrefab;
        private PlayerController spawnedPlayer;
        

        private CharacterStats player;
        private CharacterStats[] enemys;

        [SerializeField] private Transform spawnPoint;
        private DB DataBase;
        #endregion
        #region Unity Functions
        private void Awake()
        {
            GameManager.Instance.Initialize += Init;
        }
        private void OnDisable()
        {
            GameManager.Instance.Initialize -= Init;
        }
        #endregion
        #region Functions
        private void Init()
        {
            DataBase = GameManager.Instance.DataBase;
            player = DataBase.GetPlayer();
            enemys = DataBase.GetAllEnemys();

            SpawnPlayer(CharacterType.Player);
        }
        private void SpawnPlayer(CharacterType type)
        {
            GameObject spawnedCharacter = null;
            switch (type)
            {
                default:
                case CharacterType.Player:
                    spawnedCharacter = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);

                    spawnedCharacter.name = "Player_" + DataBase.Player.playerName;
                    spawnedCharacter.tag = "Player";
                    spawnedPlayer = spawnedCharacter.transform.Find("Controller").GetComponent<PlayerController>();
                    spawnedPlayer.Init();
                    break;
                case CharacterType.Enemy:
                    break;
                case CharacterType.NPC:
                    break;
            }
            GameManager.Instance.OnSpawn?.Invoke(spawnedCharacter,type);
        }
        private void Respawn()
        {
            spawnedPlayer.Respawn(spawnPoint);
        }
        #endregion
    }
    public enum CharacterType
    {
        Player,
        Enemy,
        NPC
    }
}