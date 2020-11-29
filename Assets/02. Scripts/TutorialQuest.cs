using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialQuest : MonoBehaviour
{
    public GameObject tutorial;

    // Update is called once per frame
    void Update()
    {
        if (tutorial.GetComponent<QuestTrigger>().quest.hasStarted == true)
            ActivateQuestCompletedFunc();
    }

    void ActivateQuestCompletedFunc()
    {
        Debug.Log("QuestCompleteActivated");
        tutorial.GetComponent<Button>().onClick.AddListener(QuestDone);
    }

    void QuestDone()
    {
        tutorial.GetComponent<QuestTrigger>().quest.nextAction.nextObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        tutorial.GetComponent<QuestTrigger>().quest.hasStarted = false;
    }

}
