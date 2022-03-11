using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastWarBR
{
    public class EnemyController :CharacterBase
    {
        #region Declarations
        [SerializeField] public CharacterView enemyView;

        [Header("Enemy Variables")]
        [SerializeField] private float range;
        [SerializeField] private bool playerFound;

        private float shootMovSpeed;
        private float shoot;
        #endregion
        #region Unity Functions

        private void FixedUpdate()
        {
            if ( !playerFound )
            {
                Idle();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if ( other.tag == "Player" )
            {
                Rage(other.transform);
            }
        }
        #endregion
        #region Functions
        public void Init()
        {
            shootMovSpeed = characterStats.moveSpeed * 0.25f;
            base.Init();
            enemyView.Init(this);
        }
        private void Die()
        {

        }
        private void Idle()
        {

        }
        private void Rage(Transform target)
        {
            Follow(target);
            Attack(target);
        }
        private void Follow(Transform target)
        {
            Vector3 movement = new Vector3(target.position.x,0f,target.position.y);
            movement.Normalize();

            //Movement
            float currentSpeed = characterStats.moveSpeed;
            if ( shoot > 0 )
            {
                currentSpeed = shootMovSpeed;
            }

            rigidBody.transform.Translate(movement * currentSpeed * Time.deltaTime,Space.World);

            //Rotation
            if ( movement != Vector3.zero )
            {
                Quaternion newRotation = Quaternion.LookRotation(movement,Vector3.up);

                rigidBody.transform.rotation = Quaternion.RotateTowards(
                    rigidBody.transform.rotation,
                    newRotation,
                    (characterStats.turnSpeed * 100) * Time.deltaTime);
            }
        }
        private void Attack(Transform target)
        {

        }
        #endregion
    }
}
