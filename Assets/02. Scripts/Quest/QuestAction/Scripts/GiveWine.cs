using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "QuestAction/UpperRoom/GiveWine")]
public class GiveWine : QuestAction
{
    public override bool ExecuteRole()
    {
        Inventory.instance.AddItem(0);
        return true;
    }
}

