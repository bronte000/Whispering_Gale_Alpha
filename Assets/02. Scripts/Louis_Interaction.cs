using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Louis_Interaction : MonoBehaviour
{
    public float maxDistance;

    private int JackCount;
    private LayerMask layerMask;
    private RaycastHit hit;

    private void Start()
    {
        maxDistance = 3.0f;
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
                }
            }
        }
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
