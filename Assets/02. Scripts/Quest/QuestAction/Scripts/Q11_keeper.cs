using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuestAction/Quest11/Q11_keeper")]
public class Q11_keeper : QuestAction
{
    GameObject keeper;
    public override bool ExecuteRole()
    {
        keeper = GameObject.Find("megan");
        keeper.transform.position = new Vector3(133f, 1.128601f, -30.73f);
        return true;
    }
}
