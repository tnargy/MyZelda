using UnityEngine;

public class Door : MonoBehaviour
{
    public string SceneToLoad;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameManager.canChangeScene)
        {
            GameManager.canChangeScene = false;
            GameManager.Instance.LoadScene(SceneToLoad);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.canChangeScene = true;
        }
    }
}
