using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    public QuestData quest;
    public GameObject questCertificate; //GameObject with the QuestCompleted(int questNum) function
    
    public void TriggerQuest() // (Lower City용)
    {
        FindObjectOfType<QuestManager>().StartQuest(quest);
        Debug.Log("quest started!");
        Debug.Log(quest.questName);
    }
}
