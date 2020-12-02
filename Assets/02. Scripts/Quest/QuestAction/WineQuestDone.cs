using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "QuestAction/UpperRoom/WineQuestDone")]
public class WineQuestDone : QuestAction
{
    public override bool ExecuteRole()
    {
        SceneManager.LoadScene("LowCity1");
        return true;
    }
}
