﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "QuestAction/UnStun")]
public class UnStun : QuestAction
{
    public Material mat;

    public override bool ExecuteRole()
    {
        mat.color = Color.white;
        return true;
    }
}