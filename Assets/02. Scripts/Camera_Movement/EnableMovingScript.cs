using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMovingScript : MonoBehaviour
{
    public Louis_Controller controller;

    public void EnableMoving(float time)
    {
        StartCoroutine(delayedEnable(time));
    }

    private IEnumerator delayedEnable(float time)
    {
        yield return new WaitForSeconds(time);
        controller.enabled = true;
    }
}