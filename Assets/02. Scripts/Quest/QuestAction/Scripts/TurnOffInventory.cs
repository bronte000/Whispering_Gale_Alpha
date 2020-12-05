using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "QuestAction/OnOff/TurnOffInventory")]
public class TurnOffInventory : QuestAction
{
    public override bool ExecuteRole()
    {
        GameObject inventory = GameObject.Find("Inventory");
        if (inventory) inventory.SetActive(false);
        return true;
    }
}
