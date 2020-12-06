using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDialogueTrigger : MonoBehaviour
{
    public GameObject dialogue;
    public string player_name; //임시용
    public QuestSaveData questSave;
    private GameObject louis;

    void Start()
    {
        louis = GameObject.Find("Louis");
        PlayerPrefs.DeleteKey(PlayerPrefs.GetInt(player_name).ToString() + "_quest11");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Louis")
        {
            if ((!PlayerPrefs.HasKey(PlayerPrefs.GetInt(player_name).ToString() + "_quest11")) || PlayerPrefs.GetInt(PlayerPrefs.GetInt(player_name).ToString() + "_quest11") == 0)
            {
                Vector3 newDirection = transform.position - louis.transform.position;
                transform.rotation = Quaternion.LookRotation(-newDirection);
                dialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
                questSave.SaveQuestStarted(11);
            }
                
        }
        Debug.Log(PlayerPrefs.GetInt(PlayerPrefs.GetInt(player_name).ToString() + "_quest11"));
    }
}
