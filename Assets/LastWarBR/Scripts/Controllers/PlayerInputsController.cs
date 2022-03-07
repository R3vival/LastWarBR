using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LastWarBR{
    public class PlayerInputsController : MonoBehaviour
    {
        #region Declarations
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private float speed = 20f;
        [SerializeField] private float rotationSpeed = 600f;
        [SerializeField] private bool canMove;
        private float movementY;
        private float movementX;

        public Action IsMovinG;
        #endregion
        #region Unity Functions
        private void Awake()
        {
            GameManager.Instance.OnSpawn += Init;
        }
        private void FixedUpdate()
        {
            if (canMove)
            {
                ProcessInputs();

                Vector3 movement = new Vector3(movementX, 0f, movementY);
                movement.Normalize();
                //Movement
                rigidbody.transform.Translate(movement * speed * Time.deltaTime, Space.World);

                //Rotation
                if(movement != Vector3.zero)
                {
                    Quaternion newRotation = Quaternion.LookRotation(movement, Vector3.up);

                    rigidbody.transform.rotation = Quaternion.RotateTowards(
                        rigidbody.transform.rotation,
                        newRotation,
                        rotationSpeed * Time.deltaTime);


                }
            }
        }       
        #endregion
        #region Functions
        private void Init(GameObject spawnedCharacter, CharacterType type)
        {
            if (type != CharacterType.Player)
            {
                return;
            }
            FindReferences(spawnedCharacter);
            if(rigidbody != null)
                canMove = true;
        }

        private void FindReferences(GameObject player)
        {
            rigidbody = player.GetComponent<Rigidbody>();
        }
        private void ProcessInputs()
        {

            movementX = Input.GetAxis("Horizontal");
            movementY = Input.GetAxis("Vertical");
        }
        #endregion
    }
}