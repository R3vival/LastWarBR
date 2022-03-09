using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastWarBR
{
    public class WeaponController :MonoBehaviour
    {
        #region Declarations
        [SerializeField] private MeshRenderer renderer;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform shootPoint;

        private Queue<BulletController> poolBullets = new Queue<BulletController>();
        public List<BulletController> BulletsCreated => bulletsCreated;

        private List<BulletController> bulletsCreated = new List<BulletController>();

        [SerializeField] private CharacterBase gunner;
        private Weapon weapon;
        private bool canShoot, shoot;
        private float weaponCd;
        #endregion
        #region Unity Functions
        private void Awake()
        {
            GameManager.Instance.OnSpawn += Init;
        }
        private void FixedUpdate()
        {
            EnqueueBullets();

            if ( !canShoot )
            {
                weaponCd += Time.deltaTime;
                if ( weaponCd > weapon.Coldown)
                {
                    canShoot = true;
                    shoot = false;

                }
            }
            if(shoot)
            {
                canShoot = false;
            }
        }
        #endregion
        #region Functions
        private void Init(GameObject go,CharacterType type)
        {
            CharacterBase character = go.GetComponent<CharacterBase>();

            FindReferences();

            gunner = character;
            this.weapon = character.GetSelectedObject() as Weapon;

            renderer.material = weapon.Mat;
            for (int i = 0; i< 10; i++ )
            {
                CreateBullet();
            }
            character.Shooting += Shoot;
            canShoot = true;
        }
        private void FindReferences()
        {
            if ( renderer == null )
            {
                renderer = GetComponent<MeshRenderer>();
            }
            if ( shootPoint == null )
            {
                shootPoint = transform.Find("ShootPoint");
            }
            if ( bulletPrefab == null )
            {
                Debug.LogError("WEAPON - Needs a bullet Prefab");
            }
        }
        private BulletController CreateBullet()
        {
            BulletController newBullet;

            newBullet = Instantiate(bulletPrefab, shootPoint.position,shootPoint.rotation).GetComponent<BulletController>();
            newBullet.Init(gunner);

            poolBullets.Enqueue(newBullet);
            bulletsCreated.Add(newBullet);
            return newBullet;
        }
        private void Shoot(int blend)
        {
            if (!canShoot )
            {
                return;
            }
            BulletController temp =  GetFromBulletPool();           

            temp.Enable(shootPoint);
            shoot = true;
        }
        private void EnqueueBullets()
        {
            foreach(BulletController bullet in bulletsCreated )
            {
                if ( !bullet.View.gameObject.activeSelf )
                {
                    poolBullets.Enqueue(bullet);
                }
            }
        }
        private BulletController GetFromBulletPool()
        {
            BulletController response;
            if(poolBullets.Count <= 0 )
            {
                CreateBullet();
            }
            return poolBullets.Dequeue();
        }
        #endregion
    }
}