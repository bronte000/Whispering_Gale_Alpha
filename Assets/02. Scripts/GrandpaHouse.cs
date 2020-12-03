using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrandpaHouse : MonoBehaviour
{
    private GameObject louis;
    private Scene house;
    // Start is called before the first frame update
    void Start()
    {
        louis = GameObject.Find("Louis");
        house = SceneManager.GetSceneByName("GrandpaHouse"); //index = 5
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("GrandpaHouse");
    }
}
