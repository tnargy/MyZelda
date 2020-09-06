using System.Collections.Generic;
using UnityEngine;

namespace GandyLabs.MyZelda
{
    public class Inventory : MonoBehaviour
    {
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;

     private void Awake()
    {
        itemDatabase = new ItemDatabase();
    }

    Item CheckForItems(int id) => characterItems.Find(item => item.id == id);
    public void AddItem(int id) => characterItems.Add(itemDatabase.GetItem(id));
    public void RemoteItem(int id)
    {
        Item item = CheckForItems(id);
        if (item != null)
        {
            characterItems.Remove(item);
        }
    }
}
}