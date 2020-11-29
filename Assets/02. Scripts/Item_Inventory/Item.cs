using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Food,
    Etc
}

[System.Serializable]
public class Item
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;
    public List<ItemEffect> efts;

    [TextArea(3, 30)]
    public string describe;

    public bool Use()
    {
        bool isUsed = true;
        foreach(ItemEffect eft in efts)
        {
            isUsed = isUsed && eft.ExecuteRole();
        }
        return isUsed;
    }
}
