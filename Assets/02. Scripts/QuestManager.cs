using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest[] quests;

    private void Start()
    {
        foreach (Quest quest in quests)
        {
            quest.completed = false; // change this if&when you implement Save and Load
        }
    }

    public void StartQuest(int questNum)
    {
        //show the quest's objective on-screen
    }

    public void QuestCompleted(int questNum)
    {
        //function that's activated when the quest is finished (usually attached to specified object)
    }
}
