using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int id;
    public string title;
    Sprite image;
    Dictionary<string, int> stats = new Dictionary<string, int>();

    public Item(int id, string title, string imagePath, int imageIndex, Dictionary<string, int> stats)
    {
        this.id = id;
        this.title = title;
        this.image = Resources.LoadAll<Sprite>(imagePath)[imageIndex];
        this.stats = stats;
    }
    
    public Item(Item item)
    {
        this.id = item.id;
        this.title = item.title;
        this.image = item.image;
        this.stats = item.stats;
    }
}