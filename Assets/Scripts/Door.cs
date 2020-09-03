using UnityEngine;

public class Door : MonoBehaviour
{
    public string SceneToLoad;
    public Vector2 spawnLocation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.LoadScene(SceneToLoad, spawnLocation);
        }
    }
}
