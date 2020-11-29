using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Slot : MonoBehaviour, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int slotnum;
    public Image itemIcon;
    public Item item;

    public void UpdateSlot(Item _item)
    {
        itemIcon.sprite = _item.itemImage;
        item = _item;
        itemIcon.gameObject.SetActive(true);
    }

    public void RemoveSlot()
    {
        itemIcon.sprite = null;
        item = null;
        itemIcon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (item != null)
        {
            bool isUse = item.Use();
            if (isUse)
            {
                Inventory.instance.RemoveItem(slotnum);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Entered");
        if (item  != null)
        {
            ItemDatabase.instance.ShowToolTip(item, transform.position);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ItemDatabase.instance.HideToolTip();
    }
}
