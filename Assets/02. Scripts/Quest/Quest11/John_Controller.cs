﻿using System.Collections;
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

        if (quest11)
            anim.SetBool("IsHappy", true); // OR change the layer default state to idle
    }

    public void AfterDialogue4()
    {
        //John walks away
        transform.rotation = johnTr.rotation;
        anim.SetBool("D4_done", true);

        //Start dialogue5
        dialogue5.TriggerDialogue();
        if (this.transform.position.x < 0.0f)
            this.gameObject.SetActive(false);
    }
}
