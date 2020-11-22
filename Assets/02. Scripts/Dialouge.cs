using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialouge
{
    public string name;

    [TextArea(3, 10)] //minimum & maximum number of lines TextArea will use
    public string[] sentences;
}
