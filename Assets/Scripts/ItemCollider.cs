using UnityEngine;

namespace GandyLabs.MyZelda
{
    public class ItemCollider : MonoBehaviour
{
    public int ItemID;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            float delay = 2.5f;
            GameManager.Instance.SendMessage("Pause", delay);
            transform.SetParent(other.transform);
            transform.position += new Vector3(-.06f, 0, 0);
            other.GetComponent<PlayerController>().characterInventory.AddItem(ItemID);
            Destroy(gameObject, delay);
            other.SendMessage("CollectItem");
        }
    }
}
}