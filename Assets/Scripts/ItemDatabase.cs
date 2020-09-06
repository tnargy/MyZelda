using System.Collections.Generic;

public class ItemDatabase 
{
    public List<Item> items;

    public ItemDatabase()
    {
        BuildDatabase();
    }

    public Item GetItem(int id) => items.Find(item => item.id == id);
    public Item GetItem(string title) => items.Find(item => item.title == title);

    void BuildDatabase()
    {
        items = new List<Item>() {
            new Item(
                0, 
                "Wooden Sword",
                "Sprites/NES - The Legend of Zelda - Link",
                70,
                new Dictionary<string, int>
                {
                    {"Power", 5}
                }),
            new Item(
                1, 
                "Bomb",
                "Sprites/NES - The Legend of Zelda - Link",
                85,
                new Dictionary<string, int>
                {
                    {"Power", 10}
                }),
        };
    }    
}