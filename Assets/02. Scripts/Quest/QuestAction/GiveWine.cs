using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "QuestAction/UpperRoom/GiveWine")]
public class GiveWine : QuestAction
{
    public override bool ExecuteRole()
    {
        GameObject.Find("UI").GetComponent<Inventory>().enabled = true;
        GameObject.Find("Menu").GetComponent<Button>().interactable = true;
        Inventory.instance.AddItem(0);
        return true;
    }
}

