using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "QuestAction/OnOff/TurnOffMoving")]
public class TurnOffMoving : QuestAction
{
    public override bool ExecuteRole()
    {
        GameObject.Find("Louis").GetComponent<Louis_Controller>().enabled = false;
        return true;
    }
}