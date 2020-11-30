using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialQuest2 : MonoBehaviour
{
    private float shiftPressTime;
    private QuestManager questManager;

    // Start is called before the first frame update
    void Start()
    {
        shiftPressTime = 0.0f;
        questManager = GameObject.Find("Quests").GetComponent<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
        {
            shiftPressTime += Time.deltaTime;
        }
        
        if (shiftPressTime > 3.0f)
        {
            questManager.QuestCompleted(this.gameObject.GetComponent<QuestTrigger>().quest);
        }
    }
}
