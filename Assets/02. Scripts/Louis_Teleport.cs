using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Louis_Teleport : MonoBehaviour
{
    public GameObject door;
    public GameObject Louis;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == door)
            SceneManager.LoadScene("Basic Scene");//MoveGameObjectToScene(Louis, "Basic Scene");
    }
}
