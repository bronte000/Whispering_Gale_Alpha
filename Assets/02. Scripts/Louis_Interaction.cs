using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Louis_Interaction : MonoBehaviour
{
    public float maxDistance;

    private List<Item> database;
    private int JackCount;
    private LayerMask layerMask;
    private RaycastHit hit;

    private void Start()
    {
        JackCount = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) )
            {

                Debug.Log("collid");
            }
        }
    }

    public void setDB(List<Item> DB)
    {
        database = DB;
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("collid");
        if (Input.GetKeyDown("return"))
        {
            Debug.Log("enter done");
            switch (other.gameObject.tag)
            {
                case "BookAndPotion":
                    Debug.Log("potion");
                    break;
                case "JackoLantern":
                    JackoLanternEvent(JackCount);
                    JackCount++;
                    break;
              //  case "DeliciousQuest"
                //case

            }
        }
    }

    private void JackoLanternEvent(int count)
    {
        switch (count)
        {
            case 0:
                GameObject.Find("UI").GetComponent<Inventory>().AddItem(database[1]);
                break;
        }
    }

}
