using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuestAction/Stun")]
public class Stun : QuestAction
{
    private Animator animator;
    public Material mat;

    public override bool ExecuteRole()
    {
        animator = GameObject.Find("Louis").GetComponent<Animator>();
        animator.SetBool("Stun", true);
        mat.color = Color.blue;
        return true;
    }
}

