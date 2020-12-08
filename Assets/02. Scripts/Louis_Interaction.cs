using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Louis_Interaction : MonoBehaviour
{
    public float maxDistance;
    public int status;  // 0 for no quest, 1 for after food quest, 2 for after sleep quest

    private int JackCount;
    private int KitchenCount;
    private int BedCount;

    private LayerMask layerMask;
    private RaycastHit hit;
    private Vector3 wrapPosition = Vector3.zero;

    public GameObject Dialogues;

    private void Start()
    {
        maxDistance = 2.0f;
        JackCount = 0;
        KitchenCount = 0;
        BedCount = 0;
        status = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            if (status ==2) MonologueEvent(8);
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) )
            {
                switch (hit.transform.tag)
                {
                    case "EnterDoor":
                        BedRoomEvent();
                        MoveZEvent(-2.3f);
                        break;
                    case "ExitDoor":
                        MoveZEvent(2.3f);
                        break;
                    case "Refrigerator":
                        MonologueEvent(0);  // Refrigerator event
                        break;
                    case "KitchenCabinet":
                        KitchenCabinetEvent();
                        break;
                    case "Table":
                        if (status == 0) MonologueEvent(7);
                        else MonologueEvent(10);
                        break;
                    case "Bathroom":
                        MonologueEvent(3);
                        break;
                    case "Bed":
                        Debug.Log("bed");
                        if (status == 0) MonologueEvent(5);
                        else BedEvent();
                        break;
                    case "Couch":
                        if (status == 0) MonologueEvent(5);
                        else CouchEvent();
                        break;
                    case "chair":
                        Debug.Log("chair");
                        if (status == 0) MonologueEvent(6);
                        else MonologueEvent(10);
                        break;
                    case "TV":
                        MonologueEvent(9);
                        break;
                    case "BookCase":
                        MonologueEvent(11);
                        break;

                }
            }
        }
    }
    
    void BedEvent()
    {
        MonologueEvent(12);

    }
    
    void CouchEvent()
    {
        MonologueEvent(12);

    }

    void BedRoomEvent()
    {
        BedCount++;
        if (BedCount == 1)
        {
            MonologueEvent(4);
        }
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
