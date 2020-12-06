using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Louis_Interaction : MonoBehaviour
{
    public float maxDistance;

    private int JackCount;
    private int KitchenCount;

    private LayerMask layerMask;
    private RaycastHit hit;
    private Vector3 wrapPosition = Vector3.zero;

    public GameObject Dialogues;

    private void Start()
    {
        maxDistance = 2.0f;
        JackCount = 0;
        KitchenCount = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) )
            {
                Debug.Log("collid");
                switch (hit.transform.tag)
                {
                    case "EnterDoor":
                        Debug.Log("EnterDoor");
                        MoveZEvent(-2.3f);
                        break;
                    case "ExitDoor":
                        Debug.Log("ExitDoor");
                        MoveZEvent(2.3f);
                        break;
                    case "Refrigerator":
                        Debug.Log("Refrigerator");
                        MonologueEvent(0);  // Refrigerator event
                        break;
                    case "KitchenCabinet":
                        Debug.Log("KitchenCabinet");
                        KitchenCabinetEvent();
                        break;
                    case "CoffeTable":
                        Debug.Log("CoffeTable");
                        CoffeTableEvent();
                        break;
                }
            }
        }
    }

    void CoffeTableEvent()
    {

    }

    void KitchenCabinetEvent()
    {
        KitchenCount++;
        if (KitchenCount == 1)
        {
            MonologueEvent(1);  // Cabinet Event
            Inventory.instance.AddItem(3);
            Inventory.instance.AddItem(4);
            Inventory.instance.AddItem(5);
        }
        else MonologueEvent(2);
    }


    void MonologueEvent(int index)
    {
        Dialogues.transform.GetChild(index).GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    void LateUpdate()
    {
        if (wrapPosition != Vector3.zero)
        {
            gameObject.transform.position = wrapPosition;
            wrapPosition = Vector3.zero;
        }
    }

    private void MoveZEvent(float z)
    {
        wrapPosition = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z+z);
    }

    private void JackoLanternEvent(int count)
    {
        switch (count)
        {
            case 0:
                if (!Inventory.instance.AddItem(1)) JackCount--;
                break;
        }
    }

}
