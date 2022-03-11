using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastWarBR
{
    public class SpawnController :MonoBehaviour
    {
        #region Declarations
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private GameObject enemyPrefab;
        private PlayerController spawnedPlayer;

        private CharacterStats player;
        private CharacterStats[] enemys;

        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private Transform[] enemySpawnPoints;

        private Queue<EnemyController> poolEnemys = new Queue<EnemyController>();
        public List<EnemyController> EnemysCreated => enemysCreated;

        private List<EnemyController> enemysCreated = new List<EnemyController>();

        [Space]
        [SerializeField] private float spawnRate = 300f;
        [SerializeField] private float spawnTimer = 0;
        private DB DataBase;
        #endregion
        #region Unity Functions
        private void Awake()
        {
            GameManager.Instance.Initialize += Init;
            GameManager.Instance.Respawn += Respawn;

        }
        private void OnDisable()
        {
            GameManager.Instance.Initialize -= Init;
            GameManager.Instance.Respawn -= Respawn;
        }

        private void FixedUpdate()
        {
            spawnTimer += Time.deltaTime;

            if ( spawnTimer >= spawnRate )
            {
                SpawnCharacter(CharacterType.Enemy,GetRandomSpawnPoint());
                spawnTimer = 0;
            }
        }
        #endregion
        #region Functions
        private void Init()
        {
            DataBase = GameManager.Instance.DataBase;
            player = DataBase.GetPlayer();
            enemys = DataBase.GetAllEnemys();

            SpawnCharacter(CharacterType.Player);
        }
        private void SpawnCharacter(CharacterType type,Transform spawnPoint = null)
        {
            GameObject spawnedCharacter = null;
            switch ( type )
            {
                default:
                case CharacterType.Player:
                    spawnedCharacter = Instantiate(playerPrefab,playerSpawnPoint.position,playerSpawnPoint.rotation);

                    DataBase.Player.health = DataBase.Player.maxHealth;

                    spawnedCharacter.name = "Player_" + DataBase.Player.characterName;
                    spawnedCharacter.tag = "Player";
                    spawnedPlayer = spawnedCharacter.GetComponent<PlayerController>();


                    spawnedPlayer.CharacterStats = GameManager.Instance.DataBase.GetPlayer();

                    spawnedPlayer.Init();
                    break;
                case CharacterType.Enemy:

                    spawnedCharacter = GetEnemyFromPool().gameObject;

                    spawnedCharacter.transform.position = spawnPoint.position;
                    spawnedCharacter.transform.rotation = spawnPoint.rotation;
                    break;
                case CharacterType.NPC:
                    break;
            }
            GameManager.Instance.OnSpawn?.Invoke(spawnedCharacter,type);
        }
        private Transform GetRandomSpawnPoint()
        {
            return enemySpawnPoints[Random.Range(0,enemySpawnPoints.Length)];
        }
        private void Respawn()
        {
            spawnedPlayer.Respawn(playerSpawnPoint);
            spawnedPlayer.Init();
        }

        private void CreateEnemy()
        {
            EnemyController spawnedCharacter;

            spawnedCharacter = Instantiate(enemyPrefab).GetComponent<EnemyController>();

            int enemyIndex = 0;
            if ( GameManager.Instance.DataBase.Enemys.Length > 0 )
            {
                enemyIndex = Random.Range(0,GameManager.Instance.DataBase.Enemys.Length);
            }


            DataBase.Enemys[enemyIndex].health = DataBase.Enemys[enemyIndex].maxHealth;

            spawnedCharacter.CharacterStats = DataBase.Enemys[enemyIndex];

            spawnedCharacter.name = "Enemy" + DataBase.Enemys[enemyIndex].characterName;
            spawnedCharacter.tag = "Enemy";
            spawnedCharacter.Init();

            poolEnemys.Enqueue(spawnedCharacter);
            enemysCreated.Add(spawnedCharacter);
        }
        private void EnqueueBullets()
        {
            foreach ( EnemyController enemy in enemysCreated )
            {
                if ( !enemy.enemyView.gameObject.activeSelf )
                {
                    poolEnemys.Enqueue(enemy);
                }
            }
        }
        private EnemyController GetEnemyFromPool()
        {
            if ( poolEnemys.Count <= 0 )
            {
                CreateEnemy();
            }
            return poolEnemys.Dequeue();
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