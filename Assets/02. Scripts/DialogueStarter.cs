using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueStarter : MonoBehaviour
{

    void Awake()
    {
        Debug.Log("start dialogue!");
        //FindObjectOfType<DialogueTrigger>().TriggerDialogue();

    }
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
    }
}
