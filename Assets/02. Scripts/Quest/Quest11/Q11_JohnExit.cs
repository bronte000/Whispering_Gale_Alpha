using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// After Dialogue4_JohnsTale is done, John exits the screen
[CreateAssetMenu(menuName = "QuestAction/Quest11/JohnExit")]
public class Q11_JohnExit : QuestAction
{
    private GameObject john;

    public override bool ExecuteRole()
    {
        john = GameObject.Find("john");
        // John walks away
        john.GetComponent<Animator>().SetBool("D4_done", true);

        // Execute Dialogue5
        john.GetComponent<John_Controller>().AfterDialogue4();

        return true;
    }
}
