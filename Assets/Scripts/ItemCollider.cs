using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            transform.SetParent(other.transform, false);
            Debug.Log("CollectedItem");
        }
    }
}
