using UnityEngine;

namespace GandyLabs.MyZelda
{
    public class PlayerController : MonoBehaviour
    {
        PlayerControls playerControls;
        Animator animator;
        float moveSpeed = 1;
        Vector2 lastDirection;
        public VectorValue startingPosition;

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

        private void OnEnable() => playerControls.Enable();
        private void OnDisable() => playerControls.Disable();

        private void Start() {
            if (startingPosition.initValue != Vector3.zero)
                transform.position = startingPosition.initValue;
        }

        private void Update()
        {
            var direction = playerControls.Basic.Move.ReadValue<Vector2>();
            if (!GameManager.Instance.isPaused)
                Move(direction);
        }

        private void LateUpdate() {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

            Vector3 moveCamX = new Vector3(2.6f, 0, 0);
            Vector3 moveCamY = new Vector3(0, 1.75f, 0);
            if(pos.x < 0.0) Camera.main.transform.position -= moveCamX;
            if(1.0 < pos.x) Camera.main.transform.position += moveCamX;
            if(pos.y < 0.0) Camera.main.transform.position -= moveCamY;
            if(0.9 < pos.y) Camera.main.transform.position += moveCamY;
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

        private void CollectItem()
        {
            animator.Play("CollectItem");
        }
    }
}