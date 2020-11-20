using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Slot[] slots;
    public Transform slotHolder;
    public List<Item> items = new List<Item>();

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    private void Start()
    {
        slots = slotHolder.GetComponentsInChildren<Slot>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject.Find("Menu").GetComponent<Louis_Menu>().Click_Bag_Button();
        }
    }

    public bool AddItem(Item item)
    {
        if(items.Count < 20)
        {
            items.Add(item);
            slots[items.Count - 1].UpdateSlot(item);
            return true;
        }
        return false;
    }
    
}
