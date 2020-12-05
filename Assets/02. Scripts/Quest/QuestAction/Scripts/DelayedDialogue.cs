using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "QuestAction/DelayedDialogue")]
public class DelayedDialogue : QuestAction
{
    public int dialogueNum;
    public int time;
    public override bool ExecuteRole()
    {
        delay(time);
        return true;
    }

    private IEnumerator delay(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject dialogue = GameObject.Find("DialogueManager").transform.GetChild(dialogueNum).gameObject;
        dialogue.SetActive(true);
        dialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
    }

}
