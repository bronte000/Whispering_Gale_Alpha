using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public GameObject questUI;

    public void StartQuest(QuestData quest)
    {
        //show the quest's objective on-screen
        //Debug.Log(quest.questNumber);
        quest.hasStarted = true;
        questUI.GetComponent<QuestDisplay>().activeNum += 1;
        ShowQuestInfo(quest);
    }

    void ShowQuestInfo(QuestData quest)
    {
      //  Debug.Log(quest.questName);
      //  Debug.Log(quest.questContent);
        questUI.GetComponent<QuestDisplay>().DisplayNewQuest(quest); //function that shows player the quest infos
    }

    //function that's activated when the quest is finished (usually attached to specified object)
    public void QuestCompleted(QuestData quest)
    {
        int i = quest.nextAction.nextActionCode;
        quest.hasStarted = false;
        questUI.GetComponent<QuestDisplay>().activeNum -= 1;
       // Debug.Log(quest.questNumber + "complete!");
        switch (i)
        {
            case 0: return;
            case 1: // load next scene
                SceneManager.LoadScene(quest.nextAction.nextSceneName);
                break;
            case 2: //start quest
                quest.nextAction.nextObject.GetComponent<QuestTrigger>().TriggerQuest();
                break;
            case 3://load dialogue
                quest.nextAction.nextObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                break;
        }
    }
}
