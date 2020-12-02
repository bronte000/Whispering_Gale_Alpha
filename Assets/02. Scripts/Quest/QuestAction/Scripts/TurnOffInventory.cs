using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "QuestAction/OnOff/TurnOffInventory")]
public class TurnOffInventory : QuestAction
{
    public override bool ExecuteRole()
    {
        GameObject.Find("Inventory").SetActive(false);
        return true;
    }
}
