using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDialogueTrigger : MonoBehaviour
{
    public GameObject dialogue;
    public string player_name; //임시용
    private int file_number;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Louis")
        {
            if ((!PlayerPrefs.HasKey(PlayerPrefs.GetInt(player_name).ToString() + "_quest11")) || PlayerPrefs.GetInt(PlayerPrefs.GetInt(player_name).ToString() + "_quest11") == 0)
                dialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        Debug.Log(PlayerPrefs.GetInt(PlayerPrefs.GetInt(player_name).ToString() + "_quest11"));
    }
}
