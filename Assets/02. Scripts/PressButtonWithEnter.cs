using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressButtonWithEnter : MonoBehaviour
{
    private GameObject button;

    private void Start()
    {
        button = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            //GameObject button = this.GameObject.FindGameObjectWithTag("PressWithEnter");
            //button.GetComponent<>
            if (button.GetComponent<Button>() != null)
            {
                button.GetComponent<Button>().onClick.Invoke();
            }
        }
    }


}
