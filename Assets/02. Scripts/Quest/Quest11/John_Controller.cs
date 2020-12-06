using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class John_Controller : MonoBehaviour
{
    public string player_name;
    public DialogueTrigger dialogue5;

    private Transform johnTr;
    private Animator anim;

    private bool quest11; // true if complete, false if incomplete

    // Start is called before the first frame update
    void Start()
    {
        johnTr = this.GetComponent<Transform>();
        anim = GetComponent<Animator>();

        quest11 = false;
        if (PlayerPrefs.HasKey(PlayerPrefs.GetInt(player_name).ToString() + "_quest11"))
            if (PlayerPrefs.GetInt(PlayerPrefs.GetInt(player_name).ToString() + "_quest11") == 2)
                quest11 = true;

        //if (quest11), change the layer default state to idle
    }

    // Update is called once per frame
    void Update()
    {
        if ((!quest11) && anim.GetBool("D4_done") == false)
        {
            //
        }
        else if ((!quest11) && (anim.GetBool("D4_done") == true))
        {
            //
        }
    }

    public void AfterDialogue4()
    {
        dialogue5.TriggerDialogue();
    }
}
