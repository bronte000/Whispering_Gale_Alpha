using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3, 30)] //minimum & maximum number of lines TextArea will use
    public string[] sentences;
}
