using System.Collections.Generic;
using UnityEngine;

namespace GandyLabs.MyZelda
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "MyZelda/Inventory", order = 0)]
    public class Inventory : ScriptableObject
    {
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase = new ItemDatabase();
    public Item itemA;
    public Item itemB;

    Item CheckForItems(int id) => characterItems.Find(item => item.id == id);
    public void AddItem(int id)
    {
        var item = itemDatabase.GetItem(id);
        item.SetImage();
        
        characterItems.Add(item);
        if (itemA == null)
        {
            itemA = item;
        }
        else if (itemB == null)
        {
            itemB = item;
        }
    }
    public void RemoveItem(int id)
    {
        Item item = CheckForItems(id);
        if (item != null)
        {
            if (itemA == item)
                itemA = null;
            if (itemB == item)
                itemB = null;
                
            characterItems.Remove(item);
        }
    }
}
}