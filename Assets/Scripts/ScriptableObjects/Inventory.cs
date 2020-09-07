using System.Collections.Generic;
using UnityEngine;

namespace GandyLabs.MyZelda
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "MyZelda/Inventory", order = 0)]
    public class Inventory : ScriptableObject
    {
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase = new ItemDatabase();

    Item CheckForItems(int id) => characterItems.Find(item => item.id == id);
    public void AddItem(int id) => characterItems.Add(itemDatabase.GetItem(id));
    public void RemoveItem(int id)
    {
        Item item = CheckForItems(id);
        if (item != null)
        {
            characterItems.Remove(item);
        }
    }
}
}