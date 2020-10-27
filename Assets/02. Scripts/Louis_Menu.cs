using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Louis_Menu : MonoBehaviour
{

    public GameObject ActionMenu;

    // Start is called before the first frame update
    void Start()
    {
        ActionMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click_Louis_Button()
    {
        if (ActionMenu.activeSelf == true)
        {
            ActionMenu.SetActive(false);
        } else {
            ActionMenu.SetActive(true);
        }
    }

}
