using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousey_Controller : MonoBehaviour
{
    private Animator anim;
    private GameObject louis;
    private bool hasTalked;

    public GameObject dialogue3;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        louis = GameObject.Find("Louis");
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.name == "Louis") && (!hasTalked))
        {
            hasTalked = true;
            Vector3 newDirection = transform.position - louis.transform.position;
            transform.rotation = Quaternion.LookRotation(-newDirection);
            dialogue3.GetComponent<DialogueTrigger>().TriggerDialogue();
            WhenDialogueStarts();
        }
    }

    private void WhenDialogueStarts()
    {
        anim.SetBool("D3_started", true);
    }
    public void AfterDialogue()
    {
        anim.SetBool("D3_done", true);
    }

}
