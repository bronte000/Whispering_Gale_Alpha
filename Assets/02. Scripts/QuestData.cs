using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestData
{
    // 필수
    public int questNumber;
    public string questName;

    [TextArea(3, 10)]
    public string questContent;
    public NextAction nextAction; //얘를 여기에 넣을지, QuestTrigger.cs에 넣을지 고민하다가 결국 여기다 둠

    // 선택
    public int[] npcId; //npc(s) Louis may interact with
    //public Dialogue dialogue;

    public QuestData(string name, int[] npc)
    {
        questName = name;
        npcId = npc;
    }
}