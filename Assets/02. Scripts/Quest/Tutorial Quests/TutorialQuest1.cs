using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialQuest1 : MonoBehaviour
{
    private float keyWPressTime;
    private QuestManager questManager;

    // Start is called before the first frame update
    void Start()
    {
        questManager = GameObject.Find("Quests").GetComponent<QuestManager>();
        keyWPressTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (keyWPressTime > 3.0f)
        {
            questManager.QuestCompleted(this.gameObject.GetComponent<QuestTrigger>().quest);
            this.gameObject.SetActive(false);
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            keyWPressTime += Time.deltaTime;
        }

        Debug.Log(keyWPressTime);
    }
}
