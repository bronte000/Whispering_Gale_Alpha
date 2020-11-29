using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    /*
    public int questId;

    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("tutorial quest", new int[] { }));
    }

    public int GetQuestTalkIndex(int npcId)
    {
        return questId;
    }
    */

    public void StartQuest(QuestData quest)
    {
        //show the quest's objective on-screen
        Debug.Log(quest.questNumber);
        Debug.Log("Get the bottle of wine from Louis's inventory!");
        quest.hasStarted = true;
    }

    //function that's activated when the quest is finished (usually attached to specified object)
    public void QuestCompleted(QuestData quest)
    {
        int i = quest.nextAction.nextActionCode;
        quest.hasStarted = false;
        Debug.Log(quest.questNumber + "complete!");
        if (i == 0)
            return;
        else if (i == 1) //load next scene
            SceneManager.LoadScene(quest.nextAction.nextSceneName);
        else if (i == 2) //start quest
            quest.nextAction.nextObject.GetComponent<QuestTrigger>().TriggerQuest();
        //FindObjectOfType<QuestManager>().StartQuest(quest.nextAction.nextQuestNum);
        else if (i == 3)
            quest.nextAction.nextObject.GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}
