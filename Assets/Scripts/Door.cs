using UnityEngine;

namespace GandyLabs.MyZelda
{
    public class Door : MonoBehaviour
    {
        public VectorValue playerPosition;
        public Vector2 loadPosition;

        public string SceneToLoad;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                playerPosition.initValue = loadPosition;
                GameManager.Instance.LoadScene(SceneToLoad);
            }
        }
    }
}