using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "QuestAction/UpperRoom/RoomDialogue2")]
public class RoomDialogue2 : QuestAction
{
    public override bool ExecuteRole()
    {
        GameObject dialogue2 = GameObject.Find("DialogueManager").transform.GetChild(1).gameObject;
        dialogue2.SetActive(true);
        dialogue2.GetComponent<DialogueTrigger>().TriggerDialogue();
        return true;
    }
}
