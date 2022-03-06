using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace LastWarBR{
    public class PlayerInputsController : MonoBehaviour
    {
        #region Declarations
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private float speed;
        [SerializeField] private bool canMove;
        private float movementY;
        private float movementX;
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
                Vector3 movement = new Vector3(movementX, 0f, movementY);
                rigidbody.AddForce(movement * speed);
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
        }

        private void FindReferences(GameObject player)
        {
            rigidbody = player.GetComponent<Rigidbody>();
        }
        private void OnMove(InputValue inputValue)
        {
            Vector2 movementVector = inputValue.Get<Vector2>();

            movementX = movementVector.x;
            movementY = movementVector.y;
        }
        #endregion
    }
}