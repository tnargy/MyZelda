using UnityEngine;

namespace GandyLabs.MyZelda
{
    public class PlayerController : MonoBehaviour
    {
        PlayerControls playerControls;
        Animator animator;
        float moveSpeed = 1;
        Vector2 lastDirection;

        private void Awake()
        {
            playerControls = new PlayerControls();
            animator = GetComponentInChildren<Animator>();
            lastDirection = new Vector2(0, 1);

            playerControls.Basic.AttackA.performed += _ => { Attack("A"); };
            playerControls.Basic.AttackB.performed += _ => { Attack("B"); };
        }

        private void Attack(string button)
        {
            Debug.Log($"Attacked with {button}");
        }

        private void OnEnable()
        {
            playerControls.Enable();
        }

        private void OnDisable()
        {
            playerControls.Disable();
        }

        private void Update()
        {
            var direction = playerControls.Basic.Move.ReadValue<Vector2>();

            Move(direction);
        }

        private void Move(Vector2 direction)
        {
            if (direction.sqrMagnitude > 0.01f)
            {
                var scaledMoveSpeed = moveSpeed * Time.deltaTime;
                var move = new Vector3(direction.x, direction.y, 0);
                transform.position += move * scaledMoveSpeed;
                lastDirection = direction;
            }

            animator.SetFloat("Horizontal", lastDirection.x);
            animator.SetFloat("Vertical", lastDirection.y);
            animator.SetFloat("Speed", direction.sqrMagnitude);
        }
    }
}