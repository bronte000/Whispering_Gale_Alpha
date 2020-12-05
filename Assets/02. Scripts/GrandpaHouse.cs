using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrandpaHouse : MonoBehaviour
{
    public bool startDialogue;
    [SerializeField]
    private DialogueStarter HouseEnterStarter;
    private GameObject louis;
 //   private Scene house;
    // Start is called before the first frame update
    void Start()
    {
        louis = GameObject.Find("Louis");
   //     house = SceneManager.GetSceneByName("GrandpaHouse"); //index = 5
    }

    private void OnTriggerEnter(Collider other)
    {
        if (startDialogue)
        {
            HouseEnterStarter.enabled = true;
            startDialogue = false;
        }
        SceneManager.LoadScene("GrandpaHouse");
    }
}
