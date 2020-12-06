using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuestAction/Quest11/JohnExit")]
public class Q11_JohnExit : QuestAction
{
    public GameObject john;
    public DialogueTrigger dialogue5;

    public override bool ExecuteRole()
    {
        // John walks away

        // Execute Dialogue5
        dialogue5.TriggerDialogue();

        return true;
    }
}
