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
        
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue, images, hasImages);
    }

    // Update is called once per frame
    void Update()
    {
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
    }
}
