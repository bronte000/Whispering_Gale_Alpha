using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

    public List<Item> items = new List<Item>();

    void Awake()
    {
        instance = this;
    }

    void Add(string itemName, int itemValue, int itemPrice, string itemDesc, ItemType itemType)
    {
        Item item = new Item(itemName, itemValue, itemPrice, itemDesc, itemType,
            Resources.Load<Sprite>("ItemImages/" + itemName));
        items.Add(item);
    }
    // Start is called before the first frame update
    void Start()
    {
        Add("Apple", 1, 50, "Delicious Apple", ItemType.Food);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
