using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

namespace GandyLabs.MyZelda
{
    public class PlayerController : MonoBehaviour
    {
        public InputAction moveAction;
        float moveSpeed;

        private void OnEnable()
        {
            moveAction.Enable();
        }

        private void OnDisable()
        {
            moveAction.Disable();
        }

        private void Update()
        {
            var move = moveAction.ReadValue<Vector2>();

            Move(move);
        }

        private void Move(Vector2 direction)
        {
            if (direction.sqrMagnitude < 0.01)
                return;
            var scaledMoveSpeed = moveSpeed * Time.deltaTime;
            // For simplicity's sake, we just keep movement in a single plane here. Rotate
            // direction according to world Y rotation of player.
            var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
            transform.position += move * scaledMoveSpeed;
        }
    }
}