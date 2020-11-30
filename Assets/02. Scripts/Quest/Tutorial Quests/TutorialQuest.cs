using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialQuest : MonoBehaviour
{
    public GameObject tutorial;
    private int counter;

    void Start()
    {
        counter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if ((tutorial.GetComponent<QuestTrigger>().quest.hasStarted == true) && (counter == 1))
        {
            ActivateQuestCompletedFunc();
            counter -= 1;
        } 
    }

    void ActivateQuestCompletedFunc()
    {
        //Debug.Log("QuestCompleteActivated");
        tutorial.GetComponent<Button>().onClick.AddListener(QuestDone);
    }

    void QuestDone()
    {
        tutorial.GetComponent<QuestTrigger>().quest.nextAction.nextObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        tutorial.GetComponent<QuestTrigger>().quest.hasStarted = false;
        tutorial.GetComponent<Button>().onClick.RemoveListener(QuestDone);
        GameObject.Find("QuestInfo").GetComponent<QuestDisplay>().activeNum -= 1;
        GameObject.Find("QuestInfo").SetActive(false);
    }

}
