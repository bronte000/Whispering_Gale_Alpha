using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "QuestAction/UpperRoom/ShowWineSet")]
public class ShowWineSet : QuestAction
{
    public override bool ExecuteRole()
    {
        GameObject.Find("WineSet").SetActive(true);
        return true;
    }
}
