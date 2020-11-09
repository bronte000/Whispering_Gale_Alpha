using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Slot[] slots;
    public Transform slotHolder;

    private void Start()
    {
        slots = slotHolder.GetComponentsInChildren<Slot>();
        print(slots.Length);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject.Find("Menu").GetComponent<Louis_Menu>().Click_Bag_Button();
        }
    }
}
