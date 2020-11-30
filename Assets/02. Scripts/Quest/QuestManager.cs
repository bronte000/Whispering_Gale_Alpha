using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public GameObject questWindow;

    public void StartQuest(QuestData quest)
    {
        //show the quest's objective on-screen
        //Debug.Log(quest.questNumber);
        quest.hasStarted = true;
        questWindow.GetComponent<QuestDisplay>().activeNum += 1;
        ShowQuestInfo(quest);
    }

    void ShowQuestInfo(QuestData quest)
    {
        Debug.Log(quest.questName);
        Debug.Log(quest.questContent);
        questWindow.GetComponent<QuestDisplay>().DisplayQuest(); //function that shows player the quest infos
    }

    //function that's activated when the quest is finished (usually attached to specified object)
    public void QuestCompleted(QuestData quest)
    {
        int i = quest.nextAction.nextActionCode;
        quest.hasStarted = false;
        questWindow.GetComponent<QuestDisplay>().activeNum -= 1;
        Debug.Log(quest.questNumber + "complete!");
        if (i == 0)
            return;
        else if (i == 1) //load next scene
            SceneManager.LoadScene(quest.nextAction.nextSceneName);
        else if (i == 2) //start quest
            quest.nextAction.nextObject.GetComponent<QuestTrigger>().TriggerQuest();
        //FindObjectOfType<QuestManager>().StartQuest(quest.nextAction.nextQuestNum);
        else if (i == 3) //load dialogue
            quest.nextAction.nextObject.GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}
