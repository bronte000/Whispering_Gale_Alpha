using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDialogueTrigger : MonoBehaviour
{
    public GameObject dialogue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Louis")
            dialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}
