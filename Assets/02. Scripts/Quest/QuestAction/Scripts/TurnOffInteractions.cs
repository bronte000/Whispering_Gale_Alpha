using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "QuestAction/OnOff/TurnOffInteractions")]
public class TurnOffInteractions : QuestAction
{
    public override bool ExecuteRole()
    {
        GameObject.Find("Louis").GetComponent<Louis_Interaction>().enabled = false;
        return true;
    }
}