using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueStarter : MonoBehaviour
{
    public bool isNextAction;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
        Debug.Log("start done");
    }

    private void Update()
    {
        Debug.Log("update");
    }
}
