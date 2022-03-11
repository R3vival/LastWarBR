using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LastWarBR{
    public class PlayerInputsController : MonoBehaviour
    {
        #region Declarations
        [SerializeField] private PlayerController player;
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private float speed = 20f;
        [SerializeField] private float rotationSpeed = 600f;
        [SerializeField] private bool canMove;
            
        private float shoot;
        private float movementY;
        private float movementX;
        private bool useObject;
        private bool useAidKit;
        private float shootMovSpeed;
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
#if PLATFORM_STANDALONE || UNITY_EDITOR
                ProcessInputsPC();
#endif
#if UNITY_ANDROID
                ProcessInputsMovile();
#endif

                Vector3 movement = new Vector3(movementX, 0f, movementY);
                movement.Normalize();

                //Movement
                float currentSpeed = speed;
                if (shoot > 0)
                {
                    currentSpeed = shootMovSpeed;
                }

                rigidbody.transform.Translate(movement * currentSpeed * Time.deltaTime, Space.World);

                //Rotation
                if(movement != Vector3.zero)
                {
                    Quaternion newRotation = Quaternion.LookRotation(movement, Vector3.up);

                    rigidbody.transform.rotation = Quaternion.RotateTowards(
                        rigidbody.transform.rotation,
                        newRotation,
                        rotationSpeed * Time.deltaTime);

                    player.IsMoving?.Invoke(0);
                }
                else
                {
                    player.IsNotMoving?.Invoke();
                }

                if ( useObject )
                {
                    GameManager.Instance.Interact?.Invoke();
                }

                if ( useAidKit )
                {
                    GameManager.Instance.UseAidKit?.Invoke();
                }

                if(shoot > 0)
                {
                    player.Shooting?.Invoke(1);
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
            {
                canMove = true;
            }
            shootMovSpeed = speed * 0.5f;
        }

        private void FindReferences(GameObject player)
        {
            this.player = player.GetComponent<PlayerController>();
            rigidbody = player.GetComponent<Rigidbody>();
        }
        private void ProcessInputsPC()
        {
            movementX = Input.GetAxis("Horizontal");
            movementY = Input.GetAxis("Vertical");

            shoot = Input.GetAxis("Fire1");
            useObject = Input.GetKey(KeyCode.E);
            useAidKit = Input.GetKey(KeyCode.Q);
        }
        private void ProcessInputsMovile()
        {

        }
#endregion
    }
}