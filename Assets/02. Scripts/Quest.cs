using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public int number;

    /* 플레이어에게 보여주기용 */
    [TextArea(2, 5)]
    public string objective;
    public string reward;
    public string hint;

    public bool completed;

}
