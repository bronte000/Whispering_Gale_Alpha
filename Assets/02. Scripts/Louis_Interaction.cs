using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Louis_Interaction : MonoBehaviour
{
    public float maxDistance;

    private int JackCount;

    private LayerMask layerMask;
    private RaycastHit hit;
    private Vector3 wrapPosition = Vector3.zero;

    private void Start()
    {
        maxDistance = 2.0f;
        JackCount = 0;
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
                    case "BookAndPotion":
                        Debug.Log("potion");
                        break;
                    case "JackoLantern":
                        Debug.Log("Jackolantern");
                        JackoLanternEvent(JackCount);
                        JackCount++;
                        break;
                    case "EnterDoor":
                        Debug.Log("EnterDoor");
                        MoveZEvent(-2.3f);
                        break;
                    case "ExitDoor":
                        Debug.Log("ExitDoor");
                        MoveZEvent(2.3f);
                        break;
                }
            }
        }
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
