using UnityEngine;
using UnityEngine.UI;

namespace GandyLabs.MyZelda
{   
    public class InterfaceManager : MonoBehaviour
    {
        public Inventory playerInventory;
        public GameObject itemAObj;
        public GameObject itemBObj;
        Sprite itemA;
        Sprite itemB;

        private void Awake() {
            itemA = itemAObj.GetComponent<Image>().sprite;
            itemB = itemBObj.GetComponent<Image>().sprite;
        }

        private void Update() {
            if (playerInventory.itemA != null)
                itemA = playerInventory.itemA.image;
            if (playerInventory.itemB != null)
                itemB = playerInventory.itemB.image;
        }
    }

}