using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

    [SerializeField]
    private SlotToolTip theSlotToolTip;

    private void Awake()
    {
        instance = this;
    }

    public List<Item> itemDB = new List<Item>();

    private void Start()
    {
        Inventory.instance.setDB(itemDB);
    }

    public void ShowToolTip(Item _item, Vector3 _pos)
    {
        theSlotToolTip.ShowToolTip(_item, _pos);
    }

    public void HideToolTip()
    {
        theSlotToolTip.HideToolTip();
    }

}
