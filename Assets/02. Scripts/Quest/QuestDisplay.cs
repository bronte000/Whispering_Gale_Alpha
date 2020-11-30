using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestDisplay : MonoBehaviour
{
    private string[] questNames;
    private Dictionary<int, QuestData> allQuests;

    private QuestTrigger[] questObjects;

    public GameObject questTitle;
    public GameObject questContent;
    private GameObject questViewButton;

    //public string test;
    public int activeNum; //number of active quests

    private void Start()
    {
        allQuests = new Dictionary<int, QuestData>();
        this.gameObject.SetActive(false);
        questObjects = Resources.FindObjectsOfTypeAll<QuestTrigger>();
        questViewButton = GameObject.Find("QuestViewButton");

        activeNum = 0;
        foreach (QuestTrigger q in questObjects)
        {
            allQuests.Add(q.quest.questNumber, q.quest);
            if (q.quest.hasStarted == true)
            {
                activeNum += 1;
            }
        }
        questTitle.GetComponent<TextMeshProUGUI>().text = allQuests[1].questName;
        questContent.GetComponent<TextMeshProUGUI>().text = allQuests[1].questContent;

        // hide QuestViewButton if all quests are inactive
        if (activeNum == 0)
            questViewButton.SetActive(false);
        else
            this.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (activeNum > 0)
            questViewButton.SetActive(true);
        else if (activeNum < 0)
            activeNum = 0; //just-in-case
        else
            questViewButton.SetActive(false);

        //Debug.Log(activeNum);
    }

    public void DisplayNewQuest(QuestData quest)
    {
        this.gameObject.SetActive(true);
        questTitle.GetComponent<TextMeshProUGUI>().text = quest.questName;
        questContent.GetComponent<TextMeshProUGUI>().text = quest.questContent;
    }

    public void ShowQuestDisplay()
    {
        this.gameObject.SetActive(true);
    }

    public void HideQuestDisplay(GameObject viewButton)
    {
        this.gameObject.SetActive(false);
        viewButton.SetActive(true);
    }

    public void HideGameObject(GameObject toHide)
    {
        toHide.SetActive(false);
    }
}
/* 메모
 activeNum - Scene이 열리자마자 시작되는 퀘스트 기록용
            (& 동시에 여러 퀘스트를 받을 수 있도록 프로그램 할 때 대비) -> 아직은 구현 안 함.

 */