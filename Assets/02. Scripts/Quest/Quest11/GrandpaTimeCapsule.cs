using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandpaTimeCapsule : MonoBehaviour
{
    public GameObject tower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable() //called when the attached GameObject is toggled
    {
        tower.GetComponent<Light>().enabled = true;
        tower.GetComponent<Light>().color = Color.blue;
    }
}
