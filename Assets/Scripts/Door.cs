using UnityEngine;

namespace GandyLabs.MyZelda
{
    public class Door : MonoBehaviour
    {
        public VectorValue playerPosition;
        public Vector2 loadPosition;
        public World savedWorldPosition;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                playerPosition.initValue = loadPosition;
                playerPosition.savedWorldPosition = savedWorldPosition;
                GameManager.Instance.LoadScene(savedWorldPosition.ToString());
            }
        }
    }
}